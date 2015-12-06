using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalCircuit
{
    class And: Gate
        
    {                                       /*  NPUT    OUTPUT
                                                A + B
                                                0	0	0
                                                0	1	0
                                                1	0	0
                                                1	1	1    */
        private int inputValueA ;
        private int inputValueB ;
        private int outputValue;
        bool inputSocketAConnected, inputSocketBConnected;
        bool outputSocketConnected;

        public And(string name, int nrOfInputs, int nrOfOutputs)
            : base("AND", 2,1)
        {
            this.inputValueA = -1;
            this.inputValueB = -1;
            // //initially and gate has -1 value as inputs 
            this.outputValue = this.calculateValue();
            this.inputSocketAConnected = false;
            this.inputSocketBConnected = false;
            this.outputSocketConnected = false;

        }
        /// <summary>
        /// property of input value A , to get and set the value of gate at that socket
        /// </summary>
        public int AndInputA
        {
            get { return inputValueA; }
            set { }
        }
        /// <summary>
        /// property of input value B , to get and set the value of gate at that socket
        /// </summary>
        public int AndInputB
        {
            get { return inputValueB; }
            set { }
        }
        /// <summary>
        /// property of output value  , to get and set the value of gate at that socket
        /// </summary>
        public int Andoutput
        {
            get { return outputValue; }
        }

        public override bool availableInput(int x, int y)
        {
            int freePort = 0 ;
            if (inputSocketAConnected ==false && inputSocketAConnected == false )
            {
                freePort = 2;
                return true;

            }
            else if (inputSocketAConnected == true && inputSocketAConnected == false)
            {
                freePort = 1;
                return true;
            }
            else
            {
                freePort = 0;
                return false;
            }
        }

        public override bool availableOutput(int x, int y)
        {
            return true;
        }
       
        public override int calculateValue()
        {
            int mytemp = -1;
            if (inputSocketAConnected && inputSocketBConnected)
            {
                if (inputValueA == 1 && inputValueB == 1)
                {
                    mytemp = 1;
                }
                else if ((inputValueA == 1 && inputValueB == 0) || (inputValueA == 0 && inputValueB == 1) || (inputValueA == 0 && inputValueB == 0))
                {
                    mytemp = 0;
                }
                else
                {
                    mytemp = -1;
                }

            }
            return mytemp;
        }
        
    
    
    
    
    
    
    
    
    }



}
