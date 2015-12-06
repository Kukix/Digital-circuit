using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalCircuit
{
    class Not: Gate
    {                                    /*  NPUT    OUTPUT
                                                A   B
                                                0	1	
                                                1	0	                               */
        private int inputValue ;
        private int outputValue; 

        public Not(string name, int nrOfInputs, int nrOfOutputs)
            : base(name, 1, 1)
        {
           
            this.inputValue = 0;  // initially Not gate has 0 as input
            this.outputValue = 1;  //initially Not gate has 1 as output

        }
        /// <summary>
        /// property of input value  , to get and set the value of gate at that socket
        /// </summary>
        public int NotInput
        {
            get { return inputValue; }
            set { }
        }
       
        /// <summary>
        /// property of output value  , to get and set the value of gate at that socket
        /// </summary>
        public int Notoutput
        {
            get { return outputValue; }
        }

        public override bool availableInput(int x, int y)
        {
            return false;    
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
