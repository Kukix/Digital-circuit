using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    [Serializable()]
    public class Connection
    {
        private Gate inputGate;
        private Gate outputGate; 

        /// <summary>
        /// connection is done between two gates always output with input,output output or input input cannot be connected
        /// </summary>
        /// <param name="firstGate">output side</param>
        /// <param name="lastGate">input side</param>
        public Connection(Gate firstGate, Gate lastGate)
        {
            this.outputGate = firstGate;
            this.inputGate = lastGate;
        }

        public Gate getOutputGate()
        {
            return this.outputGate;
        }

        public Gate getInputGate()
        {
            return this.inputGate;
        }
        
        public int getCurrentValue()  // gives the current value in individual connection
        {
            return outputGate.getValue();
        }
    }
}