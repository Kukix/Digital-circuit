using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalCircuit
{
    [Serializable()]
    class Not: Gate
    {                                    
        /*  INPUT    OUTPUT
            A   B
            0	1	
            1	0
         */
        public Not(Point position)
            : base(position, 1, 1)
        {
        }

        public override void calculateValue()
        {
            if (this.listOfInput.Count == 1)
            {
                if (this.listOfInput[0].getValue() == 1)
                    this.value = 0;
                else
                    this.value = 1;
            }
            else
            {
                this.value = -1;
            }
        }
    }
}