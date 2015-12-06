using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Circuit
{
    [Serializable]
    class SINK:CircleGate
    {
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="id"></param>
        public SINK(int id)
            : base(id)
        {

        }

        /// <summary>
        /// calculate the gate's out value, overwrite the old method in the super class.
        /// </summary>
        public override void CalculateValue()
        {
            this.Outvalue = this.Invalue1;
        }
    }
}
