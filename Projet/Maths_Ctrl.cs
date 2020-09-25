using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Data;
using BusinessLayer;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class Maths_Ctrl : UserControl
    {
        public Maths_Ctrl()
        {
            InitializeComponent();
        }
      

        private void addBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            addCours_ExCtrl addCours_ExCtrl1 = new addCours_ExCtrl();
            this.Controls.Add(addCours_ExCtrl1);
            addCours_ExCtrl1.Location = new Point(75,10);
            addCours_ExCtrl1.BringToFront();
            addCours_ExCtrl1.Show();

            //addCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void sousBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            soustCours_ExCtrl soustCours_ExCtrl1 = new soustCours_ExCtrl();
            this.Controls.Add(soustCours_ExCtrl1);
            soustCours_ExCtrl1.Location = new Point(75,10);
            soustCours_ExCtrl1.BringToFront();
            soustCours_ExCtrl1.Show();

            //addCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void multBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            multCours_ExCtrl multCours_ExCtrl1 = new multCours_ExCtrl();
            this.Controls.Add(multCours_ExCtrl1);
            multCours_ExCtrl1.Location = new Point(75, 10);
            multCours_ExCtrl1.BringToFront();
            multCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            divCours_ExCtrl divCours_ExCtrl1 = new divCours_ExCtrl();
            this.Controls.Add(divCours_ExCtrl1);
            divCours_ExCtrl1.Location = new Point(75, 10);
            divCours_ExCtrl1.BringToFront();
            divCours_ExCtrl1.Show();
            Maths.operation = btn.Tag.ToString().ToLower();
        }

        private void doubleBtn_Click(object sender, EventArgs e)
        {

            DoubleMoitieCours_ExCtrl DoubleMoitieCours_ExCtr1 = new DoubleMoitieCours_ExCtrl();
            this.Controls.Add(DoubleMoitieCours_ExCtr1);
            DoubleMoitieCours_ExCtr1.Location = new Point(75, 10);
            DoubleMoitieCours_ExCtr1.BringToFront();
            DoubleMoitieCours_ExCtr1.Show();
        }

        private void heureBtn_Click(object sender, EventArgs e)
        {
            cours_Ex cours_Ex = new cours_Ex();
            this.Controls.Add(cours_Ex);
            cours_Ex.Location = new Point(75, 0);
            cours_Ex.BringToFront();
            cours_Ex.Show();
        }

        private void lettreBtn_Click(object sender, EventArgs e)
        {
            chiffreEnLettreCours_ExCtrl chiffreEnLettreCours_ExCtrl1 = new chiffreEnLettreCours_ExCtrl();
            this.Controls.Add(chiffreEnLettreCours_ExCtrl1);
            chiffreEnLettreCours_ExCtrl1.Location = new Point(75, 10);
            chiffreEnLettreCours_ExCtrl1.BringToFront();
            chiffreEnLettreCours_ExCtrl1.Show();
        }

        private void fractBtn_Click(object sender, EventArgs e)
        {
            FractionCours_ExCtrl fractionCours_ExCtr1 = new FractionCours_ExCtrl();
            this.Controls.Add(fractionCours_ExCtr1);
            fractionCours_ExCtr1.Location = new Point(75, 50);
            fractionCours_ExCtr1.BringToFront();
            fractionCours_ExCtr1.Show();
        }

        private void ordreBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CroissanDecroissantCours_ExCtrl CroissanDecroissantCours_ExCtrl1 = new CroissanDecroissantCours_ExCtrl();
            this.Controls.Add(CroissanDecroissantCours_ExCtrl1);
            CroissanDecroissantCours_ExCtrl1.Location = new Point(75, 30);
            CroissanDecroissantCours_ExCtrl1.BringToFront();
            CroissanDecroissantCours_ExCtrl1.Show();

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void PrioriteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            prioriteCours_ExCtrl prioriteCours_ExCtrl1 = new prioriteCours_ExCtrl();
            this.Controls.Add(prioriteCours_ExCtrl1);
            prioriteCours_ExCtrl1.Location = new Point(75, 40);
            prioriteCours_ExCtrl1.BringToFront();
            prioriteCours_ExCtrl1.Show();

        }

        private void compBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            compCours_ExCtrl compCours_ExCtrl1 = new compCours_ExCtrl();
            this.Controls.Add(compCours_ExCtrl1);
            compCours_ExCtrl1.Location = new Point(40, 75);
            compCours_ExCtrl1.BringToFront();
            compCours_ExCtrl1.Show();
        }

        private void Complementa10Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Complementa10Cours_ExCtrl Complementa10Cours_ExCtrl1 = new Complementa10Cours_ExCtrl();
            this.Controls.Add(Complementa10Cours_ExCtrl1);
            Complementa10Cours_ExCtrl1.Location = new Point(78, 45);
            Complementa10Cours_ExCtrl1.BringToFront();
            Complementa10Cours_ExCtrl1.Show();
        }

        private void CompteEstBonBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           CompteEstBon CompteEstBon1 = new CompteEstBon();
            this.Controls.Add(CompteEstBon1);
            CompteEstBon1.Location = new Point(75, 10);
            CompteEstBon1.BringToFront();
            CompteEstBon1.Show();
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
            Button btn = (Button)sender;
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
            btn.BackgroundImage = Projet.Properties.Resources.math1;
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
        private void addBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.Font = new Font("Comic Sans ms", 10);
            btn.Text = btn.Tag.ToString();
        }
        private void Maths_Ctrl_Load(object sender, EventArgs e)
        {

        }

        private void Maths_Ctrl_Load_1(object sender, EventArgs e)
        {

        }

        private void ordreBtn_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr61;
            btn.Text = "";

        }

        private void CompteEstBonBtn_Click_1(object sender, EventArgs e)
        {
           
        }

        private void compBtn_MouseLeave_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.comparaison;
            btn.Text = "";
        }

        private void PrioriteBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.suite1;
            btn.Text = "";
        }

        private void ordreBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr61;
            btn.Text = "";
        }

        private void CompteEstBonBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr2;
            btn.Text = "";
        }

        private void SuiteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            suiteCours_ExCtrl suite = new suiteCours_ExCtrl();
            this.Controls.Add(suite);
            suite.Location = new Point(75, 50);
            suite.BringToFront();
            suite.Show();
        }
    }
}