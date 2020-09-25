using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class Logic_Ctrl : UserControl
    {
        public Logic_Ctrl()
        {
            InitializeComponent();
        }

        private void Logic_Ctrl_Load(object sender, EventArgs e)
        {

        }

        private void BPuzzle_Click(object sender, EventArgs e)
        {
            Puzzle puzzle = new Puzzle();
            this.Controls.Add(puzzle);
            puzzle.Location = new Point(50, 70);
            puzzle.BringToFront();
        }

        private void BMemoire_Click(object sender, EventArgs e)
        {
            Memoire_Ctrl memoire = new Memoire_Ctrl();
           
            this.Controls.Add(memoire);
            memoire.BringToFront();
        }

        private void BConaitremot_Click(object sender, EventArgs e)
        {
            connaitremot_Ctrl Connaitmot = new connaitremot_Ctrl();
            Connaitmot.Location = new Point(50, 100);
            this.Controls.Add(Connaitmot);
            Connaitmot.BringToFront();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        private void logBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Projet.Properties.Resources._235766b43f9706e;
            btn.Text = "";
            btn.BackColor = Color.Transparent;
        }
        private void mathBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.Font = new Font("Comic Sans ms", 15);
            btn.Text = btn.Tag.ToString();


        }
    }
}
