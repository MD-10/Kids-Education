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
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace Projet
{
    public partial class CroissanDecroissantCours_ExCtrl : UserControl
    {
        int count = 0,trueCount=0;
        static User user = new User(Form1.row);
        int userlvl = user.comparaisonLvl;
        public CroissanDecroissantCours_ExCtrl()
        {
            InitializeComponent();
        }


        void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            Point loc = new Point();
            loc = l.Location;
            l.DoDragDrop(l, DragDropEffects.Move);



        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            p2.AllowDrop = true;
            p3.AllowDrop = true;
            p4.AllowDrop = true;
            p1.AllowDrop = true;
            pInitiale.AllowDrop = true;
            if (p1.Controls.Count >= 1) p1.AllowDrop = false;
            if (p2.Controls.Count >= 1) p2.AllowDrop = false;
            if (p3.Controls.Count >= 1) p3.AllowDrop = false;
            if (p4.Controls.Count >= 1) p4.AllowDrop = false;
            e.Effect = DragDropEffects.Move;

        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel p = (Panel)sender;
            ((Label)e.Data.GetData(typeof(Label))).Parent = p;
            if (p.Name != "pInitiale") p.Controls[0].Location = new Point(15, 15);
            else for (int k = 0; k < p.Controls.Count; k++) { p.Controls[k].Location = new Point(int.Parse(p.Controls[k].Tag.ToString().Split(',')[0]), int.Parse(p.Controls[k].Tag.ToString().Split(',')[1])); }

        }

        public static bool different(string[] t)
        {
            for (int i = 0; i < t.Length - 1; i++)
                for (int j = i + 1; j < t.Length; j++) if (t[i] == t[j]) return false;
            return true;
        }
        // public static void comparaison(out string nbcomparaison1,out string nbcomparaison2,out string nbcomparaison3,out string nbcomparaison4)
        //int userlvl = 1;
        public static void comparaison(out string[] nbcomparaison,int lvl)
        {
            nbcomparaison = new string[4];
            Random n = new Random();
            int j;
            double k;
            do
            {
                for (int i = 0; i < nbcomparaison.Length; i++)
                {
                    switch (lvl)
                    {
                        case 1:
                            j = n.Next(1, 15);
                            nbcomparaison[i] = j.ToString();
                            break;
                        case 2:
                            j = n.Next(15, 100);
                            nbcomparaison[i] = j.ToString();
                            break;
                        case 3:
                            j = n.Next(-100, 0);
                            nbcomparaison[i] = j.ToString();
                            break;
                        case 4:
                            k = (10) * n.NextDouble() - 5;
                            nbcomparaison[i] = k.ToString();
                            break;
                    }
                }
            } while (different(nbcomparaison) == false);
            //nbcomparaison1 = nbcomparaison[0]; nbcomparaison2 = nbcomparaison[1]; nbcomparaison3 = nbcomparaison[2]; nbcomparaison4 = nbcomparaison[3];

        }

        private void NewEx()
        {
            nextBtn.Hide();
            exPanel.Show();
            p1.Controls.Clear();
            p2.Controls.Clear();
            p3.Controls.Clear();
            p4.Controls.Clear();
            pInitiale.Controls.Add(nbcomparaison1); pInitiale.Controls.Add(nbcomparaison2); pInitiale.Controls.Add(nbcomparaison3); pInitiale.Controls.Add(nbcomparaison4);
            nbcomparaison1.Location = new Point(44, 44);
            nbcomparaison2.Location = new Point(144, 44);
            nbcomparaison3.Location = new Point(244, 44);
            nbcomparaison4.Location = new Point(344, 44);

            p1.AllowDrop = true;
            p1.DragEnter += panel_DragEnter;
            p1.DragDrop += panel_DragDrop;
            p2.AllowDrop = true;
            p2.DragEnter += panel_DragEnter;
            p2.DragDrop += panel_DragDrop;
            p3.AllowDrop = true;
            p3.DragEnter += panel_DragEnter;
            p3.DragDrop += panel_DragDrop;
            p4.AllowDrop = true;
            p4.DragEnter += panel_DragEnter;
            p4.DragDrop += panel_DragDrop;

            Random n = new Random();
            int j = n.Next(2);
            if (j == 0) { lcroissant1.Text = "<"; lcroissant2.Text = "<"; lcroissant3.Text = "<"; }
            else { lcroissant1.Text = ">"; lcroissant2.Text = ">"; lcroissant3.Text = ">"; }
            string[] nbcomparaison;
            comparaison(out nbcomparaison,userlvl);
            nbcomparaison1.Text = nbcomparaison[0];
            nbcomparaison2.Text = nbcomparaison[1];
            nbcomparaison3.Text = nbcomparaison[2];
            nbcomparaison4.Text = nbcomparaison[3];

        }

        private void confirm_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };

           
            nextBtn.Show();
            if ((p1.Controls.Count != 1) || (p2.Controls.Count != 1) || (p3.Controls.Count != 1) || (p4.Controls.Count != 1)) progBtns[count].BackColor = Color.Red;
            else
            {
                if (lcroissant1.Text == "<")
                    if ((int.Parse(p1.Controls[0].Text) < int.Parse(p2.Controls[0].Text)) && (int.Parse(p2.Controls[0].Text) < int.Parse(p3.Controls[0].Text)) && (int.Parse(p3.Controls[0].Text) < int.Parse(p4.Controls[0].Text))) progBtns[count].BackColor = Color.LawnGreen;
                    else progBtns[count].BackColor = Color.Red;
                else
                {
                    if ((int.Parse(p1.Controls[0].Text) > int.Parse(p2.Controls[0].Text)) && (int.Parse(p2.Controls[0].Text) > int.Parse(p3.Controls[0].Text)) && (int.Parse(p3.Controls[0].Text) > int.Parse(p4.Controls[0].Text))) progBtns[count].BackColor = Color.LawnGreen;
                    else progBtns[count].BackColor = Color.Red;
                }
            } count++;
        }
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (userlvl > 4) { MessageBox.Show("no more levels"); }
            else
            {
                NewEx();
            }
        }
        private void exBtn_Click(object sender, EventArgs e)
        {
            NewEx();
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (exPanel.Visible == true) { exPanel.Visible = false; }
            else
            {
                PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause, soundPhrase8Pause, soundPhrase9Pause, soundPhrase10Pause, soundPhrase11Pause};
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
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            count = 0; trueCount = 0;
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause, soundPhrase5Pause, soundPhrase6Pause, soundPhrase7Pause, soundPhrase8Pause, soundPhrase9Pause, soundPhrase10Pause, soundPhrase11Pause};
            Label[] labels = {  coursLabel1, coursLabel2, coursLabel3, coursLabel4, coursLabel5, coursLabel6, coursLabel7, coursLabel8, coursLabel9, coursLabel10, coursLabel11};
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

        private void nextCours_Click(object sender, EventArgs e)
        {
            coursPanel2.Show();
            coursPanel2.BringToFront();
            try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }
        }

        private void soundPhrase2Pause_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void soundPhrase2Pause_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
        }

        private void pause_click(object sender, EventArgs e)
        {


            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }
    }
}
