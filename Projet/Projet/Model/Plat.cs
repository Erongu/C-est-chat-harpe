using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Plat
    {
        private String nom;
        private int table;

        //Constructeur
        public Plat(String nom, int table)
        {
            this.nom = nom;
            this.table = table;
        }

        //Getter and setter
        public String getNom()
        {
            return this.nom;
        }

        public int getTable()
        {
            return this.table;
        }

        public void setTable(int table)
        {
            this.table = table;
        }

    }
}
