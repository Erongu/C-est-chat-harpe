using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Ustensile
    {
        public enum TYPE { COUTEAUCUISINE, CASSEROLE, CUILLERE, ASSIETTE, VERRE, COUTEAU, FOURCHETTE}
        private int id
            {
            get;
            set;
            }

        private int quantite
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
