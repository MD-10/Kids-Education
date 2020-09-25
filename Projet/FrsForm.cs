using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class FrsForm : Form
    {
                SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));

        public FrsForm()
        {
            InitializeComponent();
        }

        private void confBtn_Click(object sender, EventArgs e)
        {
            confOrthHomoPanel.Show();
        }

        private void confBtn_MouseEnter(object sender, EventArgs e)
        {
           
                Button btn = (Button)sender;
                btn.BackgroundImage = null;
                btn.Font = new Font("Comic Sans ms", 10);
                btn.Text = btn.Tag.ToString();
           
            

                //Button btn = (Button)sender;
                //btn.BackgroundImage = Projet.Properties.Resources.fr1;
                //btn.Text = "";
                //btn.BackColor = Color.Transparent;
            
        }

        private void confBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr1;
            btn.Text = "";
            btn.BackColor = Color.Transparent;

        }

        private void orthBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr2;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void homoBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr3;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void conjBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr4;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void dicteeBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr5;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void lectureBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources.fr1;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }
        int count = 0, trueCount = 0;
        string lettre; string[] choix;
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer WrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        SoundPlayer mouseEnterSound = new SoundPlayer(@"../../../media/woosh.wav");
        string mot;
        private void b_pBtn_Click(object sender, EventArgs e)
        {clickSound.Play();
            exPanel.Show();
            Button btn = (Button)sender;
            choix = btn.Tag.ToString().Split(',');
            NewEx();

            //Button btn = (Button)sender;
            //string lettre, mot;
            //string[] choix = btn.Tag.ToString().Split(',');
            //choice1.Text = choix[0].ToLower();
            //choice2.Text = choix[1].ToLower();
            //Random r = new Random();
            //lettre = btn.Tag.ToString().Split(',')[r.Next(2)];
            //mot = SearchFrs.ConfusionDeSonMot(lettre);
            //motLabel.Text = mot.Replace(lettre.ToLower(), "__");

        }

        private void confusionBtn_Click(object sender, EventArgs e)
        {
            confOrthHomoPanel.Show();
            confusionBtnsPanel.Show();
            // menuPanel.Hide();
        }

        private void homoBtn_Click(object sender, EventArgs e)
        {
            confOrthHomoPanel.Show();
            homoBtnsPanel.Show(); //menuPanel.Hide();
        }

        private void orthBtn_Click(object sender, EventArgs e)
        {
            confOrthHomoPanel.Show();
            orthBtnsPanel.Show(); //menuPanel.Hide();
        }
        private void NewEx()
        {

            nextBtn.Hide();
            choice1.Enabled = choice2.Enabled = true;
            
            choice1.Text = choix[0].ToLower();
            if (choix[1].ToLower() == "gg")
            {
                choice2.Text = "g";
            }
            else choice2.Text = choix[1].ToLower();
            Random r = new Random();
            lettre = choix[r.Next(2)];
            
            mot = SearchFrs.ConfusionDeSonMot(lettre);
            
            try
            {
                motPicBox.ImageLocation = @"../../../media/" + mot + ".png";
            }
            catch (Exception) { motPicBox.Image = null; };
            if (lettre.ToLower() == "gg") lettre = "g";
            //mot=char.ToUpperInvariant(mot[0]) + mot.Substring(1);// make first letter upper case
            //Char.ToLowerInvariant(name[0]) + name.Substring(1)
            string s = mot.Replace(lettre.ToLower(), "__");
            motLabel.Text = char.ToUpperInvariant(s[0]) + s.Substring(1);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            NewEx();
        }

        private void choice1_Click(object sender, EventArgs e)
        {
            string s = motLabel.Text.Replace("__", lettre.ToLower());
            motLabel.Text = char.ToUpperInvariant(s[0]) + s.Substring(1);
            Label l = (Label)sender;
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            nextBtn.Show();
            if (l.Text == lettre) { trueAnsSound.Play(); progBtns[count].BackColor = Color.LawnGreen; count++; trueCount++; }
            else { WrongAnsSound.Play(); progBtns[count].BackColor = Color.Red; count++; }
            //choice1.Enabled = choice2.Enabled = false;
            CountEquals10();
        }

        public void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button b in progBtns)
            {
                b.BackColor = Color.RoyalBlue;
            }
            trueCount = count = 0;
        }

        private void choice2_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterSound.Play();
            Label pb = (Label)sender;
            pb.Font = new Font("Comic Sans MS", 18f);
        }

        private void choice2_MouseLeave(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            pb.Font = new Font("Comic Sans MS", 16.2f);
        }

        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterSound.Play();
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            InitialisateProg();
          
            
                if (exPanel.Visible == true) exPanel.Hide();
                else
                {

                    //menuPanel.Show();
                    if ((orthBtnsPanel.Visible == true) || (homoBtnsPanel.Visible == true) || (confOrthHomoPanel.Visible == true))
                        confOrthHomoPanel.Visible = orthBtnsPanel.Visible = homoBtnsPanel.Visible = confOrthHomoPanel.Visible = false;
                    else
                    {
                    clickSound.Play();
                    DialogResult r;
                    r = MessageBox.Show("Voulez-vous quitter le français?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        this.Close();
                        Form1.ActiveForm.Show();
                    }
                    }

                }
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            DialogResult r;
            r = MessageBox.Show("Voulez-vous quitter?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) Application.Exit();
        }

        private void FrsForm_Load(object sender, EventArgs e)
        {

        }

        private void motSoundPicBox_Click(object sender, EventArgs e)
        {
            pBuilder.ClearContent();
            pBuilder.AppendText(mot);
            sSynth.Speak(pBuilder);
        }

        private void conjBtn_Click(object sender, EventArgs e)
        {
            ConjCours_ExCtrl ConjCours_ExCtrl1 = new ConjCours_ExCtrl();
            FrsForm.ActiveForm.Controls.Add(ConjCours_ExCtrl1);
            ConjCours_ExCtrl1.Location = new Point(40, 60);
            ConjCours_ExCtrl1.BringToFront();
            ConjCours_ExCtrl1.Show();
        }

        private void lectureBtn_Click(object sender, EventArgs e)
        {
            LectureCours_ExCtrl LectureCours_ExCtrl1 = new LectureCours_ExCtrl();
            FrsForm.ActiveForm.Controls.Add(LectureCours_ExCtrl1);
            LectureCours_ExCtrl1.Location = new Point(80, 60);
            LectureCours_ExCtrl1.BringToFront();
            LectureCours_ExCtrl1.Show();
        }
        spaceInvader ConfJeux;
        private void button1_Click(object sender, EventArgs e)
        {
           
             ConfJeux= new spaceInvader();
            this.Controls.Add(ConfJeux);
            ConfJeux.Parent = Application.OpenForms[1];
            ConfJeux.Location = new Point(50, 50);
            ConfJeux.BringToFront();
            
            ConfJeux.Show();
        }

        private void dicteeBtn_Click(object sender, EventArgs e)
        {

            dicteeExCtrl dicteeCtrl = new dicteeExCtrl();
            this.Controls.Add(dicteeCtrl);
            dicteeCtrl.Parent = Application.OpenForms[1];
            dicteeCtrl.Location = new Point(50, 80);
            dicteeCtrl.BringToFront();
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {

            dictee2 dicteeCtrl = new dictee2();
            this.Controls.Add(dicteeCtrl);
            dicteeCtrl.Parent = Application.OpenForms[1];
            dicteeCtrl.Location = new Point(100, 100);
            dicteeCtrl.BringToFront();
        }

        private void circularButton1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources._811FYiOtBqL;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }

        private void CountEquals10()
        {
            if ((count == 10) && (trueCount >= 6))
            {InitialisateProg(); 
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) exPanel.Hide();
                else
                {
                    NewEx();


                }
            }
            else
            {
                if ((count == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    NewEx();
                }

                else
                {
                    choice1.Enabled = choice2.Enabled = false;
                }
            }
        }
    }
}
