using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;



namespace Projet
{
    public partial class mathsForm1 : Form
    {
        SoundPlayer mouseEnterSound = new SoundPlayer(@"../../../media/woosh.wav");
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        public mathsForm1()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            DialogResult r;
            r = MessageBox.Show("Voulez-vous quitter?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) Application.ExitThread();
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            
            this.Close();
            Form1.ActiveForm.Show();

        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterSound.Play();
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }

      
        private void mathsForm1_Load(object sender, EventArgs e)
        {

        }
        private void addBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.Font = new Font("Comic Sans ms", 10);
            btn.Text = btn.Tag.ToString();
        }


        private void divBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            divCours_ExCtrl divCours_ExCtrl1 = new divCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(divCours_ExCtrl1);
            divCours_ExCtrl1.Location = new Point(100, 100);
            divCours_ExCtrl1.BringToFront();
            divCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            addCours_ExCtrl addCours_ExCtrl1 = new addCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(addCours_ExCtrl1);
            addCours_ExCtrl1.Location = new Point(50, 100);
            addCours_ExCtrl1.BringToFront();
            addCours_ExCtrl1.Show();

           //addCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
            
        }

        private void sousBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            soustCours_ExCtrl soustCours_ExCtrl1 = new soustCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(soustCours_ExCtrl1);
            soustCours_ExCtrl1.Location = new Point(100, 100);
            soustCours_ExCtrl1.BringToFront();
            soustCours_ExCtrl1.Show();

            //addCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void heureBtn_Click(object sender, EventArgs e)
        {
            cours_Ex cours_Ex=new cours_Ex();
            mathsForm1.ActiveForm.Controls.Add(cours_Ex);
            cours_Ex.Location = new Point(50, 50);
            cours_Ex.BringToFront();
            cours_Ex.Show();
            //heureExCtrl1.Show();
        }

        private void PrioriteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //prioriteCours_ExCtrl1.Show();
        }

        private void compBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //compCours_ExCtrl1.Show();
        }

        private void lettreBtn_Click(object sender, EventArgs e)
        {
            chiffreEnLettreCours_ExCtrl chiffreEnLettreCours_ExCtrl1 = new chiffreEnLettreCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(chiffreEnLettreCours_ExCtrl1);
            chiffreEnLettreCours_ExCtrl1.Location = new Point(50, 100);
            chiffreEnLettreCours_ExCtrl1.BringToFront();
            chiffreEnLettreCours_ExCtrl1.Show();
        }

        private void multBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            multCours_ExCtrl multCours_ExCtrl1 = new multCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(multCours_ExCtrl1);
            multCours_ExCtrl1.Location = new Point(50, 100);
            multCours_ExCtrl1.BringToFront();
            multCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void doubleBtn_Click(object sender, EventArgs e)
        {
            DoubleMoitieCours_ExCtrl DoubleMoitieCours_ExCtr1 = new DoubleMoitieCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(DoubleMoitieCours_ExCtr1);
            DoubleMoitieCours_ExCtr1.Location = new Point(50, 100);
            DoubleMoitieCours_ExCtr1.BringToFront();
            DoubleMoitieCours_ExCtr1.Show();
        }

        private void fractBtn_Click(object sender, EventArgs e)
        {
            FractionCours_ExCtrl fractionCours_ExCtr1 = new FractionCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(fractionCours_ExCtr1);
            fractionCours_ExCtr1.Location = new Point(50, 100);
            fractionCours_ExCtr1.BringToFront();
            fractionCours_ExCtr1.Show();
        }

        private void addBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.addition_symbol_clip_art_23;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void sousBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn =(Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.subtraction_minus_sign;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void multBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.TN_girl_holding_multiplication_sign;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void divBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.TN_girl_holding_division_math_sign;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void doubleBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.double_moitie1;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void compBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.comparaison;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void suiteBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.suite;
            btn.Text = "";
            //btn.BackColor = Color.Transparent;
        }

        private void heureBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.heure;
            btn.Text = "";
            //btn.BackColor = Color.Transparent;
        }

        private void lettreBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.chiffre_lettre;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void fractBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fraction;
            btn.Text = "";
            
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //heureExCtrl1.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void menuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.ActiveForm.Show();
        }

        private void soustCours_ExCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void soustCours_ExCtrl1_Load_1(object sender, EventArgs e)
        {

        }

        private void divCours_ExCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void SuiteBtn_Click(object sender, EventArgs e)
        {
           
            //suiteCours_ExCtrl1.Show();
        }

        private void complementa10Btn_Click(object sender, EventArgs e)
        {
            //complementa10Cours_ExCtrl1.Show();
        }

        private void fractionCours_ExCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void CroissantBtn_Click(object sender, EventArgs e)
        {
            //croissanDecroissantCours_ExCtrl1.Show();
        }

        private void doubleMoitieCours_ExCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void compCours_ExCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void ordreBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CroissanDecroissantCours_ExCtrl CroissanDecroissantCours_ExCtrl1 = new CroissanDecroissantCours_ExCtrl();
            mathsForm1.ActiveForm.Controls.Add(CroissanDecroissantCours_ExCtrl1);
            CroissanDecroissantCours_ExCtrl1.Location = new Point(50, 100);
            CroissanDecroissantCours_ExCtrl1.BringToFront();
            CroissanDecroissantCours_ExCtrl1.Show();
  
        }
    }
}
