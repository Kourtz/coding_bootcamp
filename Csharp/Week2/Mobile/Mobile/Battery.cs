using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    class Battery
    {
        public string Type { get; private set; }
        public int Capacity { get; private set; }

        public Battery(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }

    }
}
