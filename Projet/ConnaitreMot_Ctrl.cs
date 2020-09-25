using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Data;

namespace Projet
{
    public partial class connaitremot_Ctrl : UserControl
    {
        
        public static Random n = new Random();
        public connaitremot_Ctrl()
        {
            InitializeComponent();
            label2.Text = erreur.ToString();
        }

     
       
        public static string s;
        int erreur = 0, juste = 0;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            searchmaths.searchPays(out s);
            for (int k = 0; k < panel2.Controls.Count; k++) panel2.Controls[k].Enabled = true; //ma 3m tzbt
            for (int i = 0; i < s.Length; i++)
            {

                juste = 0;
                erreur = 0;
                Label l = new Label();
                l.Tag = s[i].ToString();
                l.Size = new Size(20, 20);
                l.BackColor = Color.White;
                l.Location = new Point(10 + i * 30, 10);
                l.Text = "_";
                panel1.Controls.Add(l);
            }
            panel2.Enabled = true; ;
            label2.Visible = true;
            
            panel2.Visible = true;
            label2.Text = erreur.ToString();

        }

        private void p_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (s.IndexOf(b.Text[0]) == -1) { erreur++; label2.Text = erreur.ToString(); b.Enabled = false; if (erreur == s.Length + 1) { MessageBox.Show("YOU LOST"); panel2.Enabled = false; } }
            else
            {
                for (int i = 0; i < panel1.Controls.Count; i++) if (panel1.Controls[i].Tag.ToString()[0] == b.Text[0])
                    {
                        panel1.Controls[i].Text = panel1.Controls[i].Tag.ToString();
                        juste++;

                        b.Enabled = false;
                        if (juste == s.Length) { MessageBox.Show("YOU WON"); panel2.Enabled = false; }
                    }
            }

        }
        int j = 0;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            j++;
            if (j % 2 == 1) panel2.Enabled = false;
            else panel2.Enabled = true;

        }









    }
}
