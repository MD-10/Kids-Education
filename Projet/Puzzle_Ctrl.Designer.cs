namespace Projet
{
    partial class Puzzle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Puzzle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bQuit = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.bShuffle = new System.Windows.Forms.Button();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.gbOriginal = new System.Windows.Forms.GroupBox();
            this.lblMovesMade = new System.Windows.Forms.Label();
            this.gbPuzzleBox = new System.Windows.Forms.GroupBox();
            this.pbx1 = new System.Windows.Forms.PictureBox();
            this.pbx2 = new System.Windows.Forms.PictureBox();
            this.pbx3 = new System.Windows.Forms.PictureBox();
            this.pbx4 = new System.Windows.Forms.PictureBox();
            this.pbx5 = new System.Windows.Forms.PictureBox();
            this.pbx6 = new System.Windows.Forms.PictureBox();
            this.pbx7 = new System.Windows.Forms.PictureBox();
            this.pbx8 = new System.Windows.Forms.PictureBox();
            this.pbx9 = new System.Windows.Forms.PictureBox();
            this.tmrTimeElapse = new System.Windows.Forms.Timer(this.components);
            this.back = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gbPuzzleBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bQuit);
            this.panel1.Controls.Add(this.bPause);
            this.panel1.Controls.Add(this.bShuffle);
            this.panel1.Controls.Add(this.lblTimeElapsed);
            this.panel1.Controls.Add(this.gbOriginal);
            this.panel1.Controls.Add(this.lblMovesMade);
            this.panel1.Controls.Add(this.gbPuzzleBox);
            this.panel1.Location = new System.Drawing.Point(68, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 519);
            this.panel1.TabIndex = 0;
            // 
            // bQuit
            // 
            this.bQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bQuit.Location = new System.Drawing.Point(921, 407);
            this.bQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(100, 62);
            this.bQuit.TabIndex = 6;
            this.bQuit.Text = "Quit";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // bPause
            // 
            this.bPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPause.Location = new System.Drawing.Point(749, 407);
            this.bPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(121, 62);
            this.bPause.TabIndex = 5;
            this.bPause.Text = "Pause";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // bShuffle
            // 
            this.bShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShuffle.Location = new System.Drawing.Point(593, 407);
            this.bShuffle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bShuffle.Name = "bShuffle";
            this.bShuffle.Size = new System.Drawing.Size(100, 62);
            this.bShuffle.TabIndex = 4;
            this.bShuffle.Text = "Shuffle";
            this.bShuffle.UseVisualStyleBackColor = true;
            this.bShuffle.Click += new System.EventHandler(this.bShuffle_Click);
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeElapsed.Location = new System.Drawing.Point(724, 338);
            this.lblTimeElapsed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(182, 46);
            this.lblTimeElapsed.TabIndex = 3;
            this.lblTimeElapsed.Text = "00:00:00";
            // 
            // gbOriginal
            // 
            this.gbOriginal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbOriginal.BackgroundImage")));
            this.gbOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbOriginal.Location = new System.Drawing.Point(624, 26);
            this.gbOriginal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOriginal.Name = "gbOriginal";
            this.gbOriginal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOriginal.Size = new System.Drawing.Size(369, 305);
            this.gbOriginal.TabIndex = 2;
            this.gbOriginal.TabStop = false;
            // 
            // lblMovesMade
            // 
            this.lblMovesMade.AutoSize = true;
            this.lblMovesMade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesMade.ForeColor = System.Drawing.Color.Red;
            this.lblMovesMade.Location = new System.Drawing.Point(31, 482);
            this.lblMovesMade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovesMade.Name = "lblMovesMade";
            this.lblMovesMade.Size = new System.Drawing.Size(187, 31);
            this.lblMovesMade.TabIndex = 1;
            this.lblMovesMade.Text = "Moves Made:";
            // 
            // gbPuzzleBox
            // 
            this.gbPuzzleBox.Controls.Add(this.pbx1);
            this.gbPuzzleBox.Controls.Add(this.pbx2);
            this.gbPuzzleBox.Controls.Add(this.pbx3);
            this.gbPuzzleBox.Controls.Add(this.pbx4);
            this.gbPuzzleBox.Controls.Add(this.pbx5);
            this.gbPuzzleBox.Controls.Add(this.pbx6);
            this.gbPuzzleBox.Controls.Add(this.pbx7);
            this.gbPuzzleBox.Controls.Add(this.pbx8);
            this.gbPuzzleBox.Controls.Add(this.pbx9);
            this.gbPuzzleBox.Location = new System.Drawing.Point(37, 15);
            this.gbPuzzleBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPuzzleBox.Name = "gbPuzzleBox";
            this.gbPuzzleBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPuzzleBox.Size = new System.Drawing.Size(520, 443);
            this.gbPuzzleBox.TabIndex = 0;
            this.gbPuzzleBox.TabStop = false;
            // 
            // pbx1
            // 
            this.pbx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx1.Location = new System.Drawing.Point(8, 23);
            this.pbx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx1.Name = "pbx1";
            this.pbx1.Size = new System.Drawing.Size(161, 127);
            this.pbx1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx1.TabIndex = 0;
            this.pbx1.TabStop = false;
            this.pbx1.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx2
            // 
            this.pbx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx2.Location = new System.Drawing.Point(177, 23);
            this.pbx2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx2.Name = "pbx2";
            this.pbx2.Size = new System.Drawing.Size(161, 127);
            this.pbx2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx2.TabIndex = 1;
            this.pbx2.TabStop = false;
            this.pbx2.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx3
            // 
            this.pbx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx3.Location = new System.Drawing.Point(351, 23);
            this.pbx3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx3.Name = "pbx3";
            this.pbx3.Size = new System.Drawing.Size(161, 127);
            this.pbx3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx3.TabIndex = 2;
            this.pbx3.TabStop = false;
            this.pbx3.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx4
            // 
            this.pbx4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx4.Location = new System.Drawing.Point(8, 158);
            this.pbx4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx4.Name = "pbx4";
            this.pbx4.Size = new System.Drawing.Size(161, 127);
            this.pbx4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx4.TabIndex = 3;
            this.pbx4.TabStop = false;
            this.pbx4.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx5
            // 
            this.pbx5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx5.Location = new System.Drawing.Point(177, 158);
            this.pbx5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx5.Name = "pbx5";
            this.pbx5.Size = new System.Drawing.Size(161, 127);
            this.pbx5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx5.TabIndex = 4;
            this.pbx5.TabStop = false;
            this.pbx5.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx6
            // 
            this.pbx6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx6.Location = new System.Drawing.Point(351, 158);
            this.pbx6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx6.Name = "pbx6";
            this.pbx6.Size = new System.Drawing.Size(161, 127);
            this.pbx6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx6.TabIndex = 5;
            this.pbx6.TabStop = false;
            this.pbx6.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx7
            // 
            this.pbx7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx7.Location = new System.Drawing.Point(8, 292);
            this.pbx7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx7.Name = "pbx7";
            this.pbx7.Size = new System.Drawing.Size(161, 127);
            this.pbx7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx7.TabIndex = 6;
            this.pbx7.TabStop = false;
            this.pbx7.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx8
            // 
            this.pbx8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx8.Location = new System.Drawing.Point(177, 292);
            this.pbx8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx8.Name = "pbx8";
            this.pbx8.Size = new System.Drawing.Size(161, 127);
            this.pbx8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx8.TabIndex = 7;
            this.pbx8.TabStop = false;
            this.pbx8.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // pbx9
            // 
            this.pbx9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx9.Location = new System.Drawing.Point(347, 292);
            this.pbx9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx9.Name = "pbx9";
            this.pbx9.Size = new System.Drawing.Size(161, 127);
            this.pbx9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx9.TabIndex = 8;
            this.pbx9.TabStop = false;
            this.pbx9.Click += new System.EventHandler(this.SwitchPictureBox);
            // 
            // tmrTimeElapse
            // 
            this.tmrTimeElapse.Enabled = true;
            this.tmrTimeElapse.Interval = 900;
            this.tmrTimeElapse.Tick += new System.EventHandler(this.tmrTimeElapse_Tick);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(20, 30);
            this.back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 148;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Puzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Puzzle";
            this.Size = new System.Drawing.Size(1140, 603);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPuzzleBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bQuit;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Button bShuffle;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.GroupBox gbOriginal;
        private System.Windows.Forms.Label lblMovesMade;
        private System.Windows.Forms.GroupBox gbPuzzleBox;
        private System.Windows.Forms.PictureBox pbx9;
        private System.Windows.Forms.PictureBox pbx8;
        private System.Windows.Forms.PictureBox pbx7;
        private System.Windows.Forms.PictureBox pbx4;
        private System.Windows.Forms.PictureBox pbx6;
        private System.Windows.Forms.PictureBox pbx5;
        private System.Windows.Forms.PictureBox pbx3;
        private System.Windows.Forms.PictureBox pbx2;
        private System.Windows.Forms.PictureBox pbx1;
        private System.Windows.Forms.Timer tmrTimeElapse;
        public System.Windows.Forms.PictureBox back;
    }
}

