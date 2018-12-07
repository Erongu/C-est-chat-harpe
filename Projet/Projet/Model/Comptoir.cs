using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Comptoir
    {
        private List<Plat> plats;
        
        public List<Plat> getPlat(int numeroTable)
        {

        }

        public void addPlat(Plat plat)
        {
        if (this.plats.Count < 14)
            this.plats.Add(plat);

        else
                Console.WriteLine($"Le comptoir est plein !")
        }

    }
}
