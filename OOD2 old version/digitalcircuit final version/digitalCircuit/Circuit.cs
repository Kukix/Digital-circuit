using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace digitalCircuit
{
    [Serializable()]
    public class Circuit
    {
        private string name;
        private List<Gate> listOfGates;
        private List<Connection> listOfConnections;
        private int nrOfgridColumns, nrOfgridRows, cellSize;

        string fileLocation;
       

        
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
            this.listOfGates = new List<Gate>();
            this.listOfConnections = new List<Connection>();
        }

        /// <summary>
        /// draw the grid
        /// </summary>
        /// <param name="grid"></param>
        public void makeGrid(Graphics grid)  
        {
            Pen p = new Pen(Color.Black);
            p.Width = 1;

            for (int i = 0; i <= this.nrOfgridRows; i++)    
            {
                grid.DrawLine(p, 0, i * this.cellSize, this.cellSize * nrOfgridRows, i * this.cellSize);
            }
            for (int i = 0; i <= this.nrOfgridColumns; i++)    
            {
                grid.DrawLine(p, i * this.cellSize, 0, i * this.cellSize, this.cellSize * nrOfgridColumns);
            }
        }

        /// <summary>
        /// find the location of cell , to put gate or connection
        /// </summary>
        /// <param name="coordinate">coordinate on grid </param>
       
        /// <returns>the point coordinate of a cell</returns>
        public Point findlocation(Point coordinate)
        {
            int cell_X = (coordinate.X / this.cellSize) * this.cellSize;
            int cell_Y = (coordinate.Y / this.cellSize) * this.cellSize;
            
            Point cellCoordinate = new Point(cell_X,cell_Y);
            return cellCoordinate;
        }
       

        /// <summary>
        /// add a gate to the list
        /// </summary>
        /// <param name="name">name of the gate</param>
        /// <param name="coordinate">location of where was clicked to add the gate</param>
        /// <returns>true if added or false if not added</returns>
        public bool addGate(string name, Point coordinate)
        {
            Point position = findlocation(coordinate);
            if (checkOverlap(position))
                return false;

            // add the gate to the list
            Gate gateToAdd;
            switch (name)
            {
                case "OR": gateToAdd = new Or(position); break;
                case "AND": gateToAdd = new And(position); break;
                case "NOT": gateToAdd = new Not(position); break;
                case "SINK": gateToAdd = new Sink(position); break;
                case "SOURCE": gateToAdd = new Source(position); break;
                default: return false;
            }
            this.listOfGates.Add(gateToAdd);
            return true;
        }

        /// <summary>
        /// removes the gate from the cell at given position
        /// </summary>
        /// <param name="coordinate">the click point</param>
        /// <returns>true if removed or false if not removed</returns>
        public bool removeGate(Point coordinate)
        {
            // see if there is a gate at that location.
            Point position = findlocation(coordinate);
            Gate gateToRemove = getGate(position);
            if (gateToRemove == null)
            {
                return false;
            }

            // check if we have to remove connections
            List<Connection> toRemove = new List<Connection>();
            foreach (Connection c in this.listOfConnections)
            {
                if (c.getInputGate() == gateToRemove)
                {
                    c.getOutputGate().removeConnection(gateToRemove);
                    // recalculate values beginning on the output side of the connection
                    calculateValue(c.getOutputGate());
                    toRemove.Add(c);
                }
                else if (c.getOutputGate() == gateToRemove)
                {
                    c.getInputGate().removeConnection(gateToRemove);
                    // recalculate values beginning on the input side of the connection
                    calculateValue(c.getInputGate());
                    toRemove.Add(c);
                }
            }
            foreach (Connection c in toRemove)
            {
                this.listOfConnections.Remove(c);
            }

            // remove the gate
            this.listOfGates.Remove(gateToRemove);


            return true;
        }

        /// <summary>
        /// make a connection
        /// </summary>
        /// <param name="coordinateOutput">point of the output</param>
        /// <param name="coordinateInput">point of the input</param>
        /// <returns>true if connection made or false if connection not made</returns>
        public bool makeConnection(Point coordinateOutput, Point coordinateInput)
        {
            // check of the gates exists first
            Gate gateOutput = getGate(findlocation(coordinateOutput));
            Gate gateInput = getGate(findlocation(coordinateInput));
            if (gateOutput == null || gateInput == null)
                return false;

            // check if the gates can connect
            if (!gateOutput.availableOutput() || !gateInput.availableInput())
                return false;

            // make the connection
            gateOutput.connectToOutput(gateInput);
            gateInput.connectToInput(gateOutput);

            // add the connection to the list
            this.listOfConnections.Add(new Connection(gateOutput, gateInput));

            // recalculate values beginning on the output side of the connection
            calculateValue(gateOutput);

            return true;
        }

        /// <summary>
        /// remove connection between two points
        /// </summary>
        /// <param name="coordinate">click</param>
        public bool removeConnection(Point coordinate)
        {
            // find the connection first
           // Connection connectionToRemove = null;
            foreach (Connection c in this.listOfConnections)
            {
                bool intersect = false;
                Point outputCoordinate;
                Point inputCoordinate;

                /*
                 * TODO: do so calculation here to check if the point we clicked intersects
                 * with the line between the two points outputCoordinate and inputCoordinate
                 * if it intersect change the bool intersect to true
                 */



                if (intersect)
                {
                    // remove the connection
                    c.getOutputGate().removeConnection(c.getInputGate());
                    c.getInputGate().removeConnection(c.getOutputGate());
                    calculateValue(c.getOutputGate());  // recalculate from the output side
                    calculateValue(c.getInputGate());   // recalculate from the input side
                    this.listOfConnections.Remove(c);
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// checks weather provoded coordinates are already taken or not
        /// </summary>
        /// <param name="position">the position to check</param>
        /// <returns>false if provided points are empty, returns true if points are already taken</returns>
        public bool checkOverlap(Point position)
        {
            if (getGate(position) != null)
                return true;
            return false;
        }

        /// <summary>
        /// change the value of the source
        /// </summary>
        /// <param name="coordinate">click</param>
        /// <returns>true if changed or false if not changed or no source at click</returns>
        public bool changeValueSource(Point coordinate)
        {
            // find the source
            Gate sourceToChange = getGate(findlocation(coordinate));
            if (sourceToChange != null)
            {
                if (sourceToChange.GetType() == typeof(Source))
                {
                    // change the value
                    (sourceToChange as Source).changeValueSource();
                    calculateValue(sourceToChange);
                    return true;
                }
            }
            return false;
        }
        public bool checkCircuitEmpty()
        {
            if (listOfGates.Count == 0 && listOfConnections.Count == 0) { return true; }
            else return false;

        }
        public bool SavedFile()    //only for already saved file
        {
            if (fileLocation != null)
            {
                return saveFile(fileLocation);
            }
            return false;
        }

        /// <summary>
        /// storing of circuit file
        /// </summary>
        /// <param name="fileName">any string value as name of file</param>
        public bool saveFile(string fileName)
        {
           
                fileLocation = fileName;
            try
            {
                FileStream filesteam= new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryformatter = new BinaryFormatter();
                

                binaryformatter.Serialize(filesteam, this);
                filesteam.Close();
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
            fileLocation = fileName;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Circuit c = (Circuit)(bf.Deserialize(fs));
                fs.Close();

                return c;
            }
            catch
            {
                return null;
            }

        }

        public void New()
        {
            this.listOfConnections.Clear();
            this.listOfGates.Clear();
           

        }

        /// <summary>
        /// draw a gate
        /// </summary>
        /// <param name="gate"></param>
        /// <param name="gr"></param>
        /// <param name="coordinate"></param>
        public void paintGateFunction(Gate gate, Graphics gr, Point coordinate)
        {
            if (gate == null)
                return;

            // get where we need to draw and what we need to draw on grid
            Point position = findlocation(coordinate);
            string imageName = "";

            if (gate.GetType() == typeof(Source))
                imageName = "gate_SOURCE_";
            else if (gate.GetType() == typeof(Sink))
                imageName = "gate_SINK_";
            else if (gate.GetType() == typeof(Or))
                imageName = "gate_OR_";
            else if (gate.GetType() == typeof(And))
                imageName = "gate_AND_";
            else if (gate.GetType() == typeof(Not))
                imageName = "gate_NOT_";
            else
                return;

            // attach value to name
            imageName += gate.getValue().ToString();

            Bitmap image = new Bitmap("Graphics/" + imageName + ".png");
            gr.DrawImage(image, position.X + 1, position.Y + 1, this.cellSize - 2, this.cellSize - 2);
        }

        /// <summary>
        /// draw a connection
        /// </summary>
        /// <param name="gr">the grid to paint</param>
        /// <param name="con">the connection</param>
        public void paintConnection(Graphics gr, Connection con)
        {
            // calulate line points
            Point outputPoint = findlocation(con.getOutputGate().getPosition());
            Point inputPoint = findlocation(con.getInputGate().getPosition());
            outputPoint.X += this.cellSize;
            outputPoint.Y += (this.cellSize / 2);
            inputPoint.Y += (this.cellSize / 2);

            // check the value and decide on color
            Color penColor;
            if (con.getCurrentValue() == 0)
                penColor = Color.Blue;
            else if (con.getCurrentValue() == 1)
                penColor = Color.LightGreen;
            else
                penColor = Color.Red;

            // draw the line
            gr.DrawLine(new Pen(penColor, 4), outputPoint, inputPoint);
        }

        /// <summary>
        /// draw everything
        /// </summary>
        /// <param name="grid">place to draw</param>
        public void drawAll(Graphics grid)
        {
            grid.Clear(Color.White);
            makeGrid(grid);

            // draw all the gates
            foreach (Gate gate in this.listOfGates)
            {
                paintGateFunction(gate, grid, gate.getPosition());
            }
            // draw all the connections
            foreach (Connection con in this.listOfConnections)
            {
                paintConnection(grid, con);
            }
        }

        /// <summary>
        /// get a gate from the list
        /// </summary>
        /// <param name="position">position of the gate</param>
        /// <returns>the gate or null if the gate is not found</returns>
        private Gate getGate(Point position)
        {
            foreach (Gate gate in this.listOfGates)
            {
                if (gate.getPosition() == position)
                    return gate;
            }
            return null;
        }

        /// <summary>
        /// clears the grid
        /// </summary>
        /// <param name="grid"></param>
        public void clearAll(Graphics grid)
        {
            this.listOfGates = new List<Gate>();
            this.listOfConnections = new List<Connection>();
            drawAll(grid);
        }

        /// <summary>
        /// calculate the values for all gates
        /// </summary>
        /// <param name="startingGate">gate to start calculating from</param>
        private void calculateValue(Gate startingGate)
        {
            // make a list of gates we have to calculate the value for
            List<Gate> listToCalculate = new List<Gate>();
            listToCalculate.Add(startingGate);

            while (listToCalculate.Count > 0)
            {
                Gate nextToCalculate = listToCalculate[0];          // get the next gate on top of the list
                nextToCalculate.calculateValue();                   // calculate the value
                listToCalculate.Remove(nextToCalculate);            // then remove it from the list

                // add all the gates connected to this one to the list
                foreach (Connection c in this.listOfConnections)
                {
                    if (c.getOutputGate() == nextToCalculate)
                    {
                        listToCalculate.Add(c.getInputGate());
                    }
                }
            }
        }
    }
}