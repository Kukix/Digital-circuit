using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    [Serializable()]
    class Source: Gate
    {
        public Source(Point position)
            : base(position, 0, 1)    // source has 1 output no inputs.
        {
        }

        public override void calculateValue()
        {
            if (this.listOfOutput.Count == 0)
            {
                this.value = -1;
            }
            else if (this.listOfOutput.Count != 0 && this.value == -1)
            {
                this.value = 0;
            }
        }

        /// <summary>
        /// change the value of the source between 1 and 0
        /// </summary>
        public void changeValueSource()
        {
            if (this.listOfOutput.Count != 0)
            {
                if (this.value == 1)
                {
                    this.value = 0;
                }
                else
                {
                    this.value = 1;
                }
            }
        }
    }
}