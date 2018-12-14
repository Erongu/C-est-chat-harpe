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

        public List<int> Commandes
        {
            get;
            set;
        }


        public CommandeMessage()
        {

        }

        public CommandeMessage(List<int> commandes)
        {
            Commandes = commandes;
        }

        public override void Serialize(Writer writer)
        {
            base.Serialize(writer); // Pour écrire l'id du message

            writer.WriteInt(Commandes.Count);

            foreach(var commande in Commandes)
            {
                writer.WriteInt(commande);
            }

        }

        public override void Deserialize(Reader reader)
        {
            var length = reader.ReadInt();
            Commandes = new List<int>();

            for (var i = 0; i < length; i++)
            {
                Commandes.Add(reader.ReadInt());
            }

        }
    }
}
