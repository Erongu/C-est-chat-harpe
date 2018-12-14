using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Controller;
using Controller.Strategy;
using Model.Cuisine;

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
            set;
        }

        public int Bouteille
        {
            get;
            set;
        }

        public int NombrePlat
        {
            get;
            private set;
        }

        public GroupeEnum Etat
        {
            get;
            set;
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

        public enum GroupeEnum
        {
            Commande = 0,
            CommandeEnd = 1,
            AttenteEntree = 2,
            MangeEntree = 3,
            AttentePlat = 4,
            MangePlat = 5,
            AttenteDessert = 6,
            MangeDessert = 7,
            AttenteDePayer = 8
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
            this.Etat = GroupeEnum.Commande;
        }

        public List<Plat> Commande()
        {
            DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
            List<Plat> liste = new List<Plat>();
            foreach (Client client in Clients)//GetEntree
            {
                liste.Add(new Plat(DatabaseController.Instance.GetEntree(), this.NumeroTable, Plat.TypePlat.Entree));
            }
            foreach (Client client in Clients)//GetPlat
            {
                liste.Add(new Plat(DatabaseController.Instance.Getplat(), this.NumeroTable, Plat.TypePlat.Plat));
            }
            foreach (Client client in Clients)//GetDessert
            {
                liste.Add(new Plat(DatabaseController.Instance.GetDessert(), this.NumeroTable, Plat.TypePlat.Dessert));
            }
            Console.WriteLine("Le groupe a commandé");
            this.Etat = GroupeEnum.AttenteEntree;
            return liste;
        }


        public void RunGroupe()
        {
            while (1 == 1)
            {
                if(Etat == GroupeEnum.Commande)//En train de commander
                {
                    Thread.Sleep(10000);
                    this.Etat = GroupeEnum.CommandeEnd;
                }
                if (Etat == GroupeEnum.MangeEntree)//En train de commander
                {
                    Thread.Sleep(10000);
                    this.Etat = GroupeEnum.AttentePlat;
                }
                if (Etat == GroupeEnum.MangePlat)//En train de commander
                {
                    Thread.Sleep(10000);
                    this.Etat = GroupeEnum.AttenteDessert;
                }
                if (Etat == GroupeEnum.MangeDessert)//En train de commander
                {
                    Thread.Sleep(10000);
                    this.Etat = GroupeEnum.AttenteDePayer;
                }

            }
        }
    }
}
