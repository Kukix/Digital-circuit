using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Circuit
{
    public partial class ConnectionEditer : Form
    {
        public ConnectionEditer()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.TopMost = true;
            this.MaximizeBox = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConnectionEditer_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 100;
            this.Top = 50;
        }

        private void ConnectionEditer_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void ConnectionEditer_MouseLeave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// this is for the auto hiding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)//make the form invisible/auto hiding
        {
            if ( this.WindowState != FormWindowState.Minimized )
            {
                if (this.Bounds.Contains(Cursor.Position))
                {
                    switch (this.StopAnhor)
                    {
                        case AnchorStyles.Top:
                            this.Location = new Point(this.Location.X, 0);
                            break;
                        case AnchorStyles.Left:
                            this.Location = new Point(0, this.Location.Y);
                            break;
                        case AnchorStyles.Right:
                            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                            break;
                    }
                }
                else
                {
                    switch (this.StopAnhor)
                    {
                        case AnchorStyles.Top:
                            this.Location = new Point(this.Location.X, (this.Height - 4) * (-1));
                            break;
                        case AnchorStyles.Left:
                            this.Location = new Point((this.Width - 4) * (-1), this.Location.Y);
                            break;
                        case AnchorStyles.Right:
                            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 4, this.Location.Y);
                            break;
                    }
                }
            }
        }

        AnchorStyles StopAnhor = AnchorStyles.None;

        private void mStopAnhor()
        {
            if (this.Top <= 0)
            {
                StopAnhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAnhor = AnchorStyles.Left;
            }
            else if (this.Right >= Screen.PrimaryScreen.Bounds.Width)
            {
                StopAnhor = AnchorStyles.Right;
            }
            else
            {
                StopAnhor = AnchorStyles.None;
            }
        }

        private void ConnectionEditer_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnhor();
        }

        private void ConnectionEditer_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void tbLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                e.KeyChar = '\0';//此句可以控制输入的东西为数字.
            //如果不是数字，不是退格，不是小数点就是输入空
        }

        private void tbRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                e.KeyChar = '\0';//此句可以控制输入的东西为数字.
            //如果不是数字，不是退格，不是小数点就是输入空
        }

        private void tbLeft_TextChanged(object sender, EventArgs e)
        {
            if (tbLeft.Text == "" || tbRight.Text == "")
                button4.Enabled = false;
            else
                button4.Enabled = true;
        }

        private void tbRight_TextChanged(object sender, EventArgs e)
        {
            if (tbLeft.Text == "" || tbRight.Text == "")
                button4.Enabled = false;
            else
                button4.Enabled = true;
        }
        
    }
}
