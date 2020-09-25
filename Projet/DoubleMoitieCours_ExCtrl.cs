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
using System.Speech.Synthesis;
using System.Threading;
using System.Speech.Recognition;
using System.Globalization;

namespace Projet
{
    public partial class DoubleMoitieCours_ExCtrl : UserControl
    {

        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int counter = 0, trueCount = 0;
        public DoubleMoitieCours_ExCtrl()
        {
            InitializeComponent();
            panelDroit.AllowDrop = true;
            panelGauche.AllowDrop = true;

            panelDroit.DragEnter += panel_DragEnter;
            panelGauche.DragEnter += panel_DragEnter;

            panelDroit.DragDrop += panel_DragDrop;
            panelGauche.DragDrop += panel_DragDrop;
        }

        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.DoDragDrop(btn, DragDropEffects.Move);
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            panelDroit.AllowDrop = true; 
            e.Effect = DragDropEffects.Move;

        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {

            Panel p = (Panel)sender;
            ((PictureBox)e.Data.GetData(typeof(PictureBox))).Parent = p;
        }

        private void NewEx() 
        {
           
            nextBtn.Hide();
            exPanel.Show();
            panelGauche.Controls.Clear();
            panelDroit.Controls.Clear();
            Random n = new Random();
            int i, ii, jj, j;
            PictureBox apple = new PictureBox();
            PictureBox happle = new PictureBox();
            apple.Image = Image.FromFile(@"../../../apple/apple.jpg");
            happle.Image = Image.FromFile(@"../../../apple/halfapple.jpg");
            i = n.Next(2);
            if (i == 0)
            {
                j = n.Next(2, 10);
                i = 2 * j; ii = 2 * j;
                ldoublemoitie.Text = "Double de";
                lnombre.Text = j.ToString();
                for (int k = 0; k < i + ii; k++)
                {
                    jj = n.Next(2);
                    PictureBox btn = new PictureBox();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(20 + (k / 6) * 45, 20 + (k % 6) * 50);
                    if (jj == 0) { btn.Image = apple.Image; btn.Name = "apple" + k.ToString(); }
                    else { btn.Image = happle.Image; btn.Name = "halfapple" + k.ToString(); }
                    btn.SizeMode = PictureBoxSizeMode.StretchImage;
                    btn.MouseDown += button1_MouseDown;
                    panelGauche.Controls.Add(btn);
                }
            }
            else
            {
                j = n.Next(2, 12);
                i = 6; ii = 4;
                ldoublemoitie.Text = "Moitié de";
                lnombre.Text = j.ToString();
                for (int k = 0; k < i + ii; k++)
                {
                    jj = n.Next(2);
                    PictureBox btn = new PictureBox();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(20 + (k / 6) * 45, 20 + (k % 6) * 50);
                    if (jj == 0) { btn.Image = apple.Image; btn.Name = "apple" + k.ToString(); }
                    else { btn.Image = happle.Image; btn.Name = "halfapple" + k.ToString(); }
                    btn.SizeMode = PictureBoxSizeMode.StretchImage;
                    btn.MouseDown += button1_MouseDown;
                    panelGauche.Controls.Add(btn);
                }
            }
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };

           
            nextBtn.Show();
            float count = 0;
            for (int k = 0; k < panelDroit.Controls.Count; k++) { if (panelDroit.Controls[k].Name.Substring(0, 5) == "apple") count ++; else if (panelDroit.Controls[k].Name.Substring(0, 4) == "half") count += (float)0.5; }
            if (ldoublemoitie.Text.Substring(0, 6) == "Double")
                if (count == 2 * int.Parse(lnombre.Text)) { trueAns2Sound.Play() ; progBtns[counter].BackColor = Color.LawnGreen; }
                else { wrongAnsSound.Play(); progBtns[counter].BackColor = Color.Red; }
            else
            {
                if (count == (float)int.Parse(lnombre.Text) / 2) { trueAns2Sound.Play(); progBtns[counter].BackColor = Color.LawnGreen; }
                else {wrongAnsSound.Play(); progBtns[counter].BackColor = Color.Red; }
            }
            counter++;
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            NewEx();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            NewEx();
        }

        private void back_Click(object sender, EventArgs e)
        {

            if (exPanel.Visible == true) { exPanel.Visible = false; }
            else
            {
                PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause,soundPhrase4Pause, soundPhrase5Pause, soundPhrase6Pause };
                foreach (PictureBox pb in PauseSound) { pb.Hide(); }

                    if (coursPanel1.Visible == true) { coursPanel1.Hide(); try { sSynth.Pause(); sSynth.Dispose(); } catch (Exception) { }; }

                    else this.Hide();

            }
            InitialisateProg();
        }
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            counter = 0; trueCount = 0;
        }
        Thread childThread; string pausedName;
        SpeechSynthesizer sSynth;
        private void soundPhrase1_Click(object sender, EventArgs e)
        {
            PictureBox[] PauseSound = { soundPhrase1Pause, soundPhrase2Pause, soundPhrase3Pause, soundPhrase4Pause, soundPhrase5Pause, soundPhrase6Pause};
            Label[] labels = { coursLabel1, coursLabel2, coursLabel3, coursLabel4, coursLabel5, coursLabel6 };
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

        private void courBtn_Click(object sender, EventArgs e)
        {
            coursPanel1.Show();
        }

        private void back_MouseEnter_1(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height += 5;
            pb.Width += 5;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height -= 5;
            pb.Width -= 5;
        }

        private void pause_click(object sender, EventArgs e)
        {


            PictureBox pbox = (PictureBox)sender;
            pbox.Visible = false;
            try { sSynth.Pause(); } catch (Exception) { }; pausedName = pbox.Name.Replace("Pause", "");

        }
    }
}
