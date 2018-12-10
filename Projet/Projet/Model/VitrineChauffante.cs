using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class VitrineChauffante
    {
        //Liste de plat
        private List<Plat> plats;

        //Constructeur
        public VitrineChauffante()
        {

        }

        //Ajout d'un plat
        public void addPlat(Plat plat)
        {
            plat.setTable(0);
            this.plats.Add(plat);
        }

        //Prendre un plat
        public Plat prendrePlat(String nom)
        {
            Plat pl = getPlat(nom);
            plats.Remove(new Plat(nom, 0));
            return pl;
        }

        //Getter and setter
        public List<Plat> getPlat()
        {
            return this.plats;
        }

        public Plat getPlat(String nom)
        {
            foreach (Plat plat in plats)
            {
                if (plat.getNom() == nom) { return plat; }
            }
            return null;
        }
    }
}
