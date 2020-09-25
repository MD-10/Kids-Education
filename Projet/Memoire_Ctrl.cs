using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet
{
    public partial class Memoire_Ctrl : UserControl
    {
        Random n = new Random();
      
        Label labelcl1, labelcl2;

        public Memoire_Ctrl()
        {
            InitializeComponent();
            AssignIconsToSquare();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (labelcl1 != null && labelcl2 != null)
                return;
            Label ClickedLabel = sender as Label;
            if (ClickedLabel == null)
                return;
            if (ClickedLabel.ForeColor == Color.Black)
                return;
            if (labelcl1 == null)
            {
                labelcl1 = ClickedLabel;
                labelcl1.ForeColor = Color.Black;
                return;
            }
            labelcl2 = ClickedLabel;
            labelcl2.ForeColor = Color.Black;

            CheckWinner();

            if (labelcl1.Text == labelcl2.Text)
            {
                labelcl1 = null;
                labelcl2 = null;
            }
            else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            labelcl1.ForeColor = labelcl1.BackColor;
            labelcl2.ForeColor = labelcl2.BackColor;
            labelcl1 = null;
            labelcl2 = null;

        }

        private void CheckWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            restartPicBox.Show();

        }

        private void restartPicBox_Click(object sender, EventArgs e)
        {
           
          
            restartPicBox.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        public void AssignIconsToSquare()
        {
            List<string> image = new List<string>()
        {
            "g","g","m","m","v","v","x","x","t","t","p","p","q","q","a","a"

        };
            Label label;
            int randomNumber;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = n.Next(0, image.Count);
                label.Text = image[randomNumber];
                image.RemoveAt(randomNumber);

            }


        }

    }
}
