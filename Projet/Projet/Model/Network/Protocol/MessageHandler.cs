using Projet.Model.Network.Protocol.Identification;
using Projet.Model.Network.Protocol.IO;
using Projet.Model.Network.Protocol.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Network.Protocol
{
    public static class MessageHandler
    {
        public static Message Read(byte[] buffer)
        {
            Message message = new Message();
            Reader reader = new Reader(buffer);

            message.Deserialize(reader);

            switch (message.MessageId) // Clairement ameliorable avec un peu de réflection mais la flemme
            {
                case PingMessage.Id:
                    message = new PingMessage();
                    break;

                case PongMessage.Id:
                    message = new PongMessage();
                    break;
                case CommandeMessage.Id:
                    message = new CommandeMessage();
                    break;
            }

            message.Deserialize(reader);

            return message;
        }

        public static byte[] Write(Message message)
        {
            Writer writer = new Writer();

            message.Serialize(writer);

            return writer.Data;
        }
    }
}
