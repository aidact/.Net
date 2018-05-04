namespace GRA
{
    partial class Drawing
    {
        internal System.Windows.Forms.MenuItem mnuRectangle;
        internal System.Windows.Forms.MenuItem mnuEllipse;
        internal System.Windows.Forms.MenuItem mnuTriangle;

     
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
            this.mnuRectangle = new System.Windows.Forms.MenuItem();
            this.mnuEllipse = new System.Windows.Forms.MenuItem();
            this.mnuTriangle = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuRectangle
            // 
            this.mnuRectangle.Index = -1;
            this.mnuRectangle.Text = "";
            // 
            // mnuEllipse
            // 
            this.mnuEllipse.Index = -1;
            this.mnuEllipse.Text = "";
            // 
            // mnuTriangle
            // 
            this.mnuTriangle.Index = -1;
            this.mnuTriangle.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(10, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "RECTANGLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 41);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(189, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "CIRCLE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(369, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "TRIANGLE";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Drawing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(556, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Drawing";
            this.Text = "Cool Drawing)))";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;

    }
}

