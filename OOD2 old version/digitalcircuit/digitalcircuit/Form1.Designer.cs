namespace digitalCircuit
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_connection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btn_gate_source = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btn_gate_And = new System.Windows.Forms.ToolStripButton();
            this.btn_gate_OR = new System.Windows.Forms.ToolStripButton();
            this.btn_gate_NOT = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btn_gate_SINK = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btn_Remove = new System.Windows.Forms.ToolStripButton();
            this.btn_Clear_All = new System.Windows.Forms.Button();
            this.btn_Check = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(660, 35);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(46, 31);
            this.newToolStripMenuItem1.Text = "&New";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(52, 31);
            this.openToolStripMenuItem1.Text = "&Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(47, 31);
            this.saveToolStripMenuItem1.Text = "&Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(40, 31);
            this.exitToolStripMenuItem1.Text = "&Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(4, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(66, 458);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbox";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(53, 53);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_connection,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.btn_gate_source,
            this.toolStripLabel2,
            this.btn_gate_And,
            this.btn_gate_OR,
            this.btn_gate_NOT,
            this.toolStripLabel3,
            this.btn_gate_SINK,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.btn_Remove});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(60, 439);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_connection
            // 
            this.btn_connection.AutoSize = false;
            this.btn_connection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_connection.Image = ((System.Drawing.Image)(resources.GetObject("btn_connection.Image")));
            this.btn_connection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_connection.Name = "btn_connection";
            this.btn_connection.Size = new System.Drawing.Size(45, 35);
            this.btn_connection.Text = "toolStripButton1";
            this.btn_connection.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(58, 6);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 15);
            this.toolStripLabel1.Text = "Input";
            // 
            // btn_gate_source
            // 
            this.btn_gate_source.AutoSize = false;
            this.btn_gate_source.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_gate_source.Image = global::digitalCircuit.Properties.Resources.poweron1;
            this.btn_gate_source.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_gate_source.Name = "btn_gate_source";
            this.btn_gate_source.Size = new System.Drawing.Size(45, 35);
            this.btn_gate_source.Text = "toolStripButton1";
            this.btn_gate_source.Click += new System.EventHandler(this.btn_gate_source_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 15);
            this.toolStripLabel2.Text = "Gates";
            // 
            // btn_gate_And
            // 
            this.btn_gate_And.AutoSize = false;
            this.btn_gate_And.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_gate_And.Image = global::digitalCircuit.Properties.Resources.Logic_gate_and_us1;
            this.btn_gate_And.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_gate_And.Name = "btn_gate_And";
            this.btn_gate_And.Size = new System.Drawing.Size(45, 35);
            this.btn_gate_And.Text = "toolStripButton2";
            this.btn_gate_And.Click += new System.EventHandler(this.btn_gate_And_Click);
            // 
            // btn_gate_OR
            // 
            this.btn_gate_OR.AutoSize = false;
            this.btn_gate_OR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_gate_OR.Image = ((System.Drawing.Image)(resources.GetObject("btn_gate_OR.Image")));
            this.btn_gate_OR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_gate_OR.Name = "btn_gate_OR";
            this.btn_gate_OR.Size = new System.Drawing.Size(45, 35);
            this.btn_gate_OR.Text = "toolStripButton3";
            this.btn_gate_OR.Click += new System.EventHandler(this.btn_gate_OR_Click);
            // 
            // btn_gate_NOT
            // 
            this.btn_gate_NOT.AutoSize = false;
            this.btn_gate_NOT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_gate_NOT.Image = ((System.Drawing.Image)(resources.GetObject("btn_gate_NOT.Image")));
            this.btn_gate_NOT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_gate_NOT.Name = "btn_gate_NOT";
            this.btn_gate_NOT.Size = new System.Drawing.Size(45, 35);
            this.btn_gate_NOT.Text = "toolStripButton4";
            this.btn_gate_NOT.Click += new System.EventHandler(this.btn_gate_NOT_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 15);
            this.toolStripLabel3.Text = "Output";
            // 
            // btn_gate_SINK
            // 
            this.btn_gate_SINK.AutoSize = false;
            this.btn_gate_SINK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_gate_SINK.Image = ((System.Drawing.Image)(resources.GetObject("btn_gate_SINK.Image")));
            this.btn_gate_SINK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_gate_SINK.Name = "btn_gate_SINK";
            this.btn_gate_SINK.Size = new System.Drawing.Size(45, 35);
            this.btn_gate_SINK.Text = "toolStripButton5";
            this.btn_gate_SINK.Click += new System.EventHandler(this.btn_gate_SINK_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(45, 15);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 15);
            this.toolStripLabel4.Text = "Delete";
            // 
            // btn_Remove
            // 
            this.btn_Remove.AutoSize = false;
            this.btn_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Remove.Image = ((System.Drawing.Image)(resources.GetObject("btn_Remove.Image")));
            this.btn_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(45, 35);
            this.btn_Remove.Text = "toolStripButton6";
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Clear_All
            // 
            this.btn_Clear_All.Location = new System.Drawing.Point(582, 9);
            this.btn_Clear_All.Name = "btn_Clear_All";
            this.btn_Clear_All.Size = new System.Drawing.Size(60, 23);
            this.btn_Clear_All.TabIndex = 1;
            this.btn_Clear_All.Text = "Clear All";
            this.btn_Clear_All.UseVisualStyleBackColor = true;
            this.btn_Clear_All.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(478, 9);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(98, 23);
            this.btn_Check.TabIndex = 9;
            this.btn_Check.Text = "Check Circuit";
            this.btn_Check.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(76, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 475);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 516);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.btn_Clear_All);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Digital Circuit";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btn_gate_source;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btn_gate_And;
        private System.Windows.Forms.ToolStripButton btn_gate_OR;
        private System.Windows.Forms.ToolStripButton btn_gate_NOT;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btn_gate_SINK;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btn_Remove;
        private System.Windows.Forms.Button btn_Clear_All;
        private System.Windows.Forms.ToolStripButton btn_connection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

