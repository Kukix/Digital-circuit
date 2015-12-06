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
    class RectangleCircle : Gate
    {
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="id"></param>
        public RectangleCircle(int id)
            : base(id)
        {
            
        }

        /// <summary>
        /// overwrite the old method in the super class.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public override bool InGate(Point pt)
        {
            if ((pt.X >= (this.Location.X - 10)) && (pt.X <= (this.Location.X + this.Radius - 10)) && (pt.Y >= (this.Location.Y - 10)) && (pt.Y <= (this.Location.Y + this.Radius - 10)))
                return true;
            else
                return false;
        }
    }
}
