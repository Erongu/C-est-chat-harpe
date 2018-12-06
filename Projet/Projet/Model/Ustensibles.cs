using System;

namespace Projet.Model
{
    public class Ustensibles
    {
        enum TYPE { COUTEAUCUISINE, CASSEROLE, CUILLERE };
        TYPE type;

        //Constructeur
        public Ustensibles(Ustensibles.TYPE type)
        {
            this.type = type;

        }

        //Getter et Setter
        public TYPE getType()
        {
            return this.type;
        }

        public void test()
        {

        }
    }
}

