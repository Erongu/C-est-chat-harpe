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
        private int numero;

        //Constructeur
        public Rang(int numeroRang, int numeroCarre)
        {
            this.numero = numeroRang;

            //Création des tables
            if((numeroCarre == 1)&&(numeroRang == 1))
            {
                tables.Add(new Table(1, 4));
                tables.Add(new Table(2, 4));
                tables.Add(new Table(3, 4));
                tables.Add(new Table(4, 4));
                tables.Add(new Table(5, 4));
                tables.Add(new Table(6, 2));
                tables.Add(new Table(7, 2));
                tables.Add(new Table(8, 2));
            }
            if ((numeroCarre == 1) && (numeroRang == 2))
            {
                tables.Add(new Table(9, 2));
                tables.Add(new Table(10, 2));
                tables.Add(new Table(11, 6));
                tables.Add(new Table(12, 6));
                tables.Add(new Table(13, 6));
                tables.Add(new Table(14, 8));
                tables.Add(new Table(15, 8));
                tables.Add(new Table(16, 10));
            }
            if ((numeroCarre == 2) && (numeroRang == 1))
            {
                tables.Add(new Table(17, 4));
                tables.Add(new Table(18, 4));
                tables.Add(new Table(19, 4));
                tables.Add(new Table(20, 4));
                tables.Add(new Table(21, 4));
                tables.Add(new Table(22, 2));
                tables.Add(new Table(23, 2));
                tables.Add(new Table(24, 2));
            }
            if ((numeroCarre == 2) && (numeroRang == 2))
            {
                tables.Add(new Table(25, 2));
                tables.Add(new Table(26, 2));
                tables.Add(new Table(27, 6));
                tables.Add(new Table(28, 6));
                tables.Add(new Table(29, 8));
                tables.Add(new Table(30, 8));
                tables.Add(new Table(31, 8));
                tables.Add(new Table(32, 10));
            }
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

        public int getNumero()
        {
            return this.numero;
        }



    }
}
