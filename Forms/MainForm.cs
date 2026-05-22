using AudioVisualizer.Classes;
using AudioVisualizer.Forms;
using EntexSharp.Diagnostics;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.MediaFoundation;
using NAudio.Wave;
using ScottPlot;
using ScottPlot.Plottables;

namespace AudioVisualizer
{
    public partial class MainForm : Form
    {
        private readonly List<InputChannel> _channels = new List<InputChannel>();

        private AudioFileReader _reader;
        private WaveInEvent? _waveIn;
        private WaveOutEvent? _waveOut;

        private FftProcessor _waveInFft;
        private FftProcessor _waveOutFft;

        private FftResult? _waveInResult = new();
        private FftResult? _waveOutResult = new();

        private SignalXY? _levelSignal;
        private SignalXY? _frequencySignal;

        public MainForm()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            _levelSignal = frequencyPlot.Plot.Add.SignalXY(new double[] { 0 }, new double[] { 0 }, Colors.Red);
            _frequencySignal = frequencyPlot.Plot.Add.SignalXY(new double[] { 0 }, new double[] { 0 }, Colors.Blue);
            frequencyPlot.Plot.ShowLegend();

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
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);
                audioDeviceTsCB.Items.Add(caps.ProductName);
            }

            audioDeviceTsCB.SelectedIndex = 0;
            loopTimer.Start();
        }

        private void addTsBtn_Click(object sender, EventArgs e)
        {
            if (audioDeviceTsCB.SelectedIndex == -1) return;
            FftProcessor processor = new FftProcessor(48000);

            WaveInEvent waveIn = new WaveInEvent
            {
                DeviceNumber = audioDeviceTsCB.SelectedIndex,
                WaveFormat = new WaveFormat(48000, 16, 1),
                BufferMilliseconds = 20
            };

            InputChannel channel = new InputChannel
            {
                DeviceIndex = audioDeviceTsCB.SelectedIndex,
                Processor = processor,
                WaveIn = waveIn
            };

            waveIn.DataAvailable += (s, e) =>
            {
                channel.Result = processor.Process(e.Buffer);
            };

            waveIn.StartRecording();
            _channels.Add(channel);
        }

        private void removeTsBtn_Click(object sender, EventArgs e)
        {
            if (audioDeviceTsCB.SelectedIndex == -1) return;

            InputChannel? channel = _channels.FirstOrDefault(c => c.DeviceIndex == audioDeviceTsCB.SelectedIndex);
            if (channel == null) return;

            channel.WaveIn.StopRecording();
            channel.WaveIn.Dispose();

            _channels.Remove(channel);
        }

        private void toneGenTsBtn_Click(object sender, EventArgs e)
        {
            ToneGeneratorForm toneGeneratorForm = new ToneGeneratorForm();
            toneGeneratorForm.Show();
        }

        private void loopTimer_Tick(object sender, EventArgs e)
        {
            levelsPlot.Plot.Clear();
            frequencyPlot.Plot.Clear();

            foreach (var input in _channels)
            {
                if (input.Result == null) continue;

                levelsPlot.Plot.Add.Signal(input.Result.Samples).LineWidth = 2;
                frequencyPlot.Plot.Add.SignalXY(input.Result.Frequencies, input.Result.Magnitudes).LineWidth = 2;
            }

            frequencyPlot.Refresh();
            levelsPlot.Refresh();
        }
    }
}
