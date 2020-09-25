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
using Data;
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace Projet
{
    public partial class chiffreEnLettreCours_ExCtrl : UserControl
    {
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        public chiffreEnLettreCours_ExCtrl()
        {
            InitializeComponent();
        }
        static Random r = new Random();
        Button trueBtn;int userlvl;
        int y = r.Next(2), i = r.Next(0, 4), count = 0, trueCount = 0;
        static string s = searchmaths.ChiffreEnLettre();
        string[] t = s.Split(',');
        private void button1_Click(object sender, EventArgs e)
        {
            nextBtn.Hide();
            exPanel.Visible = true;
            if (y == 0)// the label is in letters
            {
                lettre_en_chiffre();
            }
            else
            {
                if (y == 1)
                {
                    chiffres_en_lettres();
                }
            }
            //y = r.Next(2);
            //i = r.Next(0, 101);
            //if (y == 0)//the label is in letters
            //{
            //    lettreLabel.Text = t[i];
            //}
            //else { lettreLabel.Text = i.ToString(); }

        }
        public void chiffres_en_lettres()
        {
           
            int j, k;
            Button[] btn = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
            foreach (Button b in btn)
            {
                b.Click -= b_click;
                b.Click -= wrong_click;
                b.BackColor = Color.LightGray;
                b.Enabled = true;
            }
            int x = r.Next(0, 101);
            i = r.Next(0, 4);
            trueBtn = btn[i];
            lettreLabel.Text = x.ToString();
           
            btn[i].Text = t[x];
            btn[i].Click += b_click;
            int[] rand = new int[3];
            do
            {
                for (j = 0; j < 3; j++)
                {
                    do { k = r.Next(0, 101); } while (k == x);
                    rand[j] = k;
                }
            } while (rand[0] == rand[1] || rand[1] == rand[2] || rand[0] == rand[2]);
            j = 0; k = 0;
            while (j < 4)
            {

                if (j == i) j++;
                else
                {
                    btn[j].Text = t[rand[k]];
                    btn[j].Click += wrong_click;
                    j++; k++;
                }
            }
            y = r.Next(2);

        }
        public void lettre_en_chiffre()
        {
            int j, k;
            Button[] btn = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
            foreach (Button b in btn)
            {
                b.Click -= b_click;
                b.Click -= wrong_click;
                b.BackColor = Color.LightGray;
                b.Enabled = true;
            }
            int x = r.Next(0, 101);
            i = r.Next(0, 4);
            lettreLabel.Text = x.ToString();
            btn[i].Text = t[x];
            trueBtn = btn[i];
            btn[i].Click += b_click;
            int[] rand = new int[3];
            do
            {
                for (j = 0; j < 3; j++)
                {
                    do { k = r.Next(0, 101); } while (k == x);
                    rand[j] = k;
                }
            } while (rand[0] == rand[1] || rand[1] == rand[2] || rand[0] == rand[2]);
            j = 0; k = 0;
            while (j < 4)
            {

                if (j == i) j++;
                else
                {
                    btn[j].Text = t[rand[k]];
                    btn[j].Click += wrong_click;
                    j++; k++;
                }
            }
            y = r.Next(2);
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (exPanel.Visible == true) { exPanel.Visible = false; }
            else
            {
                PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause, soundPhrase8Pause, soundPhrase9Pause };
                foreach (PictureBox pb in PauseSound) { pb.Hide(); }

                if (coursPanel2.Visible == true) { coursPanel2.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }
                else
                {
                    if (coursPanel1.Visible == true) { coursPanel1.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }

                    else this.Hide();
                }

            }
            InitialisateProg();
        }

        //public void balala()
        //{
        //    int j, k;
        //    Button[] btn = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
        //    foreach (Button b in btn)
        //    {
        //        b.Click -= b_click;
        //        b.Click -= wrong_click;
        //    }
        //    int x = r.Next(0, 101);
        //    i = r.Next(0, 4);
        //    lettreLabel.Text = t[x];
        //    btn[i].Text = x.ToString();
        //    btn[i].Click += b_click;
        //    int[] rand = new int[3];
        //    do
        //    {
        //        for (j = 0; j < 3; j++)
        //        {
        //            do { k = r.Next(0, 101); } while (k == x);
        //            rand[j] = k;
        //        }
        //    } while (rand[0] == rand[1] || rand[1] == rand[2] || rand[0] == rand[2]);
        //    j = 0; k = 0;
        //    while (j < 4)
        //    {

        //        if (j == i) j++;
        //        else
        //        {
        //            btn[j].Text = rand[k].ToString();
        //            btn[j].Click += wrong_click;
        //            j++; k++;
        //        }
        //    }
        //    y = r.Next(2);

        //}
        private void b_click(object sender, EventArgs e)
        {
            nextBtn.Show();
            trueAnsSound.Play();
            Button button = (Button)sender;
            button.BackColor = Color.LawnGreen;
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[count].BackColor = Color.LawnGreen;
            count++; trueCount++;
            CountEquals10();
            //MessageBox.Show("TRUE ANSWER!");
            //balala();

        }

        private void coursPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextCours_Click(object sender, EventArgs e)
        {
            coursPanel2.Show();
            coursPanel2.BringToFront();
            try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause, soundPhrase8Pause, soundPhrase9Pause };
            Label[] labels = { coursLabel1, coursLabel2, coursLabel3, coursLabel4, coursLabel5, coursLabel6, coursLabel7, coursLabel8, coursLabel9 };
            foreach (PictureBox box in PauseSound) box.Visible = false;
            int i = 0;
            PictureBox pbox = (PictureBox)sender;
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

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
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

        private void wrong_click(object sender, EventArgs e)
        {
            nextBtn.Show();
            wrongAnsSound.Play();
            Button button = (Button)sender;
            button.BackColor = Color.Red;
            trueBtn.BackColor = Color.LawnGreen;
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[count].BackColor = Color.Red;
            count++;
            CountEquals10();

            //MessageBox.Show("WRONG ANSWER!");

        }

        private void CountEquals10()
        {
            if ((count == 10) && (trueCount >= 6))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {
                    InitialisateProg(); if (y == 0) chiffres_en_lettres();
                    else lettre_en_chiffre();

                }
            }
            else
            {
                if ((count == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    if (y == 0) lettre_en_chiffre();
                    else chiffres_en_lettres();
                }
                else
                {
                    Button[] buttons = { choiceBtn1, choiceBtn2, choiceBtn3, choiceBtn4 };
                    foreach (Button butt in buttons) { butt.Enabled = false; }
                }
            }
        }

        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            count = 0;
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;

        }
    }
}
