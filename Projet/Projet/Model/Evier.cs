using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Evier
    {
        //Liste d'ustensiles
        private List<Ustensile> ustensiles;

        //Constructeur
        public Evier()
        {

        }

        //Laver un Ustensile
        public void laverUstensible()
        {    
            Ustensile ust = ustensiles[0];
            ustensiles.RemoveAt(0);
            if (ust.getType() == Ustensile.TYPE.COUTEAUCUISINE)
            {
                Thread.Sleep(500);
            }
            else if (ust.getType() == Ustensile.TYPE.CUILLERE)
            {
                Thread.Sleep(500);
            }
            else
            {
                Thread.Sleep(1000);
            }

            /**
             * 
             * MAJ STOCK
             * 
             * 
             */
        }

        //Getter et Setter
        public List<Ustensile> getUstensile()
        {
            return ustensiles;
        }

    }
}
