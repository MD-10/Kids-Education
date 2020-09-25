using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Data;
using System.Media;
using System.Threading;
using System.Speech.Synthesis;
using System.Globalization;
using System.Speech.Recognition;

namespace Projet
{
    public partial class addCours_ExCtrl : UserControl
    {
       
        static Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        User user;
        int counter, correct, erreur, userlvl;
        public addCours_ExCtrl()
        {
            counter = 0; correct = 0; erreur = 0;
        user = new User(Form1.row);
        userlvl = user.addLvl;
            InitializeComponent();
            Maths.lvl = userlvl;
        }
        
        
        
        private void exBtn_Click(object sender, EventArgs e)
        {/* if (userlvl > 4) MessageBox.Show("levels completed!");*/
          /* else*/ newEx();progPanel.Show();
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            label4.Visible = true;
            lFin.Visible = true;
            NextBtn. Visible = true;
                
        }
        private void newEx()
        {
            timer1.Enabled = true;
            r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;
            if (userlvl < 3)
            {
                r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;
                lvl1_2panel.Show();
                lvlLabel.Text = "level:" + userlvl.ToString();
                errLabel.Text = "Erreur:" + erreur.ToString();
                corrLabel.Text = "correcte:" + correct.ToString();
                r1.Enabled = true; r2.Enabled = true; r3.Enabled = true; r4.Enabled = true;
                eq.Text = "";
                Maths.lvl = userlvl;//lvl du user

                searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
                b1.Text = Maths.b1text;

                op.Text = "+";

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
                lvlLabel.Text = "level:" + userlvl.ToString();
                errLabel.Text = "Erreur:" + erreur.ToString();
                corrLabel.Text = "correcte:" + correct.ToString();
                r11.Enabled = true; r22.Enabled = true; r33.Enabled = true; r44.Enabled = true;
                eq2.Text = "";


                //Maths.lvl = userlvl;//lvl du user

                searchmaths.search3valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text, out Maths.b3text);
                b11.Text = Maths.b1text;

                op1.Text = "+";

                b22.Text = Maths.b2text;

                op2.Text = "+";

                b33.Text = Maths.b3text;
                Maths.operate(Maths.b1text, Maths.b2text, Maths.b3text, Maths.operation, out Maths.rep);
                Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
                r11.Text = Maths.r1;
                r22.Text = Maths.r2;
                r33.Text = Maths.r3;
                r44.Text = Maths.r4;
            }
            r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;
        }

        private void back_Click(object sender, EventArgs e)
        {if (lvl1_2panel.Visible == true || lvl3_4panel.Visible == true) { NextBtn.Visible = false; progPanel.Visible = lvl1_2panel.Visible = lvl3_4panel.Visible=pictureBox1.Visible=pictureBox2.Visible=label4.Visible=lFin.Visible = false; }
            else
            {
                if (coursPanel.Visible == true) { coursPanel.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; soundPhrase1Pause.Visible = soundPhrase2Pause.Visible = false; }
                else { timer1.Enabled = false;this.Parent.Controls.Remove(this);  }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause };
            Label[] labels = { coursLabel1, coursLabel2 };
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
                    this.Invoke(new MethodInvoker(() => { PauseSound[i].Hide();}));
                   
                }

            }));
            PauseSound[i].Show();
            PauseSound[i].Click += pause_click;
            childThread.Start();
        }


        private void pause_click(object sender, EventArgs e)
        {


            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

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

        private void r1_Click(object sender, EventArgs e)
        {
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
                    if (counter < 10) progBtns[counter].BackColor = Color.LawnGreen;
                    counter++;
                    correct++;
                    pictureBox1.Location = new Point((pictureBox1.Location.X) + 50, pictureBox1.Location.Y);
                    r.BackColor = Color.LightGreen;
                    int i = g.Next(2);
                    if (i == 0) trueAns2Sound.Play();
                    else trueAnsSound.Play();
                    corrLabel.Text = "correcte:" + correct.ToString();
                }//lzm n3mla methode
                else
                {
                    if (counter < 10) progBtns[counter].BackColor = Color.Red;
                    erreur++;
                    if (pictureBox1.Location.X >= 150) pictureBox1.Location = new Point((pictureBox1.Location.X) - 20, pictureBox1.Location.Y);
                    r.BackColor = Color.Red; wrongAnsSound.Play();
                    errLabel.Text = "Erreur:" + erreur.ToString();
                    counter++;
                }
            newEx();
            
        }

        private void pictureBox1_LocationChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X > 440)
            {
                timer1.Enabled = false;
                if (userlvl < 4)
                {
                    userlvl++;
                    user.addLvl++;
                    InitialisateProg();
                    newEx();
                }
                MessageBox.Show("lvl complete"); lvUpSound.Play();
                
            } //save button

        }

        private void pictureBox2_LocationChanged(object sender, EventArgs e)
        {
            if (pictureBox2.Location.X >440) { timer1.Enabled = false; retrySound.Play(); MessageBox.Show("retry");  }

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            InitialisateProg();
            newEx();
        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel.Show();
        }
         private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            counter = 0;correct = 0;erreur = 0;
            pictureBox1.Location = new Point(30, 390);
            pictureBox2.Location = new Point(30, 457);
            timer1.Enabled = true;
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = new Point();
            p = pictureBox2.Location;
            pictureBox2.Location = new Point((p.X) + 1, p.Y);

        }
        

    }
}
