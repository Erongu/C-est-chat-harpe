using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Comptoir
    {
        private List<Plat> plats;
        
        public List<Plat> GetPlat(int numeroTable) //Le serveur prend un plat sur le comptoir
        {
            List<Plat> platsAservir = new List<Plat>();
            
            for(var i=0; i<5 ;i++){

                for(var j=0; j<14; j++){
                     if (this.plats[j].getTable() == numeroTable){
                        platsAservir.Add(this.plats[j]);
                        break;
                     }
                }

            }
           
            return platsAservir;
            

        }

        public void AddPlat(Plat plat) //Les cuisiniers reservent un plat sur le comptoir
        {
        if (this.plats.Count < 14)
            this.plats.Add(plat);

        else
                Console.WriteLine($"Le comptoir est plein !");
        }

    }
}
