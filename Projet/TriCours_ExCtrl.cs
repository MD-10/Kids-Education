using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class TriCours_ExCtrl : UserControl
    {
        public TriCours_ExCtrl()
        {
            InitializeComponent();
            Box1.AllowDrop = true;
            Box2.AllowDrop = true;
            Box3.AllowDrop = true;
            Box4.AllowDrop = true;
        }
        public class Exercice
        {
            public static string exercice;
            public static string[] formes = { "carré", "triangle", "cercle", "hexagone" }, couleurs = { "rouge", "jaune", "vert", "blue" }, tailles = { "petit", "grand" };
            public static Size[] panelSize = { new Size(40, 40), new Size(75, 75) };
            public static Brush[] panelColor = { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Blue };
            public static Point[] panelLocation = { new Point(14, 15), new Point(133, 15), new Point(256, 15), new Point(375, 15), new Point(490, 15), new Point(37, 138), new Point(155, 138), new Point(280, 138), new Point(405, 138), new Point(520, 138) };
            public static Brush color;
            public static Size size;
            public static string forme, couleur, taille;

        }

        public static bool oknumber = false;
       

        private void bForme_Click(object sender, EventArgs e)
        {
            pExercice.Show();
            Exercice.exercice = "forme";
            NewEx();
        }


        private void bCouleur_Click(object sender, EventArgs e)
        {
            pExercice.Show();
            Exercice.exercice = "couleur";
            NewEx();
        }
        void panel_DragEnter(object sender, DragEventArgs e)
        {
            Box1.AllowDrop = true;
            Box2.AllowDrop = true;
            Box3.AllowDrop = true;
            Box4.AllowDrop = true;
            e.Effect = DragDropEffects.Move;

        }
        public static int score;
        void panel_DragDrop(object sender, DragEventArgs e)
        {
            oknumber = true;
            int i, ii;
            PictureBox p = (PictureBox)sender;
            i = p.Controls.Count;
            ((Panel)e.Data.GetData(typeof(Panel))).Parent = p;
            // p.Controls[p.Controls.Count - 1].Location = new Point(200, 200);
            ii = p.Controls.Count;
            if (i != ii)
            {
                if ((p.Tag.ToString().Split(',')[0] == p.Controls[p.Controls.Count - 1].Tag.ToString().Split(',')[0]) && (Exercice.exercice == "forme")) score++;
                else if (((p.Tag.ToString().Split(',')[1]) == p.Controls[p.Controls.Count - 1].Tag.ToString().Split(',')[1]) && (Exercice.exercice == "couleur")) score++;
            }
            for (int k = 0; k < p.Controls.Count; k++) p.Controls[k].Hide();

        }
        private Point MouseDownLocation;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel pictureBox1 = (Panel)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            Point[] Ptriangle = { new Point(0, pictureBox1.Height), new Point(pictureBox1.Width / 2, 0), new Point(pictureBox1.Width, pictureBox1.Height) };
            Point[] Phexagone = { new Point(pictureBox1.Width / 4, 0), new Point(3 * pictureBox1.Width / 4, 0), new Point(pictureBox1.Width, pictureBox1.Height / 2), new Point(3 * pictureBox1.Width / 4, pictureBox1.Height), new Point(pictureBox1.Width / 4, pictureBox1.Height), new Point(0, pictureBox1.Height / 2) };
            g = pictureBox1.CreateGraphics();
            int panelnb = int.Parse(pictureBox1.Name.Substring(2, 1));
            if (panelF[panelnb] == "cercle") g.FillEllipse(panelC[panelnb], new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            if (panelF[panelnb] == "carré") g.FillRectangle(panelC[panelnb], new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            if (panelF[panelnb] == "triangle") g.FillPolygon(panelC[panelnb], Ptriangle);
            if (panelF[panelnb] == "hexagone") g.FillPolygon(panelC[panelnb], Phexagone);

        }
        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel btn = (Panel)sender;
            btn.DoDragDrop(btn, DragDropEffects.Move);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pictureBox1 = (Panel)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Left = e.X + pictureBox1.Left - MouseDownLocation.X;
                pictureBox1.Top = e.Y + pictureBox1.Top - MouseDownLocation.Y;
            }
            Point[] Ptriangle = { new Point(0, pictureBox1.Height), new Point(pictureBox1.Width / 2, 0), new Point(pictureBox1.Width, pictureBox1.Height) };
            Point[] Phexagone = { new Point(pictureBox1.Width / 4, 0), new Point(3 * pictureBox1.Width / 4, 0), new Point(pictureBox1.Width, pictureBox1.Height / 2), new Point(3 * pictureBox1.Width / 4, pictureBox1.Height), new Point(pictureBox1.Width / 4, pictureBox1.Height), new Point(0, pictureBox1.Height / 2) };
            g = pictureBox1.CreateGraphics();
            int panelnb = int.Parse(pictureBox1.Name.Substring(2, 1));
            if (panelF[panelnb] == "cercle") g.FillEllipse(panelC[panelnb], new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            if (panelF[panelnb] == "carré") g.FillRectangle(panelC[panelnb], new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            if (panelF[panelnb] == "triangle") g.FillPolygon(panelC[panelnb], Ptriangle);
            if (panelF[panelnb] == "hexagone") g.FillPolygon(panelC[panelnb], Phexagone);
        }
        public static Graphics g;
        public static Brush[] panelC = new Brush[10];
        public static string[] panelF = new string[10];

        private void LabelsValeur()
        {

            if (Exercice.exercice == "forme")
            {
                l1.Text = "carré";
                pExercice.Controls.Add(l1);
                l2.Text = "cercle";
                pExercice.Controls.Add(l2);
                l3.Text = "triangle";
                pExercice.Controls.Add(l3);
                l4.Text = "hexagone";
                pExercice.Controls.Add(l4);
            }
            else if (Exercice.exercice == "couleur")
            {
                l1.Text = "Rouge";
                pExercice.Controls.Add(l1);
                l2.Text = "Jaune";
                pExercice.Controls.Add(l2);
                l3.Text = "Vert";
                pExercice.Controls.Add(l3);
                l4.Text = "Bleue";
                pExercice.Controls.Add(l4);
            }
        }
        private void NewEx()
        {
            Random n = new Random();
            int j;
            // for (int i = 0; i < pExercice.Controls.Count; i++) if (pExercice.Controls[i].Name.Substring(0, 2) == "pa") pExercice.Controls[i].Refresh();
            panel1.Controls.Clear();
            LabelsValeur();
            oknumber = false;
            for (int i = 0; i < 10; i++)
            {

                Panel pa = new Panel();
                pa.Name = "pa" + i.ToString();
                pa.Location = Exercice.panelLocation[i];
                j = n.Next(Exercice.panelColor.Length);
                Exercice.couleur = Exercice.couleurs[j];
                Exercice.color = Exercice.panelColor[j];
                j = n.Next(Exercice.formes.Length);
                Exercice.forme = Exercice.formes[j];
                j = n.Next(Exercice.tailles.Length);
                Exercice.taille = Exercice.tailles[j];
                Exercice.size = Exercice.panelSize[j];
                pa.Tag = Exercice.forme + "," + Exercice.couleur + "," + Exercice.taille;
                pa.Size = Exercice.size;
                Point[] Ptriangle = { new Point(0, pa.Height), new Point(pa.Width / 2, 0), new Point(pa.Width, pa.Height) };
                Point[] Phexagone = { new Point(pa.Width / 4, 0), new Point(3 * pa.Width / 4, 0), new Point(pa.Width, pa.Height / 2), new Point(3 * pa.Width / 4, pa.Height), new Point(pa.Width / 4, pa.Height), new Point(0, pa.Height / 2) };
                pa.BackColor = Color.Transparent;
                //pExercice.Controls.Add(pa);
                panel1.Controls.Add(pa);
                pa.Visible = true;
                panelC[i] = Exercice.color;
                panelF[i] = Exercice.forme;
                g = pa.CreateGraphics();
                if (Exercice.forme == "cercle") g.FillEllipse(Exercice.color, new Rectangle(0, 0, pa.Width, pa.Height));
                if (Exercice.forme == "carré") g.FillRectangle(Exercice.color, new Rectangle(0, 0, pa.Width, pa.Height));
                if (Exercice.forme == "triangle") g.FillPolygon(Exercice.color, Ptriangle);
                if (Exercice.forme == "hexagone") g.FillPolygon(Exercice.color, Phexagone);

                pa.Visible = true;
                pa.MouseDown += button1_MouseDown;
                pa.MouseMove += pictureBox1_MouseMove;
                Box1.DragDrop += panel_DragDrop;
                Box1.DragEnter += panel_DragEnter;
                Box2.DragDrop += panel_DragDrop;
                Box2.DragEnter += panel_DragEnter;
                Box3.DragDrop += panel_DragDrop;
                Box3.DragEnter += panel_DragEnter;
                Box4.DragDrop += panel_DragDrop;
                Box4.DragEnter += panel_DragEnter;
            }


        }

        private void Pa_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void back_Click(object sender, EventArgs e)
        {
            score = 0;
            panel1.Controls.Clear();
            Box1.Controls.Clear();
            Box2.Controls.Clear();
            Box3.Controls.Clear();
            Box4.Controls.Clear();
            pExercice.Hide();
        }

        private void next_Click(object sender, EventArgs e)
        {
            score = 0;
            NewEx();
            Box1.Controls.Clear();
            Box2.Controls.Clear();
            Box3.Controls.Clear();
            Box4.Controls.Clear();
        }

        private void pExercice_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if ((panel1.Controls.Count == 0) && (oknumber)) MessageBox.Show("score=" + score.ToString());

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pExercice.Visible == true) { pExercice.Hide(); }
           
                else
                {
                    this.Parent.Controls.Remove(this);
                }
            
        }
    }
}
