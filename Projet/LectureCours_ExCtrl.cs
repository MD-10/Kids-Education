using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using Data;
using System.Media;

namespace Projet
{
    public partial class LectureCours_ExCtrl : UserControl
    {
        public LectureCours_ExCtrl()
        {
            InitializeComponent();
            Panel[] panels = { choicesPanel, salle, salon, chambre, cuisine };
            foreach (Panel panel in panels)
            {
                panel.AllowDrop = true;
                panel.DragEnter += panel_DragEnter;
                panel.DragDrop += panel_DragDrop;
            }

            for (int i = 0; i < choicesPanel.Controls.Count; i++)
            {
                choicesPanel.Controls[i].MouseDown += choice_MouseDown;
            }
            newEx();
        }
             int userLevel = 1;
        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer WrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int trueCount, trueEx, countEx = 0;
        

        void choice_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.DoDragDrop(pbox, DragDropEffects.Move);
            //MessageBox.Show("mouse down");
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {

            //if (p.Controls.Count == 1) p.AllowDrop = false;
            //else p.AllowDrop = true;
            e.Effect = DragDropEffects.Move;
            Panel p = (Panel)sender;
            PictureBox pb = ((PictureBox)e.Data.GetData(typeof(PictureBox)));
            if ((pb.Parent == p) && (p.Tag.ToString().IndexOf(pb.Name) != -1)) { trueCount--; }
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            //int j = 0;
            Panel p = (Panel)sender;
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).Parent = p;
            PictureBox pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
            if (p.Name != "choicesPanel")
            {
                pb.Location = p.PointToClient(Cursor.Position);
                //if (p.Controls.Count == 1)
                //        pb.Location = new Point(15, 15);
                //    else
                //    {
                //        //pb.Location = new Point(15, 15);
                //        pb.Location = new Point(p.Controls[p.Controls.Count - 2].Left +70, p.Controls[p.Controls.Count - 2].Top);
                //    }
                //    if (pb.Left > p.Width) pb.Location = new Point(15, 100);
                try
                {
                    if (p.Tag.ToString().IndexOf(pb.Name) != -1) { trueCount++; }
                    //else wrongCount++;
                }
                catch (Exception) { }

            }
            else for (int k = 0; k < p.Controls.Count; k++) { p.Controls[k].Location = new Point(int.Parse(p.Controls[k].Tag.ToString().Split(',')[0]), int.Parse(p.Controls[k].Tag.ToString().Split(',')[1])); }



        }

        public void newEx()
        {
            try { sSynth.Pause(); } catch (Exception) { }
            trueCount = 0;
            Label[] lab = { phrase1Label, phrase2Label, phrase3Label, phrase3Label };
            PictureBox[] phrasesSound = { soundPhrase1, soundPhrase2, soundPhrase3, soundPhrase4 };
            foreach (PictureBox p in phrasesSound)
            {
                p.Click -= sound_click;
                p.Hide();
            }
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause };
            foreach (PictureBox box in PauseSound) box.Visible = false;
            foreach (Label l in lab) { l.Text = ""; }
            Panel[] panels = { choicesPanel, salle, salon, chambre, cuisine };
            foreach (Panel p in panels)
            {
                p.Tag = "";
            }
            string[] cases = SearchFrs.Lecture(userLevel);
            Random r = new Random();
            string s = cases[r.Next(cases.Length)];
            //s = "Le miroir est dans la salle de bain./miroir;salle_La table et la chaise sont dans le salon./table:chaise;salon";
            string[] phrases = s.Split('_');
            for (int j = 0; j < phrases.Length; j++)
            {
                phrasesSound[j].Show();
                phrasesSound[j].Click += sound_click;

                if (phrases[j].IndexOf('/') == -1) { lab[j].Text = phrases[j]; }
                else
                {
                    string[] ss = phrases[j].Split('/');

                    lab[j].Text = ss[0];
                    //MessageBox.Show(ss[1]);


                    string objets = ss[1].Split(';')[0];
                    string place = ss[1].Split(';')[1];
                    int i = 0;
                    while (panels[i].Name != place) { i++; }
                    panels[i].Tag = objets;

                }
                phrasesSound[j].Tag = lab[j].Text;
            } //return items to initial place
            PictureBox[] items = { banana, biberon, chaise, miroir, livre, ourson, parapluie, pomme, reveil, table, carotte, chat };
            foreach (PictureBox pBox in items)
            {
                pBox.Parent = choicesPanel; pBox.Location = new Point(int.Parse(pBox.Tag.ToString().Split(',')[0]), int.Parse(pBox.Tag.ToString().Split(',')[1]));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newEx();
        }

        private void banana_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height += 3;
            pb.Width += 3;

        }


        private void banana_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height -= 3;
            pb.Width -= 3;
        }



        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five };

            if (trueCount > 1) { trueAnsSound.Play(); progBtns[countEx].BackColor = Color.LawnGreen; countEx++; trueEx++; newEx(); }
            else { WrongAnsSound.Play(); progBtns[countEx].BackColor = Color.Red; countEx++; newEx(); }
            CountEquals5();
        }



        private void pause_click(object sender, EventArgs e)
        {
            //stopped = true;
            //    childThread.Join();// wait 1 second for something to happen.
            //doStuff();
            //if (conditionToExitReceived) // what im waiting for...
            //    break;

            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }



        //bool stopped = false;
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;



        private void sound_click(object sender, EventArgs e)
        {
            //stopped = false;
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause };
            foreach (PictureBox box in PauseSound) box.Visible = false;
            int i = 0; PictureBox pbox = (PictureBox)sender;
            while (PauseSound[i].Name != pbox.Name + "Pause") { i++; }
            //childref = new ThreadStart(voiceSpeak);
            childThread = new Thread(new ThreadStart(() =>
            {
                pBoxName = pbox.Name;
            
                if ((pbox.Name == pausedName)) { sSynth.Resume(); pausedName = ""; }
                else
                {
                    PictureBox pausePicBox = PauseSound[i];
                    try { sSynth.Pause(); } catch (Exception) { }

                    sSynth = new SpeechSynthesizer();
                    PromptBuilder pBuilder = new PromptBuilder();
                    SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));
                    //int i = 0;
                    //  PictureBox[] soundPhrases = { soundPhrase1, soundPhrase2, soundPhrase3, soundPhrase4 };
                    //  while (soundPhrases[i].Name != pBoxName) { i++; }
                    //pbox = soundPhrases[i];
                    pBuilder.ClearContent();
                    MessageBox.Show(pbox.Tag.ToString());
                    pBuilder.AppendText(pbox.Tag.ToString());
                    sSynth.Speak(pBuilder);
                    sSynth.Dispose();
                    pausedName = "";
                    this.Invoke(new MethodInvoker(() => PauseSound[i].Hide()));
                    //pausePicBox.Hide();
                  

                }

            }));
            PauseSound[i].Show();
            PauseSound[i].Click += pause_click;
            childThread.Start();




            //try { sSynth.Pause(); }catch (Exception) { };
        }
        string pBoxName;

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void CountEquals5()
        {
            if ((countEx == 5) && (trueEx >= 3))
            {
                lvUpSound.Play();
                DialogResult r;
                if (userLevel == 2)
                {
                    r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (r == DialogResult.No) this.Hide();
                    else
                    {
                        InitialisateProg();
                        newEx();


                    }
                }
                else { InitialisateProg(); userLevel++; newEx(); }
            }
            else
            {
                if ((countEx == 5) && (trueEx < 3))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    newEx();
                }
            }
        }
        public void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five };
            foreach (Button b in progBtns)
            {
                b.BackColor = Color.RoyalBlue;
            }
            trueCount = countEx = 0;
        }

    }
}

