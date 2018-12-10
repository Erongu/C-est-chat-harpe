using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Network
{
    public class BufferPool
    {
        public const int BufferSize = 8192;

        public byte[] Data
        {
            get;
            private set;
        }

        public BufferPool()
        {
            Data = new byte[BufferSize];
        }

        public void ResetBuffer()
        {
            Data = new byte[BufferSize];
        }
    }
}
