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
    public partial class multCours_ExCtrl : UserControl
    {
        static Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int counter , correct , erreur ;
        static User user ;
        int userlvl ;
        public multCours_ExCtrl()
        {
            InitializeComponent();
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.foisLvl;
            InitializeComponent();
            Maths.lvl = userlvl;
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            newEx();
            progPanel.Show();
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause,soundPhrase3Pause,soundPhrase4Pause,soundPhrase5Pause,soundPhrase6Pause,soundPhrase7Pause };
            Label[] labels = { picBoxLabel1,coursLabel1,picBoxLabel2, coursLabel2,picBoxLabel3,coursLabel4,coursLabel5 };
            foreach (PictureBox box in PauseSound) box.Visible = false;
            int i = 0; PictureBox pbox = (PictureBox)sender;
            while (PauseSound[i].Name != pbox.Name + "Pause") { i++; }
            childThread = new Thread(new ThreadStart(() =>
            {


                if ((pbox.Name == pausedName)) { sSynth.Resume(); pausedName = ""; }
                else
                {
                    try { sSynth.Pause(); } catch (Exception) { }

                    sSynth = new SpeechSynthesizer();
                    PromptBuilder pBuilder = new PromptBuilder();
                    SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));

                    pBuilder.ClearContent();
                    pBuilder.AppendText(labels[i].Text);
                    sSynth.Speak(pBuilder);
                    sSynth.Dispose();
                    pausedName = "";
                    this.Invoke(new MethodInvoker(() => PauseSound[i].Hide()));

                }

            }));
            PauseSound[i].Show();
            PauseSound[i].Click += pause_click;
            childThread.IsBackground = true;
            childThread.Start();
        }


        private void pause_click(object sender, EventArgs e)
        {


            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }


        private void circularButton1_Click(object sender, EventArgs e)
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
            
            {
                    if (userlvl < 3)
                    {
                        r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;

                        lvl1_2panel.Show();
                    lvl1_2panel.BringToFront();
                        lvl3_4panel.Hide();
                        lvlLabel.Text = "level:" + userlvl.ToString();
                        errLabel.Text = "Erreur:" + erreur.ToString();
                        corrLabel.Text = "correcte:" + correct.ToString();
                        r1.Enabled = true; r2.Enabled = true; r3.Enabled = true; r4.Enabled = true;
                        eq.Text = "";
                        Maths.lvl = userlvl;//lvl du user

                        searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
                        b1.Text = Maths.b1text;
                        op.Text = "x";
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
                        r11.BackColor = r22.BackColor = r33.BackColor = r44.BackColor = Color.LightGray;
                        lvl1_2panel.Hide();
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
                        op1.Text = "x";
                        b22.Text = Maths.b2text;
                        op2.Text = "x";
                        b33.Text = Maths.b3text;
                        Maths.operate(Maths.b1text, Maths.b2text, Maths.b3text, Maths.operation, out Maths.rep);
                        Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
                        r11.Text = Maths.r1;
                        r22.Text = Maths.r2;
                        r33.Text = Maths.r3;
                        r44.Text = Maths.r4;
                    }
                }
            }
     
        private void back_Click(object sender, EventArgs e)
        {
            try { if (a.Visible == true) this.Controls.Remove(a); } catch (Exception) { };
            if (lvl1_2panel.Visible == true || lvl3_4panel.Visible == true) { progPanel.Visible = lvl1_2panel.Visible = lvl3_4panel.Visible = false; }
            else
            {
                PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause };
            foreach (PictureBox pb in PauseSound) { pb.Hide(); }

              if (coursPanel2.Visible == true) { coursPanel2.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { };  }
                else
                {  if (coursPanel1.Visible == true) { coursPanel1.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { };  }
                    
                     else this.Hide();
                }
                
            }
            InitialisateProg();

        }

        private void nextCours_Click(object sender, EventArgs e)
        {
            try { sSynth.Pause();sSynth.Dispose(); } catch (Exception) { };
            coursPanel2.Show();
            coursPanel2.BringToFront();
        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
            coursPanel1.BringToFront();
        }

        private void back_MouseEnter(object sender, EventArgs e)
        {

            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {

            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }
        multiplicationGame_Ctrl a;
        private void gameBtn_Click(object sender, EventArgs e)
        {
             a= new multiplicationGame_Ctrl();
            this.Parent.Controls.Add(a);
            a.Parent = Application.OpenForms[0];
            a.Location = new Point(50, 50);
            a.BringToFront();
        }
       

        private void r1_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            nextBtn.Show();
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
            if (r.Text == Maths.rep) { int i = g.Next(2); if (i == 0) trueAns2Sound.Play();
                else trueAnsSound.Play();
                progBtns[counter].BackColor= r.BackColor = Color.LawnGreen;
                counter++; correct++;
                corrLabel.Text = "correcte:" + correct.ToString(); }//lzm n3mla methode
            else {wrongAnsSound.Play();progBtns[counter].BackColor= r.BackColor=Color.Red;  errLabel.Text = "Erreur:" + erreur.ToString(); counter++; erreur++; }
            if (counter == 10)
            {
                if (correct > 5) {lvUpSound.Play(); userlvl++; user.foisLvl++; MessageBox.Show("lvl complete"); InitialisateProg();newEx(); } //save button
                else {  retrySound.Play();InitialisateProg(); MessageBox.Show("retry");newEx(); }
            }

            //newEx();

        }
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            counter = 0; correct = 0; erreur = 0;
        }
    }

}
