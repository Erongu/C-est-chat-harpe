using Model.Network.Protocol.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle
{
    public class Plat
    {
        public int Nom
        {
            get;
            set;
        }

        public int Table
        {
            get;
            set;
        }

        public TypePlat Type
        {
            get;
            set;
        }

        public enum TypePlat
        {
            Entree = 1,
            Plat = 2,
            Dessert = 3
        }

        public Plat()
        {

        }

        //Constructeur
        public Plat(int nom, int table, TypePlat type)
        {
            this.Nom = nom;
            this.Table = table;
            this.Type = type;
        }

        public void Serialize(Writer writer)
        {
            writer.WriteInt(Nom);
            writer.WriteInt(Table);
            writer.WriteInt((int)Type);
        }

        public void Deserialize(Reader reader)
        {
            Nom = reader.ReadInt();
            Table = reader.ReadInt();
            Type = (TypePlat)reader.ReadInt();
        }
    }
}
