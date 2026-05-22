using AudioVisualizer.Classes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVisualizer.Forms
{
    public partial class ToneGeneratorForm : Form
    {
        private readonly ToneGenerator _toneGenerator;
        private readonly WaveOutEvent _waveOut;

        public ToneGeneratorForm()
        {
            InitializeComponent();

            _toneGenerator = new ToneGenerator();
            _waveOut = new WaveOutEvent();
            _waveOut.Init(_toneGenerator);
        }

        private void toneBar_Scroll(object sender, EventArgs e)
        {

        }

        private void toneBar_ValueChanged(object sender, EventArgs e)
        {
            //double frequency = toneBar.Minimum * Math.Pow(toneBar.Maximum / toneBar.Minimum, toneBar.Value / 100.0);
            double frequency = toneBar.Value;

            _toneGenerator.Frequency = frequency;
            hzLabel.Text = $"{frequency:N1} Hz";
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if(playBtn.Text == "Start")
            {
                playBtn.Text = "Stop";
                _waveOut.Play();
            }
            else
            {
                playBtn.Text = "Start";
                _waveOut.Stop();
            }
        }
    }
}
