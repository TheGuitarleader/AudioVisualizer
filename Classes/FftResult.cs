using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer.Classes
{
    internal class FftResult
    {
        public long TimeStamp { get; } = Environment.TickCount64;
        public double[] Samples { get; set; } = [];
        public double[] Frequencies { get; set; } = [];
        public double[] Magnitudes { get; set; } = [];

        public static FftResult Null = new();
    }
}
