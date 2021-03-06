using Controller;
using Controller.Strategy;
using Model.Salle;
using Model.Threading;
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

        public Groupe Groupe
        {
            get;
            set;
        }

        public int Carre
        {
            get;
        }

        public List<Plat> Plats
        {
            get;
            set;
        } = new List<Plat>();


        public Personnel(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args)
        {
            this.ID = (int)args["id"];
            this.Prenom = (string)args["prenom"];
            this.Nom = (string)args["nom"];
            this.Metier = (int)args["metier"];
            this.PosX = (int)args["posx"];
            this.PosY = (int)args["posy"];
            if (args.ContainsKey("carre"))
            {
                this.Carre = (int)args["carre"];
            }
            this.Groupe = null;
        }

       

        public static List<int> GetPosXTable(int numero, List<Table> tables)
        {
            List<int> pos = new List<int>();
            foreach (Table tbl in tables)
            {
                if (tbl.Numero == numero)
                {
                    pos.Add(tbl.x);
                    pos.Add(tbl.y);
                    return pos;
                }
            }
            return pos;
        }


    }
}

