using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle
{
    class Plat
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

        //Constructeur
        public Plat(string nom, int table)
        {
            this.Nom = nom;
            this.Table = table;
        }

    }
}
