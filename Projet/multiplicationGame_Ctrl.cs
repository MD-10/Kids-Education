using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Data;
using System.Media;

namespace Projet
{
    public partial class multiplicationGame_Ctrl : UserControl
    {
        SoundPlayer trueAns2Sound = new SoundPlayer(@"../../../media/trueAns1.wav");
        SoundPlayer wrongAnsSound = new SoundPlayer(@"../../../media/negatif.wav");
        User user;
        public multiplicationGame_Ctrl()
        {
            InitializeComponent();
            user = new User(Form1.row);
            lvl = user.multGameLvl;
            Generatecheese();
            if (lvl == 1) ContinueBtn.Visible = false;
        }
        int lvl = 1, wrongCount;
        int posX = 25, posY = 25;
        private void multiplicationGame_Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    { if (posX > exPanel.Width - 50) { } else { posX += 25; mousePicBox.Image = Projet.Properties.Resources.mouseRight; } }
                    break;
                case Keys.Left:
                    {
                        if (posX < 50) { } else { posX -= 25; mousePicBox.Image = Projet.Properties.Resources.mouseLeft; }
                    }
                    break;
                case (Keys.Up):
                    {
                        if (posY < 50) { } else { posY -= 25; mousePicBox.Image = Projet.Properties.Resources.mouseUp; }

                    }
                    break;
                case Keys.Down:
                    { if (posY > exPanel.Height - 50) { } else { posY += 25; mousePicBox.Image = Projet.Properties.Resources.mouse1; } }
                    break;
            }
            mousePicBox.Location = new Point(posX, posY);
            if (mousePicBox.Bounds.IntersectsWith(trueCheese.Bounds)) { posX = 61; posY = 65; trueAns2Sound.Play(); /*MessageBox.Show("omg");*/ if (lvl == 4) finishedGame.Show(); else { lvl++; user.multGameLvl++; NewEx(); } }
            else
            {
                bool intersect = MouseWrongIntersect();
                if (intersect == true) { posX = 61; posY = 65; mousePicBox.Location = new Point(61, 65); wrongCount++; wrongAnsSound.Play(); }
            }
        }
        private void cheeseEaten()
        {

        }
        PictureBox trueCheese;

        public void Generatecheese()
        {
            lvlLabel.Text = "Level:" + lvl.ToString();
            Label[] lb = { choiceLabel1, choiceLabel2, choiceLabel3, choiceLabel4 };
            Maths.lvl = 1; Maths.operation = "multiplication";
            searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
            expressionLabel.Text = Maths.b1text + "x" + Maths.b2text;
            Maths.operate(Maths.b1text, Maths.b2text, Maths.operation, out Maths.rep);
            Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
            Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
            string[] rep = { Maths.r1, Maths.r2, Maths.r3, Maths.r4 };
            PictureBox[] cheesePicBoxes = { cheesepicBox1, cheesePicBox2, cheesePicBox3, cheesePicBox4 };
            switch (lvl)
            {
                case 1:
                    {
                        catPicBox2.Visible = catPicBox3.Visible = catPicBox4.Visible = false;
                        catPicBox2.Enabled = catPicBox3.Enabled = catPicBox4.Enabled = false;
                        catPicBox1.Location = new Point(300, 20);
                        catPicBox4.Location = new Point(-500, -560);
                        catPicBox3.Location = new Point(-500, -500);
                        catPicBox2.Location = new Point(-500, -500);
                        cheesepicBox1.Location = new Point(150, exPanel.Height - 70);
                        cheesePicBox2.Location = new Point(300, exPanel.Height - 70);
                        cheesePicBox3.Location = new Point(exPanel.Width - 50, 200);
                        cheesePicBox4.Location = new Point(exPanel.Width - 50, 100);
                        ShowLabels();
                    }
                    break;
                case 2:
                    {
                        catPicBox2.Visible = catPicBox3.Visible = catPicBox4.Visible = false;
                
                        catPicBox1.Location = new Point(50, 200);
                        catPicBox4.Location = new Point(-500, -500);
                        catPicBox3.Location = new Point(-500, -500);
                        catPicBox2.Location =new Point (-500, -500);
                        cheesepicBox1.Location = new Point(100, exPanel.Height - 70);
                        cheesePicBox2.Location = new Point(300, exPanel.Height - 70);
                        cheesePicBox3.Location = new Point(exPanel.Width - 50, 200);
                        cheesePicBox4.Location = new Point(exPanel.Width - 50, 100);
                        ShowLabels();

                    }
                    break;
                case 3:
                    {
                        timer2.Enabled = true; catPicBox2.Visible = catPicBox3.Visible = catPicBox4.Visible = true;
                        catPicBox2.Enabled = catPicBox3.Enabled = catPicBox4.Enabled = true;
                        catPicBox1.Location = new Point(100, 150);
                        catPicBox2.Location = new Point(300, 50);
                        catPicBox3.Location = new Point(500, 150);
                        catPicBox4.Location = new Point(700, 50);
                        cheesepicBox1.Location = new Point(100, exPanel.Height - 70);
                        cheesePicBox2.Location = new Point(300, exPanel.Height - 70);
                        cheesePicBox3.Location = new Point(500, exPanel.Height - 70);
                        cheesePicBox4.Location = new Point(700, exPanel.Height - 70);
                        ShowLabels();

                    }
                    break;
                case 4:
                    {
                        catPicBox3.Visible = catPicBox4.Visible = false;
                        catPicBox3.Enabled = catPicBox4.Enabled = false;
                        catPicBox1.Location = new Point(400, 50);
                        catPicBox2.Location = new Point(700, 100);
                        catPicBox4.Location = new Point(-500, -560);
                        catPicBox3.Location = new Point(-500, -500);

                        cheesepicBox1.Location = new Point(100, exPanel.Height - 60);
                        cheesePicBox2.Location = new Point(300, exPanel.Height - 60);
                        cheesePicBox3.Location = new Point(exPanel.Width - 40, 200);
                        cheesePicBox4.Location = new Point(exPanel.Width - 40, 100);
                        ShowLabels();

                    }
                    break;
                //case 5:
                //    {

                //        catPicBox4.Visible = false;
                //        catPicBox1.Location = new Point(50, 50);
                //        catPicBox2.Location = new Point(100, 50);
                //        catPicBox3.Location = new Point(300, 50);
                //        cheesepicBox1.Location = new Point(100, exPanel.Height - 60);
                //        cheesePicBox2.Location = new Point(300, exPanel.Height - 60);
                //        cheesePicBox3.Location = new Point(exPanel.Width - 40, 200);
                //        cheesePicBox4.Location = new Point(exPanel.Width - 40, 100);
                //        ShowLabels();


                //    }
                //    break;
            }




            //MessageBox.Show(exPanel.Controls[2].GetType().ToString().Split('.')[3]);


            //Maths.lvl = 1;//lvl du user
            //int j=0;Maths.operation = "multiplication";
            //            searchmaths.search2valeur(Maths.operation, Maths.lvl, out Maths.b1text, out Maths.b2text);
            //            expressionLabel.Text = Maths.b1text + "x" + Maths.b2text;
            //Label[] lb = { choiceLabel1, choiceLabel2, choiceLabel3,choiceLabel4 };
            //            Maths.operate(Maths.b1text, Maths.b2text, Maths.operation, out Maths.rep);
            //            Maths.DonnerChoix(Maths.rep, out Maths.r1, out Maths.r2, out Maths.r3, out Maths.r4);
            //string[] rep = { Maths.r1, Maths.r2, Maths.r3,Maths.r4 };
            //bool areNearBool;
            //Random r = new Random();int k, x, y;
            //PictureBox[] cheesePicBoxes = { cheesepicBox1, cheesePicBox2, cheesePicBox3,cheesePicBox4 };
            //foreach( PictureBox cheesePb in cheesePicBoxes)
            //{
            //    do
            //    {
            //        areNearBool = areNear();
            //        k = r.Next(2);
            //        if (k == 0)
            //        {
            //            x = r.Next(exPanel.Width);
            //            if (x - 50 <= 50)
            //                cheesePb.Location = new Point(x + 50, exPanel.Height - 50);
            //            else
            //            {
            //                cheesePb.Location = new Point(x - 50, exPanel.Height - 50);
            //            }
            //        }
            //        else
            //        {
            //            x = r.Next(exPanel.Width);
            //            if (x - 50 <= 50)
            //                cheesePb.Location = new Point(exPanel.Width - 50, x + 50);
            //            else
            //            {
            //                cheesePb.Location = new Point(exPanel.Width - 50, x - 50);

            //            }
            //        }

            //    } while (areNear());

            //  lb[j].Text = rep[j];
            //    if (rep[j] == Maths.rep) trueCheese = cheesePb;
            //    lb[j].Location = new Point(cheesePb.Left, cheesePb.Top -40);
            //    j++;



        }
        private bool MouseWrongIntersect()
        {
            PictureBox[] cheesePicBoxes = { cheesepicBox1, cheesePicBox2, cheesePicBox3, cheesePicBox4, catPicBox1, catPicBox2, catPicBox3, catPicBox4 };
            int i = 0;
            while (i < 8)
            {
                if (mousePicBox.Bounds.IntersectsWith(cheesePicBoxes[i].Bounds) && (cheesePicBoxes[i] != trueCheese))
                {
                    //MessageBox.Show("oh");
                    //MessageBox.Show(cheesePicBoxes[i].Name);
                    return true;

                }
                i++;

            }
            return false;
        }




        //private bool areNear()
        //{
        //    Label[] lb = { choiceLabel1, choiceLabel2, choiceLabel3, choiceLabel4 };
        //    PictureBox[] cheesePicBoxes = { cheesepicBox1, cheesePicBox2, cheesePicBox3,cheesePicBox4 };
        //    int i = 0, j = 0;
        //    while(i<3)
        //    {
        //        j = 0;
        //        while (j < 3)
        //        {
        //            if (i == j) j++;
        //            else {
        //                if (cheesePicBoxes[i].Bounds.IntersectsWith(cheesePicBoxes[j].Bounds)) return true;
        //                        else j++;


        //            }
        //        }
        //        i++;
        //    }
        //    return false;

        //}
        private void circularButton1_Click(object sender, EventArgs e)
        {
            NewEx();

        }
        bool right = true, right1 = true;
        private void ShowLabels()
        {
            PictureBox[] cheesePicBoxes = { cheesepicBox1, cheesePicBox2, cheesePicBox3, cheesePicBox4 };
            string[] rep = { Maths.r1, Maths.r2, Maths.r3, Maths.r4 };
            Label[] lb = { choiceLabel1, choiceLabel2, choiceLabel3, choiceLabel4 };
            for (int i = 0; i < 4; i++)
            {
                lb[i].Text = rep[i];lb[i].ForeColor = Color.White;
                lb[i].Location = new Point(cheesePicBoxes[i].Left, cheesePicBoxes[i].Top + 30);
                if (lb[i].Text == Maths.rep) trueCheese = cheesePicBoxes[i];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //switch (lvl)
            //{
            //    case 3:
            //        if (catPicBox3.Top >= exPanel.Height - 120) right = false;
            //        else if (catPicBox3.Top <= 20) right = true;
            //        if (right) { catPicBox4.Top = catPicBox3.Top += 10; } else { catPicBox4.Top = catPicBox3.Top -= 10; }
            //        break;
            //}


        }
        bool up = false;

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            DialogResult r;
            if (user.multGameLvl > 1)
            {
                r = MessageBox.Show("Voulez-vous Commencer un nouveau jeu? ATTENTION Votre progrès sera annulé!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes) { lvl = user.multGameLvl = 1;NewEx() ; exPanel.Show(); menuPanel.Hide(); }
            }
            else { exPanel.Show(); menuPanel.Hide(); }

        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            exPanel.Show();
            lvl = user.multGameLvl;
            menuPanel.Hide();
        }

        private void restartGamePicBox_Click(object sender, EventArgs e)
        {
            lvl = user.multGameLvl = 1;
            finishedGame.Hide();
            NewEx();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuPanel.Visible == false) menuPanel.Show();
            else { this.Parent.Controls.Remove(this);}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (lvl)
            {
                case 1:
                    {
                        if (catPicBox1.Top <= 50) right = false;
                        else if (catPicBox1.Left <= 20) right = true;
                        if (right) { catPicBox1.Left += 10; catPicBox1.Top -= 10; } else { catPicBox1.Left -= 10; catPicBox1.Top += 10; }
                    }
                    break;
                case 2:
                    {
                        if (catPicBox1.Left >= exPanel.Width - 120) right = false;
                        else if (catPicBox1.Left <= 20) right = true;
                        if (right) { catPicBox1.Left += 10; } else { catPicBox1.Left -= 10; }
                    }
                    break;
                case 3:
                    {
                        PictureBox[] catPicBoxes1 = { catPicBox1, catPicBox3 }; PictureBox[] catPicBoxes2 = { catPicBox2, catPicBox4 };
                        foreach (PictureBox cat in catPicBoxes1)
                        {
                            if (cat.Top >= exPanel.Height - 120) right = false;
                            else if (cat.Top <= 20) right = true;
                            if (right) { cat.Top += 10; } else { cat.Top -= 10; }
                        }
                        foreach (PictureBox cat in catPicBoxes2)
                        {
                            if (cat.Top >= exPanel.Height - 120) right1 = false;
                            else if (cat.Top <= 20) right1 = true;
                            if (right1) { cat.Top += 15; } else { cat.Top -= 15; }
                        }

                    }
                    break;
                case 4:
                    {
                        if (catPicBox2.Left >= exPanel.Width - 130) right = false;
                        else if (catPicBox2.Left <= 70) right = true;
                        if (right) { catPicBox2.Left += 10; } else { catPicBox2.Left -= 10; }


                        if (catPicBox1.Top >= exPanel.Height - 130) catPicBox1.Left += 10;
                        if (catPicBox1.Left >= exPanel.Width - 120) catPicBox1.Top -= 10;
                        if (catPicBox1.Top <= 50) catPicBox1.Left -= 10;
                        if (catPicBox1.Left <= 50) catPicBox1.Top += 10;

                    }
                    break;
                //case 5:
                //    {
                //        PictureBox[] catPicBoxes = { catPicBox2, catPicBox3 };
                //        foreach (PictureBox cat in catPicBoxes)
                //        {
                //            if (cat.Top >= exPanel.Height - 170) right1 = false;
                //            else if (cat.Top <= 70) right1 = true;
                //            if (right1) { cat.Top += 15; } else { cat.Top -= 15; }
                //        }
                //        if (catPicBox1.Top >= exPanel.Height - 130) catPicBox1.Left += 10;
                //        if (catPicBox1.Left >= exPanel.Width - 120) catPicBox1.Top -= 10;
                //        if (catPicBox1.Top <= 50) catPicBox1.Left -= 10;
                //        if (catPicBox1.Left <= 50) catPicBox1.Top += 10;


                //    }
                //    break;
            }



        }

        private void mousePicBox_Click(object sender, EventArgs e)
        {
            this.Parent.KeyDown += new KeyEventHandler(multiplicationGame_Ctrl_KeyDown);

        }
        private void NewEx()
        {
            expressionLabel.Visible = true;
            mousePicBox.Location = new Point(61, 65);
            Generatecheese();


        }
    }
}
