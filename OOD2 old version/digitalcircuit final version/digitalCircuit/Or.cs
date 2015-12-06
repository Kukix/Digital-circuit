using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalCircuit
{
    [Serializable()]
    class Or: Gate
    {                                       
        /*  INPUT    OUTPUT
            A + B
            0	0	0
            0	1	1
            1	0	1
            1	1	1
         */
        public Or(Point position)
            : base(position, 2, 1)
        {
        }

        public override void calculateValue()
        {
            if (this.listOfInput.Count < 2)
            {
                this.value = -1;
            }
            else
            {
                foreach (Gate gate in this.listOfInput)
                {
                    if (gate.getValue() == 1)
                    {
                        this.value = 1;
                        return;
                    }
                }
                this.value = 0;
            }
        }
    }
}