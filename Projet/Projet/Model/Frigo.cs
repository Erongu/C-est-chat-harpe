using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Frigo
    {
        //Liste de plat
        private List<Plat> Plats
        {
            get;
        } = new List<Plat>();

        //Constructeur
        public Frigo()
        {
           
        }

        //Ajout d'un plat
        public void AddPlat(Plat plat)
        {
            plat.Table = 0;
            this.Plats.Add(plat);
        }

        //Prendre un plat
        public Plat prendrePlat(string nom)
        {
            Plat pl = GetPlat(nom);
            Plats.Remove(new Plat(nom,0));
            return pl;
        }

        //Getter and setter
        public Plat GetPlat(string nom)
        {
            return Plats.FirstOrDefault(x => x.Nom == nom);
        }

    }
}
