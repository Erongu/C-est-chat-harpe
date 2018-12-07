using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public class Restaurant : Form
    {
        private Panel font;
        private Panel pan;
        private Button pause;
        private Button forward;
        private Button back;

        //Constructeur qui affiche la map
        public Restaurant()
        {
            this.Height = 875;
            this.Width = 1330;

            //Création du fond
            font = new Panel();
            font.SetBounds(1,1, 1312, 800);
            font.BackgroundImage = Projet.Properties.Resources.cuisine;
            this.Controls.Add(font);//Ajout du font au form

            //Création du panneau de bouton
            pan = new Panel();
            pan.SetBounds(1,800,1330,300);
            this.Controls.Add(pan);

            //Création du bouton pause
            pause = new Button();
            pause.Text = "Pause";
            pause.SetBounds(1, 1, 100, 35);
            pan.Controls.Add(pause);

            //Création du bouton forward
            forward = new Button();
            forward.Text = "Accelère";
            forward.SetBounds(101, 1, 100, 35);
            pan.Controls.Add(forward);

            //Création du bouton reverse
            back = new Button();
            back.Text = "Reverse";
            back.SetBounds(201, 1, 100, 35);
            pan.Controls.Add(back);
        }
    }
}