using AudioVisualizer.Classes;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using ScottPlot;
using ScottPlot.Plottables;

namespace AudioVisualizer
{
    public partial class MainForm : Form
    {
        private WasapiLoopbackCapture _wasapi;
        private WaveInEvent? _waveIn;
        private FftProcessor _processor;

        private FftResult _inResult;
        private FftResult _outResult;

        private Signal? _levelSignal;

        public MainForm()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            _wasapi = new WasapiLoopbackCapture(device);

            levelsPlot.Plot.YLabel("Level");
            levelsPlot.Plot.XLabel("Time (milliseconds)");
            levelsPlot.Plot.Axes.SetLimitsX(0, 880);
            levelsPlot.Plot.Axes.SetLimitsY(-1, 1);

            frequencyPlot.Plot.XLabel("Frequency (Hz)");
            frequencyPlot.Plot.YLabel("Magnitude (dB)");
            frequencyPlot.Plot.Axes.SetLimitsX(0, 22000);
            frequencyPlot.Plot.Axes.SetLimitsY(-100, 0);
            levelsPlot.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                var caps = NAudio.Wave.WaveIn.GetCapabilities(i);
                audioDeviceCB.Items.Add(caps.ProductName);
            }

            audioDeviceCB.SelectedIndex = 0;
        }

        private void audioDeviceCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_waveIn is not null)
            {
                _waveIn.StopRecording();
                _waveIn.Dispose();
            }

            if (audioDeviceCB.SelectedIndex == -1) return;

            _waveIn = new WaveInEvent()
            {
                DeviceNumber = audioDeviceCB.SelectedIndex,
                WaveFormat = new WaveFormat(48000, 16, 1),
                BufferMilliseconds = 20
            };

            _processor = new FftProcessor(_waveIn.WaveFormat.SampleRate);
            _waveIn.DataAvailable += WaveIn_DataAvailable;
            _waveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            FftResult result = _processor.Process(e.Buffer);

            // --- TIME DOMAIN PLOT ---
            levelsPlot.Invoke((MethodInvoker)delegate
            {
                levelsPlot.Plot.Clear();
                levelsPlot.Plot.Add.Signal(result.Samples, 1, Colors.Red).LineWidth = 2;
                levelsPlot.Plot.RenderInMemory();
                levelsPlot.Refresh();
            });

            // --- FREQUENCY DOMAIN PLOT ---
            frequencyPlot.Invoke((MethodInvoker)delegate
            {
                frequencyPlot.Plot.Clear();
                frequencyPlot.Plot.Add.SignalXY(result.Frequencies, result.Magnitudes, Colors.Red).LineWidth = 2;
                frequencyPlot.Plot.RenderInMemory();
                frequencyPlot.Refresh();
            });
        }
    }
}
