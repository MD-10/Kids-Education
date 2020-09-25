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
    public partial class Geometrie_Ctrl : UserControl
    {
        public Geometrie_Ctrl()
        {
            InitializeComponent();
        }

        private void anglesBtn_Click(object sender, EventArgs e)
        {
            AngleCours_ExCtrl anglesctrl = new AngleCours_ExCtrl();
            this.Controls.Add(anglesctrl);
            anglesctrl.Location = new Point(100, 60);
            anglesctrl.BringToFront();
        }

        private void aireRectangleBtn_Click(object sender, EventArgs e)
        {
            AireRectangleCours_ExCtrl airerecctrl = new AireRectangleCours_ExCtrl();
            this.Controls.Add(airerecctrl);
            airerecctrl.Location = new Point(100, 60);
            airerecctrl.BringToFront();
        }

        private void AiredisqueBtn_Click(object sender, EventArgs e)
        {
            AireDisqueCours_ExCtrl airedisque = new AireDisqueCours_ExCtrl();
            this.Controls.Add(airedisque);
            airedisque.Location = new Point(170, 70);
            airedisque.BringToFront();
        }

        private void PerimetreDisqueBtn_Click(object sender, EventArgs e)
        {
             PerimetreCours_ExCtrl perimetredisque= new PerimetreCours_ExCtrl();
            this.Controls.Add(perimetredisque);
            perimetredisque.Location = new Point(170, 80);
            perimetredisque.BringToFront();
        }

        private void TriBtn_Click(object sender, EventArgs e)
        {
            TriCours_ExCtrl Trigeo = new TriCours_ExCtrl();
            this.Controls.Add(Trigeo);
            Trigeo.Location = new Point(100, 50);
            Trigeo.BringToFront();
        }

        private void ProprietesBtn_Click(object sender, EventArgs e)
        {
          ProprietedesfigureCours_ExCtrl proprietegeo = new ProprietedesfigureCours_ExCtrl();
            this.Controls.Add(proprietegeo);
            proprietegeo.Location = new Point(100, 90);
            proprietegeo.BringToFront();
        }

        private void anglesBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.Font = new Font("Comic Sans ms", 10);
            btn.Text = btn.Tag.ToString();
        }

        private void anglesBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.angle1;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void aireRectangleBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.rectangle;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void AiredisqueBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.disue;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void ProprietesBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.geometric_shapes_funny_monsters_cartoon_vector_137275241;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void PerimetreDisqueBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.geometry;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void TriBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.depositphotos_167408818_stock_illustration_cartoon_basic_geometric_shapes_characters1;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }
    }
}
