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
    public partial class FractionCours_ExCtrl : UserControl
    {
        public FractionCours_ExCtrl()
        {
            InitializeComponent();
            panel3.AllowDrop = true;
            panel4.AllowDrop = true;
            panel5.AllowDrop = true;
            panel6.AllowDrop = true;
            panel7.AllowDrop = true;
          }

        Random n = new Random();
        bool termine = false;
        List<string> frac = new List<string>();
        string fraction;
        public string[] fractions = { "1/3", "2/3", "1/5", "2/5", "3/5", "5/8", "3/8", "1/2", "5/6", "1/6", "1/4" };
       


        private void triangletable12_Click(object sender, EventArgs e)
        {

            if (int.Parse(lcolorit1.Text) < int.Parse(lcasest1.Text))
            {
                lcolorit1.Text = (int.Parse(lcolorit1.Text) + 1).ToString();
                tablefrac1.Refresh();
            }

        }

        private void Tablefrac1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tablefrac1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tablefrac1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            if (e.Row < int.Parse(lcolorit1.Text))
            {
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
            }

        }

        private void triangletable11_Click(object sender, EventArgs e)
        {

            if (int.Parse(lcolorit1.Text) > 1)
            {
                lcolorit1.Text = (int.Parse(lcolorit1.Text) - 1).ToString();
                tablefrac1.Refresh();
            }
        }

        private void Tablefrac1_CellPaint1(object sender, TableLayoutCellPaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void trianglePictureBox1_Click(object sender, EventArgs e)
        {
            if (tablefrac1.RowCount < 15)
            {
                tablefrac1.RowCount = tablefrac1.RowCount + 1;
                tablefrac1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tablefrac1.RowCount));
                for (int i = 0; i < tablefrac1.RowCount; i++)
                { tablefrac1.RowStyles[i] = (new RowStyle(SizeType.Percent, (100 / tablefrac1.RowCount))); }
                lcasest1.Text = tablefrac1.RowCount.ToString();
            }
        }

        private void trianglePictureBox21_Click(object sender, EventArgs e)
        {
            if (tablefrac1.RowCount > 2)
            {
                tablefrac1.RowCount = tablefrac1.RowCount - 1;
                tablefrac1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tablefrac1.RowCount));
                for (int i = 0; i < tablefrac1.RowCount; i++)
                { tablefrac1.RowStyles[i] = (new RowStyle(SizeType.Percent, (100 / tablefrac1.RowCount))); }
                lcasest1.Text = tablefrac1.RowCount.ToString();
            }
        }

        private void tablefrac2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row < int.Parse(lcolorit2.Text))
            {
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
            }
        }

        private void trianglePictureBox3_Click(object sender, EventArgs e)
        {
            if (int.Parse(lcolorit2.Text) < int.Parse(lcasest2.Text))
            {
                lcolorit2.Text = (int.Parse(lcolorit2.Text) + 1).ToString();
                tablefrac2.Refresh();
            }
        }

        private void trianglePictureBox23_Click(object sender, EventArgs e)
        {
            if (int.Parse(lcolorit2.Text) > 1)
            {
                lcolorit2.Text = (int.Parse(lcolorit2.Text) - 1).ToString();
                tablefrac2.Refresh();
            }
        }

        private void trianglePictureBox2_Click(object sender, EventArgs e)
        {
            if (tablefrac2.RowCount < 15)
            {
                tablefrac2.RowCount = tablefrac2.RowCount + 1;
                tablefrac2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tablefrac2.RowCount));
                for (int i = 0; i < tablefrac2.RowCount; i++)
                { tablefrac2.RowStyles[i] = (new RowStyle(SizeType.Percent, (100 / tablefrac2.RowCount))); }
                lcasest2.Text = tablefrac2.RowCount.ToString();
            }
        }

        private void trianglePictureBox22_Click(object sender, EventArgs e)
        {
            if (tablefrac2.RowCount > 2)
            {
                tablefrac2.RowCount = tablefrac2.RowCount - 1;
                tablefrac2.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tablefrac2.RowCount));
                for (int i = 0; i < tablefrac2.RowCount; i++)
                { tablefrac2.RowStyles[i] = (new RowStyle(SizeType.Percent, (100 / tablefrac2.RowCount))); }
                lcasest2.Text = tablefrac2.RowCount.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void label_MouseDown(object sender, MouseEventArgs e)
        {
            Panel l = (Panel)sender;
            l.DoDragDrop(l, DragDropEffects.Move);
        }
        void panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel p = (Panel)sender;
            ((Panel)e.Data.GetData(typeof(Panel))).Parent = p;
            pictureBox2.SendToBack();
            pictureBox3.SendToBack();
            pictureBox4.SendToBack();
            pictureBox5.SendToBack();
            frac.Remove(fraction);
            if (frac.Count == 0) termine = true;
            addpanel();
        }
        public void addpanel()
        {
            if (!termine)
            {
                if (panel3.Controls.Count == 0)
                {
                    fraction = frac[0];
                    Panel p = new Panel();
                    p.Size = (new Size(60, 55));
                    p.Location = (new Point(3, 3));
                    p.BackColor = Color.Transparent;
                    p.BackgroundImage = Projet.Properties.Resources.cadrefrac;   //(@"../../../apple/apple.jpg");
                    Label l1 = new Label();
                    l1.Location = new Point(14, 14); l1.BringToFront();
                    l1.Font = new Font("Arial", 10, FontStyle.Regular);
                    l1.Size = new Size(30, 22);
                    l1.Tag = "0";
                    panel3.Controls.Add(p);
                    p.Controls.Add(l1);
                    l1.Text = fraction;
                    p.MouseDown += label_MouseDown;
                    p.BringToFront();
                    if (frac.Count == 0) termine = true;

                }
            }

        }
        void panel_DragEnter(object sender, DragEventArgs e)
        {
            panel4.AllowDrop = true;
            panel5.AllowDrop = true;
            panel6.AllowDrop = true;
            panel7.AllowDrop = true;
            if (panel3.Controls.Count == 0) panel3.AllowDrop = true; else panel3.AllowDrop = false;
            e.Effect = DragDropEffects.Move;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int j;
            List<string> fr = new List<string>();
            fr.Clear();
            fr.AddRange(fractions);
            frac.Clear();
            frac.Capacity = 4;
            for (int i = 0; i < 4; i++)
            {
                j = n.Next(fr.Count);
                frac.Add(fr[j]);
                fr.RemoveAt(j);
            }
            addpanel();
            button2.Enabled = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void trianglePictureBox4_Click(object sender, EventArgs e)
        {
            string f;
            if (frac.Count != 0)
            {
                for (int j = 0; j < panel3.Controls[0].Controls.Count; j++) if (panel3.Controls[0].Controls[j].Tag.ToString() == "0")
                    {
                        f = panel3.Controls[0].Controls[j].Text;
                        for (int i = 0; i < frac.Count; i++)
                        {
                            if ((f == frac[i]) && (i < frac.Count - 1)) panel3.Controls[0].Controls[j].Text = frac[i + 1];
                        }
                    }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void trianglePictureBox24_Click(object sender, EventArgs e)
        {
            string f;
            try
            {
                for (int j = 0; j < panel3.Controls[0].Controls.Count; j++) if (panel3.Controls[0].Controls[j].Tag.ToString() == "0")
                    {
                        f = panel3.Controls[0].Controls[j].Text;
                        for (int i = 0; i < frac.Count; i++)
                        {
                            if ((f == frac[i]) && (i > 0)) panel3.Controls[0].Controls[j].Text = frac[i - 1];
                        }
                    }
            }
            catch (Exception) { };
        }
        bool pluspetit(string r1, string r2)
        {

            float f1 = float.Parse(r1.Split('/')[0]) / float.Parse(r1.Split('/')[1]);
            float f2 = float.Parse(r2.Split('/')[0]) / float.Parse(r2.Split('/')[1]);
            if (f1 <= f2) return true;
            else return false;
        }
        bool correct(string[] rep)
        {
            bool correct = true;
            for (int i = 0; i < rep.Length - 1; i++)
                if (pluspetit(rep[i], rep[i + 1]) == false) correct = false;
            return correct;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] rep = { panel4.Controls[0].Controls[0].Text, panel5.Controls[0].Controls[0].Text, panel6.Controls[0].Controls[0].Text, panel7.Controls[0].Controls[0].Text };
            if (termine)
            {
                if (correct(rep)) MessageBox.Show("Juste");
                else MessageBox.Show("rejouer");
                button2.Enabled = true;
                panel4.Controls.RemoveAt(0);
                panel5.Controls.RemoveAt(0);
                panel6.Controls.RemoveAt(0);
                panel7.Controls.RemoveAt(0);
                termine = false;
            }
        }

        private void Testbutton_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = true;
            helpPanel.Show();
            helpPanel.BringToFront();
        }

        private void bretour_Click(object sender, EventArgs e)
        {
            helpPanel.Hide();
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            exPanel.Visible = true; exPanel.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            if (helpPanel.Visible == true) helpPanel.Hide();
            else
            {
                if (exPanel.Visible == true) exPanel.Hide();
                else
                {
                    this.Parent.Controls.Remove(this);
                }
            }
        }
    }
}
