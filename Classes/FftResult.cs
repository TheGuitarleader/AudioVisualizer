using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer.Classes
{
    internal class FftResult
    {
        public double[] Samples { get; set; }
        public double[] Frequencies { get; set; }
        public double[] Magnitudes { get; set; }
    }
}
