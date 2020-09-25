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
using System.Media;

namespace Projet
{
    public partial class ConjCours_ExCtrl : UserControl
    {
        public ConjCours_ExCtrl()
        {
            InitializeComponent();
        }

        SoundPlayer trueAnsSound = new SoundPlayer(@"../../../media/trueAns.wav");
        SoundPlayer WrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int trueCount = 0, count = 0;
        bool btnClicked = false;
        Button trueBtn;
        private void nextBtn_Click(object sender, EventArgs e)
        {if (tmpsCheckedListBox1.CheckedItems.Count == 0) MessageBox.Show("Choose a time");
            else
            {
                choice1Btn.Visible = choice2Btn.Visible = choice3Btn.Visible = choice4Btn.Visible = true;
                 tmpsCheckedListBox1.Hide(); nextBtn.Text = "Next"; NewEx(); }
        }
        private void b_click(object sender, EventArgs e)
        {
            if (!comp) nextBtn.Show();
            else nextBtn.Hide();
            btnClicked = true;
            trueAnsSound.Play();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[count].BackColor = Color.LawnGreen;
            trueCount++; count++;
            Button button = (Button)sender;
            button.BackColor = Color.LawnGreen;
            Button[] btn = { choice1Btn, choice2Btn, choice3Btn, choice4Btn };
            foreach (Button b in btn)
            {
                b.Enabled = false;
            }
            CountEquals10();
        }
        private void wrong_click(object sender, EventArgs e)
        {
            if (!comp) nextBtn.Show();
            else nextBtn.Hide();
            btnClicked = true;
            WrongAnsSound.Play();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            progBtns[count].BackColor = Color.Red;
            trueBtn.BackColor = Color.LawnGreen;
            count++;
            Button button = (Button)sender;
            button.BackColor = Color.Red;
            Button[] btn = { choice1Btn, choice2Btn, choice3Btn, choice4Btn };
            foreach (Button b in btn)
            {
                b.Enabled = false;
            }
            CountEquals10();

        }
        private void NewEx()
        {
            nextBtn.Hide();
            btnClicked = false;
            int a = tmpsCheckedListBox1.CheckedItems.Count;
            int[] tmps = new int[a]; int j = 0;
            foreach (int indexChecked in tmpsCheckedListBox1.CheckedIndices)
            {
                tmps[j] = indexChecked;
                j++;
            }
            Random r = new Random();
            int i = r.Next(tmps.Length);
            string[] sujet = { "Je", "Tu", "Il/Elle/On", "Nous", "Vous", "Ils/Elles,On" };
            string[] tmpsArr = { "Present", "Passé composé", "Futur", "Imparfait" };
            int suj = r.Next(sujet.Length);
            try
            {comp=false;
                string trueAns = SearchFrs.Conjugaison(nextBtn.Tag.ToString(), tmps[i], suj);
                string choices = SearchFrs.VerbsChoix(nextBtn.Tag.ToString());
                choices = choices.Remove(choices.IndexOf(trueAns)-1, trueAns.Length+1).Trim();
                //MessageBox.Show(choices);
                string[] choiceArr = choices.Split(',');
                Button[] btn = { choice1Btn, choice2Btn, choice3Btn, choice4Btn };
                foreach (Button b in btn)
                {
                    b.Enabled = true;
                    b.BackColor = Color.LightGray;
                    b.Click -= b_click;
                    b.Click -= wrong_click;
                }
                int x = r.Next(4);

                btn[x].Text = verbLabel.Text = trueAns.ToLower();
                if ((suj == 0) && ((trueAns[0] == 'é') || (trueAns[0] == 'a') || (trueAns[0] == 'i')))
                {
                    sujet[suj] = "J'";
                }
                else if (suj == 0) sujet[suj] = "Je";
                sujLabel.Text = sujet[suj];
                tmpLabel.Text = tmpsArr[tmps[i]];
                btn[x].Click += b_click;
                trueBtn = btn[x];

                int k;
                string[] randChoix = new string[3];
                do
                {
                    for (j = 0; j < 3; j++)
                    {
                        k = r.Next(choiceArr.Length);
                        randChoix[j] = choiceArr[k];
                    }
                } while (randChoix[0] == randChoix[1] || randChoix[1] == randChoix[2] || randChoix[0] == randChoix[2]);
                j = 0; k = 0;
                while (j < 4)
                {

                    if (j == x) j++;
                    else
                    {
                        btn[j].Text = randChoix[k].ToLower();
                        btn[j].Click += wrong_click;
                        j++; k++;
                    }
                }
            }
            catch (Exception EX) { MessageBox.Show(EX.ToString()); };
        }

        private void avoirBtn_Click(object sender, EventArgs e)
        {
            choice1Btn.Visible = choice2Btn.Visible = choice3Btn.Visible = choice4Btn.Visible = false;
            tmpLabel.Text = verbLabel.Text=sujLabel.Text = "";
            nextBtn.Show();
            nextBtn.Text = "Start";
            tmpsCheckedListBox1.Show();
            exPanel.Show();
            verbsListPanel.Hide();
            Button button = (Button)sender;
            nextBtn.Tag = button.Tag;
        }

        private void compBtn_Click(object sender, EventArgs e)
        {
            verbsListPanel.Hide();
            compNiveauPanel.Show();
            //exPanel.Show();
            //NewCompEx();
            //timer1.Enabled = true;

        }
        bool timerFinished = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
                if (btnClicked == false)
                { WrongAnsSound.Play(); progBtns[count].BackColor = Color.Red; count++; }
            }
            catch (Exception) { }; NewCompEx();
            if (count == 10)
            {

                timer1.Stop();
                timerFinished = true;
                //timer1.Stop();
                CountEquals10();
            }
        }
        bool comp = false;
        public void NewCompEx()
        {
            comp = true;
            nextBtn.Visible = false;
            timer1.Start();
            btnClicked = false;
            Random r = new Random();
            int tmps = r.Next(4), v = r.Next(5);
            string[] sujet = { "Je", "Tu", "Il/Elle/On", "Nous", "Vous", "Ils/Elles,On" };
            string[] tmpsArr = { "Present", "Passé composé", "Futur", "Imparfait" };
            string[] VerbsArr = { "avoir", "etre", "faire", "venir", "aller" };
            int suj = r.Next(sujet.Length);
            try
            {
                string trueAns = SearchFrs.Conjugaison(VerbsArr[v], tmps, suj);
                string choices = SearchFrs.VerbsChoix(VerbsArr[v]);
                choices = choices.Remove(choices.IndexOf(trueAns), trueAns.Length + 1).Trim();
                //MessageBox.Show(choices);
                string[] choiceArr = choices.Split(',');
                Button[] btn = { choice1Btn, choice2Btn, choice3Btn, choice4Btn };
                foreach (Button b in btn)
                {
                    b.Enabled = true;
                    b.BackColor = Color.LightGray;
                    b.Click -= b_click;
                    b.Click -= wrong_click;
                }
                int x = r.Next(4);

                btn[x].Text = verbLabel.Text = trueAns.ToLower();
                if ((suj == 0) && ((trueAns[0] == 'é') || (trueAns[0] == 'a') || (trueAns[0] == 'i')))
                {
                    sujet[suj] = "J'";
                }
                else if (suj == 0) sujet[suj] = "Je";
                sujLabel.Text = sujet[suj];
                tmpLabel.Text = tmpsArr[tmps];
                btn[x].Click += b_click;
                trueBtn = btn[x];

                int k, j;
                string[] randChoix = new string[3];
                do
                {
                    for (j = 0; j < 3; j++)
                    {
                        k = r.Next(choiceArr.Length);
                        randChoix[j] = choiceArr[k];
                    }
                } while (randChoix[0] == randChoix[1] || randChoix[1] == randChoix[2] || randChoix[0] == randChoix[2]);
                j = 0; k = 0;
                while (j < 4)
                {

                    if (j == x) j++;
                    else
                    {
                        btn[j].Text = randChoix[k].ToLower();
                        btn[j].Click += wrong_click;
                        j++; k++;
                    }
                }
            }
            catch (Exception) { };
        }
        public void InitialisateProg()
        {for(int i = 0; i < 4; i++) { tmpsCheckedListBox1.SetItemChecked(i, false); }
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button b in progBtns)
            {
                b.BackColor = Color.RoyalBlue;
            }
            trueCount = count = 0;
        }

        private void back_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            InitialisateProg();
            timerFinished = false;
            if (exPanel.Visible == true) { exPanel.Hide(); verbsListPanel.Show(); }
            else
            {
                if (compNiveauPanel.Visible == true) compNiveauPanel.Hide();
                else
                {
                    if (verbsListPanel.Visible == true)
                    {
                        verbsListPanel.Hide(); cours_exPanel.Show();
                    }
                    else this.Hide();
                }
            }
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            cours_exPanel.Hide();
            verbsListPanel.Show();
            verbsListPanel.BringToFront();
        }

        private void compBtn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            timer1.Interval = int.Parse(btn.Tag.ToString());
            exPanel.Show();
            compNiveauPanel.Hide();
            NewCompEx();
            //timer1.Enabled = true;
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
                    InitialisateProg();
                    if (timerFinished == false)
                        NewEx();
                    else
                        NewCompEx();

                }
            }
            else
            {
                if ((count == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    if (timerFinished == false)
                        NewEx();
                    else
                        NewCompEx();
                }
                else
                {
                    Button[] buttons = { choice1Btn, choice2Btn, choice3Btn, choice4Btn };
                    foreach (Button butt in buttons) { butt.Enabled = false; }
                }
            }
        }



    }
}

