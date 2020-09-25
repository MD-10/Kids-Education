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
using Data;
namespace Projet

    //public partial class heureExCtrl : UserControl
    //{
    //    public heureExCtrl()
    //    {
    //        InitializeComponent();
    //        if (y == 0) newTextEx();
    //        else newImgEx();
    //    }
    //}


{
    public partial class heureExCtrl : UserControl
    {
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

        public heureExCtrl()
        {
            InitializeComponent();
            if (y == 0) newTextEx();
            else newImgEx();
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
            //  soundPicBox.Tag = (@"../../../media/") + s[x].Substring(0, 5).Trim() + ".wav";
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
                    //soundPicbox[j].Tag = (@"../../../media/") + s[rand[k]].Substring(0, 5).Trim() + ".wav";
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
            if ((j == 10) && (trueCount >= 6)) {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {
                    j = 0; if (y == 0) newImgEx();
                    else newTextEx();
                    foreach (Button b in progBtns) b.BackColor = Color.RoyalBlue;
                }
            }
            else {
                if ((j == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    j = 0;
                    if (y == 0) newImgEx();
                    else newTextEx();
                    foreach (Button b in progBtns) b.BackColor = Color.LightBlue;
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
                trueBtn.BackColor = Color.LightGreen;
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
                {
                    j = 0; if (y == 0) newImgEx();
                    else newTextEx();
                    foreach (Button b in progBtns) b.BackColor = Color.RoyalBlue;
                }
            }
            else
            { if ((j == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    j = 0;
                    if (y == 0) newImgEx();
                    else newTextEx();
                    foreach (Button b in progBtns) b.BackColor = Color.Gray;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void sound_click(object sender, EventArgs e)
        {
            SpeechSynthesizer sSynth = new SpeechSynthesizer();
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
            sSynth.Speak(pBuilder);
        }
            //try
            //{
            //    PictureBox pbox = (PictureBox)sender;
            //    SoundPlayer sound = new SoundPlayer(pbox.Tag.ToString().Trim());
            //    sound.Play();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); };

        }

    }


