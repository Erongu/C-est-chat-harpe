﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine
{
    class LaveVaisselle
    {
        private List<Ustensile> Ustensiles
        {
            get;
        } = new List<Ustensile>();

        public int Etat
        {
            get;
        }

        //Constructeur
        public LaveVaisselle()
        {

        }

        //Ajout d'ustensile
        public void AddUstensile(Ustensile ust)
        {
            Ustensiles.Add(ust);
        }

        //Vider la machine
        public void VideLaveVaisselle()
        {
            foreach(Ustensile ust in Ustensiles)
            {
                //MAJ BDD
            }

            Ustensiles.Clear();
        }

    }
}
