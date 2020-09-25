using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Projet
{
    public partial class Menu : UserControl
    {
      
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        public Menu()
        {  
            InitializeComponent();
           
            frProg.Value = 35;
            logProg.Value = 20;
            geoProg.Value=15;
            if (mathProg.Value == 100) mathProg.ProgressColor = Color.Green;
        }

        private void circularProgressBar4_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }



        private void mathBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           btn.BackgroundImage = null;
            btn.Font = new Font("Comic Sans ms", 15);
            btn.Text = btn.Tag.ToString();
            
            
        }

        private void mathBtn_MouseLeave(object sender, EventArgs e)
        {
            
            mathBtn.BackgroundImage = Projet.Properties.Resources.kids_and_numbers_in_the_book_vector_180025604;
            mathBtn.Text = "";
            mathBtn.BackColor = Color.Transparent;
        }

        private void frBtn_MouseLeave(object sender, EventArgs e)
        {
            frBtn.BackgroundImage = Projet.Properties.Resources._811FYiOtBqL;
            frBtn.Text = "";
            frBtn.BackColor = Color.Transparent;
        }

        private void geoBtn_MouseLeave(object sender, EventArgs e)
        {
            geoBtn.BackgroundImage = Projet.Properties.Resources.depositphotos_167408818_stock_illustration_cartoon_basic_geometric_shapes_characters1;
            geoBtn.Text = "";
            geoBtn.BackColor = Color.Transparent;
        }

        private void logBtn_MouseLeave(object sender, EventArgs e)
        {
            logBtn.BackgroundImage = Projet.Properties.Resources._235766b43f9706e;
            logBtn.Text = "";
            logBtn.BackColor = Color.Transparent;
        }

        private void mathBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            //Form1.ActiveForm.Hide();
            Maths_Ctrl mathsCtrl = new Maths_Ctrl();
            Application.OpenForms[0].Controls.Add(mathsCtrl);
            mathsCtrl.Size = mathsCtrl.Parent.Size;
            mathsCtrl.BringToFront();
            
        }

        private void frBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            //Form1.ActiveForm.Hide();
            ((Form)this.TopLevelControl).Hide();
            FrsForm form2 = new FrsForm();
            form2.ShowDialog();
            form2 = null;
            try
            {
                ((Form)this.TopLevelControl).Show();
            }
            catch (Exception) { MessageBox.Show("done"); }
            //Form1.ActiveForm.Show();
        }

        private void geoBtn_Click(object sender, EventArgs e)
        {
            
            clickSound.Play();
            //Form1.ActiveForm.Hide();
            Geometrie_Ctrl GeoCtrl = new Geometrie_Ctrl();
            Application.OpenForms[0].Controls.Add(GeoCtrl);
            GeoCtrl.BringToFront();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            //Form1.ActiveForm.Hide();
           Logic_Ctrl logicCtrl = new Logic_Ctrl();
            Application.OpenForms[0].Controls.Add(logicCtrl);
            logicCtrl.BringToFront();
        }
    }
}
