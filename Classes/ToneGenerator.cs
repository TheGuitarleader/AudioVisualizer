using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer.Classes
{
    internal class ToneGenerator : WaveProvider32
    {
        private double _phase;

        public double Frequency { get; set; } = 440.0;

        public ToneGenerator() : base(48000, 1) { }

        public override int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[offset + i] = (float)Math.Sin(_phase * 2.0 * Math.PI);
                _phase += Frequency / WaveFormat.SampleRate;

                if (_phase >= 1.0) _phase -= 1.0;
            }

            return count;
        }
    }
}
