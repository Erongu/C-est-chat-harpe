using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Table
    {
        private Groupe groupe;
        private int numero;
        private int place;

        //Constructeur
        public Table(int numero, int place)
        {
            this.numero = numero;
            this.place = place;
        }

        //Getter and Setter
        public Groupe getGroupe()
        {
            return this.groupe;
        }

        public int getNumero()
        {
            return this.numero;
        }

        public int getPlace()
        {
            return this.place;
        }

        public void setGroupe(Groupe grp)
        {
            this.groupe = grp;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public void setPlace(int place)
        {
            this.place = place;
        }

    }
}
