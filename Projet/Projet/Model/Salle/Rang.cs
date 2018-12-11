using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle
{
    class Rang
    {
        //Liste des tables
        public List<Table> Tables
        {
            get;
        } = new List<Table>();

        public int Numero
        {
            get;
            set;
        }

        //Constructeur
        public Rang(int numeroRang, int numeroCarre)
        {
            this.Numero = numeroRang;

            //Création des tables
            if((numeroCarre == 1)&&(numeroRang == 1))
            {
                Tables.Add(new Table(1, 4, 1, 1, 38, 4));
                Tables.Add(new Table(2, 4, 1, 1, 38, 7));
                Tables.Add(new Table(3, 4, 1, 1, 38, 10));
                Tables.Add(new Table(4, 4, 1, 1, 38, 13));
                Tables.Add(new Table(5, 4, 1, 1, 38, 16));
                Tables.Add(new Table(6, 2, 1, 1, 26, 4));
                Tables.Add(new Table(7, 2, 1, 1, 26, 7));
                Tables.Add(new Table(8, 2, 1, 1, 26, 10));
            }
            if ((numeroCarre == 1) && (numeroRang == 2))
            {
                Tables.Add(new Table(9, 2, 2, 1, 26, 13));
                Tables.Add(new Table(10, 2, 2, 1, 26, 16));
                Tables.Add(new Table(11, 6, 2, 1, 2, 14));
                Tables.Add(new Table(12, 6, 2, 1, 2, 18));
                Tables.Add(new Table(13, 6, 2, 1, 2, 22));
                Tables.Add(new Table(14, 8, 2, 1, 29, 31));
                Tables.Add(new Table(15, 8, 2, 1, 36, 31));
                Tables.Add(new Table(16, 10, 2, 1, 14, 19));
            }
            if ((numeroCarre == 2) && (numeroRang == 1))
            {
                Tables.Add(new Table(17, 4, 1, 2, 32, 4));
                Tables.Add(new Table(18, 4, 1, 2, 32, 7));
                Tables.Add(new Table(19, 4, 1, 2, 32, 10));
                Tables.Add(new Table(20, 4, 1, 2, 32, 13));
                Tables.Add(new Table(21, 4, 1, 2, 32, 16));
                Tables.Add(new Table(22, 2, 1, 2, 19, 4));
                Tables.Add(new Table(23, 2, 1, 2, 19, 7));
                Tables.Add(new Table(24, 2, 1, 2, 19, 10));
            }
            if ((numeroCarre == 2) && (numeroRang == 2))
            {
                Tables.Add(new Table(25, 2, 2, 2, 19, 13));
                Tables.Add(new Table(26, 2, 2, 2, 19, 16));
                Tables.Add(new Table(27, 6, 2, 2, 6, 14));
                Tables.Add(new Table(28, 6, 2, 2, 6, 18));
                Tables.Add(new Table(29, 8, 2, 2, 8, 21));
                Tables.Add(new Table(30, 8, 2, 2, 15, 21));
                Tables.Add(new Table(31, 8, 2, 2, 22, 21));
                Tables.Add(new Table(32, 10, 2, 2, 14, 14));
            }
        }

        //Getter and Setter

        public Table GetTable(int numero)
        {
            return Tables.FirstOrDefault(x => x.Numero == numero);
        }

    }
}
