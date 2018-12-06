using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Evier
    {
        //Liste d'ustensiles
        private List<Ustensiles> ustensiles;

        //Constructeur
        public Evier()
        {

        }

        //Laver un Ustensile
        public void laverUstensible()
        {
            
            Ustensiles ust = ustensiles[0];
            ustensiles.RemoveAt(0);
            if(ust.)
        }

        //Getter et Setter
        public List<Ustensible> getUstensible()
        {
            return ustensiles;
        }

    }
}
