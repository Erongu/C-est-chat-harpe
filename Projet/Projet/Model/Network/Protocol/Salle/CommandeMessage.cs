using Model.Network.Protocol.IO;
using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Network.Protocol.Salle
{
    public class CommandeMessage : Message
    {
        public const int Id = 3;

        public override int MessageId
        {
            get => Id;
        }

        public List<Plat> Plats
        {
            get;
            set;
        }


        public CommandeMessage()
        {

        }

        public CommandeMessage(List<Plat> plats)
        {
            Plats = plats;
        }

        public override void Serialize(Writer writer)
        {
            base.Serialize(writer); // Pour écrire l'id du message

            writer.WriteInt(Plats.Count);

            foreach(var plat in Plats)
            {
                plat.Serialize(writer);
            }

        }

        public override void Deserialize(Reader reader)
        {
            var length = reader.ReadInt();
            Plats = new List<Plat>();

            for (var i = 0; i < length; i++)
            {
                var plat = new Plat();
                plat.Deserialize(reader);

                Plats.Add(plat);
            }

        }
    }
}
