using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    class Connection
    {
        private static Color connectionColor;
        Gate inputGate;
        Gate outputGate;
        /*private int XstartPosition;
        private int YstartPosition;
        private int XendPosition;
        private int YendPosition;*/
        private int currentValue=0; // default value in connection is 0

      /*  /// <summary>
        /// connection is done between two gates always output with input,output output or input input cannot be connected
        /// </summary>
        /// <param name="X1">x-position from the first mouseclick</param>
        /// <param name="Y1">y-position from the first mouseclick</param>
        /// <param name="X2">x-position from the second mouseclick</param>
        /// <param name="Y2">y-position from the second mouseclick</param>*/
        public Connection(Gate firstGate , Gate lastGate)
        {
            this.inputGate = firstGate;
            this.outputGate = lastGate;

        }
        
        public int getCurrentValue()  // gives the current value in individual connection
        {
            return currentValue;

        }

        public Color getColor()    // gives the color of connection
        {
            return connectionColor;
        }

        public void setColor(int value) // sets the color of connection based on its value 
        {                               // only three type of color is used in circuit
            
            if (value == 1) { connectionColor = ColorTranslator.FromHtml("Green");  }
            if (value == 0) { connectionColor = ColorTranslator.FromHtml("Yellow"); }
            else connectionColor = ColorTranslator.FromHtml("Red");

        }
    }
}
