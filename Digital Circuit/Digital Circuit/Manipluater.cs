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
    class Manipluater
    {
        /// <summary>
        /// list of gates and connections, used to store all the gates and connections.
        /// </summary>
        public List<Gate> Gates { get; set; }
        public List<Connections> Connection { get; set; }

        /// <summary>
        /// constructor.
        /// </summary>
        public Manipluater()
        {
            this.Gates = new List<Gate>();
            this.Connection = new List<Connections>();
        }

        /// <summary>
        /// add 1 gate to the list
        /// </summary>
        /// <param name="g"></param>
        public void Add1Gate(Gate g)
        {
            Gates.Add(g);
        }

        /// <summary>
        /// remove 1 gate.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public List<Connections> Remove1Gate(Gate g)
        {
            List<Connections> temp = new List<Connections>();
            foreach (Connections c in this.Connection)
            {
                if (c.Left.GateID == g.GateID || c.Right.GateID == g.GateID)
                {
                    temp.Add(c);
                }
            }
            Gates.RemoveAll(t => t.GateID == g.GateID);
            RemoveConnections(g);
            return temp;
        }

        /// <summary>
        /// remove all related connections when removing 1 gate.
        /// </summary>
        /// <param name="g"></param>
        public void RemoveConnections(Gate g)
        {
            Connection.RemoveAll(x => (x.Left.GateID == g.GateID || x.Right.GateID == g.GateID));
        }

        /// <summary>
        /// remove 1 connection.
        /// </summary>
        /// <param name="c"></param>
        public void Remove1Connection(Connections c)
        {
            Connection.RemoveAll(x => x == c);
        }

        /// <summary>
        /// refresh and set all connection's color.
        /// </summary>
        public void ReSetAllConnectionsColor()
        {
            foreach (Connections c in this.Connection)
            {
                c.Actived = false;
            }
        }

        /// <summary>
        /// get the gate in some specific area.
        /// since we have 2 different shape of gates.
        /// the method will be overwritten in the sub classes.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Gate GetGateByLocation(Point p)
        {
            foreach (Gate g in Gates)
            {
                if (g.InGate(p))
                    return g;
            }
            return null;
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
            foreach (Gate gt in Gates)
            {
                if (!gt.Allow1MoreAround(p))
                    return false;
            }
            return true;
        }

        //-----------------------------------------------------

        /// <summary>
        /// add 1 connection.
        /// </summary>
        /// <param name="c"></param>
        public void Add1Connection(Connections c)
        {
            Connection.Add(c);
        }

        /// <summary>
        /// check if the connection already exsit.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool ConnectonExsit(Gate l, Gate r)
        {
            foreach (Connections  c in Connection)
            {
                if (c.Left == l && c.Right == r)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// check if the connection is valid or not.
        /// different with the one in the connection class.
        /// here we check more, for example, a AND gate can only have 2 incoming values
        /// so if you are trying to give it a 3rd connection, then it is not possible.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool ConnectionValid(Connections c)//check if the connection user is going to add is valid or not.
        {
            foreach (Gate g in Gates)
            {
                foreach (Connections ce in Connection)
                {
                    if (g is NOT || g is SINK)
                    {
                        if (ce.Right.GateID == g.GateID && c.Right.GateID == g.GateID)
                            return false;
                    }
                    if (g is AND || g is OR)
                    {
                        if (ce.Right.GateID == g.GateID && c.Right.GateID == g.GateID)
                        {
                            foreach (Connections ce2 in Connection)
                            {
                                if (ce2.Right.GateID == g.GateID && c.Right.GateID == g.GateID && ce != ce2)
                                    return false;
                            }
                        }
                    }
                }
            }
            return true;
            
        }

        /// <summary>
        /// change color of connectons based on their values.
        /// change color of all gates based on their values.
        /// </summary>
        public void ChangeColorForAll()
        {
            //clear first, otherwise other gates' values will not be changed.
            foreach (Gate g in Gates)
            {
                if (!(g is SOURCE))
                    g.Invalue1 = g.Invalue2 = g.Outvalue = -1;
            }

            //calculate all the values of the connections and the gates.
            //we should do not need the loop here, but for some reason we need.
            //because in the calculate value method, i did the iterative loop to check, for every loop if there is any new gate changing its value.
            //if no, then stop, but for some reason, sometimes 1 iterative loop is not enough(a small chance)
            //and after testing the program for many times, we found that 2 should be a sufficient number, but just incase, finally we decided to use 4 times loop.
            for (int i = 0; i < 4; i++)
            {
                CalculateValue();
            }

            //set all the color of the gates.
            foreach (Gate g in Gates)
            {
                if (g is SINK)
                {
                    if (g.Outvalue == 1)
                    {
                        g.Text = "1";
                    }
                    else
                        if (g.Outvalue == 0)
                        {
                            g.Text = "0";
                        }
                        else
                            g.Text = "";
                }
            }

            //set all the color of the connection.
            foreach (Gate g in Gates)
            {
                if (g.Outvalue == -1)
                {
                    g.BgColor = Color.Yellow;
                    foreach (Connections c in Connection)
                    {
                        if (c.Left.GateID == g.GateID)
                            c.LineColor = Color.Black;
                    }
                }
                if (g.Outvalue == 0)
                {
                    g.BgColor = Color.Red;
                    foreach (Connections c in Connection)
                    {
                        if (c.Left.GateID == g.GateID)
                            c.LineColor = Color.Red;
                    }
                }
                if (g.Outvalue == 1)
                {
                    g.BgColor = Color.Green;
                    foreach (Connections c in Connection)
                    {
                        if (c.Left.GateID == g.GateID)
                            c.LineColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// calculate all the values for the connections and the gates.
        /// use a couner to calculate how many gates' out value is still -1.
        /// stop the loop until no more gates' value is changed.
        /// </summary>
        int counter = 0;
        public void CalculateValue()
        {
            foreach (Connections c in Connection)
            {
                if (c.Left.Outvalue != -1)
                {
                    //c.WithSource = true;
                    if (c.Right is AND || c.Right is OR)
                    {
                        c.Right.Invalue1 = c.Left.Outvalue;
                        foreach (Connections ce in Connection)
                        {
                            if (ce.Right.GateID == c.Right.GateID && ce.Left.GateID != c.Left.GateID)
                                c.Right.Invalue2 = ce.Left.Outvalue;
                        }
                    }
                    if (c.Right is SINK || c.Right is NOT)
                    {
                        c.Right.Invalue1 = c.Left.Outvalue;
                    }
                }
            }
            foreach (Gate g in Gates)
            {
                g.CalculateValue();
            }

            int counterInside = 0;
            foreach (Gate g in Gates)
            {
                if (g.Outvalue != -1)
                    counterInside++;
            }
            if (counterInside != counter)
            {
                counter = counterInside;
                CalculateValue();
            }
        }

    }
}
