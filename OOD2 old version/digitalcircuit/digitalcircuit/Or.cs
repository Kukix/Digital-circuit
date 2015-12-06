using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalCircuit
{
    class OR: Gate
    {                                               /*  NPUT    OUTPUT
                                                A + B
                                                0	0	0
                                                0	1	1
                                                1	0	1
                                                1	1	1    */

        
        private int inputValueA ;
        private int inputValueB ;
        private int outputValue; 

        public OR(string name, int nrOfInputs, int nrOfOutputs)
            : base(name, nrOfInputs, nrOfOutputs)
        {
           
            this.inputValueA = 0;
            this.inputValueB = 0;
            this.outputValue = 0;  //initially and gate has 0 value as inputs and output

        }
        /// <summary>
        /// property of input value A , to get and set the value of gate at that socket
        /// </summary>
        public int ORInputA
        {
            get { return inputValueA; }
            set { }
        }
        /// <summary>
        /// property of input value B , to get and set the value of gate at that socket
        /// </summary>
        public int ORInputB
        {
            get { return inputValueB; }
            set { }
        }
        /// <summary>
        /// property of output value  , to get and set the value of gate at that socket
        /// </summary>
        public int ORoutput
        {
            get { return outputValue; }
        }

        public override bool availableInput(int x, int y)
        {
            return false;     //checks both input point 
        }

        public override bool availableOutput(int x, int y)
        {
            return true;
        }
        public override int calculateValue()
        {
            int value = 0;
            return value;
        }

    }
}
