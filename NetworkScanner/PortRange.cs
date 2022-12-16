using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkScanner
{
    public class PortRange
    {
        private int min;
        public int Min { get { return min; } }

        private int max;
        public int Max { get { return max; } }

        public PortRange(int min,  int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
