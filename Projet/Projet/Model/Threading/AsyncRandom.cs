using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Threading
{
    public sealed class AsyncRandom : Random
    {
        private static int m_incrementer;

        public AsyncRandom()
            : base(Environment.TickCount + Thread.CurrentThread.ManagedThreadId + m_incrementer)
        {
            unchecked
            {
                Interlocked.Increment(ref m_incrementer);
            }
        }

        public AsyncRandom(int seed)
            : base(seed)
        {

        }

        public double NextDouble(double min, double max)
        {
            return NextDouble() * (max - min) + min;
        }

    }
}
