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
    public partial class Puzzle : UserControl
    {
        int inNullSliceIndex, inmoves = 0;
        List<Bitmap> lstOriginalPictureList = new List<Bitmap>();
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle();
        }
        void Shuffle()
        {
            do
            {
                int j;
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9 });
                Random r = new Random();
                for (int i = 0; i < 9; i++)
                {
                    Indexes.Remove((j = Indexes[r.Next(0, Indexes.Count)]));
                    ((PictureBox)gbPuzzleBox.Controls[i]).Image = lstOriginalPictureList[j];
                    if (j == 9) inNullSliceIndex = i;
                }
            } while (CheckWin());
        }

        private void bShuffle_Click(object sender, EventArgs e)
        {
            DialogResult YesOrNo = new DialogResult();
            if (lblTimeElapsed.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show("Are You Sure To Restart ?", "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (YesOrNo == DialogResult.Yes || lblTimeElapsed.Text == "00:00:00")
            {
                Shuffle();
                timer.Reset();
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                lblMovesMade.Text = "Moves Made : 0";
            }
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            if (bPause.Text == "Pause")
            {
                timer.Stop();
                gbPuzzleBox.Visible = false;
                bPause.Text = "Resume";
            }
            else
            {
                timer.Start();
                gbPuzzleBox.Visible = true;
                bPause.Text = "Pause";
            }
        }
        private void AskPermissionBeforeQuit(object sender, FormClosingEventArgs e)
        {
            DialogResult YesOrNo = MessageBox.Show("Are You Sure To Quit ?", "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sender as Button != bQuit && YesOrNo == DialogResult.No) e.Cancel = true;
            if (sender as Button == bQuit && YesOrNo == DialogResult.Yes) Environment.Exit(0);
        }
        private void bQuit_Click(object sender, EventArgs e)
        {
            AskPermissionBeforeQuit(sender, e as FormClosingEventArgs);
        }
        private void SwitchPictureBox(object sender, EventArgs e)
        {
            if (lblTimeElapsed.Text == "00:00:00") timer.Start();
            int inPictureBoxIndex = gbPuzzleBox.Controls.IndexOf(sender as Control);
            if (inNullSliceIndex != inPictureBoxIndex)
            {
                List<int> FourBrothers = new List<int>(new int[] { ((inPictureBoxIndex % 3 == 0) ? -1 : inPictureBoxIndex - 1), inPictureBoxIndex - 3, (inPictureBoxIndex % 3 == 2) ? -1 : inPictureBoxIndex + 1, inPictureBoxIndex + 3 });
                if (FourBrothers.Contains(inNullSliceIndex))
                {
                    ((PictureBox)gbPuzzleBox.Controls[inNullSliceIndex]).Image = ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image;
                    ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image = lstOriginalPictureList[9];
                    inNullSliceIndex = inPictureBoxIndex;
                    lblMovesMade.Text = "Moves Made: " + (++inmoves);
                    if (CheckWin())
                    {
                        timer.Stop();
                        (gbPuzzleBox.Controls[8] as PictureBox).Image = lstOriginalPictureList[8];
                        MessageBox.Show("Congratulations...\nYour Is Completed\nTime Elapsed : " + timer.Elapsed.ToString().Remove(8) + "\nTotal Moves Made : " + inmoves, "Puzzle");
                        inmoves = 0;
                        lblMovesMade.Text = "Moves Made : 0";
                        lblTimeElapsed.Text = "00:00:00";
                        timer.Reset();
                        Shuffle();
                    }
                }
            }
        }

        bool CheckWin()
        {
            int i;
            bool result;
            result = true;
            for (i = 0; i < 8; i++)
            {
                if ((gbPuzzleBox.Controls[i] as PictureBox).Image != lstOriginalPictureList[i]) result = false;
            }
            return result;
        }

        private void tmrTimeElapse_Tick(object sender, EventArgs e)
        {
            if (timer.Elapsed.ToString() != "00:00:00")
                lblTimeElapsed.Text = timer.Elapsed.ToString().Remove(8);
            if (timer.Elapsed.ToString() == "00:00:00")
                bPause.Enabled = false;
            else bPause.Enabled = true;
            if (timer.Elapsed.Minutes.ToString() == "2")
            {
                timer.Reset();
                lblMovesMade.Text = "Moves Made : 0";
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                bPause.Enabled = false;
                MessageBox.Show("Timer Is Up\nTry Again", "Puzzle");
                Shuffle();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        public Puzzle()
        {
            InitializeComponent();
            lstOriginalPictureList.AddRange(new Bitmap[] { Properties.Resources.image_part_001, Properties.Resources.image_part_002, Properties.Resources.image_part_003, Properties.Resources.image_part_004, Properties.Resources.image_part_005, Properties.Resources.image_part_006, Properties.Resources.image_part_007, Properties.Resources.image_part_008, Properties.Resources.image_part_009,Properties.Resources.wallgrid___Copy });
            lblMovesMade.Text += inmoves;
            lblTimeElapsed.Text = "00:00:00";
        }


    }
}
