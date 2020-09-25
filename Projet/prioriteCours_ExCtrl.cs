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
    public partial class prioriteCours_ExCtrl : UserControl
    {
        Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");

        int counter , correct , erreur;
        static User user;
        int userlvl ;
        private void newEx()
        {
            nextBtn.Hide();
            panelpriorite.BringToFront();
            bprioritechoix1.BackColor = bprioritechoix2.BackColor = bprioritechoix3.BackColor = bprioritechoix4.BackColor = Color.LightGray;
            panelpriorite.Show();
            etapesPanel.Hide();
            etapesPanel.Controls.Clear();
            lvlLabel.Text = "level:" + userlvl.ToString();
            erreurLabel.Text = "Erreur:" + erreur.ToString();
            correctLabel.Text = "correcte:" + correct.ToString();
            showetapes.Visible = false;
            bprioritechoix1.Enabled = true; bprioritechoix2.Enabled = true; bprioritechoix3.Enabled = true; bprioritechoix4.Enabled = true;
            Maths.lvl = userlvl;
            Maths.priorite();
            Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
            lexpression.Text = Maths.expression;
            bprioritechoix1.Text = Maths.r1;
            bprioritechoix2.Text = Maths.r2;
            bprioritechoix3.Text = Maths.r3;
            bprioritechoix4.Text = Maths.r4;
        }
        public prioriteCours_ExCtrl()
        {
            InitializeComponent();
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.prioriteLvl;
            Maths.lvl = userlvl;
            newEx();
        }
       
        private void prioriteCours_ExCtrl_Load(object sender, EventArgs e)
        {

        }
        private void exBtn_Click(object sender, EventArgs e)
        {
       
            newEx();
        }
      
        private void nextBtn_Click(object sender, EventArgs e)
        {
            newEx();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void bprioritechoix1_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            nextBtn.Show();
            showetapes.Visible = true;
            bprioritechoix1.Enabled = false; bprioritechoix2.Enabled = false; bprioritechoix3.Enabled = false; bprioritechoix4.Enabled = false;
            Button r = (Button)sender;
            if (r.Text == Maths.rep) {
                int i = g.Next(2);
                if (i == 0) trueAnsSound.Play();
                else trueAns2Sound.Play();
                progBtns[counter].BackColor = Color.LawnGreen;
                r.BackColor = Color.LawnGreen;
                counter++; correct++;
                correctLabel.Text = "correcte:" + correct.ToString(); }//lzm n3mla methode
            else
            {
                wrongAnsSound.Play();
                progBtns[counter].BackColor = Color.Red;
                r.BackColor = Color.Red;
                erreur++;// MessageBox.Show("reponse pas correcte");
                erreurLabel.Text = "Erreur:" + erreur.ToString(); counter++; }
            if (counter == 10)
            {
                if (correct > 5) { lvUpSound.Play();userlvl++; user.prioriteLvl++; MessageBox.Show("lvl complete"); InitialisateProg();newEx(); } //save button
                else {retrySound.Play();  MessageBox.Show("retry");InitialisateProg();newEx(); }
            }

            //newEx();//button 
        }

        private void courBtn_Click(object sender, EventArgs e)
        {

        }

        private void showetapes_Click(object sender, EventArgs e)
        {
            etapesPanel.Show();
            etapesPanel.BringToFront();
            for (int i = 0; i < Maths.etapes.Length + 1; i++)
            {
                Label l = new Label();
                if (i == 0) {l.Text = (i + 1).ToString() + ") " + Maths.expression.ToString(); }
                else { l.Text = (i + 1).ToString() + ")  " + Maths.etapes[i - 1].ToString(); }
                l.Size = new Size(200, 30);
                l.BackColor = etapesPanel.BackColor;
                l.Location = new Point(43, 35 + 30 * i);
                l.Font = new Font("Comic Sans MS", 15);
                etapesPanel.Controls.Add(l);
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
