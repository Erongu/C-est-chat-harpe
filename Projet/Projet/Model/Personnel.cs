using Controller;
using Controller.Strategy;
using System.Collections.Generic;

namespace Model
{
    public class Personnel : ClassTemplate
    {
        public int ID
        {
            get;
            protected set;
        }
        public string Prenom
        {
            get;
            protected set;
        }

        public string Nom
        {
            get;
            protected set;
        }

        public int Metier
        {
            get;
            protected set;
        }


        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }



        public Personnel(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args)
        {
            this.ID = (int)args["id"];
            this.Prenom = (string)args["prenom"];
            this.Nom = (string)args["nom"];
            this.Metier = (int)args["metier"];
            this.PosX = (int)args["posx"];
            this.PosY = (int)args["posy"];
        }
    }
}

