using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using BusinessLayer;
using System.Media;

namespace Projet
{
    public partial class suiteCours_ExCtrl : UserControl
    {
        static Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");

        int counter = 0, correct = 0, erreur = 0;
        static User user = new User(Form1.row);
        int userlvl = user.suiteLvl;
        private void newEx()
        {
            suitechoix1.BackColor = suitechoix2.BackColor = suitechoix3.BackColor = suitechoix4.BackColor = Color.AliceBlue;
            exPanel.Show();
            lvlLabel.Text = "level:" + userlvl.ToString();
            errLabel.Text = "Erreur:" + erreur.ToString();
            corrLabel.Text = "correcte:" + correct.ToString();
            suitechoix1.Enabled = true; suitechoix2.Enabled = true; suitechoix3.Enabled = true; suitechoix4.Enabled = true;
            Random m = new Random();
            Maths.lvl = userlvl;
            int j;
            Maths.suite(Maths.lvl, out Maths.bsuite1, out Maths.bsuite2, out Maths.bsuite3, out Maths.bsuite4, out Maths.bsuite5);
            j = m.Next(1, 5);
            switch (j)
            {
                case 1:
                    {
                        bsuite2.Text = Maths.bsuite2;
                        bsuite3.Text = Maths.bsuite3;
                        bsuite4.Text = Maths.bsuite4;
                        bsuite5.Text = Maths.bsuite5;
                        Maths.rep = Maths.bsuite1; bsuite1.Text = "?";
                    }
                    break;
                case 2:
                    {
                        bsuite1.Text = Maths.bsuite1;
                        bsuite3.Text = Maths.bsuite3;
                        bsuite4.Text = Maths.bsuite4;
                        bsuite5.Text = Maths.bsuite5;
                        Maths.rep = Maths.bsuite2; bsuite2.Text = "?";
                    }
                    break;
                case 3:
                    {
                        bsuite2.Text = Maths.bsuite2;
                        bsuite1.Text = Maths.bsuite1;
                        bsuite4.Text = Maths.bsuite4;
                        bsuite5.Text = Maths.bsuite5;
                        Maths.rep = Maths.bsuite3; bsuite3.Text = "?";
                    }
                    break;
                case 4:
                    {
                        bsuite2.Text = Maths.bsuite2;
                        bsuite3.Text = Maths.bsuite3;
                        bsuite1.Text = Maths.bsuite1;
                        bsuite5.Text = Maths.bsuite5;
                        Maths.rep = Maths.bsuite4; bsuite4.Text = "?";
                    }
                    break;
                case 5:
                    {
                        bsuite2.Text = Maths.bsuite2;
                        bsuite3.Text = Maths.bsuite3;
                        bsuite4.Text = Maths.bsuite4;
                        bsuite1.Text = Maths.bsuite1;
                        Maths.rep = Maths.bsuite5; bsuite5.Text = "?";
                    }
                    break;
            }
            Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
            suitechoix1.Text = Maths.r1;
            suitechoix2.Text = Maths.r2;
            suitechoix3.Text = Maths.r3;
            suitechoix4.Text = Maths.r4;
        }
        public suiteCours_ExCtrl()
        {
            InitializeComponent();
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.suiteLvl;
            Maths.lvl = userlvl;
            exPanel.Show();
            newEx();
        }

       

        private void exBtn_Click(object sender, EventArgs e)
        {
           
            newEx();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            nextBtn.Hide();
            newEx();
        }



        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this) ;
        }

        private void suitechoix1_Click(object sender, EventArgs e)
        {
            nextBtn.Show();
            suitechoix1.Enabled = false; suitechoix2.Enabled = false; suitechoix3.Enabled = false; suitechoix4.Enabled = false;
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            Button r = (Button)sender;
            if (r.Text == Maths.rep)
            {int i = g.Next(2);
                if (i == 0) trueAns2Sound.Play();
                else trueAnsSound.Play();
                progBtns[counter].BackColor = r.BackColor = Color.LawnGreen;
                counter++;
                correct++;
                corrLabel.Text = "correcte:" + correct.ToString();
            }//lzm n3mla methode
            else
            {  wrongAnsSound.Play();
                progBtns[counter].BackColor=r.BackColor  = Color.Red;
                erreur++;
                errLabel.Text = "Erreur:" + erreur.ToString();
                counter++;
            }

            if (counter == 10)
            {
                if (correct > 5) { userlvl++; user.suiteLvl++;MessageBox.Show("lvl complete"); lvUpSound.Play(); InitialisateProg();newEx();  } //save button
                else { retrySound.Play(); MessageBox.Show("retry"); InitialisateProg();newEx(); }
            }
        }
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            counter = 0; correct = 0; erreur = 0;
        }
    }
}
