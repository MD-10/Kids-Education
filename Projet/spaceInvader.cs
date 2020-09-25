using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using Data;
using System.Threading;
using System.Media;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace Projet
{
    public partial class spaceInvader : UserControl
    {
        public spaceInvader()
        {
            InitializeComponent();
           
        }
        bool goLeft, goRight, isPressed;

        private void spaceInvader_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { goLeft = false; }
            if (e.KeyCode == Keys.Right) { goRight = false; }
            if (isPressed)
            {
                isPressed = false;
            }
        }
        SoundPlayer playerSound = new SoundPlayer("../../../media/gunshot.wav");
        SoundPlayer trueAns = new SoundPlayer("../../../media/true.wav");
        SoundPlayer WorngAns = new SoundPlayer("../../../media/wrong.wav");
        SoundPlayer applauseSound = new SoundPlayer(@"../../../media/applause.wav");
        SoundPlayer retrySound = new SoundPlayer(@"../../../media/fail.wav");
        int trueShoot,wrongShoot;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Parent.KeyDown += new KeyEventHandler(spaceInvader_KeyDown);
                this.Parent.KeyUp += new KeyEventHandler(spaceInvader_KeyUp);
                if (goLeft) { player.Left -= playerSpeed; }
                else if (goRight) { player.Left += playerSpeed; }

                foreach (Control x in this.Controls)
                {
                    try
                    {
                        if (x is Label && x.Tag.ToString() == "invaders")
                        {
                            if (((Label)x).Bounds.IntersectsWith(player.Bounds) || ((Label)x).Top > this.Height - 50 || (trueShoot == j) || (trueShoot + wrongShoot == 6)) { newEx(); /*//gameOver();*/ }
                            ((Label)x).Top += speed;


                            if (((Label)x).Left > 720)
                            {
                                ((Label)x).Top += ((Label)x).Height + 10;
                                ((Label)x).Left = -50;
                            }

                        }
                        if (x is PictureBox && x.Tag.ToString() == "bullet")
                        {
                            x.Top -= 20;
                            if (((PictureBox)x).Top < this.Height - 490) this.Controls.Remove(x);

                        }
                    }
                    catch (Exception) { };

                }
                foreach (Control i in this.Controls)
                {
                    try
                    {
                        if (i.Tag.ToString() == "score") { i.Hide(); }
                        foreach (Control j in this.Controls)
                        {

                            if (i is Label && i.Tag.ToString() == "invaders")
                            {
                                if (j is PictureBox && j.Tag.ToString() == "bullet")
                                {
                                    if (i.Bounds.IntersectsWith(j.Bounds))
                                    {
                                        if (i.Text.IndexOf(lettre) != -1)
                                        {



                                            trueAns.Play();
                                            i.Text = "+1"; i.Tag = "score";
                                            score++;
                                            trueShoot++;
                                            //this.Controls.Remove(i);
                                            this.Controls.Remove(j);
                                        }
                                        else
                                        {
                                            WorngAns.Play(); wrongShoot++;
                                            i.Text = "-1"; i.Tag = "score";
                                            score--; this.Controls.Remove(j);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception) { };
                }
                scoreLabel.Text = "Score:" + score;
                //if (score > totalEnemies - 1)
                //{
                //    gameOver();
                //    newEx();
                //    MessageBox.Show("you saved Earth");
                //}
            }
            catch (Exception) { };
        }

        int speed = 1, score = 0/*, totalEnemies = 12*/, playerSpeed = 6;

        private void player_Click(object sender, EventArgs e)
        {
            //this.Parent.KeyDown += new KeyEventHandler(spaceInvader_KeyDown);
            //this.Parent.KeyUp += new KeyEventHandler(spaceInvader_KeyUp);
        }

        private void spaceInvader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { goLeft = true; }
            if (e.KeyCode == Keys.Right) { goRight = true; }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                playerSound.Play();
                isPressed = true;
                makeBullet();
            }
        }
        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Projet.Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            newEx();
        }

        static int highScore = 0;
        static string[] lettres = { "B", "p", "v", "f", "d", "t", "g", "C" };
        static Random r = new Random();
        string lettre;

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (score > highScore) { applauseSound.Play();highScore = score;scoreLabel2.Text = scoreLabel.Text; highScoreLabel.Text="Nouveau highscore:"+score; resultLabel.Text = "Félicitations vous avez dépasser le Highscore!"; }
            else { retrySound.Play();highScoreLabel.Text = "HighScore:" + highScore.ToString();scoreLabel.Text = "Votre Score est:" + score.ToString(); resultLabel.Text = "Réessayer!"; }
            timer1.Enabled = false;
           gameTimer.Enabled = false;
            finishedGame.Show();


        }

        private void exitGameLabel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void startLabel_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            panel1.Hide();
            newEx();
        }

        private void restartGamePicBox_Click(object sender, EventArgs e)
        {
            score = 0;
            finishedGame.Hide();
            newEx();
        }

        int j; Thread childThread;
        SpeechSynthesizer sSynth;
        private void newEx()

        {
            trueShoot = wrongShoot = 0;
            timer1.Enabled = true;
            gameTimer.Enabled = true;
            timer1.Start();
            lettre = lettres[r.Next(0, 7)].ToLower();
            childThread = new Thread(new ThreadStart(() =>
            {

                    sSynth = new SpeechSynthesizer();
                    PromptBuilder pBuilder = new PromptBuilder();
                    SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(new CultureInfo("fr-FR"));
                    //int i = 0;
                    //  PictureBox[] soundPhrases = { soundPhrase1, soundPhrase2, soundPhrase3, soundPhrase4 };
                    //  while (soundPhrases[i].Name != pBoxName) { i++; }
                    //pbox = soundPhrases[i];
                    pBuilder.ClearContent();
                string s = "tirer tous les mots contenants la lettre" + lettre;
                    pBuilder.AppendText(s);
                    sSynth.Speak(pBuilder);
                    sSynth.Dispose();



                

            }));
           
            childThread.Start();




            //try { sSynth.Pause(); }catch (Exception) { };
        

        lettreLabel.Text = "tirer tous les mots contenants la lettre " + lettre;
            string allWords = SearchFrs.allWords();
            string[] t = allWords.Split(',');

            Label[] labels = { label1, label2, label3, label4, label5, label6 };

            int i = 0; j = r.Next(1, 5);

            List<string> mots = new List<string>();
            int lettreMotCount = 0, nonLettreCount = 0, k = 0;

           
            while ((i < allWords.Length) && (k < 6))
            {
                if ((t[i].IndexOf(lettre) == -1) && (nonLettreCount < 6 - j)) { mots.Add(t[i]); k++; nonLettreCount++; }
                else
                {
                    if ((t[i].IndexOf(lettre) != -1) && (lettreMotCount < j)) { mots.Add(t[i]); k++; lettreMotCount++; }
                }
                i++;
            }


            k = 0; int x = 26;
            while (k < 6)
            {
                i = r.Next(0, mots.Count); labels[k].Show();
                labels[k].Text = mots[i]; labels[k].Tag = "invaders";
                labels[k].Location = new Point(x, 55); x = x + 120;
                mots.RemoveAt(i);
                k++;
            }

        }


    }
}
