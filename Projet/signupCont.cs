using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projet;
using System.Media;
using Data;
namespace Projet
{
    public partial class signupCont : UserControl
    {
        SoundPlayer mouseEnterSound = new SoundPlayer(@"../../../media/woosh.wav");
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        string ss="";
        public signupCont()
        {
            InitializeComponent();
         

        }
        private void username_MouseClick(object sender, MouseEventArgs e)
        {
            uexistlabel.Hide(); uinvalidlabel.Hide();
        }
        private void email_MouseClick(object sender, MouseEventArgs e)
        {
            enotval.Hide();
            e_exist.Hide();

        }
        private void p_MouseClick(object sender, MouseEventArgs e)
        {
            pnotconf.Hide();
            pinvalid.Hide();
        }
        private void p2_MouseClick(object sender, MouseEventArgs e)
        {
            pnotconf.Hide();
            pinvalid.Hide();
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            string s = email.Text;
            bool a = Search.username(username.Text.ToLower()), b =Search.Email(email.Text.ToLower()), c = (p.Text != p2.Text ? true : false);
            //if (a == b == c == true)
            //{
            //    label1.Show();
            //    label2.Show();
            //    label3.Show();
            //}
            bool u= false,pp = false,ee = false,sex = false;
            if (username.Text.Length < 5) { uinvalidlabel.Show(); uexistlabel.Hide(); }
            else
            {
                if (a == true)
                {
                    uexistlabel.Show();
                    uinvalidlabel.Hide();
                    
                }
                else u = true;
            }


            if ((s.IndexOf('@') == -1) || s.LastIndexOf('@') != s.IndexOf('@') || s.IndexOf('@') > s.LastIndexOf('.')) { enotval.Show(); e_exist.Hide(); }
            else
            {
                if (b == true)
                {
                    e_exist.Show();
                    enotval.Hide();
                    
                }
                else ee = true;
            }


            if (c == true) { pnotconf.Show(); pinvalid.Hide(); }
            else
            {

                if (p.Text.Length < 5)
                {

                    pinvalid.Show();
                    pnotconf.Hide();
                    

                }
                else pp = true;

            }
            if (ss.Length != 0) sex = true;
            else genre.Show();
            if (ee == true && pp == true && u == true&& sex==true)
            {

                User user = new User(username.Text.ToLower(), email.Text.ToLower(), dateTimePicker1.Value, ss,p.Text);
                Form1.row = user.Row;
               Form1.User = user;
                bacck();
            }
            
        }
        private void male_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            PictureBox pb = (PictureBox)sender;
            ss = pb.Tag.ToString();
            genre.Hide();   
            
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            clickSound.Play(); bacck();
        }
        private void bacck()
        {
            uinvalidlabel.Hide();
            uexistlabel.Hide();
            e_exist.Hide();
            pnotconf.Hide();
            enotval.Hide();
            pinvalid.Hide();
            genre.Hide();
            username.Text = p.Text = p2.Text = email.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            ss = "";
            this.Hide();
        }
        private void male_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterSound.Play();
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void male_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }

        private void signupCont_Load(object sender, EventArgs e)
        {

        }

        private void p2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) confirm_Click(this, new EventArgs());
        }
    }
}
