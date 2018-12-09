using Projet.Model.Network.Protocol.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model.Network.Protocol.Identification
{
    public class PongMessage : Message
    {
        public const int Id = 2;

        public override int MessageId
        {
            get => Id;
        }

        public int TimeStamp
        {
            get;
            set;
        }


        public PongMessage()
        {

        }

        public PongMessage(int timeStamp)
        {
            TimeStamp = timeStamp;
        }

        public override void Serialize(Writer writer)
        {
            base.Serialize(writer);

            writer.WriteInt(TimeStamp);
        }

        public override void Deserialize(Reader reader)
        {
            TimeStamp = reader.ReadInt();
        }
    }
}
