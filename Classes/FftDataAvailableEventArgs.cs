namespace AudioVisualizer.Classes
{
    internal class FftDataAvailableEventArgs : EventArgs
    {
        public float[] Buffer { get; set; }

        public FftDataAvailableEventArgs(float[] buffer)
        {
            Buffer = buffer;
        }
    }
}