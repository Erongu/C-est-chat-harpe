using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine
{
    class Ustensile
    {
        public enum TYPE { COUTEAUCUISINE, CASSEROLE, CUILLERE, ASSIETTE, VERRE, COUTEAU, FOURCHETTE}
        private int Id
        {
            get;
            set;
        }

        private int Quantite
        {
            get;
            set;
        }

        public TYPE Type
        {
            get;
            set;
        }

        //Constructeur
        public Ustensile(TYPE type)
        {
            this.Type = type;
        }
    }
}
