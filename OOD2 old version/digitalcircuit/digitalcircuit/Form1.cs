using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digitalCircuit
{
    public partial class Form1 : Form
    {

        Circuit myCircuit;
        Graphics grid;
        String toolSelected = "";
        Point coordinate;


        public Form1()
        {
            InitializeComponent();
            grid = pictureBox1.CreateGraphics();
            toolSelected.Clone();
            myCircuit = new Circuit("A", 9, 9, 50);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // btn_Clear_All.Attributes.Add("onClick", "javascript:alert('Message Here');");
         

        }

        private void btn_gate_OR_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_gate_OR.Checked = true;
            toolSelected = "OR";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_connection.Checked = true;
            toolSelected = "Connection";

        }

        private void btn_gate_SINK_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_gate_SINK.Checked = true;
            toolSelected = "SINK";


        }

        private void btn_gate_source_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_gate_source.Checked = true;
            toolSelected = "SOURCE";

        }

        private void btn_gate_And_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_gate_And.Checked = true;
            toolSelected = "AND";
        }

        private void btn_gate_NOT_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_gate_NOT.Checked = true;
            toolSelected = "NOT";

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            this.btn_Remove.Checked = true;
            toolSelected = "REMOVE";
        }

        public void buttoncheckedFalse()
        {
            this.btn_gate_SINK.Checked = false;
            this.btn_gate_source.Checked = false;
            this.btn_gate_OR.Checked = false;
            this.btn_gate_And.Checked = false;
            this.btn_gate_NOT.Checked = false;
            this.btn_connection.Checked = false;
            this.btn_Remove.Checked = false;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grid = e.Graphics;
            myCircuit.makeGrid(grid);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (toolSelected != "")
            {

                //Point coordinate;// = new Point();

                if (toolSelected == "OR" || toolSelected == "AND" || toolSelected == "NOT" || toolSelected == "SINK" || toolSelected == "SOURCE")
                {
                    coordinate = new Point(e.X, e.Y);
                    myCircuit.paintGateFunction(toolSelected, grid, coordinate);
                }
                else if (toolSelected == "Connection")  // store first click location
                {
                    coordinate = e.Location;
                    toolSelected = "tempSecondPoint";
                }
                else if (toolSelected == "tempSecondPoint")      // get new point   for connection
                {
                    myCircuit.paintConnection(grid, coordinate, e.Location);
                    toolSelected = "connection";
                }
                //coordinate = new Point();
            }
            else if (toolSelected == "Remove")
            {

            }




        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (toolSelected == "Connection" || toolSelected == "tempSecondPoint")
            {
                this.Cursor = Cursors.Cross;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Circuit (*.cir)|*.cir";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (!myCircuit.saveFile(saveDialog.FileName))
                {
                    MessageBox.Show("Saving Failed", "error");
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Circuit (*.cir)|*.cir";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true; 
            this.myCircuit = new Circuit();
            grid = pictureBox1.CreateGraphics();
            grid.Clear(Color.White);
           // myCircuit.makeGrid(grid);

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
              myCircuit = myCircuit.openFile(openDialog.FileName);
                //c.EraseAll(grid);
               myCircuit.drawAll(grid);
            }
        }

      






    }
}
        

     
    

