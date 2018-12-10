using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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

        //Constructeur
        public Table(int numero, int place)
        {
            this.Numero = numero;
            this.Place = place;
        }

    }
}
