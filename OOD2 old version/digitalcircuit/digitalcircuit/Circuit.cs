using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace digitalCircuit
{
    class Circuit
    {
        private string name;
        private List<Gate> listOfGates;
        private List<Connection> listOfConnections;
        private int nrOfgridColumns, nrOfgridRows, cellSize;
        
        Pen myPen = new Pen(Color.Maroon); 
        Font myFont = new Font("Times New Roman", 9, FontStyle.Bold);
        Brush myBrush = new SolidBrush(Color.BlueViolet);


        public Circuit()
        {
            this.cellSize = 50;
            this.nrOfgridColumns = 9;
            this.nrOfgridRows = 9;
        }
        
        /// <summary>
        /// the constructor is set to set the properties of circuit
        /// </summary>
        /// <param name="name">just given name can be any string</param>
        /// <param name="row">number of row required for grid</param>
        /// <param name="column">number of column required for grid</param>
        /// <param name="cellSize">length of individual square cell</param>
        public Circuit(string name, int row, int column, int cellSize)
        {
            this.name = name;
            this.nrOfgridColumns = column;
            this.nrOfgridRows = row;
            this.cellSize = cellSize;
            listOfGates = new List<Gate>();
            listOfConnections = new List<Connection>();
        }

       
        public void makeGrid(Graphics grid)  
        {
           Pen p = new Pen(Color.Black); 
            
            p.Width = 2;
           
            for (int i = 0; i <= this.nrOfgridRows; i++)    
            {
                grid.DrawLine(p, 0, i * this.cellSize, this.cellSize * nrOfgridRows, i * this.cellSize);
               // grid.DrawLine(p, i * this.cellSize, 0, i * this.cellSize, this.cellSize*nrOfgridColumns);
            }
            for (int i = 0; i <= this.nrOfgridColumns; i++)    
            {
                //grid.DrawLine(p, 0, i * this.cellSize, this.cellSize * nrOfgridRows, i * this.cellSize);
                grid.DrawLine(p, i * this.cellSize, 0, i * this.cellSize, this.cellSize * nrOfgridColumns);
            }   
        }

       /// <summary>
       /// find the locationof cell , to put gate or connection
       /// </summary>
       /// <param name="x">x-position of mouseclick on grid </param>
       /// <param name="y">y-position of mouseclick on grid</param>
       /// <returns>the x,y as a list of coordinate</returns>
       
        public Point findlocation(Point coordinate)
        {
            int cell_X = (coordinate.X / this.cellSize)*this.cellSize;
            int cell_Y = (coordinate.Y / this.cellSize) *this.cellSize;
            
            Point cellCoordinate = new Point(cell_X,cell_Y) ;

            return cellCoordinate;
        }

        /// <summary>
        /// add gates to the digital circuit listfr
        /// </summary>
        /// <param name="name">type of gate i.e. sorce, sink, and , not , or</param>
        /// <param name="xpos">x-position of mouse click</param>
        /// <param name="ypos">y-position of mouseclick</param>
        public void addGate(Gate g)//(string name, int xpos, int ypos)//
        {
            listOfGates.Add(g);
           // Point position = findlocation(xpos, ypos);

        }
        public void addConnection(Connection c)
        {
            listOfConnections.Add(c);
        }
        

        /// <summary>
        /// removes the gate from the cell at given position
        /// </summary>
        /// <param name="xpos">x-position of mouse click</param>
        /// <param name="ypos">y-position of mouseclick</param>
        public void removeGate(ref Point coordinate)
        {
            Point position = findlocation(coordinate);
        }

       /* /// <summary>
        /// connect between two points 
        /// </summary>
        /// <param name="x1">it is the x-position of mouse first click</param>
        /// <param name="y1">it is the y-position of mouse first click</param>
        /// <param name="x2">it is the x-position of mouse second click</param>
        /// <param name="y2">it is the y-position of mouse second click</param>
        public void makeComnnection(Point connectionA ,Point connectionB)
        {
            Point startPoint = connectionA;
            Point endPoint = connectionB;

        }*/
        /// <summary>
        /// remove connection between two points
        /// </summary>
        /// <param name="x1">it is the x-position of mouse first click</param>
        /// <param name="y1">it is the y-position of mouse first click</param>
        /// <param name="x2">it is the x-position of mouse second click</param>
        /// <param name="y2">it is the y-position of mouse second click</param>
        public void removeConnection(Point connectionA ,Point connectionB)
        {
            Point position = findlocation(connectionA );  // finds the start position
            Point position2 = findlocation( connectionB);   // find end position
        }
        public void paintGateFunction(string name, Graphics gr, Point coordinate)
        {
            Point cellToPaint = findlocation(coordinate);
            //have to check overlap call overlap function
            myPen.Width = 2.5f;
            Rectangle rect = new Rectangle(cellToPaint.X, cellToPaint.Y, this.cellSize - 2, this.cellSize - 2);


            gr.DrawRectangle(myPen, rect);



            if (name == "OR") { gr.DrawString("OR", myFont, myBrush, cellToPaint.X + 4, cellToPaint.Y + 20); }
            else if (name == "AND") { gr.DrawString("AND", myFont, myBrush, cellToPaint.X + 4, cellToPaint.Y + 20); }
            else if (name == "NOT") { gr.DrawString("NOT", myFont, myBrush, cellToPaint.X + 4, cellToPaint.Y + 20); }
            else if (name == "SINK")
            {
                gr.DrawEllipse(myPen, cellToPaint.X, cellToPaint.Y, this.cellSize - 4, this.cellSize - 4);
                gr.DrawString("SINK", myFont, myBrush, cellToPaint.X + 4, cellToPaint.Y + 20);
            }
            else if (name == "SOURCE")
            {
                gr.DrawEllipse(myPen, cellToPaint.X, cellToPaint.Y, this.cellSize - 4, this.cellSize - 4);
                gr.DrawString("Source", myFont, myBrush, cellToPaint.X + 1, cellToPaint.Y + 20);
            }
        }
        public void paintConnection(Graphics gr, Point coordinateA, Point coordinateB)
        {
            gr.DrawLine(myPen, coordinateA, coordinateB);

        }

        /// <summary>
        /// this function is called when we do the calcultion of circuit
        /// </summary>
        /// <param name="value">value currently in the connection</param>
        /// <returns>the color according to the value in connection</returns>
        public Color setConnectionColor(int value)
        {
            Color c = ColorTranslator.FromHtml("Green"); //
            return c ;

        }
        /// <summary>
        /// this function is used to select items on the circuit
        /// </summary>
        /// <param name="x">x-coordinate from mouse click</param>
        /// <param name="y">y-coordinate from mouse click</param>
        public void selectItem(Point coordinate)
        {
            Point celllocation = findlocation(coordinate);

        }
        
        /// <summary>
        /// checks weather provoded coordinates are already taken or not
        /// </summary>
        /// <param name="x">x-position from mouse click</param>
        /// <param name="y">y-position from mouse click</param>
        /// <returns>true if provided points are empty, returns false if points are already taken</returns>
        public bool checkOverlap(Point coordinate)
        {
            Point cellLocation = findlocation(coordinate);
            return false;
        }

        /// <summary>
        /// to change the value of source from 1 to 0 and vice-verse
        /// </summary>
        /// <param name="orginalValue">current value on source</param>
        /// <param name="x">x-postion of source </param>
        /// <param name="y">y-position 0f source</param>
        /// <returns> changed value</returns>
        public int changeValue(int orginalValue, Point coordinate)
        {
            Point cellLocation = findlocation(coordinate);
            return 343;
        }

        /// <summary>
        /// storing of circuit file
        /// </summary>
        /// <param name="fileName">any string value as name of file</param>
        public bool saveFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, this);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return false;
            }

        }
        /// <summary>
        /// to open saved circuit
        /// </summary>
        /// <param name="fileName">name of file to open</param>
        public Circuit openFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Circuit c = (Circuit)(bf.Deserialize(fs));

                return c;
            }
            catch
            {
                return null;
            }
        }

        public void New()
        {


        }
       
        public void drawAll(Graphics grid)
        {
            this.makeGrid(grid);
            for (int i = 0; i < listOfGates.Count(); i++)
            {
                
            }
            for (int i = 0; i < listOfConnections.Count(); i++)
            {
                
            }
        }

    }
}




        
        


    