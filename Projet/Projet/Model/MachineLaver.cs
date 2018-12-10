using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class MachineLaver
    {
        private List<Ustensile> ustensiles;
        private int etat;

        //Constructeur
        public MachineLaver()
        {

        }

        //Ajout d'ustensile
        public void addUstensile(Ustensile ust)
        {
            ustensiles.Add(ust);
        }

        //Vider la machine
        public void videLaveVaisselle()
        {
            foreach (Ustensile ust in ustensiles)
            {
                //MAJ BDD
            }
            ustensiles.Clear();

        }
    }
}
