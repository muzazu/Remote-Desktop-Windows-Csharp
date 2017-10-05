namespace aplikasi_remote
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.max = new System.Windows.Forms.Label();
            this.warn = new System.Windows.Forms.Label();
            this.sound = new System.Windows.Forms.Label();
            this.dc = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(619, 404);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pic_click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.max);
            this.panel1.Controls.Add(this.warn);
            this.panel1.Controls.Add(this.sound);
            this.panel1.Controls.Add(this.dc);
            this.panel1.Location = new System.Drawing.Point(142, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 34);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.BackColor = System.Drawing.Color.Silver;
            this.max.Cursor = System.Windows.Forms.Cursors.Hand;
            this.max.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max.Location = new System.Drawing.Point(326, 8);
            this.max.Name = "max";
            this.max.Padding = new System.Windows.Forms.Padding(3);
            this.max.Size = new System.Drawing.Size(33, 19);
            this.max.TabIndex = 2;
            this.max.Text = "Max";
            this.max.Click += new System.EventHandler(this.max_Click);
            // 
            // warn
            // 
            this.warn.AutoSize = true;
            this.warn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.warn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.warn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.warn.Location = new System.Drawing.Point(165, 8);
            this.warn.Name = "warn";
            this.warn.Padding = new System.Windows.Forms.Padding(3);
            this.warn.Size = new System.Drawing.Size(81, 19);
            this.warn.TabIndex = 3;
            this.warn.Text = "Send Warning";
            this.warn.Click += new System.EventHandler(this.warn_Click);
            // 
            // sound
            // 
            this.sound.AutoSize = true;
            this.sound.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sound.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sound.Location = new System.Drawing.Point(252, 8);
            this.sound.Name = "sound";
            this.sound.Padding = new System.Windows.Forms.Padding(3);
            this.sound.Size = new System.Drawing.Size(56, 19);
            this.sound.TabIndex = 2;
            this.sound.Text = "♫ Sound";
            this.sound.Click += new System.EventHandler(this.sound_Click);
            // 
            // dc
            // 
            this.dc.AutoSize = true;
            this.dc.BackColor = System.Drawing.Color.OrangeRed;
            this.dc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dc.Location = new System.Drawing.Point(12, 9);
            this.dc.Name = "dc";
            this.dc.Padding = new System.Windows.Forms.Padding(3);
            this.dc.Size = new System.Drawing.Size(67, 19);
            this.dc.TabIndex = 0;
            this.dc.Text = "Disconnect";
            this.dc.Click += new System.EventHandler(this.dc_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 34);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyform);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(124, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label1.Size = new System.Drawing.Size(21, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "H";
            this.label1.Click += new System.EventHandler(this.btnhide_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 404);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(619, 404);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyform);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label warn;
        private System.Windows.Forms.Label sound;
        private System.Windows.Forms.Label dc;
        private System.Windows.Forms.Label max;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}