using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle
{
    public class Plat
    {
        public string Nom
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

        //Constructeur
        public Plat(string nom, int table, TypePlat type)
        {
            this.Nom = nom;
            this.Table = table;
            this.Type = type;
        }

        public Plat(string nom, int table)
        {
            this.Nom = nom;
            this.Table = table;
        }

    }
}
