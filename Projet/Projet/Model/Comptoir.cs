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
        
        public List<Plat> GetPlat(int numeroTable)
        {
            return Plats.Where(x => x.Table == numeroTable).ToList();
        }

        public void AddPlat(Plat plat)
        {
            if (this.Plats.Count < 14)
                this.Plats.Add(plat);

            else
                Console.WriteLine($"Le comptoir est plein !");
        }

    }
}
