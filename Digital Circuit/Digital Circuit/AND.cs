﻿using System;
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
    class AND : RectangleCircle
    {
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="id"></param>
        public AND(int id)
            : base(id)
        {
            base.Text = "AND";
        }

        /// <summary>
        /// calculate the gate's out value, overwrite the old method in the super class.
        /// </summary>
        public override void CalculateValue()
        {
            if (this.Invalue1 == -1 || this.Invalue2 == -1)
                this.Outvalue = -1;
            else
            {
                if (this.Invalue1 == 1 && this.Invalue2 == 1)
                    this.Outvalue = 1;
                else
                    this.Outvalue = 0;
            }
        }
    }
}
