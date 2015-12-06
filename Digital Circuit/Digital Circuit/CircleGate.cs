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
    class CircleGate : Gate
    {
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="id"></param>
        public CircleGate(int id)
            : base(id)
        {
            
        }

        /// <summary>
        /// overwrite the old method in the super class.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool InGate(Point p)
        {
            if (((this.Location.X + 10 - p.X) * (this.Location.X + 10 - p.X) + (this.Location.Y + 10 - p.Y) * (this.Location.Y + 10 - p.Y)) < 400)
                return true;
            else
                return false;
        }
    }
}
