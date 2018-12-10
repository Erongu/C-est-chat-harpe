using Model.Network.Protocol.IO;
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

        public List<int> Plats
        {
            get;
            set;
        }
        public List<int> Tables
        {
            get;
            set;
        }


        public CommandeMessage()
        {

        }

        public CommandeMessage(List<int> plats, List<int> tables)
        {
            Plats = plats;
            Tables = tables;
        }

        public override void Serialize(Writer writer)
        {
            base.Serialize(writer); // Pour écrire l'id du message

            writer.WriteInt(Plats.Count);

            foreach(var plat in Plats)
            {
                writer.WriteInt(plat);
            }

            writer.WriteInt(Tables.Count);

            foreach (var table in Tables)
            {
                writer.WriteInt(table);
            }
        }

        public override void Deserialize(Reader reader)
        {
            var length = reader.ReadInt();
            Plats = new List<int>();

            for (var i = 0; i < length; i++)
            {
                Plats.Add(reader.ReadInt());
            }

            length = reader.ReadInt();
            Tables = new List<int>();

            for (var i = 0; i < length; i++)
            {
                Tables.Add(reader.ReadInt());
            }
        }
    }
}
