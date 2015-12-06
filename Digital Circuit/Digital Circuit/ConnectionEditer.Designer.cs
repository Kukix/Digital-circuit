namespace Digital_Circuit
{
    partial class ConnectionEditer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionEditer));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.tbRight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(337, 220);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "DELETE (delete)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "UNDO (ctrl+Z)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(368, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "REFRESH (ctrl+R)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(368, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 30);
            this.button4.TabIndex = 4;
            this.button4.Text = "SEARCH (ctrl+S)";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(71, 12);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(100, 21);
            this.tbLeft.TabIndex = 5;
            this.tbLeft.TextChanged += new System.EventHandler(this.tbLeft_TextChanged);
            this.tbLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLeft_KeyPress);
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(249, 12);
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(100, 21);
            this.tbRight.TabIndex = 6;
            this.tbRight.TextChanged += new System.EventHandler(this.tbRight_TextChanged);
            this.tbRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRight_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "LEFT ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "RIGHT ID:";
            // 
            // ConnectionEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRight);
            this.Controls.Add(this.tbLeft);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ConnectionEditer";
            this.Text = "ConnectionEditer";
            this.Load += new System.EventHandler(this.ConnectionEditer_Load);
            this.LocationChanged += new System.EventHandler(this.ConnectionEditer_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionEditer_KeyDown);
            this.MouseEnter += new System.EventHandler(this.ConnectionEditer_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ConnectionEditer_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox tbLeft;
        public System.Windows.Forms.TextBox tbRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}