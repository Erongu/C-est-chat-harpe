using Controller;
using Model.Pathfinding;
using Model.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Threading
{
    public class TaskPool
    {
        private readonly LockFreeQueue<TaskMessage> m_taskQueues;
        private readonly PriorityQueueB<TaskTimer> m_timers = new PriorityQueueB<TaskTimer>(new TimedTimerComparer());

        private readonly Stopwatch m_queueTimer;

        private Task m_updateTask;

        private int m_currentThreadId;
        private int m_lastUpdate;

        public string Name
        {
            get;
            protected set;
        }

        public int UpdateInterval
        {
            get;
            protected set;
        }

        public bool IsRunning
        {
            get;
            protected set;
        }

        public bool IsInContext
        {
            get { return true; }
        }

        public TaskPool(string name, int interval)
        {
            Name = name;
            UpdateInterval = interval;

            m_taskQueues = new LockFreeQueue<TaskMessage>();
            m_queueTimer = Stopwatch.StartNew();

        }

        public void Start()
        {
            IsRunning = true;

            m_updateTask = Task.Factory.StartNewDelayed(UpdateInterval, ProccessUpdate, this);

        }

        public void AddMessage(Action action)
        {
            AddMessage(new TaskMessage(action));
        }

        public void AddMessage(TaskMessage message)
        {
            m_taskQueues.Enqueue(message);
        }

        public void AddTimer(TaskTimer timer)
        {
            ExecuteInContext(() =>
            {
                if (!timer.Enabled)
                    timer.Start();

                m_timers.Push(timer);
            });
        }

        public TaskTimer CallPeriodically(int delayMillis, Action callback)
        {
            var timer = new TaskTimer(delayMillis, callback);
            AddTimer(timer);
            return timer;
        }

        public TaskTimer CallDelayed(int delayMillis, Action callback)
        {
            var timer = new TaskTimer(delayMillis, -1, callback);
            AddTimer(timer);
            return timer;
        }

        public bool ExecuteInContext(Action action)
        {
            if (IsInContext)
            {
                action();
                return true;
            }

            AddMessage(action);
            return false;
        }

        private void ProccessUpdate(object state)
        {
            if (!IsRunning)
                return;

            if (Interlocked.CompareExchange(ref m_currentThreadId, Thread.CurrentThread.ManagedThreadId, 0) != 0)
            {
                LogController.Instance.Debug("Thread: " + Thread.CurrentThread.ManagedThreadId);
                return;
            }

            long timerStart = 0;

            timerStart = m_queueTimer.ElapsedMilliseconds;

            var updateDt = (int)(timerStart - m_lastUpdate);
            m_lastUpdate = (int)timerStart;

            int msgCount = 0;
            int timersCount = 0;

            var list = new List<TaskMessage>();

            try
            {
                TaskMessage msg;
                while (m_taskQueues.TryDequeue(out msg))
                {
                    msgCount++;
                    list.Add(msg);

                    try
                    {
                        msg.Execute();
                    }
                    catch (Exception ex)
                    {
                        LogController.Instance.Error("Failed to execute message {0} : {1}", msg, ex);
                    }
                }

                TaskTimer peek;
                while ((peek = m_timers.Peek()) != null && peek.NextTick <= DateTime.Now)
                {
                    timersCount++;
                    var timer = m_timers.Pop();

                    if (timer.Enabled)
                    {
                        try
                        {
                            timer.Trigger();

                            if (timer.Enabled)
                                m_timers.Push(timer);
                        }
                        catch (Exception ex)
                        {
                            LogController.Instance.Error("Exception raised when processing TaskTimer {2} in {0} : {1}.", this, ex, timer);
                        }
                    }
                }

            }
            catch { }
            finally
            {
                // get the end time
                var timerStop = m_queueTimer.ElapsedMilliseconds;

                var updateLagged = timerStop - timerStart > UpdateInterval;
                var callbackTimeout = updateLagged ? 0 : ((timerStart + UpdateInterval) - timerStop);

                Interlocked.Exchange(ref m_currentThreadId, 0);

                m_updateTask = Task.Factory.StartNewDelayed((int)callbackTimeout, ProccessUpdate, this);

            }
        }

        
    }

    static class TaskFactoryExtension
    {
        public static Task StartNewDelayed(this TaskFactory factory, int millisecondsDelay, Action<object> action, object state)
        {
            var result = new TaskCompletionSource<object>(state);

            var tcs = new TaskCompletionSource<object>(factory.CreationOptions);
            CancellationTokenRegistration[] ctr = { default(CancellationTokenRegistration) };

            var timer = new Timer(self =>
            {
                ctr[0].Dispose();
                ((Timer)self).Dispose();
                tcs.TrySetResult(null);
            });

            if (factory.CancellationToken.CanBeCanceled)
            {
                ctr[0] = factory.CancellationToken.Register(() =>
                {
                    timer.Dispose();
                    tcs.TrySetCanceled();
                });
            }

            timer.Change(millisecondsDelay, Timeout.Infinite);

            return tcs.Task
                   .ContinueWith(t =>
                   {
                       if (t.IsCanceled) result.TrySetCanceled();
                       else
                       {
                           try
                           {
                               action(state);
                               result.TrySetResult(null);
                           }
                           catch (Exception exc)
                           {
                               result.TrySetException(exc);
                           }
                       }
                   }, TaskScheduler.Current);
        }
    }
}
