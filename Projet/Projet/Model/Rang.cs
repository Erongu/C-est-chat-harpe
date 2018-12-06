using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Rang
    {
        //Liste des tables
        private List<Table> tables;

        //Constructeur
        public Rang(int numeroRang, int numeroCarre)
        {

        }

        //Getter and Setter
        public List<Table> getTable()
        {
            return this.tables;
        }

        public Table getTable(int numero)
        {
            foreach(Table tab in tables)
            {
                if(tab.getNumero() == numero) { return tab; }
            }
            return null;
        }


    }
}
