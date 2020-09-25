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
    public partial class divCours_ExCtrl : UserControl
    {
        Random g = new Random();
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
         int counter , correct , erreur ;
        static User user;
        int userlvl;
        public divCours_ExCtrl()
        {
            InitializeComponent();
            counter = 0; correct = 0; erreur = 0;
            user = new User(Form1.row);
            userlvl = user.divLvl;
            InitializeComponent();
            Maths.lvl = userlvl;
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            newEx();
        }



        private void back_Click(object sender, EventArgs e)
        {
            if (pDivisetous.Visible == true) pDivisetous.Hide();
            else {
                if (exPanel.Visible == true) { exPanel.Visible = false; }
                else
                {
                    PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause, soundPhrase8Pause, soundPhrase9Pause, soundPhrase10Pause, soundPhrase11Pause, soundPhrase12Pause, soundPhrase13Pause, soundPhrase14Pause };
                    foreach (PictureBox pb in PauseSound) { pb.Hide(); }

                    if (coursPanel2.Visible == true) { coursPanel2.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }
                    else
                    {
                        if (coursPanel1.Visible == true) { coursPanel1.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }
                        else
                        { this.Parent.Controls.Remove(this); }
                        
                    }
                } }
            InitialisateProg();
        }

            private void newEx()
        {
            r1.BackColor = r2.BackColor = r3.BackColor = r4.BackColor = Color.LightGray;
            {
                nextBtn.Hide();
                exPanel.Show();
                exPanel.BringToFront();
                lvlLabel.Text = "level:" + userlvl.ToString();
                errLabel.Text = "Erreur:" + erreur.ToString();
                corrLabel.Text = "correcte:" + correct.ToString();
                r1.Enabled = true; r2.Enabled = true; r3.Enabled = true; r4.Enabled = true;
                eq.Text = "";
                Maths.lvl = userlvl;//lvl du user

                searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
                b1.Text = Maths.b1text;
                op.Text = searchmaths.divsymbol();
                b2.Text = Maths.b2text;
                Maths.operate(Maths.b1text, Maths.b2text, Maths.operation, out Maths.rep);
                Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
                r1.Text = Maths.r1;
                r2.Text = Maths.r2;
                r3.Text = Maths.r3;
                r4.Text = Maths.r4;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (userlvl > 4) { MessageBox.Show("no more levels"); }
            else
            {
                newEx();
            }
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
            nextBtn.Show();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            r1.Enabled = false; r2.Enabled = false; r3.Enabled = false; r4.Enabled = false;
                eq.Text = Maths.rep;
            Button r = (Button)sender;
            if (r.Text == Maths.rep)
            {int i = g.Next(2);
                if (i == 0) trueAns2Sound.Play();
                else trueAnsSound.Play();
                progBtns[counter].BackColor = Color.LawnGreen;
                counter++;
                correct++;
                r.BackColor = Color.LightGreen;
                
                corrLabel.Text = "correcte:" + correct.ToString();
            }//lzm n3mla methode
            else
            {wrongAnsSound.Play();
                progBtns[counter].BackColor = Color.Red;
                erreur++;
                r.BackColor = Color.Red; 
                errLabel.Text = "Erreur:" + erreur.ToString();
                counter++;
            }

            if (counter == 10)
            {
                if (correct > 5) { lvUpSound.Play();userlvl++; user.divLvl++;MessageBox.Show("lvl complete");  InitialisateProg();newEx();  } //save button
                else { retrySound.Play(); MessageBox.Show("retry"); InitialisateProg(); newEx(); }
            }Panel p = pDivisetous;
        } //newEx();
       
            
            Random n = new Random();
            int i = 0, k = 0;
            public string[] nombres2a9 = { "2", "3", "4", "5", "6", "7", "8", "9" };
            Color[] color = { Color.BlueViolet, Color.Red, Color.DarkSeaGreen, Color.CornflowerBlue, Color.LightGreen, Color.LightPink, Color.DarkRed, Color.CornflowerBlue, Color.Fuchsia };
            public string[] tables = { "2,4,6,8,10,12,14,16,18,20", "3,6,9,12,15,18,21,24,27,30", "4,8,12,16,20,24,28,32,36,40", "5,10,15,20,25,30,35,40,45,50", "6,12,18,24,30,36,42,48,54,60", "7,14,21,28,35,42,49,56,63,70", "8,16,24,32,40,48,56,64,72,80", "9,18,27,36,45,54,63,72,81,90" };
            public List<string> list = new List<string>();
            Button btn = new Button();
            bool clicked = false;
            void shuffle()
            {
                int p = 0, j;
                list.Clear();
                for (int i = 0; i < nombres2a9.Length; i++)
                    if (nombres2a9[i] == label2.Text) p = i;
                list.AddRange(tables[p].Split(','));
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
                foreach (Button b in panel1.Controls)
                {
                    Indexes.Remove((j = Indexes[n.Next(0, Indexes.Count)]));
                    b.BackColor = color[j];
                    b.Text = list[j];
                    b.Tag = b.Text;
                }
            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                foreach (Button b in panel1.Controls) if (b == btn)
                    {
                        if (i == 0) k = int.Parse(b.Text);
                        b.Text = (k - 1 + (i % 3)).ToString();
                    }
                i++;
            }

            private void b1_Click(object sender, EventArgs e)
            {

                timer1.Enabled = false;
                clicked = true;
            }


            private void b1_MouseDown(object sender, EventArgs e)
            {
                Button b = (Button)sender;
                b.BackColor = color[n.Next(color.Length)];
                if (!clicked)
                {
                    b.Text = b.Tag.ToString();
                    string c = (int.Parse(b.Text) / int.Parse(label2.Text)).ToString();
                    b.Text = ((int.Parse(c)) - 1 + n.Next(3)).ToString();
                    btn = b;
                    timer1.Enabled = true;
                }
            }

            private void next_Click(object sender, EventArgs e)
            {
                shuffle();
            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                bool juste = true; int correct = 9;
                foreach (Button b in panel1.Controls)
                {
                    if (b.Text != (float.Parse(b.Tag.ToString()) / float.Parse(label2.Text)).ToString()) { correct--; juste = false; }
                }
                if (juste) { pjuste.Visible = true; pjuste.Show(); pjuste.BringToFront(); }
                else { ppascorrecte.Visible = true; ppascorrecte.Show(); ppascorrecte.BringToFront(); }
            }

            private void brejouer2_Click(object sender, EventArgs e)
            {
                ppascorrecte.Visible = false;
                shuffle();
            }

            private void Home2_Click(object sender, EventArgs e)
            {
                ppascorrecte.Visible = false; pDivisetous.Visible = false;

            }

            private void Rejouer1_Click(object sender, EventArgs e)
            {
                pjuste.Visible = false;
                shuffle();
            }

            private void Home1_Click(object sender, EventArgs e)
            {
                pjuste.Visible = false; pDivisetous.Visible = false;
            }

            private void trianglePictureBox1_Click(object sender, EventArgs e)
            {
            if (int.Parse(label2.Text) < 9) { label2.Text = (int.Parse(label2.Text) + 1).ToString(); shuffle(); }

        }

        private void trianglePictureBox21_Click(object sender, EventArgs e)
            {
            if (int.Parse(label2.Text) > 2) { label2.Text = (int.Parse(label2.Text) - 1).ToString(); shuffle(); }

        }

        private void b1_MouseLeave(object sender, EventArgs e)
            {
                Button b = (Button)sender;
                b.BackColor = color[n.Next(color.Length)];
                i = 0;
                if (!clicked)
                {
                    b.Text = b.Tag.ToString();
                }
                timer1.Enabled = false;
                clicked = false;
            }
        




















    private void InitialisateProg()
            {
                Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
                foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
                counter = 0; correct = 0; erreur = 0;
            }
    
   

        private void nextCours_Click(object sender, EventArgs e)
        {
            coursPanel2.Show();
            coursPanel2.BringToFront();
            try { sSynth.Pause();sSynth.Dispose(); } catch (Exception) { }
        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
            coursPanel1.BringToFront();
        }
 Thread childThread; string pausedName;
    SpeechSynthesizer sSynth;

        private void r1_MouseEnter(object sender, EventArgs e)
        {
            Button r = (Button)sender;
            r.BackColor = Color.Blue;
        }

        private void r1_MouseLeave(object sender, EventArgs e)
        {
            Button r = (Button)sender;
            r.BackColor = Color.Gainsboro;
        }

        private void brejouer2_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.LightBlue;
        }

        private void Rejouer1_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.White;
        }

        private void bjeux_Click(object sender, EventArgs e)
        {
            pDivisetous.Visible = true;pDivisetous.BringToFront();
            label2.Text = nombres2a9[n.Next(nombres2a9.Length)];
            shuffle();
        }

        private void soundPhrase1_Click(object sender, EventArgs e)
    {
        PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause,soundPhrase8Pause,soundPhrase9Pause,soundPhrase10Pause,soundPhrase11Pause,soundPhrase12Pause,soundPhrase13Pause,soundPhrase14Pause };
        Label[] labels = { coursLabel, coursLabel1,CoursLabel2,coursLabel3, coursLabel4, coursLabel5, coursLabel6, coursLabel7,coursLabel8,coursLabel9,CoursLabel10,coursLabel11,coursLabel12};
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
