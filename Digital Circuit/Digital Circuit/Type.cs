using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Circuit
{
    [Serializable]
    public enum Type
    {
        //types of the gates, no more used.
        Source = 1,
        Sink = 2,
        And = 3,
        Not = 4,
        Or = 5
    }
}
