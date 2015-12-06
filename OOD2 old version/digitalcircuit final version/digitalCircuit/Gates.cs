using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    [Serializable()]
    public abstract class Gate
    {
        protected int numOfInput;
        protected int numOfOutput;
        protected List<Gate> listOfInput;
        protected List<Gate> listOfOutput;
        protected Point position;
        protected int value;
        
        /// <summary>
        /// a gate is constructed 
        /// </summary>
        /// <param name="nrOfInput">number of input for the gate</param>
        /// <param name="nrOfOutput">number of output of the gate</param>
        public Gate(Point position, int nrOfInput, int nrOfOutput)
        {
            this.numOfInput = nrOfInput;
            this.numOfOutput = nrOfOutput;
            this.listOfInput = new List<Gate>();
            this.listOfOutput = new List<Gate>();
            this.position = position;
            this.value = -1;
        }

        /// <summary>
        /// gets the position of the gate on the grid
        /// </summary>
        /// <returns>the position</returns>
        public Point getPosition()
        {
            return this.position;
        }

        /// <summary>
        /// gets the value of the gate
        /// </summary>
        /// <returns>the value</returns>
        public int getValue()
        {
            return this.value;
        }

        /// <summary>
        /// calculate and return the value
        /// </summary>
        public abstract void calculateValue();
        
        /// <summary>
        /// checks weather the gate has available input for connection  or not
        /// </summary>
        /// <returns>true if there is available input</returns>
        public bool availableInput()
        {
            if (this.numOfInput == this.listOfInput.Count)
                return false;
            return true;
        }
        
        /// <summary>
        /// checks weather the gate has available output for connection or not
        /// </summary>
        /// <returns>true if there is available output</returns>
        public bool availableOutput()
        {
            if (this.numOfOutput == this.listOfOutput.Count)
                return false;
            return true;
        }

        /// <summary>
        /// connect gate to input side
        /// </summary>
        /// <param name="toConnect"></param>
        public void connectToInput(Gate toConnect)
        {
            this.listOfInput.Add(toConnect);
        }

        /// <summary>
        /// connect a gate to the output side
        /// </summary>
        /// <param name="toConnect"></param>
        public void connectToOutput(Gate toConnect)
        {
            this.listOfOutput.Add(toConnect);
        }

        /// <summary>
        /// removes a gate from the input or output
        /// </summary>
        /// <param name="toRemove">gate to remove</param>
        /// <returns>true or false</returns>
        public bool removeConnection(Gate toRemove)
        {
            if (this.listOfInput.Contains(toRemove))
            {
                this.listOfInput.Remove(toRemove);
                return true;
            }
            if (this.listOfOutput.Contains(toRemove))
            {
                this.listOfOutput.Remove(toRemove);
                return true;
            }
            return false;
        }
    }
}