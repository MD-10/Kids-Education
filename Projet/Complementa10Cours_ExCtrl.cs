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
    public partial class Complementa10Cours_ExCtrl : UserControl
    {
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        SoundPlayer lvUpSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int trueCount=0, count= 0;
        Graphics g;
        Pen blackPen = new Pen(Color.Black, 3);
        public Complementa10Cours_ExCtrl()
        {
            InitializeComponent();
            
        }
        private void NewEx()
        {
            panel3.Show();
            panel3.Controls.Clear();
            count = 0;
            Random n = new Random();
            int i, j;
            i = n.Next(12, 15);
            j = n.Next(1, 9);
            PictureBox apple = new PictureBox();
            apple.Image = Projet.Properties.Resources.apple;
            for (int k = 0; k < j; k++)
            {
                PictureBox btn = new PictureBox();
                btn.Size = new Size(30, 30);
                btn.Location = new Point(330 + (k / 5) * 45, 25 + (k % 5) * 50);
                btn.Image = apple.Image;
                btn.SizeMode = PictureBoxSizeMode.StretchImage;
                panel3.Controls.Add(btn);
                Helper.ControlMover.Init(btn);

            }
            for (int k = 0; k < i - j; k++)
            {
                PictureBox btn = new PictureBox();
                btn.Size = new Size(30, 30);
                btn.Location = new Point(20 + (k / 5) * 45, 15 + (k % 5) * 50);
                btn.Image = apple.Image;
                btn.SizeMode = PictureBoxSizeMode.StretchImage;
                panel3.Controls.Add(btn);
                Helper.ControlMover.Init(btn);

            }


        }

        private void confirm_Click(object sender, EventArgs e)
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            nextBtn.Show();
            for (int i = 0; i < panel3.Controls.Count; i++)
            {
               if ((panel3.Controls[i].Location.X > 320) && (panel3.Controls[i].Location.X < 558) && (panel3.Controls[i].Location.Y > 10) && (panel3.Controls[i].Location.Y < 300)) count++;

            }
            if (count == 10) { progBtns[count].BackColor = Color.LawnGreen; trueCount++; trueAns2Sound.Play(); }
            else { wrongAnsSound.Play(); progBtns[count].BackColor = Color.Red; }
            panel3.Controls.Clear();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, 5, 10, 230, 300);
            e.Graphics.DrawRectangle(blackPen, 320, 10, 250, 300);
        }

   
        

        private void exBtn_Click(object sender, EventArgs e)
        {
           NewEx();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            NewEx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel3.Controls.Count; i++)
            {
                if ((panel3.Controls[i].Location.X > 320) && (panel3.Controls[i].Location.X < 558) && (panel3.Controls[i].Location.Y > 10) && (panel3.Controls[i].Location.Y < 300)) count++;

            }
            if (count == 10) MessageBox.Show("bravo");
            else MessageBox.Show("pas correcte!");
            panel3.Controls.Clear();
        }

        private void InitialisateProg()
        {
            Button[] progBtns = { one, two, three, four, five, six, seven, eight, nine, ten };
            foreach (Button btn in progBtns) btn.BackColor = Color.RoyalBlue;
            count=0;trueCount=0;
        }
    }
}
