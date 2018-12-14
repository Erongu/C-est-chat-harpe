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
        
        public List<Plat> GetPlat(int numeroTable) //Le serveur prend un plat sur le comptoir
        {
            List<Plat> plats = Plats.Where(x => x.Table == numeroTable).ToList();
            foreach(Plat plat in plats)
            {
                Plats.Remove(plat);
            }

            return plats;
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
