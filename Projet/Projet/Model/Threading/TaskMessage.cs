using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Threading
{
    public class TaskMessage
    {
        public static TaskMessage Obtain(Action callback)
        {
            return new TaskMessage(callback);
        }

        public TaskMessage()
        {
        }

        public TaskMessage(Action callback)
        {
            Callback = callback;
        }

        public Action Callback
        {
            get;
            private set;
        }

        public virtual void Execute()
        {
            var cb = Callback;
            if (cb != null)
            {
                cb();
            }
        }

        public static implicit operator TaskMessage(Action dele)
        {
            return new TaskMessage(dele);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var actions = Callback.GetInvocationList();
            foreach (var del in actions)
            {
                sb.Append(del.Method.ReflectedType.FullName + "." + del.Method.Name);
            }
            return sb.ToString();
        }
    }
}
