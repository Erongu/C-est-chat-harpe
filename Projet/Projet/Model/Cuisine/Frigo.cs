using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Salle;

namespace Model.Cuisine
{
    class Frigo
    {
        //Liste de plat
        public List<Plat> Plats
        {
            get;
        } = new List<Plat>();

        //Constructeur
        public Frigo()
        {
            Plats.Add(new Plat(6, 0, Plat.TypePlat.Plat));
        }

        //Ajout d'un plat
        public void AddPlat(Plat plat)
        {
            plat.Table = 0;
            this.Plats.Add(plat);
        }

        //Prendre un plat
        public Plat prendrePlat(int nom)
        {
            Plat pl = GetPlat(nom);
            Plats.Remove(pl);
            return pl;
        }

        //Getter and setter
        public Plat GetPlat(int nom)
        {
            return Plats.FirstOrDefault(x => x.Nom == nom);
        }

    }
}
