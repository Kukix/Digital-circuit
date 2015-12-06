using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    class Source: Gate
    {
        private Color sourceColor;
        private int value;



        public Source(string name, int nrOfInputs, int nrOfOutputs)
            : base(name,nrOfInputs,nrOfOutputs)
        {
                         // default color of source is green i.e it will have value 1 by default
            this.sourceColor = ColorTranslator.FromHtml("Green");
            this.value = 1; // default value of source is 1
        }
        public int  sourceValue
        {
            get {return value ;}
            set { }
            
        }

        public Color setSourceColor(int value)
        {
            return ColorTranslator.FromHtml("Green");
        }

        public override bool availableInput(int x, int y)
        {
            return false;     //always false for sink
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
