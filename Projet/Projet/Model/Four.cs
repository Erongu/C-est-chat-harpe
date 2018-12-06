using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Four
    {
       private List<Ingredient> ingredients;
       private bool etat; //Definit si le four est en cours d utilsation

        public void cuisson(int temps, List<Ingredient> ingredients)
        {
            Thread.Sleep(1000*temps);
            return ingredients;
        }
    }
}
