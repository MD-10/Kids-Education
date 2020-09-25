using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using Data;

namespace Projet
{
    public partial class CompteEstBon : UserControl
    {
        
        public static Random n = new Random();
        public string r1, r2, r3, r4, rep, op;
        public int a, b, c, score = 0;
        public bool apresop = false;
       
        class Vector
        {
            float x, y, norm;
            Vector univector;
            public float X { get { return x; } set { x = value; } }
            public float Y { get { return y; } set { y = value; } }
            public float Norm { get { norm = calculNorm(this); return norm; } }
            public Vector() { x = 0; y = 0; norm = 0; univector = null; }
            public Vector(Point p1, Point p2)
            {
                x = p1.X - p2.X;
                y = p1.Y - p2.Y;
                norm = (float)Math.Sqrt((x) * (x) + (y) * (y));
                univector = Calculunivector(p1, p2);
            }
            public Vector(Vector v)
            {
                x = v.x;
                y = v.y;
                norm = v.norm;
                univector = v.univector;
            }

            private static float calculNorm(Vector v)
            {
                float n = 0;
                n = (v.x) * (v.x) + (v.y) * (v.y);
                n = (float)Math.Sqrt(n);
                return n;
            }
            public Vector Calculunivector(Point p1, Point p2)
            {
                Vector v = new Vector();
                v.x = p1.X - p2.X;
                v.y = p1.Y - p2.Y;
                v.norm = calculNorm(v);
                try
                {
                    v.x = v.x / v.norm;
                    v.y = v.y / v.norm;
                }
                catch (Exception ex) { throw ex; }
                v.norm = 1;
                return v;
            }
            public Vector vunivector()
            {
                Vector v = new Vector();
                v.x = x;
                v.y = y;
                v.norm = calculNorm(v);
                try
                {
                    v.x = v.x / v.norm;
                    v.y = v.y / v.norm;
                }
                catch (Exception ex) { throw ex; }
                v.norm = 1;
                return v;
            }
            public static Vector operator -(Vector v)
            {
                Vector nv = new Vector();
                nv.x = -v.x;
                nv.y = -v.y;
                nv.norm = v.norm;
                return nv;
            }
            public static Vector operator *(float i, Vector v)
            {
                Vector nv = new Vector();
                nv.x = i * v.x;
                nv.y = i * v.y;
                nv.norm = v.norm;
                return nv;
            }

        }
        Graphics g;

        private void ballon2_Paint(object sender, PaintEventArgs e)
        {
            PictureBox ball = (PictureBox)sender;
            Font f = new Font("Arial", 14);
            e.Graphics.DrawString(r2, f, Brushes.Black, new PointF(ball.Width / 3 + 10, ball.Height / 2 - 15));
        }

        private void ballon1_Paint(object sender, PaintEventArgs e)
        {
            PictureBox ball = (PictureBox)sender;
            Font f = new Font("Arial", 14);
            e.Graphics.DrawString(r1, f, Brushes.Black, new PointF(ball.Width / 3 + 10, ball.Height / 2 - 15));
        }



        private void ballon3_Paint(object sender, PaintEventArgs e)
        {
            PictureBox ball = (PictureBox)sender;
            Font f = new Font("Arial", 14);
            e.Graphics.DrawString(r3, f, Brushes.Black, new PointF(ball.Width / 3 + 10, ball.Height / 2 - 15));
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (lScoreAct.Text == rep) MessageBox.Show("bravo");
            else MessageBox.Show("Pas Correcte! Reasseyez!");
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        private void opx_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            Button b = (Button)sender;
            op = b.Text;
            ballon1.Enabled = true; ballon2.Enabled = true; ballon3.Enabled = true; ballon4.Enabled = true;

        }



        private void ballon4_Paint(object sender, PaintEventArgs e)
        {
            PictureBox ball = (PictureBox)sender;
            Font f = new Font("Arial", 14);
            e.Graphics.DrawString(ball.Tag.ToString(), f, Brushes.Black, new PointF(ball.Width / 3 + 10, ball.Height / 2 - 15));
        }
        SoundPlayer bubbleSound = new SoundPlayer(@"../../../media/bubbleSound.wav");
        private void ballon2_Click(object sender, EventArgs e)
        {
            PictureBox ballon = (PictureBox)sender;
            if (!apresop)
            {
                a = int.Parse(ballon.Tag.ToString());
                apresop = true;
                bubbleSound.Play();
    //sound
                Thread.Sleep(200);
                ballon.Visible = false;
                vinit.RemoveAt(ballons.IndexOf(ballon));
                ballons.Remove(ballon);
                ballon1.Enabled = false; ballon2.Enabled = false; ballon3.Enabled = false; ballon4.Enabled = false;
                opx.Enabled = true; opadd.Enabled = true; opsous.Enabled = true; opdiv.Enabled = true;

            }
            else
            {
                b = int.Parse(ballon.Tag.ToString());
                bubbleSound.Play();
                Thread.Sleep(200);
                vinit.RemoveAt(ballons.IndexOf(ballon));
                ballons.Remove(ballon);
                ballon.Visible = false;
                switch (op)
                {
                    case "x":
                        c = a * b;
                        break;
                    case "+":
                        c = a + b;
                        break;
                    case "-":
                        c = a - b;
                        break;
                    case "÷":
                        if ((a / b) == ((float)a / b)) c = a / b;
                        break;
                }


                score = c;
                Ballon bal = new Ballon();
                bal.Image = Projet.Properties.Resources.bubble;
                bal.SizeMode = PictureBoxSizeMode.StretchImage;
                bal.Size = new Size(80, 80);
                bal.Location = new Point(60, 60);
                bal.Cursor = Cursors.Hand;
                bal.Tag = c;
                g = bal.CreateGraphics();
                Font f = new Font("Arial", 14);
                g.DrawString(bal.Tag.ToString(), f, Brushes.Black, new PointF(bal.Width / 3 + 10, bal.Height / 2 - 15));
                bal.Click += ballon2_Click;
                ballons.Add(bal);
                vinit.Add(new Vector(new Point(0, 0), new Point(1, 1)));
                bal.Paint += ballon4_Paint;
                panelgame.Controls.Add(bal);


                opx.Enabled = false; opadd.Enabled = false; opsous.Enabled = false; opdiv.Enabled = false;
                apresop = false;
            }
        }

        private void Bal_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public CompteEstBon()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Pen blackPen = new Pen(Color.Black, 3);
            g = CreateGraphics();//usercontrol
            g.DrawRectangle(blackPen, 50, 35, panelgame.Width - 3, panelgame.Height - 3);
            ballons.Add(ballon3);
            ballons.Add(ballon4);
            ballons.Add(ballon2);
            ballons.Add(ballon1);
            vinit.Add(new Vector(new Point(0, 0), new Point(-0, 1)));
            vinit.Add(new Vector(new Point(0, 0), new Point(1, 1)));
            vinit.Add(new Vector(new Point(0, 0), new Point(-2, 2)));
            vinit.Add(new Vector(new Point(0, 0), new Point(1, -2)));
            searchmaths.search4valeur(out rep, out r1, out r2, out r3, out r4);
            ballon1.Tag = r1;
            ballon2.Tag = r2;
            ballon3.Tag = r3;
            ballon4.Tag = r4;
            ballon1.Paint += ballon1_Paint;
            ballon2.Paint += ballon2_Paint;
            ballon3.Paint += ballon3_Paint;
            ballon4.Paint += ballon4_Paint;
            opx.Enabled = false; opadd.Enabled = false; opsous.Enabled = false; opdiv.Enabled = false;


        }

        List<Vector> vinit = new List<Vector>();
        List<PictureBox> ballons = new List<PictureBox>();

        private void timer1_Tick(object sender, EventArgs e)
        {

            lScoreAct.Text = score.ToString();
            lScoreFinale.Text = rep.ToString();
            for (int i = 0; i < ballons.Count; i++)
            {
                ballons[i].Location = new Point(ballons[i].Location.X + (int)vinit[i].X, ballons[i].Location.Y + (int)vinit[i].Y);

                if ((ballons[i].Location.X <= 50) || (ballons[i].Location.X >= 500) || (ballons[i].Location.Y <= 50) || (ballons[i].Location.Y >= 250)) vinit[i] = -vinit[i];

            }

            for (int i = 0; i < ballons.Count - 1; i++)
            {
                for (int j = i + 1; j < ballons.Count; j++)
                {
                    Vector vec = new Vector(new Point((ballons[i].Location.X + ballons[i].Width / 2), (ballons[i].Location.Y + ballons[i].Height / 2)), new Point((ballons[j].Location.X + ballons[j].Width / 2), (ballons[j].Location.Y + ballons[j].Height / 2)));
                    if (vec.Norm <= 80)
                    {

                        vinit[i] = 0.05F * vec;
                        vinit[j] = 0.05F * -vec;
                    }
                }

            }
        }

    }
}
