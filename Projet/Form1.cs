using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Projet
{

    public partial class Form1 : Form
    {
        SoundPlayer mouseEnterSound = new SoundPlayer(@"../../../media/woosh.wav");
        SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
        
        static int ro;
        private static Random r = new Random();
        public static int x = r.Next(1000, 9999);
        private static User user;
        public static int row { get => ro; set => ro = value; }
        public static User User { get => user; set => user = value; }
        public Form1()
        {

            InitializeComponent();
            signupCont1.Hide();
            menu1.Hide();
            

        }

        private void ShowSignup_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            signupCont1.Show();
            loginInvalid.Hide();
            username.Text = "";
            password.Text = "";
        }
        private void login_Click(object sender, EventArgs e)
        {
            bool a; string hash;
            a = Search.username(username.Text.ToLower(), out hash);
            clickSound.Play();bool b = Hashing.CheckPassword(password.Text, hash);
            if (a == true && b == true)
            {
                loginInvalid.Hide();
                menu1.Show();
                logOut.Show();
                logOut.BringToFront();
                Search.UseroutRow(username.Text, out ro);
                user = new User(ro);
                username.Text = password.Text = "";
            }
            else
            {
                loginInvalid.Show();

            }


        }
        private void logOut_Click(object sender, EventArgs e)
        {
           
            clickSound.Play();
            menu1.Hide();
            signupCont1.Hide();
            logOut.Hide();

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult r; clickSound.Play();
            r = MessageBox.Show("Voulez-vous quitter?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes) this.Close();
           
        }
        private void start_Click(object sender, EventArgs e)
        {  clickSound.Play();
            startPanel.Hide();
         
        }
        private void start_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = 5;
            pb.Size = new Size(width + larger, height + larger);
            mouseEnterSound.Play();
        }
        private void start_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int width = pb.Size.Width;
            int height = pb.Size.Height;
            int larger = -5;
            pb.Size = new Size(width + larger, height + larger);
        }
        
        private void confirm_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            if (Search.EmailoutRow(email.Text.ToLower().Trim(), out ro) == true)
            {
                //Search.EmailoutRow(email.Text.ToLower().Trim(), out row);
                try
                {
                    //Smpt Client Details
                    //gmail >> smtp server : smtp.gmail.com, port : 587 , ssl required
                    //yahoo >> smtp server : smtp.mail.yahoo.com, port : 587 , ssl required
                    SmtpClient clientDetails = new SmtpClient();
                    clientDetails.Port = Convert.ToInt32("587");
                    clientDetails.Host = "smtp-mail.outlook.com";
                    clientDetails.EnableSsl = true;
                    clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                    clientDetails.UseDefaultCredentials = false;
                    clientDetails.Credentials = new NetworkCredential("rami.hajar@hotmail.com", "roro.love.99");

                    //Message Details
                    MailMessage mailDetails = new MailMessage();

                    mailDetails.From = new MailAddress("rami.hajar@hotmail.com");
                    mailDetails.To.Add(email.Text.ToLower().Trim());//receiver email
                                                                    //for multiple recipients
                                                                    //mailDetails.To.Add("another recipient email address");
                                                                    //for bcc
                                                                    //mailDetails.Bcc.Add("bcc email address")
                    mailDetails.Subject = "App forgotten password";
                    mailDetails.IsBodyHtml = false;
                    mailDetails.Body = ("your code is:  " + x.ToString());


                    //file attachment
                    //if(fileName.Length>0)
                    //{
                    //    Attachment attachment = new Attachment(fileName);
                    //    mailDetails.Attachments.Add(attachment);
                    //}

                    clientDetails.Send(mailDetails);

                    MessageBox.Show("Your mail has been sent.");
                    sendEmailPanel.Hide();
                    codePanel.Show();

                    //fileName = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Confirmer votre email!");
            }
        }
        private void ValidCode_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            if (codeTextBox.Text!= x.ToString()) codeLabel.Show();
            else
            {
                codePanel.Hide();
                codeLabel.Hide();
                changePass1.Show();
            }
        }
        private void forgotPassLabel_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            sendEmailPanel.Show();
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) confirm_Click(this, new EventArgs());
        }
        private void codeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ValidCode_Click(this, new EventArgs());
        }
        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) login_Click(this, new EventArgs());
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Escape) exitBtn_Click(this, new EventArgs());
        }
        private void username_Click(object sender, EventArgs e)
        {
            loginInvalid.Hide();
        }
        //
        //




        private void button1_Click(object sender, EventArgs e)
        {
            menu1.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            sendEmailPanel.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changePass1.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            codePanel.Hide();
        }
    }
}
