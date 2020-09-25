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
using System.Speech.Recognition;
using System.Globalization;
using System.Speech.Synthesis;
using System.Threading;

namespace Projet
{
    public partial class cours_Ex : UserControl
    {
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int j = 0, trueCount = 0;
        Button trueBtn;
        static Random r = new Random();
        int i = r.Next(0, 4), y = r.Next(2);
        int l = r.Next(0, 4);
        string[] s = { "11-00.jpg", "10-05.jpg", " 9-10.jpg", " 8-15.jpg", " 7-20.jpg", " 6-25.jpg", "11-55.jpg", "12-50.jpg", " 1-45.jpg", " 2-40.jpg", " 3-35.jpg", " 5-30.jpg" };

        public cours_Ex()
        {
            InitializeComponent();
        }

        private void courBtn_MouseEnter(object sender, EventArgs e)
        {
            coursArr.Show();
        }

        private void courBtn_MouseLeave(object sender, EventArgs e)
        {
            coursArr.Hide();
        }

        private void exBtn_MouseEnter(object sender, EventArgs e)
        {
            exArr.Show();
        }

        private void exBtn_MouseLeave(object sender, EventArgs e)
        {
            exArr.Hide();
        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
            
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            exPanel.Show();
            if (y == 0) newTextEx();
            else newImgEx();
        }

        private void back_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void back_Click(object sender, EventArgs e)
        {//clickSound.Play();

            if (exPanel.Visible == true) { exPanel.Visible = false; }
            else
            {
                PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause };
                foreach (PictureBox pb in PauseSound) { pb.Hide(); }

                if (coursPanel2.Visible == true) { coursPanel2.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }
                else
                {
                    if (coursPanel1.Visible == true) { coursPanel1.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }

                    else this.Hide();
                }
            }
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }
      
        private void newTextEx()
        {
            //choiceBtn1.BackColor = choiceBtn2.BackColor = choiceBtn3.BackColor = choiceBtn4.BackColor = Color.LightGray;
            nextBtn.Hide();
            hourPic.Hide();
            BtnchoicesPanel.Hide();
            labelPanel.Show();
            imgChoicesPanel.Show();

            PictureBox[] btn = { choice1Pbox, choice2Pbox, choice3Pbox, choice4Pbox };
            foreach (PictureBox b in btn)
            {
                b.Click -= wrong_click;
                b.Click -= b_click;
                b.Enabled = true;
            }
            soundPicBox.Click -= sound_click;
            int x = r.Next(0, 12), k, j;
            hourLabel.Text = s[x].Replace('-', ':').Substring(0, 5);
            //btn[l].Click -= b_click;
            //soundPicBox.Tag = (@"../../../media/") + s[x].Substring(0, 5).Trim() + ".wav";
            soundPicBox.Tag = s[x].Substring(0, 5).Trim();

            soundPicBox.Click += sound_click;
            l = r.Next(0, 4);
            btn[l].ImageLocation = (@"../../../media/") + s[x].Trim();
            btn[l].Click += b_click;
            int[] rand = new int[3];
            do
            {
                for (j = 0; j < 3; j++)
                {
                    do { k = r.Next(0, 12); } while (k == x);
                    rand[j] = k;
                }
            } while (rand[0] == rand[1] || rand[1] == rand[2] || rand[0] == rand[2]);
            j = 0; k = 0;
            while (j < 4)
            {

                if (j == l) j++;
                else
                {
                    btn[j].ImageLocation = (@"../../../media/") + s[rand[k]].Trim();
                    btn[j].Click += wrong_click;
                    j++; k++;
                }
            }
            y = r.Next(2);
        }
        private void newImgEx()
        {
            nextBtn.Hide();
            //choiceBtn1.BackColor = choiceBtn2.BackColor = choiceBtn3.BackColor = choiceBtn4.BackColor = Color.LightGray;
            labelPanel.Hide();
            imgChoicesPanel.Hide();
            hourPic.Show();
            BtnchoicesPanel.Show();
            Button[] btn = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
            PictureBox[] soundPicbox = { soundPicBox1, soundPicBox2, soundPicBox3, soundPicBox4 };
            foreach (Button b in btn)
            {
                b.Click -= wrong_click;
                b.Click -= b_click;
                b.Enabled = true;
                b.BackColor = Color.LightBlue;
            }
            foreach (PictureBox pbox in soundPicbox)
            {
                pbox.Click -= sound_click;
            }
            int x = r.Next(0, 12), k, j;
            hourPic.ImageLocation = (@"../../../media/") + s[x].Trim();
            //btn[i].Click -= b_click;
            i = r.Next(0, 4);

            btn[i].Text = s[x].Substring(0, 5).Replace('-', ':');
            btn[i].Click += b_click;
            trueBtn = btn[i];
            //soundPicbox[i].Tag = (@"../../../media/") + s[x].Substring(0, 5).Trim() + ".wav";
            soundPicbox[i].Tag = s[x].Substring(0, 5).Trim();

            soundPicbox[i].Click += sound_click;
            int[] rand = new int[3];
            do
            {
                for (j = 0; j < 3; j++)
                {
                    do { k = r.Next(0, 12); } while (k == x);
                    rand[j] = k;
                }
            } while (rand[0] == rand[1] || rand[1] == rand[2] || rand[0] == rand[2]);
            j = 0; k = 0;
            while (j < 4)
            {

                if (j == i) j++;
                else
                {
                    btn[j].Text = s[rand[k]].Substring(0, 5).Replace('-', ':');
                    btn[j].Click += wrong_click;
                    // soundPicbox[j].Tag = (@"../../../media/") + s[rand[k]].Substring(0, 5).Trim() + ".wav";
                    soundPicbox[j].Tag = s[rand[k]].Substring(0, 5).Trim();
                    soundPicbox[j].Click += sound_click;
                    j++; k++;
                }
            }
            y = r.Next(2);
        }
        private void b_click(object sender, EventArgs e)
        {
            nextBtn.Show();
            if (y == 0) trueAnsSound.Play();
            else trueAns2Sound.Play();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[j].BackColor = Color.LawnGreen;
            j++;
            trueCount++;
            try
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.LightGreen;
                Button[] buttons = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
                foreach (Button butt in buttons) { butt.Enabled = false; }
            }
            catch (Exception)
            {
                PictureBox[] btn = { choice1Pbox, choice2Pbox, choice3Pbox, choice4Pbox };
                foreach (PictureBox butt in btn) { butt.Enabled = false; }
                ///* MessageBox.Show("WRONG ANSWER!")*/;
            }
            if ((j == 10) && (trueCount >= 6))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {    InitialisateProg();
                     if (y == 0) newImgEx();
                    else newTextEx();
                   
                }
            }
            else
            {
                if ((j == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    if (y == 0) newImgEx();
                    else newTextEx();
                   
                }
                //else
                //{
                //    if (y == 0) newImgEx();
                //    else newTextEx();
                //}
            }
            //try
            //{
            //    Button btn = (Button)sender;
            //    btn.BackColor = Color.LightGreen;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("TRUE ANSWER!");
            //}


        }
        private void wrong_click(object sender, EventArgs e)
        {
            nextBtn.Show();
            wrongAnsSound.Play();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[j].BackColor = Color.Red;
            j++;
            try
            {
                Button btn = (Button)sender;
                btn.BackColor = Color.Red;
                Button[] buttons = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
                foreach (Button butt in buttons) { butt.Enabled = false; }
                trueBtn.BackColor = Color.LawnGreen;
            }
            catch (Exception)
            {
                PictureBox[] btn = { choice1Pbox, choice2Pbox, choice3Pbox, choice4Pbox };
                foreach (PictureBox butt in btn) { butt.Enabled = false; }
                //MessageBox.Show("WRONG ANSWER!");
            }
            if ((j == 10) && (trueCount >= 6))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {InitialisateProg();
                     if (y == 0) newImgEx();
                    else newTextEx();
                    
                }
            }
            else
            {
                if ((j == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    if (y == 0) newImgEx();
                    else newTextEx();
                    
                }
                //else
                //{
                //    if (y == 0) newImgEx();
                //    else newTextEx();
                //}
            }


        }

        private void choice1Pbox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);

        }

        private void choice1Pbox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
            clickSound.Play();
            if (y == 0) newTextEx();
            else newImgEx();
        }

        private void nextCours_Click(object sender, EventArgs e)
        {
            try { sSynth1.Pause(); sSynth1.Dispose(); } catch (Exception) { };
            coursPanel2.Show();
            coursPanel2.BringToFront();
        }
        SpeechSynthesizer sSynth1;
        private void sound_click(object sender, EventArgs e)
        {
            sSynth1 = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();
            SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));
            PictureBox pbox = (PictureBox)sender;
            string[] ss = pbox.Tag.ToString().Split('-');
            pBuilder.ClearContent();
            string min = ss[1].Trim(), heure = ss[0].Trim(), textToAppend = "";




            if (min == "00") textToAppend = heure;
            else
            {
                if (min == "15") textToAppend = heure + " et quart";
                else
                {
                    if (min == "30") textToAppend = heure + " et demi";
                    else
                    {
                        if (min == "45") textToAppend = (int.Parse(heure) + 1).ToString() + " moins le quart";
                        else
                        {
                            if (min == "50") textToAppend = (int.Parse(heure) + 1).ToString() + " moins 10";
                            else
                            {
                                if (min == "5") textToAppend = (int.Parse(heure) + 1).ToString() + " moins 5";
                                else textToAppend = heure + " heures " + min + " minutes";

                            }
                        }
                    }

                }
            }
            pBuilder.AppendText(textToAppend);
            sSynth1.Speak(pBuilder);
        }
        //try
        //{
        //    PictureBox pbox = (PictureBox)sender;
        //    SoundPlayer sound = new SoundPlayer(pbox.Tag.ToString().Trim());
        //    sound.Play();
        //}
        //catch (Exception ex) { MessageBox.Show(ex.ToString()); };


        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            j = 0; trueCount = 0;
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause};
            Label[] labels = { coursLabel, coursLabel1, CoursLabel2, coursLabel3, coursLabel4, coursLabel5 };
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
            childThread.Start();
        }


        private void pause_click(object sender, EventArgs e)
        {


            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }
    }
}
