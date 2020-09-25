using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;
using Data;

namespace Projet
{
    public partial class dicteeExCtrl : UserControl
    {
        public dicteeExCtrl()
        {
            InitializeComponent();
            newEx();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            nextBtn.Hide();
            newEx();
        }
        List<string> mots = new List<string>();
        Label[] motsLabels;string s;
        private void newEx()
        {
             s= SearchFrs.Dictee();

            mots.AddRange(s.Split(' '));
            //try { if (motsLabels.Length != 0) try { for (int xx = 0; xx < motsLabels.Length; i++) { motsLabels[xx] = motsLabels[xx]; this.Controls.Remove(motsLabels[xx]); } } catch (Exception) { } } catch (Exception) { }

            try { foreach (Label l in motsLabels) { this.Controls.Remove(l); } } catch (Exception) { }
            motsLabels = new Label[mots.Count];

            Random r = new Random();
            for (int i = 0; i < mots.Count; i++)
            {
                Label l = new Label(); l.BackColor = Color.AliceBlue; l.TextAlign = ContentAlignment.MiddleCenter; l.Font = new Font("Comic SAns MS", 10f);
                this.Controls.Add(l);
                motsLabels[i] = l;

            }
            int k = 0, x = 26;/*int j;*/
            while (k < motsLabels.Length)
            {
                motsLabels[k].Text = mots[k].TrimEnd();

                k++;
            }

            motsLabels = motsLabels.OrderBy(Y => r.Next()).ToArray();
            k = 0;
            while (k < motsLabels.Length)
            {
                motsLabels[k].Location = new Point(x, 100); motsLabels[k].Size = new Size(100, 25);
                motsLabels[k].Tag = motsLabels[k].Left + "," + motsLabels[k].Top;
                x += 100;
                motsLabels[k].Click += label1_Click;
                k++;
            }



            //while (k < motsLabels.Length)
            //{
            //    j = r.Next(0, mots.Count);
            //    motsLabels[k].Text = mots[j];
            //    motsLabels[k].Location = new Point(x, 100);motsLabels[k].Tag = j.ToString() + ";" + motsLabels[k].Left + "," + motsLabels[k].Top; x = x + 100; motsLabels[k].Click += label1_Click;
            //    mots.RemoveAt(j);
            //    k++;
            //}



        }
        int i = -1;
        private void label1_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            i++;
            if (i % 2 == 0)
            {
                Thread childThread = new Thread(new ThreadStart(() =>

                {
                    while (true)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        { l.Location = this.PointToClient(Cursor.Position); }));
                        if (i % 2 != 0) break;
                        else
                        {
                            if (l.Left > this.Width - 40 || l.Left < 20 || l.Top > this.Height - 40 || l.Top < 40)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                { l.Location = new Point(int.Parse(l.Tag.ToString().Split(',')[0]), int.Parse(l.Tag.ToString().Split(',')[1])); })); i++; break;
                            }
                        }
                    }
                }));
                childThread.Start();
            }

            else
            {
                l.Location = this.PointToClient(Cursor.Position);
            }

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            nextBtn.Show();
            bool permut = false;
            int i = 0;
            Label aux;
            do
            {
                permut = false;
                for (i = 0; i < motsLabels.Length - 1; i++)
                {
                    if (motsLabels[i].Left > motsLabels[i + 1].Left)
                    {
                        aux = motsLabels[i]; motsLabels[i] = motsLabels[i + 1]; motsLabels[i + 1] = aux;
                        permut = true;
                    }
                }
            } while (permut);

            for (i = 0; i < motsLabels.Length; i++)
            {
                if (motsLabels[i].Text != mots[i]) { motsLabels[i].BackColor = Color.Red; }
                else motsLabels[i].BackColor = Color.Green;
            }
            mots.Clear();
        }

        Thread childThread; string pausedName, pBoxName;
        SpeechSynthesizer sSynth;

        private void soundPhrase1Pause_Click(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            //stopped = false;

            soundPhrase1Pause.Visible = false;
            int i = 0; PictureBox pbox = (PictureBox)sender;

            //childref = new ThreadStart(voiceSpeak);
            childThread = new Thread(new ThreadStart(() =>
            {
                pBoxName = pbox.Name;

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

                    pBuilder.AppendText(s);
                    sSynth.Speak(pBuilder);
                    sSynth.Dispose();
                    pausedName = "";
                    this.Invoke(new MethodInvoker(() => soundPhrase1Pause.Hide()));
                    //pausePicBox.Hide();


                }

            }));
            soundPhrase1Pause.Show();
            childThread.Start();





        }
    }
}

