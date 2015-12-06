namespace Digital_Circuit
{
    partial class Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manual));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btopen = new System.Windows.Forms.Button();
            this.btopenTXT = new System.Windows.Forms.Button();
            this.btopenPDF = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.Color.Maroon;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(-1, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(895, 360);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // btopen
            // 
            this.btopen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopen.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopen.Location = new System.Drawing.Point(454, 4);
            this.btopen.Name = "btopen";
            this.btopen.Size = new System.Drawing.Size(185, 29);
            this.btopen.TabIndex = 1;
            this.btopen.Text = "Open In Word Document";
            this.btopen.UseVisualStyleBackColor = false;
            this.btopen.Click += new System.EventHandler(this.btopen_Click);
            // 
            // btopenTXT
            // 
            this.btopenTXT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopenTXT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopenTXT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopenTXT.Location = new System.Drawing.Point(246, 4);
            this.btopenTXT.Name = "btopenTXT";
            this.btopenTXT.Size = new System.Drawing.Size(185, 29);
            this.btopenTXT.TabIndex = 2;
            this.btopenTXT.Text = "Open In Text File";
            this.btopenTXT.UseVisualStyleBackColor = false;
            this.btopenTXT.Click += new System.EventHandler(this.btopenTXT_Click);
            // 
            // btopenPDF
            // 
            this.btopenPDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopenPDF.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopenPDF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopenPDF.Location = new System.Drawing.Point(37, 4);
            this.btopenPDF.Name = "btopenPDF";
            this.btopenPDF.Size = new System.Drawing.Size(185, 29);
            this.btopenPDF.TabIndex = 3;
            this.btopenPDF.Text = "Open In PDF Document";
            this.btopenPDF.UseVisualStyleBackColor = false;
            this.btopenPDF.Click += new System.EventHandler(this.btopenPDF_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(-1, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 2);
            this.panel1.TabIndex = 4;
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 403);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btopenPDF);
            this.Controls.Add(this.btopenTXT);
            this.Controls.Add(this.btopen);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Manual";
            this.Text = "Manual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btopen;
        private System.Windows.Forms.Button btopenTXT;
        private System.Windows.Forms.Button btopenPDF;
        private System.Windows.Forms.Panel panel1;
    }
}