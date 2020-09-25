namespace Projet
{
    partial class CompteEstBon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompteEstBon));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelgame = new System.Windows.Forms.Panel();
            this.opx = new System.Windows.Forms.Button();
            this.opadd = new System.Windows.Forms.Button();
            this.opsous = new System.Windows.Forms.Button();
            this.opdiv = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.lScoreAct = new System.Windows.Forms.Label();
            this.lScoreFinale = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.PictureBox();
            this.ballon1 = new Ballon();
            this.ballon4 = new Ballon();
            this.ballon2 = new Ballon();
            this.ballon3 = new Ballon();
            this.panelgame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelgame
            // 
            this.panelgame.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelgame.Controls.Add(this.ballon1);
            this.panelgame.Controls.Add(this.ballon4);
            this.panelgame.Controls.Add(this.ballon2);
            this.panelgame.Controls.Add(this.ballon3);
            this.panelgame.Location = new System.Drawing.Point(67, 43);
            this.panelgame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelgame.Name = "panelgame";
            this.panelgame.Size = new System.Drawing.Size(800, 431);
            this.panelgame.TabIndex = 4;
            // 
            // opx
            // 
            this.opx.BackgroundImage = global::Projet.Properties.Resources.fishCompteEstBon;
            this.opx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opx.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opx.Location = new System.Drawing.Point(153, 497);
            this.opx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opx.Name = "opx";
            this.opx.Size = new System.Drawing.Size(99, 73);
            this.opx.TabIndex = 5;
            this.opx.Text = "x";
            this.opx.UseVisualStyleBackColor = true;
            this.opx.Click += new System.EventHandler(this.opx_Click);
            // 
            // opadd
            // 
            this.opadd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opadd.BackgroundImage")));
            this.opadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opadd.Location = new System.Drawing.Point(316, 497);
            this.opadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opadd.Name = "opadd";
            this.opadd.Size = new System.Drawing.Size(99, 73);
            this.opadd.TabIndex = 6;
            this.opadd.Text = "+";
            this.opadd.UseVisualStyleBackColor = true;
            this.opadd.Click += new System.EventHandler(this.opx_Click);
            // 
            // opsous
            // 
            this.opsous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opsous.BackgroundImage")));
            this.opsous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opsous.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opsous.Location = new System.Drawing.Point(480, 497);
            this.opsous.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opsous.Name = "opsous";
            this.opsous.Size = new System.Drawing.Size(99, 73);
            this.opsous.TabIndex = 7;
            this.opsous.Text = "-";
            this.opsous.UseVisualStyleBackColor = true;
            this.opsous.Click += new System.EventHandler(this.opx_Click);
            // 
            // opdiv
            // 
            this.opdiv.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opdiv.BackgroundImage")));
            this.opdiv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opdiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opdiv.Location = new System.Drawing.Point(645, 497);
            this.opdiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opdiv.Name = "opdiv";
            this.opdiv.Size = new System.Drawing.Size(99, 73);
            this.opdiv.TabIndex = 8;
            this.opdiv.Text = "÷";
            this.opdiv.UseVisualStyleBackColor = true;
            this.opdiv.Click += new System.EventHandler(this.opx_Click);
            // 
            // bOK
            // 
            this.bOK.BackColor = System.Drawing.Color.Teal;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOK.Location = new System.Drawing.Point(895, 230);
            this.bOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(101, 68);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = false;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lScoreAct
            // 
            this.lScoreAct.AutoSize = true;
            this.lScoreAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScoreAct.Location = new System.Drawing.Point(891, 411);
            this.lScoreAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScoreAct.Name = "lScoreAct";
            this.lScoreAct.Size = new System.Drawing.Size(29, 31);
            this.lScoreAct.TabIndex = 10;
            this.lScoreAct.Text = "0";
            // 
            // lScoreFinale
            // 
            this.lScoreFinale.AutoSize = true;
            this.lScoreFinale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScoreFinale.Location = new System.Drawing.Point(875, 79);
            this.lScoreFinale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScoreFinale.Name = "lScoreFinale";
            this.lScoreFinale.Size = new System.Drawing.Size(131, 31);
            this.lScoreFinale.TabIndex = 11;
            this.lScoreFinale.Text = "finalscore";
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Projet.Properties.Resources.icons8_left_24;
            this.back.Location = new System.Drawing.Point(3, 17);
            this.back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(41, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 186;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ballon1
            // 
            this.ballon1.BackColor = System.Drawing.Color.Transparent;
            this.ballon1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ballon1.Image = ((System.Drawing.Image)(resources.GetObject("ballon1.Image")));
            this.ballon1.Location = new System.Drawing.Point(532, 117);
            this.ballon1.Margin = new System.Windows.Forms.Padding(4);
            this.ballon1.Name = "ballon1";
            this.ballon1.Size = new System.Drawing.Size(107, 98);
            this.ballon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballon1.TabIndex = 6;
            this.ballon1.TabStop = false;
            this.ballon1.Click += new System.EventHandler(this.ballon2_Click);
            // 
            // ballon4
            // 
            this.ballon4.BackColor = System.Drawing.Color.Transparent;
            this.ballon4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ballon4.Image = ((System.Drawing.Image)(resources.GetObject("ballon4.Image")));
            this.ballon4.Location = new System.Drawing.Point(115, 162);
            this.ballon4.Margin = new System.Windows.Forms.Padding(4);
            this.ballon4.Name = "ballon4";
            this.ballon4.Size = new System.Drawing.Size(107, 98);
            this.ballon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballon4.TabIndex = 5;
            this.ballon4.TabStop = false;
            this.ballon4.Click += new System.EventHandler(this.ballon2_Click);
            // 
            // ballon2
            // 
            this.ballon2.BackColor = System.Drawing.Color.Transparent;
            this.ballon2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ballon2.Image = ((System.Drawing.Image)(resources.GetObject("ballon2.Image")));
            this.ballon2.Location = new System.Drawing.Point(256, 87);
            this.ballon2.Margin = new System.Windows.Forms.Padding(4);
            this.ballon2.Name = "ballon2";
            this.ballon2.Size = new System.Drawing.Size(107, 98);
            this.ballon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballon2.TabIndex = 4;
            this.ballon2.TabStop = false;
            this.ballon2.Click += new System.EventHandler(this.ballon2_Click);
            // 
            // ballon3
            // 
            this.ballon3.BackColor = System.Drawing.Color.Transparent;
            this.ballon3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ballon3.Image = ((System.Drawing.Image)(resources.GetObject("ballon3.Image")));
            this.ballon3.Location = new System.Drawing.Point(353, 218);
            this.ballon3.Margin = new System.Windows.Forms.Padding(4);
            this.ballon3.Name = "ballon3";
            this.ballon3.Size = new System.Drawing.Size(107, 98);
            this.ballon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballon3.TabIndex = 3;
            this.ballon3.TabStop = false;
            this.ballon3.Click += new System.EventHandler(this.ballon2_Click);
            // 
            // CompteEstBon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.back);
            this.Controls.Add(this.lScoreFinale);
            this.Controls.Add(this.lScoreAct);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.opdiv);
            this.Controls.Add(this.opsous);
            this.Controls.Add(this.opadd);
            this.Controls.Add(this.opx);
            this.Controls.Add(this.panelgame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CompteEstBon";
            this.Size = new System.Drawing.Size(1027, 597);
            this.panelgame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelgame;
        private Ballon ballon4;
        private Ballon ballon2;
        private Ballon ballon3;
        private Ballon ballon1;
        private System.Windows.Forms.Button opx;
        private System.Windows.Forms.Button opadd;
        private System.Windows.Forms.Button opsous;
        private System.Windows.Forms.Button opdiv;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label lScoreAct;
        private System.Windows.Forms.Label lScoreFinale;
        public System.Windows.Forms.PictureBox back;
    }
}

