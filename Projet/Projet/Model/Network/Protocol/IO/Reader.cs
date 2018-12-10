using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Network.Protocol.IO
{
    public class Reader
    {
        public BinaryReader m_reader;
        public Stream BaseStream
        {
            get
            {
                return m_reader.BaseStream;
            }
        }
        public Reader(byte[] data)
        {
            m_reader = new BinaryReader(new MemoryStream(data), Encoding.UTF8);
        }

        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBigEndianBytes(4), 0);
        }

        public string ReadString()
        {
            int length = ReadInt();

            byte[] bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }
        public byte[] ReadBytes(int n)
        {
            return m_reader.ReadBytes(n);
        }

        private byte[] ReadBigEndianBytes(int count)
        {
            var bytes = new byte[count];
            int i;
            for (i = count - 1; i >= 0; i--)
                bytes[i] = (byte)BaseStream.ReadByte();
            return bytes;
        }


    }

}
