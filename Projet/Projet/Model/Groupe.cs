using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Groupe
    {
        private List<Client> clients; //Liste des clients du groupes
        private int type; //Type du groupe
        private int pain;
        private int bouteille;
        private int nombrePlat;
        private int etat;
        
        
       
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
                    clients.Add(new Client());
                }
            }
            else if(i < 7)//Groupe de 5 à 8 clients ~28%
            {
                for (int j = 0; j < rnd.Next(5, 8); j++)
                {
                    clients.Add(new Client());
                }
            }
            else//Groupe de 9 à 10 clients ~14%
            {
                for (int j = 0; j < rnd.Next(9, 10); j++)
                {
                    clients.Add(new Client());
                }
            }
            this.type = moyenneGroupe();
        }

        //Moyenne du groupe
        private int moyenneGroupe()
        {
            int count = 0;
            double total = 0;
            foreach (Client client in clients)
            {
                count++;
                total += client.getType();
            }
            total = total / count;
            return Convert.ToInt32(Math.Round(total,0));
        }

        public void runGroupe()
        {

        }

        //Getter and Setter
        public List<Client> getClients()
        {
            return this.clients;
        }

        public int getType()
        {
            return this.type;
        }

        public int getPain()
        {
            return this.pain;
        }

        public int getBouteille()
        {
            return this.bouteille;
        }

        public int getNombrePlat()
        {
            return this.nombrePlat;
        }

        public int getEtat()
        {
            return this.etat;
        }

        public void setPain(int pain)
        {
            this.pain = pain;
        }

        public void setBouteille(int bouteille)
        {
            this.bouteille = bouteille;
        }

        public void setNombrePlat(int nbPlat)
        {
            this.nombrePlat = nbPlat;
        }

    }
}
