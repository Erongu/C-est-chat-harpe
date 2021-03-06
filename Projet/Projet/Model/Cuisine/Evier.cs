﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Cuisine
{
    class Evier
    {
        //Liste d'ustensiles
        public List<Ustensile> Ustensiles
        {
            get;
        } = new List<Ustensile>();

        //Constructeur
        public Evier()
        {

        }

        //Laver un Ustensile
        public void laverUstensible()
        {    
            if(Ustensiles.Count != 0)
            {
                Console.WriteLine("Le Plongeur lave un ustensile");
                Ustensile ust = Ustensiles[0];
                Ustensiles.RemoveAt(0);

                if (ust.Type == Ustensile.TYPE.COUTEAUCUISINE)
                {
                    Thread.Sleep((int)((30000) / Projet.Properties.Settings.Default.Vitesse));
                }
                else if (ust.Type == Ustensile.TYPE.CUILLERE)
                {
                    Thread.Sleep((int)((30000) / Projet.Properties.Settings.Default.Vitesse));
                }
                else
                {
                    Thread.Sleep((int)((10000) / Projet.Properties.Settings.Default.Vitesse));
                }
            }
            

        }

    }
}
