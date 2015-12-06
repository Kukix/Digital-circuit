using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    class Sink: Gate
    {

        private Color sinkColor;
        private int value;

        public Sink(string name, int nrOfInputs, int nrOfOutputs)
            : base(name,nrOfInputs,nrOfOutputs)
        {
                         // default color of sink is white i.e it will have value 0 by default
            this.sinkColor = ColorTranslator.FromHtml("white");
            this.value = 0; // default value of source is 0
        }
        /// <summary>
        /// this property Sink value is used to get and set the value on sink
        /// </summary>
        public int  sinkValue
        {
            get {return value ;}
            set { }
            
        }
        /// <summary>
        /// this set function is used to set the color of sink according to value eithr 0 (white) or 1 ( blue)
        /// </summary>
        /// <param name="value">it is the final value on sink after calculating all circuit </param>
        
        public void setSinkColor(int value)
        {
           if (value == 1 ) {this.sinkColor = ColorTranslator.FromHtml("blue");}
               else ColorTranslator.FromHtml("white");
        }

        //this function is ovver ride here to 
        public override bool availableInput(int x, int y)
        {
            return true;
        }

        public override bool availableOutput(int x, int y)
        {
            return false;  // always false for sink
        }
        public override int calculateValue()
        {
            int value = 0;
            return value;
        }
    
    }
}
