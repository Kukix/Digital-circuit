using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    abstract class Gate
    {
       
        protected int numOfInput;
        protected int numOfOutput;
        protected List<int> inputs = new List<int>();
        protected Point position;
        

       /// <summary>
       /// a gate is constructed 
       /// </summary>
       /// <param name="type">gate type i.e source , or , and , not or sink</param>
       /// <param name="nrOfInput">number of input for the gate</param>
       /// <param name="nrOfOutput">number of output of the gate</param>
        public Gate(string type, int nrOfInput, int nrOfOutput)
        {
            this.position = new Point();
            this.numOfInput = nrOfInput;
            this.numOfOutput = nrOfOutput;
        }
       
        /// <summary>
        /// get number of input point
        /// </summary>
        /// <returns>number of input point in a gate</returns>
        public int getNrofInput()
        {
            return numOfInput;
        }
        /// <summary>
        /// to calcualte how many output socket does a gate has
        /// </summary>
        /// <returns>number of output point</returns>
        public int getNrofOutput()
        {
            return numOfOutput;
        }
        public abstract int calculateValue();
        
        /// <summary>
        /// checks weather the gate has available input for connection  or not
        /// </summary>
        /// <param name="x">x-position of the gate in circuit </param>
        /// <param name="y">y-position of the gate in circuit</param>
        /// <returns>true if there is available input</returns>
        public abstract bool availableInput(int x, int y);
        
        /// <summary>
        /// checks weather the gate has available output for connection or not
        /// </summary>
        /// <param name="x">x-position of the gate in circuit </param>
        /// <param name="y">y-position of the gate in circuit</param>
        /// <returns>true if there is available output</returns>
        public abstract bool availableOutput(int x , int y);   // this function is overriden in its inheritance class
        

       

    }
}
