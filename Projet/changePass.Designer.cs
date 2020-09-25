namespace Projet
{
    partial class changePass
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
            this.p = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pinvalid = new System.Windows.Forms.Label();
            this.pnotconf = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.Color.White;
            this.p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.p.Font = new System.Drawing.Font("Comic Sans MS", 16.2F);
            this.p.ForeColor = System.Drawing.Color.Black;
            this.p.Location = new System.Drawing.Point(105, 172);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(245, 38);
            this.p.TabIndex = 152;
            this.p.Click += new System.EventHandler(this.p_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Projet.Properties.Resources.icons8_lock_32__1_;
            this.pictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox5.Location = new System.Drawing.Point(60, 171);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 42);
            this.pictureBox5.TabIndex = 153;
            this.pictureBox5.TabStop = false;
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.p2.Font = new System.Drawing.Font("Comic Sans MS", 16.2F);
            this.p2.ForeColor = System.Drawing.Color.Black;
            this.p2.Location = new System.Drawing.Point(110, 234);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(250, 38);
            this.p2.TabIndex = 154;
            this.p2.Click += new System.EventHandler(this.p_Click);
            this.p2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p2_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Projet.Properties.Resources.icons8_lock_32__1_;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(61, 233);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 42);
            this.pictureBox1.TabIndex = 155;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(101, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 19);
            this.label8.TabIndex = 156;
            this.label8.Text = "Nouveau mot de passe :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 19);
            this.label9.TabIndex = 157;
            this.label9.Text = "Confirmer le mot de passe :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(105, 213);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 1);
            this.panel5.TabIndex = 158;
            // 
            // pinvalid
            // 
            this.pinvalid.AutoSize = true;
            this.pinvalid.ForeColor = System.Drawing.Color.Red;
            this.pinvalid.Location = new System.Drawing.Point(111, 275);
            this.pinvalid.Name = "pinvalid";
            this.pinvalid.Size = new System.Drawing.Size(249, 17);
            this.pinvalid.TabIndex = 160;
            this.pinvalid.Text = "Mot de pass invalid(minimum 5 caract)";
            this.pinvalid.Visible = false;
            // 
            // pnotconf
            // 
            this.pnotconf.AutoSize = true;
            this.pnotconf.ForeColor = System.Drawing.Color.Red;
            this.pnotconf.Location = new System.Drawing.Point(171, 275);
            this.pnotconf.Name = "pnotconf";
            this.pnotconf.Size = new System.Drawing.Size(187, 17);
            this.pnotconf.TabIndex = 159;
            this.pnotconf.Text = "Confirmer vos mot de passe!";
            this.pnotconf.Visible = false;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.White;
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("Comic Sans MS", 13.8F);
            this.confirm.ForeColor = System.Drawing.Color.Black;
            this.confirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confirm.Location = new System.Drawing.Point(114, 304);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(193, 45);
            this.confirm.TabIndex = 161;
            this.confirm.Text = "Valider";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(108, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 1);
            this.panel1.TabIndex = 162;
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(17, 14);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 163;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // changePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.pinvalid);
            this.Controls.Add(this.pnotconf);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.p);
            this.Name = "changePass";
            this.Size = new System.Drawing.Size(412, 532);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox p;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox p2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label pinvalid;
        private System.Windows.Forms.Label pnotconf;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox back;
    }
}
