using Projet.Model.Network.Protocol.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model.Network.Protocol.Identification
{
    public class PingMessage : Message
    {
        public const int Id = 1;

        public override int MessageId
        {
            get => Id;
        }

        public int TimeStamp
        {
            get;
            set;
        }

       
        public PingMessage()
        {

        }

        public PingMessage(int timeStamp)
        {
            TimeStamp = timeStamp;
        }

        public override void Serialize(Writer writer)
        {
            base.Serialize(writer); // Pour écrire l'id du message

            writer.WriteInt(TimeStamp);
        }

        public override void Deserialize(Reader reader)
        {
            TimeStamp = reader.ReadInt();
        }
    }
}
