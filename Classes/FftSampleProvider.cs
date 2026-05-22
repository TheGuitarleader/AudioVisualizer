using EntexSharp.Diagnostics;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer.Classes
{
    internal class FftSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider _source;

        public event EventHandler<FftDataAvailableEventArgs>? DataAvailable;
        public WaveFormat WaveFormat => _source.WaveFormat;

        public FftSampleProvider(ISampleProvider source)
        {
            _source = source;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int read = _source.Read(buffer, offset, count);
            int channels = WaveFormat.Channels;
            float[] mono;

            if (channels == 1)
            {
                mono = buffer.Take(read).ToArray();
            }
            else
            {
                int monoSamples = read / channels;

                mono = new float[monoSamples];

                for (int i = 0; i < monoSamples; i++)
                {
                    float sum = 0;

                    for (int ch = 0; ch < channels; ch++)
                    {
                        sum += buffer[i * channels + ch];
                    }

                    mono[i] = sum / channels;
                }
            }

            DataAvailable?.Invoke(this, new FftDataAvailableEventArgs(mono));
            return read;
        }

        //public int Read(float[] buffer, int offset, int count)
        //{
        //    int read = _source.Read(buffer, offset, count);
        //    float[] mono = new float[1024];

        //    for (int i = 0; i < mono.Length; i++)
        //    {
        //        mono[i] = (float)(_random.NextDouble() * 2.0 - 1.0);
        //    }

        //    DataAvailable?.Invoke(
        //        this,
        //        new FftDataAvailableEventArgs(mono));

        //    return read;
        //}
    }
}
