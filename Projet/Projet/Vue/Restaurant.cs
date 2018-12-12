using Controller;
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
        private Panel panel1;
        private Button reverseBtn;
        private Button pauseBtn;
        private Button debugBtn;
        private Label lb_positionVoulu;
        private Label lb_serveurPosition;
        private TrackBar tb_vitesse;
        private Label lb_vitesse;
        private PictureBox imagesContainer;
        private Button spawnClient;
        private List<Personnel> personnels = new List<Personnel>(); //List de panel personnel

        //Constructeur qui affiche la map
        public Restaurant()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.font = new System.Windows.Forms.Panel();
            this.imagesContainer = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spawnClient = new System.Windows.Forms.Button();
            this.lb_vitesse = new System.Windows.Forms.Label();
            this.tb_vitesse = new System.Windows.Forms.TrackBar();
            this.lb_positionVoulu = new System.Windows.Forms.Label();
            this.lb_serveurPosition = new System.Windows.Forms.Label();
            this.debugBtn = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.font.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagesContainer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_vitesse)).BeginInit();
            this.SuspendLayout();
            // 
            // font
            // 
            this.font.BackgroundImage = global::Projet.Properties.Resources.cuisine;
            this.font.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.font.Controls.Add(this.imagesContainer);
            this.font.Controls.Add(this.panel1);
            this.font.Dock = System.Windows.Forms.DockStyle.Top;
            this.font.Location = new System.Drawing.Point(0, 0);
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(1314, 839);
            this.font.TabIndex = 0;
            this.font.Paint += new System.Windows.Forms.PaintEventHandler(this.font_Paint);
            // 
            // imagesContainer
            // 
            this.imagesContainer.BackColor = System.Drawing.Color.Transparent;
            this.imagesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagesContainer.Location = new System.Drawing.Point(0, 0);
            this.imagesContainer.Name = "imagesContainer";
            this.imagesContainer.Size = new System.Drawing.Size(1314, 800);
            this.imagesContainer.TabIndex = 1;
            this.imagesContainer.TabStop = false;
            this.imagesContainer.Click += new System.EventHandler(this.imagesContainer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spawnClient);
            this.panel1.Controls.Add(this.lb_vitesse);
            this.panel1.Controls.Add(this.tb_vitesse);
            this.panel1.Controls.Add(this.lb_positionVoulu);
            this.panel1.Controls.Add(this.lb_serveurPosition);
            this.panel1.Controls.Add(this.debugBtn);
            this.panel1.Controls.Add(this.reverseBtn);
            this.panel1.Controls.Add(this.pauseBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 800);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1314, 39);
            this.panel1.TabIndex = 0;
            // 
            // spawnClient
            // 
            this.spawnClient.Location = new System.Drawing.Point(329, 3);
            this.spawnClient.Name = "spawnClient";
            this.spawnClient.Size = new System.Drawing.Size(91, 33);
            this.spawnClient.TabIndex = 8;
            this.spawnClient.Text = "Spawn Client";
            this.spawnClient.UseVisualStyleBackColor = true;
            this.spawnClient.Click += new System.EventHandler(this.spawnClient_Click);
            // 
            // lb_vitesse
            // 
            this.lb_vitesse.AutoSize = true;
            this.lb_vitesse.Location = new System.Drawing.Point(819, 13);
            this.lb_vitesse.Name = "lb_vitesse";
            this.lb_vitesse.Size = new System.Drawing.Size(21, 13);
            this.lb_vitesse.TabIndex = 7;
            this.lb_vitesse.Text = "x 1";
            // 
            // tb_vitesse
            // 
            this.tb_vitesse.LargeChange = 2;
            this.tb_vitesse.Location = new System.Drawing.Point(456, 9);
            this.tb_vitesse.Maximum = 5;
            this.tb_vitesse.Name = "tb_vitesse";
            this.tb_vitesse.Size = new System.Drawing.Size(359, 45);
            this.tb_vitesse.TabIndex = 6;
            this.tb_vitesse.Value = 1;
            this.tb_vitesse.Scroll += new System.EventHandler(this.tb_vitesse_Scroll);
            // 
            // lb_positionVoulu
            // 
            this.lb_positionVoulu.AutoSize = true;
            this.lb_positionVoulu.Location = new System.Drawing.Point(1100, 13);
            this.lb_positionVoulu.Name = "lb_positionVoulu";
            this.lb_positionVoulu.Size = new System.Drawing.Size(84, 13);
            this.lb_positionVoulu.TabIndex = 5;
            this.lb_positionVoulu.Text = "Position requise:";
            // 
            // lb_serveurPosition
            // 
            this.lb_serveurPosition.AutoSize = true;
            this.lb_serveurPosition.Location = new System.Drawing.Point(949, 13);
            this.lb_serveurPosition.Name = "lb_serveurPosition";
            this.lb_serveurPosition.Size = new System.Drawing.Size(79, 13);
            this.lb_serveurPosition.TabIndex = 4;
            this.lb_serveurPosition.Text = "Position actuel:";
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(167, 3);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(75, 33);
            this.debugBtn.TabIndex = 3;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.debugBtn_Click);
            // 
            // reverseBtn
            // 
            this.reverseBtn.Location = new System.Drawing.Point(86, 3);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(75, 33);
            this.reverseBtn.TabIndex = 2;
            this.reverseBtn.Text = "Reverse";
            this.reverseBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(5, 3);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 33);
            this.pauseBtn.TabIndex = 0;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // Restaurant
            // 
            this.ClientSize = new System.Drawing.Size(1314, 841);
            this.Controls.Add(this.font);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1330, 880);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1330, 0);
            this.Name = "Restaurant";
            this.Load += new System.EventHandler(this.Restaurant_Load);
            this.font.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagesContainer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_vitesse)).EndInit();
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
                    imagesContainer.Controls.Add(personnel);
                    imagesContainer.BringToFront();
                    personnel.BringToFront();
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

                        lb_serveurPosition.Text = "Position actuel: " + personnels[i].PosX.ToString() + "," + personnels[i].PosY.ToString();


                        this.personnels[i].SetBounds(this.personnels[i].PosX * 32, (this.personnels[i].PosY - 1) * 32, 32, 64);

                        this.personnels[i].Invalidate();
                    }
                }
            });
        }

        public void UpdatePositionNeeded(int x, int y)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                lb_positionVoulu.Text = "Position voulu: " +x.ToString() + "," + y.ToString();
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

        private void debugBtn_Click(object sender, EventArgs e)
        {
            font.BackgroundImage = global::Projet.Properties.Resources.cuisine_grille;
        }

        private void font_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_vitesse_Scroll(object sender, EventArgs e)
        {
            double vitesse = 1;

            if (tb_vitesse.Value == 0)
                vitesse = 0.5;
            else
                vitesse = tb_vitesse.Value;

            lb_vitesse.Text = "x " + vitesse;

            RestaurantController.Vitesse = vitesse;
        }

        private void spawnClient_Click(object sender, EventArgs e)
        {
            RestaurantController.AddGroupe();
        }

        private void imagesContainer_Click(object sender, EventArgs e)
        {

        }
    }
}