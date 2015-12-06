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
    public partial class Manual : Form
    {
        /// <summary>
        /// these two variables are used for loading the manual from the file.
        /// </summary>
        FileHelper fh = null;
        List<string> manual = null;

        /// <summary>
        /// when this form is initialized, the manual will be automatically loaded.
        /// </summary>
        public Manual()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            fh = new FileHelper();
            manual = fh.GettingManual();
            foreach (string s in manual)
            {
                listBox1.Items.Add(s);
            }
        }

        /// <summary>
        /// open the manual with MS word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btopen_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position.
            path = path + "Manual.doc";
            System.Diagnostics.Process.Start(path);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// poen the manual with a pdf format version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btopenPDF_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position.
            path = path + "Manual.pdf";
            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// open the manual with a notepad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btopenTXT_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position.
            path = path + "Manual.txt";
            System.Diagnostics.Process.Start(path);
        }
    }
}
