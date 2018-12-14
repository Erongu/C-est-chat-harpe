using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine
{
    public class Etape
    {
        public enum ActionEnum
        {
            Prendre = 1,
            Preparer = 2,
            Cuire = 3,
            Cuire_Four = 4
        }
        public ActionEnum Action
        {
            get;
            set;
        }

        public int Temps
        {
            get;
            set;
        }

        public int Ingredient
        {
            get;
            set;
        }

        public int NumeroEtape
        {
            get;
            set;
        }

        public int Part
        {
            get;
            set;
        }

        public Etape(int action,int temps, int ingredient,int part )
        {
            
            if(action == 1) { Action = ActionEnum.Prendre; }
            if (action == 2) { Action = ActionEnum.Preparer; }
            if (action == 3) { Action = ActionEnum.Cuire; }
            if (action == 4) { Action = ActionEnum.Cuire_Four; }
            this.Temps = temps;
            this.Ingredient = ingredient;
            this.Part = part;
        }

    }
}
