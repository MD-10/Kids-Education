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
    public partial class compCours_ExCtrl : UserControl
    {
        Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvlUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        int userlvl; User user;
        public compCours_ExCtrl()
        {
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.comparaisonLvl;
            InitializeComponent();
            Maths.lvl = userlvl;
            panelcomparaison.Show();
            newEx();
        }
        
        
        int counter = 0, correct = 0, erreur = 0;
        //int userlvl = 1;//methode

       
        private void newEx()
        {
            nextBtn.Hide();
            label4.Text = "?";
            panelcomparaison.Show();
            lvlLabel.Text = "level:" + userlvl.ToString();
            errLabel.Text = "Erreur:" + erreur.ToString();
            corrLabel.Text = "correcte:" + correct.ToString();
            bplusgrand.Enabled = true; bpluspetit.Enabled = true;
            Maths.lvl = userlvl;
            Maths.comparaison(Maths.lvl, out Maths.bcomparaison1, out Maths.bcomparaison2);
            bcomparaison1.Text = Maths.bcomparaison1;
            bcomparaison2.Text = Maths.bcomparaison2;
        }

        private void compCours_ExCtrl_Load(object sender, EventArgs e)
        {

        }

        private void bplusgrand_Click(object sender, EventArgs e)
        // clickSound.Play();
        {
            nextBtn.Show();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };

            bplusgrand.Enabled = false;
            bpluspetit.Enabled = false;
            Label r = (Label)sender;
            if (r.Text == Maths.rep)
            {
                int k = g.Next(2);
                if (k == 1) { trueAns2Sound.Play(); } else trueAnsSound.Play();
                progBtns[counter].BackColor = Color.LawnGreen; counter++;
                correct++;
                label4.Text = r.Text;
                //trueAnsSound.Play();
                //MessageBox.Show("bravo");
                corrLabel.Text = "correcte:" + correct.ToString();
            }//lzm n3mla methode
            else { progBtns[counter].BackColor = Color.Red; erreur++; label4.Text = r.Text; wrongAnsSound.Play();
                //MessageBox.Show("reponse pas correcte");
                errLabel.Text = "Erreur:" + erreur.ToString(); counter++; }
            if (counter == 10)
            { if (userlvl > 3) MessageBox.Show("no more levels");
                else
                {
                    if (correct > 5)
                    {
                        lvlUpSound.Play(); userlvl++; user.comparaisonLvl++; lvlUpSound.Play(); MessageBox.Show("lvl complete");
                        counter = 0; correct = 0; erreur = 0; 
                    } //save button
                    else
                    {
                        retrySound.Play();
                         retrySound.Play();
                        MessageBox.Show("retry");
                        newEx();
                        InitialisateProg();
                    }
                }
                //newEx();
            }
        }

        private void circularButton1_Click(object sender, EventArgs e)
        { 
            if (userlvl > 4) MessageBox.Show("levels completed!");
            else newEx();
        }

        private void bpluspetit_MouseEnter(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            pb.Font = new Font("Comic Sans MS", 35f);

        }

        private void bpluspetit_MouseLeave(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            pb.Font = new Font("Comic Sans MS", 28.2f);
            
            
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (userlvl > 4) MessageBox.Show("levels completed!");
            else newEx();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void courBtn_Click(object sender, EventArgs e)
        {

        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            newEx();

        }
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            counter = 0; correct = 0; erreur = 0;
        }


    }
}
