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
using System.Diagnostics;
namespace Projet
{
    public partial class PerimetreCours_ExCtrl : UserControl
    {
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");

        Process p = new Process();

        public PerimetreCours_ExCtrl()
        {
            InitializeComponent();

        }
        public class CalculePDisque
        {
            static public string rep;
            public static void DonnerChoix(string rep, out string r1, out string r2, out string r3, out string r4)
            {
                double ss = double.Parse(rep);
                int j;
                Random n = new Random();
                r1 = r2 = r3 = r4 = null;
                j = n.Next(1, 5);
                if (ss > 0)
                {
                    do
                    {
                        switch (j)
                        {
                            case 1:
                                { r1 = rep; r2 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r3 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r4 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); }
                                break;
                            case 2:
                                { r2 = rep; r1 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r3 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r4 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); }
                                break;
                            case 3:
                                { r3 = rep; r2 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r1 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r4 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); }
                                break;
                            case 4:
                                {
                                    r4 = rep; r2 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r3 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString(); r1 = (ss - (n.NextDouble() * n.Next(-(int)ss, (int)ss))).ToString();
                                }
                                break;
                        }
                    } while ((r1 == r2) || (r1 == r3) || (r1 == r4) || (r2 == r3) || (r2 == r4) || (r3 == r4));
                }
            }

        }

        private void newEx()
        {
            lRep1.Enabled = lRep2.Enabled = lRep3.Enabled = lRep4.Enabled = true;
            int rayon, replength;
            string r1, r2, r3, r4;
            double rep;
            Random n = new Random();
            rayon = n.Next(2, 8);
            lVictoire.Hide();
            lPerdu.Hide();
            lRayon.Text = rayon.ToString();
            rep = 2 * rayon * 3.14;
            CalculePDisque.rep = rep.ToString();
            CalculePDisque.DonnerChoix(CalculePDisque.rep, out r1, out r2, out r3, out r4);
            replength = CalculePDisque.rep.Length;
            lRep1.Text = r1.Substring(0, replength);
            lRep2.Text = r2.Substring(0, replength);
            lRep3.Text = r3.Substring(0, replength);
            lRep4.Text = r4.Substring(0, replength);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            NextBtn.Hide();
            newEx();

        }
        int trueCount = 0, count = 0;
        private void lRep1_Click(object sender, EventArgs e)
        {
            NextBtn.Show();
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            Label l = (Label)sender;
            lRep1.Enabled = lRep2.Enabled = lRep3.Enabled = lRep4.Enabled = false;
            if (l.Text == CalculePDisque.rep) { trueAns2Sound.Play(); progBtns[count].BackColor = Color.LawnGreen;trueCount++ ; count++; }
            else { wrongAnsSound.Play(); progBtns[count].BackColor = Color.Red; count++; }

            if ((count == 10) && (trueCount >= 6))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                { InitialisateProg();
                    newEx();
                    
                }
            }
            else
            {
                if ((count == 10) && (trueCount < 6))
                {
                    retrySound.Play();
                    MessageBox.Show("Réessayer");
                    InitialisateProg();
                    newEx();
                    
                }
                //else
                //{
                //    if (y == 0) newImgEx();
                //    else newTextEx();
                //}
            }

        }


        private void Comprendre_Click(object sender, EventArgs e)
        {
            pComprendre.Show();
        }

        private void Jouer_Click(object sender, EventArgs e)
        {
            pExercice.Show();
            p.StartInfo.FileName = "calc.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            
            newEx();
        }


        private void Back_Click(object sender, EventArgs e)
        {
            if (pExercice.Visible == true) { pExercice.Hide(); p.WaitForExit();  }
            else
            {
                if (pComprendre.Visible == true) pComprendre.Hide();
                else
                {
                    this.Parent.Controls.Remove(this);
                }
            }
           
        }
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            count = 0; trueCount = 0;
        }

    }
}
