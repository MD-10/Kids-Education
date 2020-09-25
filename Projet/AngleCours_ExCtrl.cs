using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Projet
{
    public partial class AngleCours_ExCtrl : UserControl
    {
        int correct=0, count=0, erreur = 0;
        public AngleCours_ExCtrl()
        {
            InitializeComponent();
        }

        public class PointChoix
        {
            static public string aigue = "170,240,170,80,400,180.280,210,400,210,390,160.170,240,170,80,400,220.170,240,200,100,400,180", droit = "170,240,170,80,310,240.260,210,260,100,410,210", obtue = "170,240,150,90,310,240.260,210,350,210,200,130.170,200,120,90,310,200.170,240,80,180,310,240";
            static public Random n = new Random();
            static public PointF point1, point2, point3;
            static public int j;
            public static void DonnerPoint(out PointF point1, out PointF point2, out PointF point3)
            {
                string[] tab;
                j = n.Next(3);
                point1 = point2 = point3 = new PointF(0, 0);
                if (j == 0)
                {
                    tab = aigue.Split('.')[n.Next(aigue.Split('.').Length)].Split(',');

                    point1 = new PointF((float.Parse(tab[0])), (float.Parse(tab[1])));
                    point2 = new PointF((float.Parse(tab[2])), (float.Parse(tab[3])));
                    point3 = new PointF((float.Parse(tab[4])), (float.Parse(tab[5])));
                }
                if (j == 1)
                {
                    tab = droit.Split('.')[n.Next(droit.Split('.').Length)].Split(',');

                    point1 = new PointF((float.Parse(tab[0])), (float.Parse(tab[1])));
                    point2 = new PointF((float.Parse(tab[2])), (float.Parse(tab[3])));
                    point3 = new PointF((float.Parse(tab[4])), (float.Parse(tab[5])));
                }
                if (j == 2)
                {
                    tab = obtue.Split('.')[n.Next(obtue.Split('.').Length)].Split(',');

                    point1 = new PointF((float.Parse(tab[0])), (float.Parse(tab[1])));
                    point2 = new PointF((float.Parse(tab[2])), (float.Parse(tab[3])));
                    point3 = new PointF((float.Parse(tab[4])), (float.Parse(tab[5])));
                }
            }

        }
        public Graphics g;


        private void pComprendre_Paint(object sender, PaintEventArgs e)
        {//aigue
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create points that define line.
            PointF point1 = new PointF(466.0F, 115.0F);
            PointF point2 = new PointF(530.0F, 85.0F);
            PointF point3 = new PointF(530.0F, 115.0F);
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
            e.Graphics.DrawLine(blackPen, point1, point3);
            //droit

            // Create points that define line.
            PointF point4 = new PointF(420.0F, 230.0F);
            PointF point5 = new PointF(480.0F, 230.0F);
            PointF point6 = new PointF(420.0F, 180.0F);
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point4, point5);
            e.Graphics.DrawLine(blackPen, point4, point6);
            //obtue

            // Create points that define line.
            PointF point7 = new PointF(520.0F, 320.0F);
            PointF point8 = new PointF(570.0F, 320.0F);
            PointF point9 = new PointF(490.0F, 290.0F);
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point7, point8);
            e.Graphics.DrawLine(blackPen, point7, point9);



        }


        private void Comprendre_Click(object sender, EventArgs e)
        {
            pComprendre.Show();
        }
       int i = -1;
        private void Equere_Click(object sender, EventArgs e)
        {

        }


        private Point MouseDownLocation;


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox1 = (PictureBox)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Left = e.X + pictureBox1.Left - MouseDownLocation.X;
                pictureBox1.Top = e.Y + pictureBox1.Top - MouseDownLocation.Y;
            }

            g = pJouer.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 3);
            g.DrawLine(blackPen, PointChoix.point1, PointChoix.point2);
            g.DrawLine(blackPen, PointChoix.point1, PointChoix.point3);
        }
        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.DoDragDrop(btn, DragDropEffects.Move);
        }
        void panel_DragEnter(object sender, DragEventArgs e)
        {
            pJouer.AllowDrop = true;
            e.Effect = DragDropEffects.Move;

        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {

            Panel p = (Panel)sender;
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).Parent = p;
        }
        private void pJouer_Paint(object sender, PaintEventArgs e)
        {
            
        }
        void newEx()
        {
            pJouer.Refresh();
            bAigue.Enabled = bObtue.Enabled = bDroit.Enabled = true;
            Pen blackPen = new Pen(Color.Black, 3);
            PointChoix.DonnerPoint(out PointChoix.point1, out PointChoix.point2, out PointChoix.point3);
            g = pJouer.CreateGraphics();
            g.DrawLine(blackPen, PointChoix.point1, PointChoix.point2);
            g.DrawLine(blackPen, PointChoix.point1, PointChoix.point3);
        }
        private void Next_Click(object sender, EventArgs e)
        {
            nextBtn.Hide();
            newEx();
            bAigue.Enabled = bObtue.Enabled = bDroit.Enabled = true;

        }
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        private void lAigue_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five };
            Button l = (Button)sender;
            bAigue.Enabled = bObtue.Enabled = bDroit.Enabled = false;
            nextBtn.Show();
            if (((PointChoix.j == 0) && (l.Text == "Aigue")) || ((PointChoix.j == 1) && (l.Text == "Droit")) || ((PointChoix.j == 2) && (l.Text == "Obtue")))
            {
                trueAns2Sound.Play();
                progBtns[count].BackColor = Color.LawnGreen;
                count++;
                correct++;
            }
            else
            {
                wrongAnsSound.Play();
                progBtns[count].BackColor = Color.Red;
                erreur++;
                count++;
            }
            if ((count == 5) && (correct >= 3))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {
                    InitialisateProg();
                    newEx();
                   
                }
            }
            else
            {
                if ((count == 5) && (correct < 3))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    newEx();

                }

            }
        }

        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            count = 0; erreur = 0; correct=0;
        }

        private void Jouer_Click(object sender, EventArgs e)
        {
            pJouer.Show();
            newEx();
        }

        private void bAigue_MouseHover(object sender, EventArgs e)
        {
            bAigue.Size = new Size(102, 62);
        }

        private void retour1_Click(object sender, EventArgs e)
        {
            pJouer.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (pJouer.Visible == true) pJouer.Hide();
            else if (pComprendre.Visible == true) pComprendre.Hide();
            else { this.Parent.Controls.Remove(this); }
        }

        private void bAigue_MouseLeave(object sender, EventArgs e)
        {
            bAigue.Size = new Size(92, 62);
        }

        private void retour_Click(object sender, EventArgs e)
        {
            pComprendre.Hide();
        }
    }
}
