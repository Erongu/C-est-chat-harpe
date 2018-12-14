using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Comptoir
    {
        private List<Plat> Plats
        {
            get;
        } = new List<Plat>();
        
        public List<Plat> GetPlat(int numeroTable,Plat.TypePlat type) //Le serveur prend un plat sur le comptoir
        {
            List<Plat> plats = Plats.Where(x => x.Table == numeroTable).ToList();
            List<Plat> platReturn = new List<Plat>();
            foreach(Plat plat in plats)
            {
                if(type == plat.Type)
                {
                    platReturn.Add(plat);
                    Plats.Remove(plat);
                }
                
            }

            return platReturn;
        }

        public Boolean CheckTable(int numeroTable, int nbTable, Plat.TypePlat type)
        {
            int i = 0;
            foreach (Plat plat in Plats)
            {
                if((plat.Table == numeroTable) && (plat.Type == type))
                {
                    i++;
                }
            }
            if (i == nbTable)
            {
                return true;
            }
            return false;
        }

        public void AddPlat(Plat plat) //Les cuisiniers reservent un plat sur le comptoir
        {
            if (this.Plats.Count < 60)
                this.Plats.Add(plat);

            else
                Console.WriteLine($"Le comptoir est plein !");
        }

    }
}
