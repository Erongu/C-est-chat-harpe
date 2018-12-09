using Projet.Model.Network.Protocol.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model.Network.Protocol
{
    public class Message
    {
        public virtual int MessageId
        {
            get;
            set;
        }

        public Message()
        {

        }

        public virtual void Serialize(Writer writer)
        {
            writer.WriteInt(MessageId);
        }

        public virtual void Deserialize(Reader reader)
        {
            MessageId = reader.ReadInt();
        }
    }
}
