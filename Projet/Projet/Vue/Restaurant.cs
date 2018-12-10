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
        private List<Personnel> personnels = new List<Personnel>(); //List de panel personnel

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

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Restaurant
            // 
            this.ClientSize = new System.Drawing.Size(1314, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1330, 835);
            this.MinimumSize = new System.Drawing.Size(1330, 0);
            this.Name = "Restaurant";
            this.Load += new System.EventHandler(this.Restaurant_Load);
            this.ResumeLayout(false);

        }

        public void InitVue(List<Model.Personnel> personnels)
        {
            foreach(Model.Personnel personnel in personnels)
            {
                this.personnels.Add(new View.Personnel(personnel.PosX, personnel.PosY,personnel.Metier));
            }

            this.Invoke((MethodInvoker)delegate ()
            {
                foreach (View.Personnel personnel in this.personnels)
                {
                    
                    font.Controls.Add(personnel);
                }

            });

                
        }

        public void UpdateVue(List<Model.Personnel> personnels)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                
                //Comparaison des liste
                for (int i = 0; i < personnels.Count; i++)
                {
                    if ((personnels[i].PosX != this.personnels[i].PosX) || (personnels[i].PosY != this.personnels[i].PosY))
                    {
                        this.personnels[i].PosX = personnels[i].PosX;
                        this.personnels[i].PosY = personnels[i].PosY;
                        this.personnels[i].SetBounds(this.personnels[i].PosX*32, (this.personnels[i].PosY*32)-1, 32, 64);
                    }
                }
            });
        }

        private void Restaurant_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //close logic here
            e.Cancel = true;
        }
    }
}