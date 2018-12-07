using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Ustensile
    {
        public enum TYPE { COUTEAUCUISINE, CASSEROLE, CUILLERE, ASSIETTE, VERRE, COUTEAU, FOURCHETTE}

        private TYPE type;

        //Constructeur
        public Ustensile(TYPE type)
        {
            this.type = type;
        }

        //Getter et Setter
        public TYPE getType()
        {
            return this.type;
        }
    }
}
