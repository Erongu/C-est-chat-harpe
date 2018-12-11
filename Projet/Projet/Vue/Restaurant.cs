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
        private Button fastBtn;
        private Button pauseBtn;
        private Button button1;
        private Label lb_positionVoulu;
        private Label lb_serveurPosition;
        private List<Personnel> personnels = new List<Personnel>(); //List de panel personnel

        //Constructeur qui affiche la map
        public Restaurant()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.font = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_positionVoulu = new System.Windows.Forms.Label();
            this.lb_serveurPosition = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.reverseBtn = new System.Windows.Forms.Button();
            this.fastBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.font.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // font
            // 
            this.font.BackgroundImage = global::Projet.Properties.Resources.cuisine;
            this.font.Controls.Add(this.panel1);
            this.font.Dock = System.Windows.Forms.DockStyle.Fill;
            this.font.Location = new System.Drawing.Point(0, 0);
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(1314, 796);
            this.font.TabIndex = 0;
            this.font.Paint += new System.Windows.Forms.PaintEventHandler(this.font_Paint);
            this.font.BackgroundImageLayout = ImageLayout.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_positionVoulu);
            this.panel1.Controls.Add(this.lb_serveurPosition);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.reverseBtn);
            this.panel1.Controls.Add(this.fastBtn);
            this.panel1.Controls.Add(this.pauseBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 757);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1314, 39);
            this.panel1.TabIndex = 0;
            // 
            // lb_positionVoulu
            // 
            this.lb_positionVoulu.AutoSize = true;
            this.lb_positionVoulu.Location = new System.Drawing.Point(480, 18);
            this.lb_positionVoulu.Name = "lb_positionVoulu";
            this.lb_positionVoulu.Size = new System.Drawing.Size(84, 13);
            this.lb_positionVoulu.TabIndex = 5;
            this.lb_positionVoulu.Text = "Position requise:";
            // 
            // lb_serveurPosition
            // 
            this.lb_serveurPosition.AutoSize = true;
            this.lb_serveurPosition.Location = new System.Drawing.Point(329, 18);
            this.lb_serveurPosition.Name = "lb_serveurPosition";
            this.lb_serveurPosition.Size = new System.Drawing.Size(79, 13);
            this.lb_serveurPosition.TabIndex = 4;
            this.lb_serveurPosition.Text = "Position actuel:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reverseBtn
            // 
            this.reverseBtn.Location = new System.Drawing.Point(167, 3);
            this.reverseBtn.Name = "reverseBtn";
            this.reverseBtn.Size = new System.Drawing.Size(75, 33);
            this.reverseBtn.TabIndex = 2;
            this.reverseBtn.Text = "Reverse";
            this.reverseBtn.UseVisualStyleBackColor = true;
            // 
            // fastBtn
            // 
            this.fastBtn.Location = new System.Drawing.Point(86, 3);
            this.fastBtn.Name = "fastBtn";
            this.fastBtn.Size = new System.Drawing.Size(75, 33);
            this.fastBtn.TabIndex = 1;
            this.fastBtn.Text = "Accélérer";
            this.fastBtn.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(1314,850);
            this.Controls.Add(this.font);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1330, 850);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1330, 0);
            this.Name = "Restaurant";
            this.Load += new System.EventHandler(this.Restaurant_Load);
            this.font.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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

        private void button1_Click(object sender, EventArgs e)
        {
            font.BackgroundImage = global::Projet.Properties.Resources.cuisine_grille;
        }

        private void font_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}