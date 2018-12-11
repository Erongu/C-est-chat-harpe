using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle
{
    class Table
    {
        public Groupe Groupe
        {
            get;
            set;
        }

        public int Numero
        {
            get;
            set;
        }

        public int Place
        {
            get;
            set;
        }

        public int Rang
        {
            get;
            set;
        }

        public int Carre
        {
            get;
            set;
        }

        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

        //Constructeur
        public Table(int numero, int place, int rang, int carre, int x, int y)
        {
            this.Numero = numero;
            this.Place = place;
            this.Rang = rang;
            this.Carre = carre;
            this.x = x;
            this.y = y;
        }

    }
}
