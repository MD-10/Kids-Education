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
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace Projet
{
    public partial class soustCours_ExCtrl : UserControl
    {
        Random g = new Random();
        public soustCours_ExCtrl()
        {
            InitializeComponent();
        }
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
int counter , correct , erreur ;
        static User user ;
        int userlvl ;
        private void exBtn_Click(object sender, EventArgs e)
        {
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.sousLvl;
            InitializeComponent();
            Maths.lvl = userlvl;
            newEx();
        }
        

        private void lvl1_2Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextBtn_Click(object sender, EventArgs e)
        { 
            if (userlvl > 4) { MessageBox.Show("no more levels"); }
            else
            {
                newEx();
            }
        }

        private void newEx()
        {
            nextBtn.Hide();
            r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;
            if (userlvl < 3)
            {
                lvl1_2panel.Show();
                lvl1_2panel.BringToFront();
                lvlLabel.Text = "level:" + userlvl.ToString();
                errLabel.Text = "Erreur:" + erreur.ToString();
                corrLabel.Text = "correcte:" + correct.ToString();
                r1.Enabled = true; r2.Enabled = true; r3.Enabled = true; r4.Enabled = true;
                eq.Text = "";
                Maths.lvl = userlvl;//lvl du user

                searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
                b1.Text = Maths.b1text;
                op.Text = "-";
                b2.Text = Maths.b2text;
                Maths.operate(Maths.b1text, Maths.b2text, Maths.operation, out Maths.rep);
                Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
                r1.Text = Maths.r1;
                r2.Text = Maths.r2;
                r3.Text = Maths.r3;
                r4.Text = Maths.r4;
            }
            else
            {
                lvl3_4panel.Show();
                lvl3_4panel.BringToFront();
                lvlLabel.Text = "level:" + userlvl.ToString();
                errLabel.Text = "Erreur:" + erreur.ToString();
                corrLabel.Text = "correcte:" + correct.ToString();
                r11.Enabled = true; r22.Enabled = true; r33.Enabled = true; r44.Enabled = true;
                eq2.Text = "";


                Maths.lvl = userlvl;//lvl du user

                searchmaths.search3valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text, out Maths.b3text);
                b11.Text = Maths.b1text;
                op1.Text = "-";
                b22.Text = Maths.b2text;
                op2.Text = "-";
                b33.Text = Maths.b3text;
                Maths.operate(Maths.b1text, Maths.b2text, Maths.b3text, Maths.operation, out Maths.rep);
                Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
                r11.Text = Maths.r1;
                r22.Text = Maths.r2;
                r33.Text = Maths.r3;
                r44.Text = Maths.r4;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (lvl1_2panel.Visible == true || lvl3_4panel.Visible == true) { progPanel.Visible = lvl1_2panel.Visible = lvl3_4panel.Visible = false; }
            else
            {
                if (coursPanel.Visible == true) { coursPanel.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; soundPhrase1Pause.Visible = false; }
                else this.Hide();
            }
            InitialisateProg();
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {

        PictureBox pbox = (PictureBox)sender;
           
            //childref = new ThreadStart(voiceSpeak);
            childThread = new Thread(new ThreadStart(() =>
            {


                if ((pbox.Name == pausedName)) { sSynth.Resume(); pausedName = ""; }
                else
                {

                    try { sSynth.Pause(); } catch (Exception) { }

                    sSynth = new SpeechSynthesizer();
                    PromptBuilder pBuilder = new PromptBuilder();
                    SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));
                    //int i = 0;
                    //  PictureBox[] soundPhrases = { soundPhrase1, soundPhrase2, soundPhrase3, soundPhrase4 };
                    //  while (soundPhrases[i].Name != pBoxName) { i++; }
                    //pbox = soundPhrases[i];
                    pBuilder.ClearContent();
                    pBuilder.AppendText(coursLabel1.Text);
                    sSynth.Speak(pBuilder);
                    sSynth.Dispose();
                    pausedName = "";
                    this.Invoke(new MethodInvoker(() => soundPhrase1Pause.Hide()));

                    //pausePicBox.Hide();


                }

            }));
           soundPhrase1Pause.Show();
           soundPhrase1Pause.Click += pause_click;
            childThread.Start();




            //try { sSynth.Pause(); }catch (Exception) { };
        }
        private void pause_click(object sender, EventArgs e)
        {

            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel.Show();
        }

        private void back_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height += 5;
            pb.Width += 5;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height -= 5;
            pb.Width -= 5;
        }

        private void r1_Click(object sender, EventArgs e)
        {
            nextBtn.Show();
          
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
    
            if (userlvl < 3)
            {
                r1.Enabled = false; r2.Enabled = false; r3.Enabled = false; r4.Enabled = false;
                eq.Text = Maths.rep;
            }
            else
            {
                r11.Enabled = false; r22.Enabled = false; r33.Enabled = false; r44.Enabled = false;
                eq2.Text = Maths.rep;

            }
            Button r = (Button)sender;
            if (r.Text == Maths.rep)
            {
                progBtns[counter].BackColor = Color.LawnGreen;
                counter++;
                correct++;
                r.BackColor = Color.LightGreen;
                int i = g.Next(2);
                if (i == 0) trueAns2Sound.Play();
                else trueAnsSound.Play();
                corrLabel.Text = "correcte:" + correct.ToString();
            }//lzm n3mla methode
            else
            {
                progBtns[counter].BackColor = Color.Red;
                erreur++;
                r.BackColor = Color.Red; wrongAnsSound.Play();
                errLabel.Text = "Erreur:" + erreur.ToString();
                counter++;
            }

            if (counter == 10)
            {
                if (correct > 5) { if (userlvl < 4) { userlvl++; user.sousLvl++; } MessageBox.Show("lvl complete"); lvUpSound.Play(); InitialisateProg(); user.addLvl++; } //save button
                else { retrySound.Play(); MessageBox.Show("retry"); InitialisateProg(); }
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
