using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace digitalCircuit
{
    [Serializable()]
    class Sink: Gate
    {
        public Sink(Point position)
            : base(position, 1, 0)
        {
        }

        public override void calculateValue()
        {
            if (this.listOfInput.Count == 0)
            {
                this.value = 0;
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
                    this.value = 0;
                }
            }
        }
    }
}