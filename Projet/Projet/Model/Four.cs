using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Four
    {
        private List<Ingredient> Ingredients
        {
            get;
        } = new List<Ingredient>();

       public bool Etat
        {
            get;
            set;
        } //Definit si le four est en cours d utilsation

        public List<Ingredient> cuisson(int temps, List<Ingredient> ingredients)
        {
            System.Threading.Thread.Sleep(1000 * temps);

            return ingredients;
        }
    }
}
