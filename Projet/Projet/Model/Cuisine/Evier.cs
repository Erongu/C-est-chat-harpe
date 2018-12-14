using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Cuisine
{
    class Evier
    {
        //Liste d'ustensiles
        public List<Ustensile> Ustensiles
        {
            get;
        } = new List<Ustensile>();

        //Constructeur
        public Evier()
        {

        }

        //Laver un Ustensile
        public void laverUstensible()
        {    
            Ustensile ust = Ustensiles[0];
            Ustensiles.RemoveAt(0);

            if (ust.Type == Ustensile.TYPE.COUTEAUCUISINE)
            {
                Thread.Sleep(500);
                //addStock(couteaucuisine); ///////////
            }
            else if (ust.Type == Ustensile.TYPE.CUILLERE)
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

    }
}
