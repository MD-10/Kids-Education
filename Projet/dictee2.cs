using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class dictee2 : UserControl
    {
        public dictee2()
        {
            InitializeComponent();
            newEx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { test(s, textBox2.Text); } catch (Exception) { MessageBox.Show("Le ecriver la phrase que vous avez entandez"); }
            //MessageBox.Show(test().ToString());
        }
        static void test(string s1, string s2)
        {



            //List<string> diff11 = new List<string>(new string[] { "0" }), diff22 = new List<string>(new string[] { "0" });
            //IEnumerable<string> set11 = s1.Split(' ');
            //IEnumerable<string> set22 = s2.Split(' ');
            //diff11 = set22.Except(set11).ToList();
            //diff22 = set11.Except(set22).ToList();
            //string s33 = String.Join(",", diff11.ToArray());
            //MessageBox.Show("Method1:" + s33);
            //string sss1 = String.Join(",", diff22.ToArray());
            //MessageBox.Show("Method1:" + sss1);
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            s1 = regex.Replace(s1, " ").Trim();
            s2 = regex.Replace(s2, " ").Trim();
            ArrayList diff1 = new ArrayList();
            ArrayList diff2 = new ArrayList();
            ArrayList set1 = new ArrayList();
            ArrayList set2 = new ArrayList();
            set1.AddRange(s1.Split(' '));
            set2.AddRange(s2.Split(' '));
            diff1.AddRange(set1);
            diff2.AddRange(set2);

            //diff1 = set1.ToList();
            //diff2 = set1.ToList();
            if (Compute(s1, s2) == 0) MessageBox.Show("true dictee");
            else
            {
                int i, x;
                for (i = 0; i < set1.Count; i++)
                {
                    if (diff2.IndexOf(set1[i]) != -1) diff2.Remove(set1[i]);

                }
                for (i = 0; i < set2.Count; i++)
                {
                    if (diff1.IndexOf(set2[i]) != -1) diff1.Remove(set2[i]);

                }
                string s = String.Join(",", diff1.ToArray());
                // MessageBox.Show("diff1:" + s);
                string ss1 = String.Join(",", diff2.ToArray());
                // MessageBox.Show("dff2:" + ss1);
                float noteTotale, note;
                noteTotale = note = 2;
                i = 0; ArrayList missedWords = new ArrayList();
                if (diff1.Count == diff2.Count)
                {

                    while (i < diff1.Count)
                    {
                        x = Compute(diff1[i].ToString(), diff2[i].ToString());
                        if (x < 2) note -= (noteTotale / 20);
                        else { if (x >= 2) note -= noteTotale / 10; }
                        i++;
                        //MessageBox.Show(x.ToString());
                    }
                    MessageBox.Show("votre note:" + (note * 10 / noteTotale).ToString());
                }
                else
                {
                    if (diff2.Count == 0) missedWords.AddRange(diff1);
                    else
                    {
                        diff1.Reverse(); diff2.Reverse();
                        if ((diff2.Count != 0) && (diff1.Count > diff2.Count))
                        {
                            string mot1, mot2; int j;
                            while (diff2.Count != 0)
                            {
                                i = diff1.Count - 1; j = diff2.Count - 1; int lengthDiff;
                                if (diff1.Count != 0)
                                {
                                    mot1 = diff1[i].ToString(); mot2 = diff2[j].ToString();
                                    x = Compute(mot1, mot2); lengthDiff = (Math.Abs(mot1.Length - mot2.Length));


                                    if ((mot1.Length < 3) && (mot2.Length < 3) && (mot1.ToLower() != mot2.ToLower())) { note -= noteTotale / 10; diff1.Remove(mot1); diff2.Remove(mot2); }
                                    else
                                    {
                                        if ((lengthDiff == 0) && (x > mot1.Length / 2)) { /*MessageBox.Show("first");*/ note -= noteTotale / 10; missedWords.Add(mot1); diff1.Remove(mot1); }

                                        else
                                        {
                                            if (((lengthDiff < 3) && (x > lengthDiff) && (lengthDiff != 0)) || (lengthDiff >= 3))
                                            {
                                                //MessageBox.Show("jdsd");
                                                note -= noteTotale / 10; missedWords.Add(mot1); diff1.Remove(mot1);
                                            }

                                            else
                                            {
                                                if (x < 2) { note -= noteTotale / 20; }
                                                else note -= noteTotale / 10;
                                                diff1.Remove(mot1); diff2.Remove(mot2);
                                            }


                                        }
                                    }
                                }

                            }
                            if (diff1.Count != 0) missedWords.AddRange(diff1);
                        }
                        missedWords.Reverse();
                        string sa = String.Join(",", missedWords.ToArray());
                        MessageBox.Show("Missed:" + sa);

                    }

                    //while (i < diff1.Count)
                    //{


                }

                //}



            }
        }

        //MessageBox.Show(Compute(s1.Split(' '), s2.Split(' ')).ToString());

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);

                }
            }
            // Step 7
            return d[n, m];
        }

        Thread childThread; string pausedName, pBoxName;
        SpeechSynthesizer sSynth;string s;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
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
        void newEx()
        {
            s = SearchFrs.Dictee2();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            newEx();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void soundPhrase1Pause_Click(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");
        }


    }


}




