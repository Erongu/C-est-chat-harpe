using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public class Restaurant : Form
    {
        private Panel font;

        //Constructeur qui affiche la map
        public Restaurant()
        {
            this.Height = 900;
            this.Width = 1400;

            //Création du fond
            font = new Panel();
            font.SetBounds(1,1, 1400, 900);
            font.BackgroundImage = Projet.Properties.Resources.cuisine;
            this.Controls.Add(font);//Ajout du font au form
        }
    }
}