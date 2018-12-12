using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public class Personnel : PictureBox
    {
        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }

        public int Metier
        {
            get;
            set;
        }


        public Personnel(int PosX, int PosY, int metier)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.Metier = metier;

            if (Metier == 1) { this.Image = Projet.Properties.Resources.serveur; }
            if (Metier == 2) { this.Image = Projet.Properties.Resources.maître_d_hotel; }
            if (Metier == 3) { this.Image = Projet.Properties.Resources.chef_de_rang; }
            if (Metier == 4) { this.Image = Projet.Properties.Resources.commis_s; }
            if (Metier == 5) { this.Image = Projet.Properties.Resources.chef_de_cusine; }
            if (Metier == 6) { this.Image = Projet.Properties.Resources.chef_de_partie; }
            if (Metier == 7) { this.Image = Projet.Properties.Resources.commis_c; }
            if (Metier == 8) { this.Image = Projet.Properties.Resources.plongeur; }
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();

            this.BackColor = Color.Transparent;
            this.SetBounds(PosX*32, (PosY*32)-1, 32, 64);
        }

       
    }
}