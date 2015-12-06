using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Digital_Circuit
{
    public partial class Form1 : Form
    {
        Manipluater Mani = null;
        Gate current;
        Gate left;
        Gate right;
        Gate selected;
        Connections connection;
        FileHelper fh;
        bool saved = true;
        string path = "";
        bool usingTextBoxes = true;
        List<Gate> DeletedGates = null;
        List<List<Connections>> DeletedConnections = null;

        int X, Y = 0;//the mouse click position.

        public Form1()
        {
            InitializeComponent();
            Reset();
            this.WindowState = FormWindowState.Maximized;  //the window starts maximized
        }

        /// <summary>
        /// remove the textboxes for source.
        /// </summary>
        public void ClearTextBoxes()
        {
            foreach (Gate g in Mani.Gates)
            {
                if (g is SOURCE)
                {
                    Control[] source = this.Controls.Find(g.GateID.ToString(), true);//get the control.
                    panel1.Controls.Remove(source[0]);//remove the control.
                }
            }
        }

        /// <summary>
        /// reset some values.
        /// </summary>
        public void Reset()
        {
            Mani = new Manipluater();
            connection = null;
            left = right = current =selected= null;
            fh = new FileHelper();
            DeletedGates = new List<Gate>();
            DeletedConnections = new List<List<Connections>>();
            UNDOToolStripMenuItem1.Enabled = false;
        }

        /// <summary>
        /// add the textboxes for the source.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private TextBox AddTextBoxes(Gate g,Point p)
        {
            TextBox tb1 = null;
            tb1 = new TextBox();
            tb1.Location = new Point(p.X, p.Y);
            tb1.Size = new Size(20, 10);
            tb1.MaxLength = 1;
            tb1.Name = g.GateID.ToString();
            tb1.TextChanged += tb1_TextChanged;
            panel1.Controls.Add(tb1);
            return tb1;
        }

        /// <summary>
        /// add the checkBoxes for the source.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private CheckBox AddCheckBox(Gate g, Point p)
        {
            CheckBox rb1 = null;
            rb1 = new CheckBox();
            rb1.Location = new Point(p.X+4,p.Y+4);
            rb1.Name = g.GateID.ToString();
            rb1.Height = 13;
            rb1.Width = 13;
            rb1.CheckedChanged += rb1_CheckedChanged;
            panel1.Controls.Add(rb1);
            return rb1;
        }

        void rb1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox rb = (CheckBox)sender;
            //ActiveControl = null;//unactivate the textbox.
            foreach (Gate g in Mani.Gates)
            {
                if (g.GateID.ToString() == rb.Name)
                {
                    if (rb.Checked)
                        g.Outvalue = 1;
                    else
                        g.Outvalue = 0;
                    break;
                }
            }
            saved = false;
            panel1.Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// this is for the connection_Editer form.
        /// </summary>
        ConnectionEditer NewEditer = null;
        //this is the connection_editer... system gives this strange name because of some wrong operations of me.
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEditer = new ConnectionEditer();
            NewEditer.Visible = true;
            this.EditerConnection.Enabled = false;
            NewEditer.FormClosing += NewEditer_FormClosing;
            NewEditer.button2.Click += button2_Click;
            NewEditer.button1.Click += button1_Click;
            NewEditer.button3.Click += button3_Click;
           // NewEditer.button4.Click += button4_Click;
            NewEditer.KeyDown += NewEditer_KeyDown;
            UdateEditer();
            NewEditer.listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            NewEditer.button2.Enabled = false;
            NewEditer.button1.Enabled = false;
            NewEditer.button4.Click += button4_Click;
            //NewEditer.button4.Enabled = false;
        }

        void button4_Click(object sender, EventArgs e)
        {
            Mani.ReSetAllConnectionsColor();
            foreach (Connections c in Mani.Connection)
            {
                if (Convert.ToInt32(NewEditer.tbLeft.Text) == c.Left.GateID && Convert.ToInt32(NewEditer.tbRight.Text) == c.Right.GateID)
                {
                    c.Actived = true;
                    int index = 0;
                    foreach (string s in NewEditer.listBox1.Items)
                    {
                        string[] splits = s.Split(' ');
                        if (c.Left.GateID.ToString() == splits[3] && c.Right.GateID.ToString() == splits[7])
                        {
                            NewEditer.listBox1.SelectedIndex = index;
                            break;
                        }
                        index++;
                    }
                    panel1.Invalidate();
                    return;
                }
            }
            MessageBox.Show("No result found.");
        }

        /// <summary>
        /// for the keyboard control of the connection_editer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewEditer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                button1_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.Z)
                button2_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.R)
                button3_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (NewEditer.button4.Enabled)
                    button4_Click(sender, e);
            }
        }

        /// <summary>
        /// event of the button on the connection_editer form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button3_Click(object sender, EventArgs e)
        {
            UdateEditer();
            panel1.Invalidate();
        }

        /// <summary>
        /// set the button2_click event for the connection_editer form.
        /// </summary>
        List<Connections> connectionsDone = new List<Connections>();
        void button2_Click(object sender, EventArgs e)
        {
            if (connectionsDone.Count != 0)
            {
                Mani.Add1Connection(connectionsDone[connectionsDone.Count - 1]);
                connectionsDone.RemoveAt(connectionsDone.Count - 1);
                UdateEditer();
                if (connectionsDone.Count == 0)
                    NewEditer.button2.Enabled = false;
                panel1.Invalidate();
            }
        }

        private void UdateEditer()
        {
            Mani.ReSetAllConnectionsColor();
            NewEditer.listBox1.Items.Clear();
            foreach (Connections c in Mani.Connection)
            {
                NewEditer.listBox1.Items.Add("Left gate ID: " + c.Left.GateID + " Right gate ID: " + c.Right.GateID);
            }
        }

        /// <summary>
        /// set the button1_click event for the connection_editer form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button1_Click(object sender, EventArgs e)
        {
            Connections c = GetselectedConnection(NewEditer.listBox1);
            foreach (Connections ce in Mani.Connection)
            {
                if (c == ce)
                {
                    Mani.Remove1Connection(c);
                    connectionsDone.Add(c);
                    UdateEditer();
                    saved = false;
                    NewEditer.button2.Enabled = true;
                    NewEditer.button1.Enabled = false;
                    return;
                }
            }
        }

        /// <summary>
        /// set the listbox selected changed event for the connection_editer form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetselectedConnection((ListBox)sender) != null)
                NewEditer.button1.Enabled = true;
            
        }

        private Connections GetselectedConnection(ListBox l)
        {
            if (l.SelectedItem != null)
            {
                string[] splits = l.SelectedItem.ToString().Split(' ');
                Mani.ReSetAllConnectionsColor();
                foreach (Connections c in Mani.Connection)
                {
                    if (c.Left.GateID.ToString() == splits[3] && c.Right.GateID.ToString() == splits[7])
                    {
                        NewEditer.tbLeft.Text = c.Left.GateID.ToString();
                        NewEditer.tbRight.Text = c.Right.GateID.ToString();
                        c.Actived = true;
                        panel1.Invalidate();
                        return c;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// set the form_closeing event for the connection_editer form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewEditer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mani.ReSetAllConnectionsColor();
            panel1.Invalidate();
            this.EditerConnection.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// change the size of the panel based on the size of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            this.panel1.ClientSize = new Size(Convert.ToInt32(this.ClientSize.Width - 150), Convert.ToInt32(this.ClientSize.Height -70));
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// panel mouse_click event, one of the most important event.
        /// check if the postion user clcik is too close to the border.
        /// check if the user just want to deselect one gate or not.
        /// check if the user is trying to add a connection.
        /// check if the user is trying to select one gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //not too closed to the corner.
                if (e.X < 30 || e.Y < 30 || (panel1.Width-e.X < 30) || ( panel1.Height-e.Y  < 30))
                {
                    return;
                }
                MouseEventArgs Mouse_e = (MouseEventArgs)e;
                if (Mouse_e.Button == MouseButtons.Left)
                {
                    foreach (Gate g in Mani.Gates)
                    {
                        if (selected != null)
                        {
                            if (g.GateID == selected.GateID)
                            {
                                break;
                            }
                        }
                    }//check if the user want to deactivate the chosen gate.

                    selected = null;
                    //Mani.UnactivedAll();
                    panel1.Invalidate();

                    this.X = e.X;
                    this.Y = e.Y;
                    right = Mani.GetGateByLocation(new Point(this.X, this.Y));
                    if (right != null)//check if the user is trying to delete one.
                    {
                        selected = right;
                        if (left != right && left != null && right != null && connection != null)
                        {
                            if (left.Location.X >= right.Location.X - right.Radius)
                            {
                                DialogResult result = MessageBox.Show("Lines should be from left to the right side or maybe two gates vertically too close to each other. \nDo you want to check the manual now?","Error", MessageBoxButtons.YesNoCancel);
                                if (result == DialogResult.Yes)
                                    ViewManual();
                            }
                            else
                            {
                                //starting making changes from here.
                                connection.SetLfet(left);
                                connection.SetRight(right);
                                if (Mani.ConnectonExsit(connection.Left, connection.Right))
                                {
                                    MessageBox.Show("Connection exsit.");
                                }
                                else
                                {
                                    if (!connection.ConnectionValid() || !Mani.ConnectionValid(connection))
                                    {
                                        DialogResult result = MessageBox.Show("Invalid connection. \nDo you want to check the manual now?", "Error", MessageBoxButtons.YesNoCancel);
                                        if (result == DialogResult.Yes)
                                            ViewManual();
                                    }
                                    else
                                    {
                                        Mani.Add1Connection(connection);
                                        saved = false;
                                        UNDOToolStripMenuItem1.Enabled = true;
                                        if(NewEditer!=null)
                                            button3_Click(sender, e);
                                    }
                                }
                            }
                            left = right = null;
                            connection = new Connections(left, right);
                            selected = null;
                            //Mani.UnactivedAll();
                            panel1.Refresh();
                            return;
                        }
                        panel1.Refresh();
                        left = right;
                        return;
                    }

                    if (current == null)
                    {
                        left = right = null;
                        return;
                    }

                    if (!Mani.Allow1MoreAround(new Point(e.X, e.Y)))//check if it is allowed to add a new gate here.
                    {
                        MessageBox.Show("Too close to the exsit ones. Please choose another position.");
                        return;
                    }

                    current.SetLocation(new Point(e.X, e.Y));
                    if (current is SOURCE)//if it is source-gate, then add textbox control
                    {
                        if (usingTextBoxes)
                            AddTextBoxes(current, new Point(e.X, e.Y));
                        else
                            AddCheckBox(current, new Point(e.X, e.Y));
                    }
                    Mani.Add1Gate(current);
                    UNDOToolStripMenuItem1.Enabled = true;
                    saved = false;
                    panel1.Invalidate();
                    SetGatesColor();
                    GetNextGate(current, sender, e);//give next gate the same type of gate.
                    //current = null;//aftr draing one gate, current gate becomes null.
                }
                if (Mouse_e.Button == MouseButtons.Right)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetNextGate(Gate current, object sender, MouseEventArgs e)
        {
            if (current is SINK)
            {
                panel3_MouseClick(sender, e);
            }
            if (current is SOURCE)
            {
                panel2_MouseClick(sender, e);
            }
            if (current is AND)
            {
                panel4_MouseClick(sender, e);
            }
            if (current is OR)
            {
                panel5_MouseClick(sender, e);
            }
            if (current is NOT)
            {
                panel6_MouseClick(sender, e);
            }
        }

        /// <summary>
        /// change the source value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tb1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            ActiveControl = null;//unactivate the textbox.
            //tb.TabStop = true;
            try
            {
                if (tb.Text != "")
                {
                    int i = Convert.ToInt32(tb.Text);
                    if (i != 1 && i != 0)
                    {
                        MessageBox.Show("Only 0 or 1 is valid here");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            foreach (Gate g in Mani.Gates)
            {
                if (g.GateID.ToString() == tb.Name)
                {
                    if (tb.Text == "")
                        g.Outvalue = -1;
                    else
                        g.Outvalue = Convert.ToInt32(tb.Text);
                }
            }
            saved = false;
            panel1.Refresh();
        }

        /// <summary>
        /// panel paint event.
        /// will be called everytime any single value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Mani.ChangeColorForAll();//change color for the connections.
            Graphics gr = e.Graphics;
            foreach (Gate g in Mani.Gates)
            {
                Brush Mybrush = new SolidBrush(g.BgColor);
                if (g is SOURCE || g is SINK)
                {
                    gr.FillEllipse(Mybrush, g.Location.X - 10, g.Location.Y - 10, g.Radius, g.Radius);//draw source and sink
                }
                else
                {
                    gr.FillRectangle(Mybrush, g.Location.X - 10, g.Location.Y - 10, g.Radius, g.Radius);//draw and/or/not
                }
                //add the string text to the icons.
                gr.DrawString(g.Text,new Font("April",10), new SolidBrush(Color.Black), g.Location.X-5,g.Location.Y+5);
                gr.DrawString("ID:" + g.GateID.ToString(), new Font("April", 10), new SolidBrush(Color.Black), g.Location.X - 15, g.Location.Y - 25);
                if (selected != null)
                {
                    if (g.GateID == selected.GateID)
                    {
                        Pen pen = new Pen(Color.Black, 4);
                        gr.DrawRectangle(pen, g.Location.X - 10, g.Location.Y - 10, g.Radius + 2, g.Radius + 2);
                    }
                }
            }
            foreach (Connections c in Mani.Connection)
            {
                Pen mp =new Pen(c.LineColor, 1);
                if (c.Actived)
                    mp = new Pen(Color.Blue, 4);
                //mp.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //mp.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                //draw the arrow
                SolidBrush s = new SolidBrush(c.LineColor);
                if (c.Actived)
                    s = new SolidBrush(Color.Blue);
                int x = Math.Abs(c.Right.Location.X - c.Left.Location.X - c.Left.Radius);
                int y = Math.Abs(c.Right.Location.Y - c.Left.Location.Y);
                int r = 10;
                double d =(Math.Round(Math.Sqrt(Convert.ToDouble((c.Left.Location.X - c.Right.Location.X - c.Left.Radius) * (c.Left.Location.X - c.Right.Location.X - c.Left.Radius) + (c.Left.Location.Y - c.Right.Location.Y) * (c.Left.Location.Y - c.Right.Location.Y))), 0));
                Point p1;//the arrow potions
                Point p2;
                if (c.Right.Location.Y >= c.Left.Location.Y)
                {
                    p1 = new Point(c.Left.Location.X+30 + Convert.ToInt32((((d - r) / d) * x) + ((r / d) * y)), c.Left.Location.Y +10+ Convert.ToInt32(((d - r) / d) * y - (r / d) * x));
                    p2 = new Point(c.Left.Location.X+30 + Convert.ToInt32(((d - r) / d) * x - (r / d) * y), c.Left.Location.Y+10 + Convert.ToInt32(((d - r) / d) * y + (r / d) * x));
                }
                else
                {
                    p1 = new Point(c.Left.Location.X+30 + Convert.ToInt32((((d - r) / d) * x) + ((r / d) * y)), c.Left.Location.Y +10- Convert.ToInt32(((d - r) / d) * y - (r / d) * x));
                    p2 = new Point(c.Left.Location.X+30 + Convert.ToInt32(((d - r) / d) * x - (r / d) * y), c.Left.Location.Y+10 - Convert.ToInt32(((d - r) / d) * y + (r / d) * x));
                }
                Point[] p = { new Point(c.Right.Location.X - 10, c.Right.Location.Y + 10), p1, p2 };
                gr.FillPolygon(s, p);
                //draw the line
                gr.DrawLine(mp, new Point(c.Left.Location.X -10 +c.Left.Radius, c.Left.Location.Y + 10), new Point(c.Right.Location.X - 10, c.Right.Location.Y + 10));
            }
        }

        /// <summary>
        /// get the current selected gate/ connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            current = new SOURCE(Mani.Gates.Count + 1);
            SetGatesColor();
            panel2.BackColor = Color.Blue;
            connection = null;
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            current = new SOURCE(Mani.Gates.Count + 1);
            SetGatesColor();
            panel2.BackColor = Color.Blue;
            connection = null;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            current = new SINK(Mani.Gates.Count + 1);
            SetGatesColor();
            panel3.BackColor = Color.Blue;
            connection = null;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            current = new SINK(Mani.Gates.Count + 1);
            SetGatesColor();
            panel3.BackColor = Color.Blue;
            connection = null;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            current = new AND(Mani.Gates.Count + 1);
            SetGatesColor();
            panel4.BackColor = Color.Blue;
            connection = null;
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            current = new AND(Mani.Gates.Count + 1);
            SetGatesColor();
            panel4.BackColor = Color.Blue;
            connection = null;
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            current = new OR(Mani.Gates.Count + 1);
            SetGatesColor();
            panel5.BackColor = Color.Blue;
            connection = null;
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            current = new OR(Mani.Gates.Count + 1);
            SetGatesColor();
            panel5.BackColor = Color.Blue;
            connection = null;
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            current = new NOT(Mani.Gates.Count + 1);
            SetGatesColor();
            panel6.BackColor = Color.Blue;
            connection = null;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            current = new NOT(Mani.Gates.Count + 1);
            SetGatesColor();
            panel6.BackColor = Color.Blue;
            connection = null;
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            connection = new Connections(left, right);
            SetGatesColor();
            panel7.BackColor = Color.Blue;
            current = null;
        }

        private void label6_MouseClick(object sender, MouseEventArgs e)
        {
            connection = new Connections(left, right);
            SetGatesColor();
            panel7.BackColor = Color.Blue;
            current = null;
        }

        private void SetGatesColor()//set color of gate-options.
        {
            panel4.BackColor = panel2.BackColor = panel3.BackColor = panel5.BackColor = panel6.BackColor = panel7.BackColor = Color.FromArgb(-6703919);
        }
        //end of getting the current selected gate.

        /// <summary>
        /// for the delete funtion.
        /// allow the user to delete a gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Gate g in Mani.Gates)
            {

                if (g.InGate(new Point(this.X, this.Y)))
                {
                    DialogResult result = MessageBox.Show("Do you really want to delete?", "Delete?", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    DeletedGates.Add(g);
                    List<Connections> temp = new List<Connections>();
                    foreach (Connections c in Mani.Remove1Gate(g))
                    {
                        temp.Add(c);
                    }
                    DeletedConnections.Add(temp);
                    UNDOToolStripMenuItem1.Enabled = true;
                    saved = false;
                    if (g is SOURCE)
                    {
                        Control[] source = this.Controls.Find(g.GateID.ToString(), true);//get the control.
                        panel1.Controls.Remove(source[0]);//remove the control.
                    }
                    //panel1_Paint(this, new PaintEventArgs(CreateGraphics(), ClientRectangle));//paint the panel
                    panel1.Invalidate();
                    left = right = null;
                    return;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            SetGatesColor();
            current = null;
            connection = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// save the project.
        /// if the path is not know, then ask for a new file path.
        /// othewise just save/overwrite it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( path != "")
                try
                {
                    fh.SaveToFile(path, Mani);
                    saved = true;
                    MessageBox.Show("saving is done.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// quit the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                DialogResult result = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                DialogResult Want2Save = MessageBox.Show("Do you want to Save your work before quiting?", "Saving?", MessageBoxButtons.YesNoCancel);
                if (Want2Save == DialogResult.Yes)
                {
                    if (path == "")
                        SaveToFile();
                    else
                    {
                        fh.SaveToFile(path, Mani);
                    }
                }
                if (Want2Save == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// view manual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewManual();
        }

        /// <summary>
        /// save as funtion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            try
            {
                string filename = "";
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    path = filename = saveFileDialog1.FileName;
                    fh.SaveToFile(filename, Mani);
                    saved = true;
                    MessageBox.Show("Saving is done.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// open a project from the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the previous work?", "save?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (path == "")
                        SaveToFile();
                    else
                    {
                        fh.SaveToFile(path, Mani);
                    }
                }
            }
            string filename = "";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = filename = openFileDialog1.FileName;
                ClearTextBoxes();
                Reset();
                Mani = fh.LoadFromFile(filename);
                if (Mani == null)
                {
                    Mani = new Manipluater();
                }
                else
                {
                    foreach (Gate g in Mani.Gates)
                    {
                        if (g is SOURCE)
                        {
                            if (usingTextBoxes)
                            {
                                TextBox temp = AddTextBoxes(g, g.Location);
                                if (g.Outvalue != -1)
                                    temp.Text = g.Outvalue.ToString();
                            }
                            else
                            {
                                CheckBox rb = AddCheckBox(g, g.Location);
                                if (g.Outvalue == 1)
                                    rb.Checked = true;
                                else
                                    rb.Checked = false;
                            }
                        }
                    }
                }
                panel1.Invalidate();
                saved = true;
                if (NewEditer != null)
                    button3_Click(sender, e);
            }
        }

        /// <summary>
        /// create a new project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult result1 = MessageBox.Show("Do you really want to create a new project?","new project?", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    DialogResult result = MessageBox.Show("Do you want to save the previous work?", "save?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (path == "")
                            SaveToFile();
                        else
                        {
                            fh.SaveToFile(path, Mani);
                        }
                    }
                }
                else
                    return;
            }
            ClearTextBoxes();
            Reset();
            panel1.Invalidate();
            path = "";
            saved = true;
            if (NewEditer != null)
                button3_Click(sender, e);
        }

        private void ViewManual()
        {
            Manual newManual = new Manual();
            newManual.Visible = true;
            this.openManualToolStripMenuItem.Enabled = false;
            newManual.FormClosing += newManual_FormClosing;
        }

        /// <summary>
        /// the form_closing event for the manual form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void newManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.openManualToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// undo the delete operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uNDOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DeletedGates.Count == 0)
            {
                return;
            }
            Gate GT = DeletedGates[DeletedGates.Count - 1];
            Mani.Add1Gate(GT);
            if (GT is SOURCE)
            {
                if (usingTextBoxes)
                {
                    TextBox temp = AddTextBoxes(GT, GT.Location);
                    if (GT.Outvalue != -1)
                        temp.Text = GT.Outvalue.ToString();
                }
                else
                {
                    CheckBox rb = AddCheckBox(current, GT.Location);
                    if (GT.Outvalue == 1)
                        rb.Checked = true;
                    else
                        rb.Checked = false;
                }
            }
            DeletedGates.RemoveAt(DeletedGates.Count - 1);
            foreach (Connections c in DeletedConnections[DeletedConnections.Count-1])
            {
                Mani.Add1Connection(c);
            }
            DeletedConnections.RemoveAt(DeletedConnections.Count - 1);
            panel1.Invalidate();
            if (DeletedGates.Count == 0)
            {
                UNDOToolStripMenuItem1.Enabled = false;
            }
        }

        /// <summary>
        /// set the keyboard control for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (UNDOToolStripMenuItem1.Enabled)
                    uNDOToolStripMenuItem1_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.O)
                openToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.S && !e.Shift)
                saveToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.H)
            {
                if (openManualToolStripMenuItem.Enabled)
                    openManualToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.N)
                newToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (EditerConnection.Enabled)
                    undoToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.S && e.Shift)
                saveAsToolStripMenuItem_Click(sender, e);
            if (e.KeyCode == Keys.Delete)
                deleteToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// use textboxes in the source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void useTextBoxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Mani.Gates.Count == 0)
            {
                return;
            }
            useTextBoxesToolStripMenuItem.Checked = true;
            useCheckBoxesToolStripMenuItem.Checked = false;
            usingTextBoxes = true;
            ClearTextBoxes();
            foreach (Gate g in Mani.Gates)
            {
                if (g is SOURCE)
                {
                    if (usingTextBoxes)
                    {
                        TextBox temp = AddTextBoxes(g, g.Location);
                        if (g.Outvalue != -1)
                            temp.Text = g.Outvalue.ToString();
                    }
                    else
                    {
                        CheckBox rb = AddCheckBox(g, g.Location);
                        if (g.Outvalue == 1)
                            rb.Checked = true;
                        else
                            rb.Checked = false;
                    }
                }
            }
            panel1.Invalidate();
        }

        /// <summary>
        /// use checkboxes in the sources.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void useCheckBoxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Mani.Gates.Count == 0)
            {
                return;
            }
            useTextBoxesToolStripMenuItem.Checked = false;
            useCheckBoxesToolStripMenuItem.Checked = true;
            usingTextBoxes = false;
            ClearTextBoxes();
            foreach (Gate g in Mani.Gates)
            {
                if (g is SOURCE)
                {
                    if (usingTextBoxes)
                    {
                        TextBox temp = AddTextBoxes(g, g.Location);
                        if (g.Outvalue != -1)
                            temp.Text = g.Outvalue.ToString();
                    }
                    else
                    {
                        CheckBox rb = AddCheckBox(g, g.Location);
                        if (g.Outvalue == 1)
                            rb.Checked = true;
                        else
                            rb.Checked = false;
                    }
                }
            }
            panel1.Invalidate();
        }

        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    foreach (Gate g in Mani.Gates)
        //    {
        //        g.Radius = trackBar1.Value;
        //    }
        //    panel1.Invalidate();
        //}
    }
}
