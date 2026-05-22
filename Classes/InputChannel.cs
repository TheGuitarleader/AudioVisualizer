using NAudio.Wave;

namespace AudioVisualizer.Classes
{
    internal class InputChannel
    {
        public int DeviceIndex;
        public WaveInEvent WaveIn;
        public FftProcessor Processor;
        public FftResult? Result;
    }
}
