namespace Projet
{
    partial class spaceInvader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.finishedGame = new System.Windows.Forms.Panel();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.scoreLabel2 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.exitGameLabel = new System.Windows.Forms.Label();
            this.restartGamePicBox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.lettreLabel = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newGameBtn = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.finishedGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restartGamePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // player
            // 
            this.player.Image = global::Projet.Properties.Resources.tank;
            this.player.Location = new System.Drawing.Point(497, 539);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(113, 117);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Tag = "player";
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 14;
            this.label2.Tag = "invaders";
            this.label2.Text = "label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 15;
            this.label3.Tag = "invaders";
            this.label3.Text = "label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(530, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 16;
            this.label4.Tag = "invaders";
            this.label4.Text = "label";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(866, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 24);
            this.label5.TabIndex = 17;
            this.label5.Tag = "invaders";
            this.label5.Text = "label";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(698, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 24);
            this.label6.TabIndex = 18;
            this.label6.Tag = "invaders";
            this.label6.Text = "label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 19;
            this.label1.Tag = "invaders";
            this.label1.Text = "label";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 30000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // finishedGame
            // 
            this.finishedGame.BackColor = System.Drawing.Color.White;
            this.finishedGame.Controls.Add(this.highScoreLabel);
            this.finishedGame.Controls.Add(this.scoreLabel2);
            this.finishedGame.Controls.Add(this.resultLabel);
            this.finishedGame.Controls.Add(this.exitGameLabel);
            this.finishedGame.Controls.Add(this.restartGamePicBox);
            this.finishedGame.Location = new System.Drawing.Point(128, 174);
            this.finishedGame.Name = "finishedGame";
            this.finishedGame.Size = new System.Drawing.Size(787, 301);
            this.finishedGame.TabIndex = 24;
            this.finishedGame.Visible = false;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highScoreLabel.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(199, 113);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(151, 37);
            this.highScoreLabel.TabIndex = 18;
            this.highScoreLabel.Text = "HighScore";
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.AutoSize = true;
            this.scoreLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scoreLabel2.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel2.Location = new System.Drawing.Point(199, 76);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(92, 37);
            this.scoreLabel2.TabIndex = 17;
            this.scoreLabel2.Text = "Score";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultLabel.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(136, 39);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(328, 37);
            this.resultLabel.TabIndex = 16;
            this.resultLabel.Text = "Le jeux est terminé !";
            // 
            // exitGameLabel
            // 
            this.exitGameLabel.AutoSize = true;
            this.exitGameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitGameLabel.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitGameLabel.ForeColor = System.Drawing.Color.Red;
            this.exitGameLabel.Location = new System.Drawing.Point(369, 175);
            this.exitGameLabel.Name = "exitGameLabel";
            this.exitGameLabel.Size = new System.Drawing.Size(123, 37);
            this.exitGameLabel.TabIndex = 15;
            this.exitGameLabel.Text = "Quitter";
            this.exitGameLabel.Click += new System.EventHandler(this.exitGameLabel_Click);
            // 
            // restartGamePicBox
            // 
            this.restartGamePicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartGamePicBox.Image = global::Projet.Properties.Resources.icons8_restart_321;
            this.restartGamePicBox.Location = new System.Drawing.Point(230, 166);
            this.restartGamePicBox.Name = "restartGamePicBox";
            this.restartGamePicBox.Size = new System.Drawing.Size(57, 52);
            this.restartGamePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.restartGamePicBox.TabIndex = 0;
            this.restartGamePicBox.TabStop = false;
            this.restartGamePicBox.Click += new System.EventHandler(this.restartGamePicBox_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.White;
            this.scoreLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Blue;
            this.scoreLabel.Location = new System.Drawing.Point(959, 96);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(125, 31);
            this.scoreLabel.TabIndex = 13;
            this.scoreLabel.Tag = "ll";
            this.scoreLabel.Text = "Score:00";
            // 
            // lettreLabel
            // 
            this.lettreLabel.AutoSize = true;
            this.lettreLabel.BackColor = System.Drawing.Color.White;
            this.lettreLabel.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lettreLabel.ForeColor = System.Drawing.Color.Blue;
            this.lettreLabel.Location = new System.Drawing.Point(48, 4);
            this.lettreLabel.Name = "lettreLabel";
            this.lettreLabel.Size = new System.Drawing.Size(100, 37);
            this.lettreLabel.TabIndex = 23;
            this.lettreLabel.Tag = "ll";
            this.lettreLabel.Text = "lettre";
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(13, 14);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 95;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.newGameBtn);
            this.panel1.Controls.Add(this.startLabel);
            this.panel1.Location = new System.Drawing.Point(131, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 301);
            this.panel1.TabIndex = 96;
            // 
            // newGameBtn
            // 
            this.newGameBtn.AutoSize = true;
            this.newGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newGameBtn.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameBtn.Location = new System.Drawing.Point(175, 46);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(420, 37);
            this.newGameBtn.TabIndex = 16;
            this.newGameBtn.Text = "Appuyer ici pour commencer";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startLabel.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Red;
            this.startLabel.Location = new System.Drawing.Point(294, 107);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(173, 37);
            this.startLabel.TabIndex = 15;
            this.startLabel.Text = "Commencer";
            this.startLabel.Click += new System.EventHandler(this.startLabel_Click);
            // 
            // spaceInvader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.lettreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.finishedGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player);
            this.Name = "spaceInvader";
            this.Size = new System.Drawing.Size(1085, 724);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spaceInvader_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.spaceInvader_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.finishedGame.ResumeLayout(false);
            this.finishedGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restartGamePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Panel finishedGame;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label scoreLabel2;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label exitGameLabel;
        private System.Windows.Forms.PictureBox restartGamePicBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label lettreLabel;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label newGameBtn;
        private System.Windows.Forms.Label startLabel;
    }
}
