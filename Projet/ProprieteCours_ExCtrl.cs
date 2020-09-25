using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Data;

namespace Projet
{
    public partial class ProprietedesfigureCours_ExCtrl : UserControl
    {
      
        public ProprietedesfigureCours_ExCtrl()
        {
            InitializeComponent();
        }
        public static int counter = 0, correct = 0;
        private void BNiveau1_Click(object sender, EventArgs e)
        {
            counter = correct = 0;
           searchmaths.SearchProp.niveau = "1";
            pExercice.Show();
            NewEx();
        }
        private void Dessin()
        {

            string[] tab2 = new string[4];
            bool present = false;
            Graphics g;
            Random n = new Random();
            Point[] Ptriangle = { new Point(65, 44), new Point(38, 80), new Point(120, 80) };
            Point[] Plosange = { new Point(80, 30), new Point(40, 60), new Point(80, 90), new Point(120, 60) };
            Point[] Ppectagone = { new Point(80, 40), new Point(40, 60), new Point(60, 95), new Point(100, 95), new Point(120, 60) };
            Point[] Phexagone = { new Point(80, 40), new Point(50, 60), new Point(50, 80), new Point(80, 100), new Point(110, 80), new Point(110, 60) };
            Point[] Poctogone = { new Point(100, 40), new Point(60, 40), new Point(40, 60), new Point(40, 80), new Point(60, 100), new Point(100, 100), new Point(120, 80), new Point(120, 60) };

            if (searchmaths.SearchProp.niveau == "1")
            {

                string[] tab = { "carré", "rectangle", "triangle", "cercle", "losange" };

                do
                {
                    present = false; for (int i = 0; i < 4; i++) { tab2[i] = tab[n.Next(tab.Length)]; if (tab2[i] ==searchmaths.SearchProp.rep) present = true; }
                } while ((present == false) || (tab2[0] == tab2[1]) || (tab2[1] == tab2[2]) || (tab2[0] == tab2[2]) || (tab2[0] == tab2[3]) || (tab2[1] == tab2[3]) || (tab2[2] == tab2[3]));
            }
            else
            {
                string[] tab = { "carré", "rectangle", "triangle", "cercle", "losange", "pentagone", "hexagone", "octogone" };
                do
                {
                    present = false; for (int i = 0; i < 4; i++) { tab2[i] = tab[n.Next(tab.Length)]; if (tab2[i] ==searchmaths.SearchProp.rep) present = true; }
                } while ((present == false) || (tab2[0] == tab2[1]) || (tab2[1] == tab2[2]) || (tab2[0] == tab2[2]) || (tab2[0] == tab2[3]) || (tab2[1] == tab2[3]) || (tab2[2] == tab2[3]));
            }

            l1.Text = tab2[0];
            g = p1.CreateGraphics();
            if (l1.Text == "cercle") g.FillEllipse(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l1.Text == "carré") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l1.Text == "rectangle") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(30, 40, 100, 50));
            if (l1.Text == "triangle") g.FillPolygon(Brushes.DarkGoldenrod, Ptriangle);
            if (l1.Text == "losange") g.FillPolygon(Brushes.DarkGoldenrod, Plosange);
            if (l1.Text == "pentagone") g.FillPolygon(Brushes.DarkGoldenrod, Ppectagone);
            if (l1.Text == "hexagone") g.FillPolygon(Brushes.DarkGoldenrod, Phexagone);
            if (l1.Text == "octogone") g.FillPolygon(Brushes.DarkGoldenrod, Poctogone);

            l2.Text = tab2[1];
            g = p2.CreateGraphics();
            if (l2.Text == "cercle") g.FillEllipse(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l2.Text == "carré") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l2.Text == "rectangle") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(30, 40, 100, 50));
            if (l2.Text == "triangle") g.FillPolygon(Brushes.DarkGoldenrod, Ptriangle);
            if (l2.Text == "losange") g.FillPolygon(Brushes.DarkGoldenrod, Plosange);
            if (l2.Text == "pentagone") g.FillPolygon(Brushes.DarkGoldenrod, Ppectagone);
            if (l2.Text == "hexagone") g.FillPolygon(Brushes.DarkGoldenrod, Phexagone);
            if (l2.Text == "octogone") g.FillPolygon(Brushes.DarkGoldenrod, Poctogone);

            l3.Text = tab2[2];
            g = p3.CreateGraphics();
            if (l3.Text == "cercle") g.FillEllipse(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l3.Text == "carré") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l3.Text == "rectangle") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(30, 40, 100, 50));
            if (l3.Text == "triangle") g.FillPolygon(Brushes.DarkGoldenrod, Ptriangle);
            if (l3.Text == "losange") g.FillPolygon(Brushes.DarkGoldenrod, Plosange);
            if (l3.Text == "pentagone") g.FillPolygon(Brushes.DarkGoldenrod, Ppectagone);
            if (l3.Text == "hexagone") g.FillPolygon(Brushes.DarkGoldenrod, Phexagone);
            if (l3.Text == "octogone") g.FillPolygon(Brushes.DarkGoldenrod, Poctogone);

            l4.Text = tab2[3];
            g = p4.CreateGraphics();
            if (l4.Text == "cercle") g.FillEllipse(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l4.Text == "carré") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(60, 40, 50, 50));
            if (l4.Text == "rectangle") g.FillRectangle(Brushes.DarkGoldenrod, new Rectangle(30, 40, 100, 50));
            if (l4.Text == "triangle") g.FillPolygon(Brushes.DarkGoldenrod, Ptriangle);
            if (l4.Text == "losange") g.FillPolygon(Brushes.DarkGoldenrod, Plosange);
            if (l4.Text == "pentagone") g.FillPolygon(Brushes.DarkGoldenrod, Ppectagone);
            if (l4.Text == "hexagone") g.FillPolygon(Brushes.DarkGoldenrod, Phexagone);
            if (l4.Text == "octogone") g.FillPolygon(Brushes.DarkGoldenrod, Poctogone);

        }
        private void NewEx()
        {
            p1.BackColor = Color.DarkKhaki; p2.BackColor = Color.DarkKhaki; p3.BackColor = Color.DarkKhaki; p4.BackColor = Color.DarkKhaki;
           searchmaths.SearchProp.DonnerValeur(searchmaths.SearchProp.niveau, out searchmaths.SearchProp.rep, out searchmaths.SearchProp.question);
            lQuestion.Text = searchmaths.SearchProp.question;
            Dessin();

        }
        private void Suivant_Click(object sender, EventArgs e)
        {
            p1.Refresh(); p2.Refresh(); p3.Refresh(); p4.Refresh();
            NewEx();
        }

        private void p2_Paint(object sender, PaintEventArgs e)
        {//p.invalidate

            //e.Graphics.FillEllipse(Brushes.Red, new Rectangle(10, 10, 32, 32));
        }

        private void Niveau2_Click(object sender, EventArgs e)
        {
            correct = counter = 0;
           searchmaths.SearchProp.niveau = "2";
            pExercice.Show();
            NewEx();
        }

        private void Menugame_Click(object sender, EventArgs e)
        {
            correct = 0;
            counter = 0;
            pExercice.Hide();
            pTermineniv.Visible = false;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            counter = correct = 0;
           searchmaths.SearchProp.niveau = "2";
            pExercice.Show();
            pTermineniv.Hide();

            // clear
            NewEx();
        }

        private void p2_Enter(object sender, EventArgs e)
        {

        }

        private void p2_Leave(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {

        }

        private void back_Click_1(object sender, EventArgs e)
        {
            if (pTermineniv.Visible == true) pTermineniv.Visible = false;
            else { if (pExercice.Visible == true) pExercice.Visible = false;
                else this.Parent.Controls.Remove(this);
            }
        }

        private void p2_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            bool ok = false;
            for (int i = 0; i < p.Controls.Count; i++) if (p.Controls[i].Name.Substring(0, 1) == "l") { if (p.Controls[i].Text == searchmaths.SearchProp.rep) { ok = true; p.BackColor = Color.Green;  } }
            if (p1 != p) { p1.BackColor = Color.DimGray; l1.Text = ""; }
            if (p2 != p) { p2.BackColor = Color.DimGray; l2.Text = ""; }
            if (p3 != p) { p3.BackColor = Color.DimGray; l3.Text = ""; }
            if (p4 != p) { p4.BackColor = Color.DimGray; l4.Text = ""; }
            counter++;
            if (ok == true) correct++;
            else p.BackColor = Color.Red;
            if ((counter == 5) && (correct > 2))
            {
                pTermineniv.Show();
                pTermineniv.BringToFront();
                if (searchmaths.SearchProp.niveau == "1") { lniv1termine.Show(); Continue.Show(); Continue.Text = "Niveau2"; }
                else if (searchmaths.SearchProp.niveau == "2") { lniv1termine.Hide(); lniv2termine.Show(); Continue.Hide(); }

            }
            else Suivant.Show();
        }

    }
}
