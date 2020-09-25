namespace Projet
{
    partial class dicteeExCtrl
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.soundPhrase1Pause = new System.Windows.Forms.PictureBox();
            this.soundPhrase1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1Pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(863, 485);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(109, 51);
            this.confirmBtn.TabIndex = 3;
            this.confirmBtn.Text = "Confirmer";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 39);
            this.label1.TabIndex = 211;
            this.label1.Text = "Ranger les mots comme vous l\'entandez!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 33);
            this.label2.TabIndex = 212;
            this.label2.Text = "Appuyer ici pour commencer le son!";
            // 
            // nextBtn
            // 
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.Image = global::Projet.Properties.Resources.icons8_double_right_filled_50;
            this.nextBtn.Location = new System.Drawing.Point(975, 354);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(51, 50);
            this.nextBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextBtn.TabIndex = 213;
            this.nextBtn.TabStop = false;
            this.nextBtn.Visible = false;
            this.nextBtn.Click += new System.EventHandler(this.Next_Click);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(3, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 210;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // soundPhrase1Pause
            // 
            this.soundPhrase1Pause.Image = global::Projet.Properties.Resources.icons8_pause_button_32;
            this.soundPhrase1Pause.Location = new System.Drawing.Point(476, 75);
            this.soundPhrase1Pause.Name = "soundPhrase1Pause";
            this.soundPhrase1Pause.Size = new System.Drawing.Size(58, 53);
            this.soundPhrase1Pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundPhrase1Pause.TabIndex = 209;
            this.soundPhrase1Pause.TabStop = false;
            this.soundPhrase1Pause.Visible = false;
            this.soundPhrase1Pause.Click += new System.EventHandler(this.soundPhrase1Pause_Click);
            // 
            // soundPhrase1
            // 
            this.soundPhrase1.Image = global::Projet.Properties.Resources.icons8_play_32;
            this.soundPhrase1.Location = new System.Drawing.Point(476, 75);
            this.soundPhrase1.Name = "soundPhrase1";
            this.soundPhrase1.Size = new System.Drawing.Size(58, 53);
            this.soundPhrase1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundPhrase1.TabIndex = 208;
            this.soundPhrase1.TabStop = false;
            this.soundPhrase1.Click += new System.EventHandler(this.soundPhrase1_Click);
            // 
            // dicteeExCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.soundPhrase1Pause);
            this.Controls.Add(this.soundPhrase1);
            this.Controls.Add(this.confirmBtn);
            this.Name = "dicteeExCtrl";
            this.Size = new System.Drawing.Size(1127, 548);
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1Pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.PictureBox soundPhrase1Pause;
        private System.Windows.Forms.PictureBox soundPhrase1;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox nextBtn;
    }
}

