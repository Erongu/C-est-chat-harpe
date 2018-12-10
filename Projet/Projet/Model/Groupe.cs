using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Groupe
    {
        private List<Client> Clients
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
        
        
       
        //Constructeur
        public Groupe()
        {
            //Création de la liste de client du groupe
            Random rnd = new Random();
            int i = rnd.Next(1, 7);
            if (i < 5)//Groupe de 1 à 4 clients ~57%
            {
                for(int j = 0;j < rnd.Next(1, 4); j++)
                {
                    Clients.Add(new Client());
                }
            }
            else if(i < 7)//Groupe de 5 à 8 clients ~28%
            {
                for (int j = 0; j < rnd.Next(5, 8); j++)
                {
                    Clients.Add(new Client());
                }
            }
            else//Groupe de 9 à 10 clients ~14%
            {
                for (int j = 0; j < rnd.Next(9, 10); j++)
                {
                    Clients.Add(new Client());
                }
            }
            this.Type = moyenneGroupe();
        }

        //Moyenne du groupe
        private int moyenneGroupe()
        {
            int count = 0;
            double total = 0;
            foreach (Client client in Clients)
            {
                count++;
                total += client.Type;
            }
            total = total / count;
            return Convert.ToInt32(Math.Round(total,0));
        }

        public void runGroupe()
        {

        }

        //Getter and Setter

        public void SetPain(int pain)
        {
            this.Pain = pain;
        }

        public void SetBouteille(int bouteille)
        {
            this.Bouteille = bouteille;
        }

        public void SetNombrePlat(int nbPlat)
        {
            this.NombrePlat = nbPlat;
        }

    }
}
