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
        Point temp;

        public Form1()
        {
            InitializeComponent();
            grid = pictureBox1.CreateGraphics();
            toolSelected.Clone();
            myCircuit = new Circuit("Untitled", 9, 9, 50);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myCircuit.clearAll(this.grid);
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

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            buttoncheckedFalse();
            toolSelected = "";
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
            myCircuit.drawAll(grid);
        }      
 
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            coordinate = new Point(e.X, e.Y);
            if (toolSelected != "")
            {
                if (toolSelected == "OR" || toolSelected == "AND" || toolSelected == "NOT" || toolSelected == "SINK" || toolSelected == "SOURCE")
                {
                    // add gate and redraw if addded
                    if (myCircuit.addGate(toolSelected, coordinate))
                        myCircuit.drawAll(this.grid);
                }
                else if (toolSelected == "Connection")  // store first click location
                {
                    temp = e.Location;
                    toolSelected = "tempSecondPoint";
                }
                else if (toolSelected == "tempSecondPoint")      // get new point   for connection
                {
                    if (myCircuit.makeConnection(temp, e.Location))
                        myCircuit.drawAll(this.grid);
                    toolSelected = "Connection";
                }
                else if (toolSelected == "REMOVE")
                {
                    // remove gate and redraw if removed
                    if (myCircuit.removeGate(coordinate))
                        myCircuit.drawAll(this.grid);
                }
            }
            else
            {
                // try to change source value and redraw if changed
                if (myCircuit.changeValueSource(coordinate))
                    myCircuit.drawAll(this.grid);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (toolSelected == "Connection" || toolSelected == "tempSecondPoint")
            {
                this.Cursor = Cursors.Cross;
            }
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!myCircuit.SavedFile() || !myCircuit.checkCircuitEmpty())
            {
                DialogResult dialogResult = MessageBox.Show("Current Circuit will be closed.Do you Want To save  Circuit? ", "Message", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    saveASToolStripMenuItem1_Click(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                {
                    myCircuit.New();
                    myCircuit.drawAll(grid);
                }
            }
            else if (myCircuit.checkCircuitEmpty()) { myCircuit.New(); }
      
             
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!myCircuit.SavedFile() && !myCircuit.checkCircuitEmpty())
            {
                DialogResult dialogResult = MessageBox.Show(" Do you want to save current Circuit", "Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveASToolStripMenuItem1_Click(sender, e);
                    open();
                }
                else open();
                
            }
            else if (myCircuit.checkCircuitEmpty()) { open(); }
            
            
        }
        public void open()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Circuit (*.cir)|*.cir";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
          
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                myCircuit = myCircuit.openFile(openDialog.FileName);
            
                myCircuit.drawAll(grid);
            }
            else myCircuit.drawAll(grid);

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!myCircuit.SavedFile())
            {
                saveASToolStripMenuItem1_Click(sender, e);
            }
        }
        private void saveASToolStripMenuItem1_Click(object sender, EventArgs e)
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


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    }
}