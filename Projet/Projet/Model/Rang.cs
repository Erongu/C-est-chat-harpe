using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Rang
    {
        //Liste des tables
        private List<Table> Tables
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
                Tables.Add(new Table(1, 4, 1, 1, 0, 0));
                Tables.Add(new Table(2, 4, 1, 1, 0, 0));
                Tables.Add(new Table(3, 4, 1, 1, 0, 0));
                Tables.Add(new Table(4, 4, 1, 1, 0, 0));
                Tables.Add(new Table(5, 4, 1, 1, 0, 0));
                Tables.Add(new Table(6, 2, 1, 1, 0, 0));
                Tables.Add(new Table(7, 2, 1, 1, 0, 0));
                Tables.Add(new Table(8, 2, 1, 1, 0, 0));
            }
            if ((numeroCarre == 1) && (numeroRang == 2))
            {
                Tables.Add(new Table(9, 2, 2, 1, 0, 0));
                Tables.Add(new Table(10, 2, 2, 1, 0, 0));
                Tables.Add(new Table(11, 6, 2, 1, 0, 0));
                Tables.Add(new Table(12, 6, 2, 1, 0, 0));
                Tables.Add(new Table(13, 6, 2, 1, 0, 0));
                Tables.Add(new Table(14, 8, 2, 1, 0, 0));
                Tables.Add(new Table(15, 8, 2, 1, 0, 0));
                Tables.Add(new Table(16, 10, 2, 1, 0, 0));
            }
            if ((numeroCarre == 2) && (numeroRang == 1))
            {
                Tables.Add(new Table(17, 4, 1, 2, 0, 0));
                Tables.Add(new Table(18, 4, 1, 2, 0, 0));
                Tables.Add(new Table(19, 4, 1, 2, 0, 0));
                Tables.Add(new Table(20, 4, 1, 2, 0, 0));
                Tables.Add(new Table(21, 4, 1, 2, 0, 0));
                Tables.Add(new Table(22, 2, 1, 2, 0, 0));
                Tables.Add(new Table(23, 2, 1, 2, 0, 0));
                Tables.Add(new Table(24, 2, 1, 2, 0, 0));
            }
            if ((numeroCarre == 2) && (numeroRang == 2))
            {
                Tables.Add(new Table(25, 2, 2, 2, 0, 0));
                Tables.Add(new Table(26, 2, 2, 2, 0, 0));
                Tables.Add(new Table(27, 6, 2, 2, 0, 0));
                Tables.Add(new Table(28, 6, 2, 2, 0, 0));
                Tables.Add(new Table(29, 8, 2, 2, 0, 0));
                Tables.Add(new Table(30, 8, 2, 2, 0, 0));
                Tables.Add(new Table(31, 8, 2, 2, 0, 0));
                Tables.Add(new Table(32, 10, 2, 2, 0, 0));
            }
        }

        //Getter and Setter

        public Table GetTable(int numero)
        {
            return Tables.FirstOrDefault(x => x.Numero == numero);
        }

        public List<Table> GetTable()
        {
            return this.Tables;
        }

    }
}
