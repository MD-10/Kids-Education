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
using Data;
namespace Projet
{
    public partial class changePass : UserControl
    {
        public changePass()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            SoundPlayer clickSound = new SoundPlayer(@"../../../media/tick.wav");
            clickSound.Play();
            bool c = (p.Text != p2.Text ? true : false), pp = false;
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
            if (pp == true)
            {
                Search.ChangeForgtnPass(Form1.row,p.Text.Trim());
                MessageBox.Show("Le mot de pass a éte changé!.Maintenant vous pouvez se connecter en utilisant le nouveau mot de passe");
                this.Hide();
            }
            
        }

        private void p2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) confirm_Click(this, new EventArgs());
        }

        private void p_Click(object sender, EventArgs e)
        {
            pinvalid.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
