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
    class Gate
    {
        /// <summary>
        /// some prop of this class, 1st one the unique ID.
        /// </summary>
        public int GateID { get; set; }//unique gate id

        /// <summary>
        /// the background color of the gate, will be changed based on its value.
        /// </summary>
        public Color BgColor { get; set; }

        /// <summary>
        /// the location of the gate.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// the radius of the gate.
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// the text that will be shown for different gates.
        /// for the source it will be none, for and it will be "AND", for or it will be "OR", for not it will be "NOT"
        /// and for sink it will be the sink value.
        /// </summary>
        public string Text { get; set; }
        //public bool Actived { get; set; }//use a selected gate instead.

        /// <summary>
        /// the incoming values and out values of the gates.
        /// all initialized as -1. the color based on its out value.
        /// source has 0 incoming value and many out values.
        /// sink has 1 incoming value and 0 out value.
        /// and has 2 incoming value and many out values.
        /// or has 2 incoming value and many out values.
        /// not has 1 incoming value and many out values.
        /// for some reason we still put this in the super class intead of putting them in their own sub classes.
        /// </summary>
        public int Invalue1 { get; set; }
        public int Invalue2 { get; set; }
        public int Outvalue { get; set; }

        /// <summary>
        /// constructor of this class
        /// initialize all the properities.
        /// </summary>
        /// <param name="id"></param>
        public Gate(int id)
        {
            this.GateID = id;
            this.BgColor = Color.Yellow;//initial color without value is yellow.s
            this.Location = new Point();
            this.Radius = 40;
            this.Invalue1 = this.Invalue2 = this.Outvalue = -1;
        }

        /// <summary>
        /// set the location of the gate.
        /// </summary>
        /// <param name="p"></param>
        public void SetLocation(Point p)
        {
            this.Location = p;
        }

        /// <summary>
        /// a method to check if the potion passed as the param is in side the gate.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public virtual bool InGate(Point p)
        {
            return true;
        }

        /// <summary>
        /// a method to check if the potion passed as the param is enough far away from this gate.
        /// if it is, return true, which means allowing 1 more gates around, if not, then false.
        /// this is a method to avoid overlapping.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Allow1MoreAround(Point p)
        {
            if ((Math.Abs(p.X - this.Location.X) > this.Radius) || (Math.Abs(p.Y - this.Location.Y) > this.Radius))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// calculate the values of the gate, different gate has different algorithm to compute.
        /// </summary>
        public virtual void CalculateValue()
        {
            //will be overwrited in the subclasses.
        }

        /// <summary>
        /// set the gate color to Green.
        /// </summary>
        public void ResetBG2Green()
        {
            this.BgColor = Color.Green;
        }

        /// <summary>
        /// change the gate color to red.
        /// </summary>
        public void ResetBG2Red()
        {
            this.BgColor = Color.Red;
        }
    }
}
