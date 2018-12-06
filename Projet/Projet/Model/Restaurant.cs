using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Restaurant
    {
        private List<Carre> carres;
        private Comptoir comptoir;
        private Frigo frigo;
        private VitrineChauffante vitrineChauffante;
        private Evier evier;

        //Constructeur
        public Restaurant()
        {
            carres.Add(new Carre(1));
            carres.Add(new Carre(2));
            comptoir = new Comptoir();
            frigo = new Frigo();
            vitrineChauffante = new VitrineChauffante();
            evier = new Evier();
        }

        //Getter and Setter
        public List<Carre> getCarre()
        {
            return this.carres;
        }

        public Carre getCarre(int numero)
        {
            foreach (Carre carre in carres)
            {
                if (carre.getNumero() == numero) { return carre; }
            }
            return null;
        }

        public Comptoir getComptoir()
        {
            return this.comptoir;
        }

        public Frigo getFrigo()
        {
            return this.frigo;
        }

        public VitrineChauffante getVitrineChauffante()
        {
            return this.vitrineChauffante;
        }

        public Evier getEvier()
        {
            return this.evier;
        }

    }
}
