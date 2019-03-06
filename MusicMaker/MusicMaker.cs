using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MusicMaker
{
    public partial class MusicMaker : Form
    {
        public static MusicMaker ui;
        public const int SamplesInView = 50000;
        public const int TimeScale = 20;
        private AppController app;
        private Color waveColor = Color.DodgerBlue;

        public MusicMaker()
        {
            InitializeComponent();
            ui = this;
            app = new AppController();
            CreateCharts();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openWavFile.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            app.Reset();
            charWave.Series["chanL"].Points.Clear();
            charWave.Series["chanR"].Points.Clear();
            GC.Collect();
            lblFile.Text = "No .wav file opened";
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
        }

        private void openWavFile_FileOk(object sender, CancelEventArgs e)
        {
            if (app.OpenAudio(openWavFile.FileName))
            {
                lblFile.Text = "'" + openWavFile.FileName + "' opened successfully!";
                app.UpdateDisplay();
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
            }
            else
            {
                lblFile.Text = "Error: File could not be opened";
                return;
            }
        }

        private void CreateCharts()
        {
            charWave.Series.Add("chanL");
            charWave.Series["chanL"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            charWave.Series["chanL"].ChartArea = "ChartArea1";
            charWave.Series["chanL"].Color = waveColor;
            charWave.Series.Add("chanR");
            charWave.Series["chanR"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            charWave.Series["chanR"].ChartArea = "ChartArea1";
            charWave.Series["chanR"].Color = waveColor;

            charWave.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            charWave.ChartAreas[0].CursorX.AutoScroll = true;
            charWave.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            charWave.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
        }

        public void DrawWave(short[] left, short[] right)
        {
            decimal temp = left.Length / SamplesInView;
            int compFactor = (int)Math.Ceiling(temp);

            short[] compLeft = FileHandler.CompressWave(left, compFactor);
            short[] compRight = FileHandler.CompressWave(right, compFactor);

            var leftData = charWave.Series["chanL"].Points;
            var rightData = charWave.Series["chanR"].Points;
            leftData.SuspendUpdates();
            rightData.SuspendUpdates();

            for (int i = 0; i < compLeft.Length; i++)
            {
                leftData.Add(compLeft[i] + 20000);
                rightData.Add(compRight[i] - 20000);
            }
            leftData.ResumeUpdates();
            rightData.ResumeUpdates();

            AddCustomLabels(charWave.ChartAreas[0], compLeft.Length, SamplesInView / TimeScale);
        }

        private string ToMinSec(int seconds)
        {
            int sec = seconds % 60;
            int min = ((seconds - sec) / 60) % 60;
            return min + "m" + sec.ToString("00") + "s";
        }

        private void AddCustomLabels(ChartArea ca, int max, int interval)
        {
            ca.AxisX.CustomLabels.Clear();
            
            for (int i = 0; i < max; i += interval)
            {
                int timeStamp = Convert.ToInt32(i / (app.GetAudioProperties().SampleRate / app.GetAudioLength()));
                CustomLabel cl = new CustomLabel
                {
                    FromPosition = i - 100,
                    ToPosition = i + 100,
                    Text = ToMinSec(timeStamp)
                };
                ca.AxisX.CustomLabels.Add(cl);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (app.PlayPause())
                btnPlay.Text = "Pause";
            else
                btnPlay.Text = "Play";
        }
    }
}
