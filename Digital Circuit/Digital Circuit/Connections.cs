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
    class Connections
    {
        /// <summary>
        /// the left gate of the connnection.
        /// </summary>
        public Gate Left { get; set; }

        /// <summary>
        /// the right gate of the connection.
        /// </summary>
        public Gate Right { get; set; }

        /// <summary>
        /// the line's color, also means the line's value.
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// this means if the connection is selected.
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        public Connections(Gate l,Gate r)
        {
            this.Left = l;
            this.Right = r;
            this.LineColor = Color.Black;
            this.Actived = false;
        }

        /// <summary>
        /// set the left gate of the connection.
        /// </summary>
        /// <param name="l"></param>
        public void SetLfet(Gate l)
        {
            this.Left = l;
        }

        /// <summary>
        /// set the right gate of the connection.
        /// </summary>
        /// <param name="r"></param>
        public void SetRight(Gate r)
        {
            this.Right = r;
        }

        /// <summary>
        /// check if the connection is valie.
        /// simple check, source can not be on the right side and sink can not be on the left side.
        /// </summary>
        /// <returns></returns>
        public bool ConnectionValid()
        {
            if (Left is SINK)
                return false;
            if (Right is SOURCE)
                return false;
            return true;
        }
    }
}
