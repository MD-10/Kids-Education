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

namespace Projet
{
    public partial class AireRectangleCours_ExCtrl : UserControl
    {
        public AireRectangleCours_ExCtrl()
        {
            InitializeComponent();
        }
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        private void AireRectangleCours_ExCtrl_Load(object sender, EventArgs e)
        {

        }
        public class Dessin
        {
            static public int initRow, initColumn, row, column;
            static public int rectangleHeight, rectangleWidth, AireRectangle;
            static public Random n = new Random();

            public static void DonnerValeur()
            {
                rectangleHeight = n.Next(2, 4);
                rectangleWidth = n.Next(2, 6);
                AireRectangle = rectangleHeight * rectangleWidth;
                initColumn = n.Next(2, 8);
                initRow = n.Next(2, 4);
            }
            public static void DonnerChoix(string rep, out string r1, out string r2, out string r3, out string r4)
            {
                int ss = int.Parse(rep);
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
                                { r1 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 2:
                                { r2 = rep; r1 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 3:
                                { r3 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r1 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 4:
                                {
                                    r4 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r1 = (ss - n.Next(-ss, ss)).ToString();
                                }
                                break;
                        }
                    } while ((r1 == r2) || (r1 == r3) || (r1 == r4) || (r2 == r3) || (r2 == r4) || (r3 == r4));
                }
            }
        }

        private void newEx()
        {
            l1.Enabled = l2.Enabled = l3.Enabled = l4.Enabled = true;
            string r1, r2, r3, r4;
            Repere.Show();
            Repere.Controls.Clear();
            Dessin.DonnerValeur();
            Dessin.DonnerChoix(Dessin.AireRectangle.ToString(), out r1, out r2, out r3, out r4);
            Repere.CellPaint += tableLayoutPanel1_CellPaint;

            l1.Text = r1;
            l2.Text = r2;
            l3.Text = r3;
            l4.Text = r4;
            Label label1 = new Label();
            Label label2 = new Label();
            label1.Text = (Dessin.rectangleWidth.ToString());
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label2.Text = (Dessin.rectangleHeight.ToString());

            Repere.Controls.Add(label1, Dessin.initColumn + 1 + (Dessin.rectangleWidth) / 2, Dessin.initRow + Dessin.rectangleHeight + 1);
            Repere.Controls.Add(label2, Dessin.initColumn + Dessin.rectangleWidth + 1, Dessin.initRow + 1 + (Dessin.rectangleHeight) / 2);
            Repere.Refresh();
        }
        int count = 0, trueCount = 0;
        public void BtnNext_Click(object sender, EventArgs ee)
        {
            newEx();
            BtnNext.Enabled = false;

        }
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            
                    if ((e.Column <= Dessin.initColumn + Dessin.rectangleWidth) && (e.Column > Dessin.initColumn) && (e.Row <= Dessin.initRow + Dessin.rectangleHeight) && (e.Row > Dessin.initRow))
                    {
                        e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                    }
               
        }

        private void l1_Click(object sender, EventArgs e)
        { Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            Label l = (Label)sender;
            l1.Enabled = l2.Enabled = l3.Enabled = l4.Enabled = false;
            BtnNext.Enabled = true;
            if (l.Text == Dessin.AireRectangle.ToString()) {trueAns2Sound.Play(); progBtns[count].BackColor = Color.LawnGreen; count++; trueCount++; }


            else {wrongAnsSound.Play(); progBtns[count].BackColor = Color.Red; count++; }
            if ((count == 10) && (trueCount >= 6))
            {
                lvUpSound.Play();
                DialogResult r;
                r = MessageBox.Show("Bon Travail! Voulez vous réessayer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No) this.Hide();
                else
                {
                    InitialisateProg();
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




        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
   
        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            count = 0; trueCount = 0;
        }
    }
}
