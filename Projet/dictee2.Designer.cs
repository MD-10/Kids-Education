namespace Projet
{
    partial class dictee2
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.soundPhrase1Pause = new System.Windows.Forms.PictureBox();
            this.soundPhrase1 = new System.Windows.Forms.PictureBox();
            this.nextBtn = new System.Windows.Forms.PictureBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1Pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 156);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(464, 48);
            this.textBox2.TabIndex = 2;
            // 
            // soundPhrase1Pause
            // 
            this.soundPhrase1Pause.Image = global::Projet.Properties.Resources.icons8_pause_button_32;
            this.soundPhrase1Pause.Location = new System.Drawing.Point(290, 25);
            this.soundPhrase1Pause.Name = "soundPhrase1Pause";
            this.soundPhrase1Pause.Size = new System.Drawing.Size(58, 53);
            this.soundPhrase1Pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundPhrase1Pause.TabIndex = 211;
            this.soundPhrase1Pause.TabStop = false;
            this.soundPhrase1Pause.Visible = false;
            this.soundPhrase1Pause.Click += new System.EventHandler(this.soundPhrase1Pause_Click);
            // 
            // soundPhrase1
            // 
            this.soundPhrase1.Image = global::Projet.Properties.Resources.icons8_play_32;
            this.soundPhrase1.Location = new System.Drawing.Point(290, 25);
            this.soundPhrase1.Name = "soundPhrase1";
            this.soundPhrase1.Size = new System.Drawing.Size(58, 53);
            this.soundPhrase1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundPhrase1.TabIndex = 210;
            this.soundPhrase1.TabStop = false;
            this.soundPhrase1.Click += new System.EventHandler(this.soundPhrase1_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.Image = global::Projet.Properties.Resources.icons8_double_right_filled_50;
            this.nextBtn.Location = new System.Drawing.Point(670, 210);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(51, 50);
            this.nextBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextBtn.TabIndex = 215;
            this.nextBtn.TabStop = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(443, 344);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(109, 51);
            this.confirmBtn.TabIndex = 214;
            this.confirmBtn.Text = "Confirmer";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(13, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 216;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // dictee2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.soundPhrase1Pause);
            this.Controls.Add(this.soundPhrase1);
            this.Controls.Add(this.textBox2);
            this.Name = "dictee2";
            this.Size = new System.Drawing.Size(800, 486);
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1Pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPhrase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox soundPhrase1Pause;
        private System.Windows.Forms.PictureBox soundPhrase1;
        private System.Windows.Forms.PictureBox nextBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.PictureBox back;
    }
}

