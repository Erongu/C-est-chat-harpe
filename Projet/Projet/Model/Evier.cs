using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
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
                //addStock(couteaucuisine); ///////////
            }
            else if (ust.getType() == Ustensile.TYPE.CUILLERE)
            {
                Thread.Sleep(500);
                //addStock(cuillere); /////////////////
            }
            else
            {
                Thread.Sleep(1000);
                //addStock(casserole); ////////////////
            }

            /**
             * 
             * MAJ STOCK
             * 
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
