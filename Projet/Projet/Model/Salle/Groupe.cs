using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Strategy;

namespace Model.Salle
{
    public class Groupe : ClassTemplate
    {
        public List<Client> Clients
        {
            get;
        } = new List<Client>(); //Liste des clients du groupes

        public int Type
        {
            get;
        } //Type du groupe

        public int Pain
        {
            get;
            private set;
        }

        public int Bouteille
        {
            get;
            private set;
        }

        public int NombrePlat
        {
            get;
            private set;
        }

        public int Etat
        {
            get;
        }

        public int Taille
        {
            get;
        }

        public int NumeroTable
        {
            get;
            set;
        }

        public int NumeroRang
        {
            get;
            set;
        }

        public int NumeroCarre
        {
            get;
            set;
        }

        //Moyenne du groupe
        private int MoyenneGroupe
        {
            get
            {
                int count = 0;
                double total = 0;
                foreach (Client client in Clients)
                {
                    count++;
                    total += client.Type;
                }
                total = total / count;
                return Convert.ToInt32(Math.Round(total, 0));
            }
        }


        //Constructeur
        public Groupe(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args)
        {
            //Création de la liste de client du groupe
            Random rnd = new Random();
            int i = rnd.Next(1, 7);
            if (i < 5) // Groupe de 1 à 4 clients ~57%
            {
                for(int j = 0; j < rnd.Next(1, 4); j++)
                {
                    Clients.Add(new Factory().Create<Client>());
                }
            }
            else if(i < 7) // Groupe de 5 à 8 clients ~28%
            {
                for (int j = 0; j < rnd.Next(5, 8); j++)
                {
                    Clients.Add(new Factory().Create<Client>());
                }
            }
            else // Groupe de 9 à 10 clients ~14%
            {
                for (int j = 0; j < rnd.Next(9, 10); j++)
                {
                    Clients.Add(new Factory().Create<Client>());
                }
            }

            this.Type = MoyenneGroupe;
            this.Taille = Clients.Count;
        }


        public void RunGroupe()
        {

        }
    }
}
