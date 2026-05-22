using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer.Classes
{
    internal class FftProcessor
    {
        private double[] _magnitudes;

        public int FftSize { get; } = 2048;
        public int SampleRate { get; }

        public FftProcessor(int sampleRate)
        {
            SampleRate = sampleRate;
        }

        public FftResult Process(byte[] buffer)
        {
            int sampleCount = Math.Min(buffer.Length / 2, FftSize);

            double[] samples = new double[sampleCount];

            for (int i = 0; i < sampleCount; i++)
            {
                short sample = BitConverter.ToInt16(buffer, i * 2);
                samples[i] = sample / 32768.0;
            }

            Complex[] fftBuffer = CreateFFTBuffer(samples);
            RunFFT(fftBuffer);

            double[] magnitudes = ComputeMagnitudes(fftBuffer);
            double[] smoothed = SmoothMagnitudes(magnitudes);
            double[] frequencies = BuildFrequencyAxis();

            return new FftResult
            {
                Samples = samples,
                Frequencies = frequencies,
                Magnitudes = smoothed
            };
        }

        private double[] ExtractSamples(byte[] buffer)
        {
            int sampleCount = Math.Min(buffer.Length / 2, FftSize);

            double[] samples = new double[sampleCount];

            for (int i = 0; i < sampleCount; i++)
            {
                short sample = BitConverter.ToInt16(buffer, i * 2);

                samples[i] = sample / 32768.0;
            }

            return samples;
        }

        private Complex[] CreateFFTBuffer(double[] samples)
        {
            Complex[] fftBuffer = new Complex[FftSize];

            for (int i = 0; i < samples.Length; i++)
            {
                fftBuffer[i].X = (float)(samples[i] * HannWindow(i, FftSize));
                fftBuffer[i].Y = 0;
            }

            return fftBuffer;
        }

        private void RunFFT(Complex[] fftBuffer)
        {
            FastFourierTransform.FFT(
                true,
                (int)Math.Log(FftSize, 2.0),
                fftBuffer);
        }

        private double[] ComputeMagnitudes(Complex[] fftBuffer)
        {
            int length = FftSize / 2;

            double[] magnitudes = new double[length];

            for (int i = 0; i < length; i++)
            {
                double mag = Math.Sqrt(fftBuffer[i].X * fftBuffer[i].X + fftBuffer[i].Y * fftBuffer[i].Y);
                double db = 20 * Math.Log10(mag + 1e-10);

                if (db < -100) db = -100;
                magnitudes[i] = db;
            }

            return magnitudes;
        }

        private double[] SmoothMagnitudes(double[] magnitudes)
        {
            if (_magnitudes == null || _magnitudes.Length != magnitudes.Length)
            {
                _magnitudes = magnitudes.ToArray();
                return magnitudes;
            }

            double smoothingFactor = 0.85;

            for (int i = 0; i < magnitudes.Length; i++)
            {
                _magnitudes[i] = smoothingFactor * _magnitudes[i] + (1 - smoothingFactor) * magnitudes[i];
            }

            return _magnitudes;
        }

        private double[] BuildFrequencyAxis()
        {
            return Enumerable.Range(0, FftSize / 2).Select(i => i * SampleRate / (double)FftSize).ToArray();
        }

        private double HannWindow(int index, int size)
        {
            return 0.5 * (1 - Math.Cos((2 * Math.PI * index) / (size - 1)));
        }
    }
}
