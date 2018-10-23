using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using NAudio.Wave;
using SharpAvi.Codecs;

namespace SharpAvi.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            recordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            recordingTimer.Tick += recordingTimer_Tick;
            DataContext = this;
            this.ShowInTaskbar = false;
            double ScreenWidth = SystemParameters.PrimaryScreenWidth;//WPF
            double ScreenHight = SystemParameters.PrimaryScreenHeight;
            this.Top = ScreenHight - this.Height - 5;
            this.Left = 0 ;
            InitDefaultSettings();

            WindowMoveBehavior.Attach(this);
        }



        #region Recording

        private readonly DispatcherTimer recordingTimer;
        private readonly Stopwatch recordingStopwatch = new Stopwatch();
        private Recorder recorder;
        private string lastFileName;

        private static readonly DependencyPropertyKey IsRecordingPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRecording", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        public static readonly DependencyProperty IsRecordingProperty = IsRecordingPropertyKey.DependencyProperty;

        public bool IsRecording
        {
            get { return (bool)GetValue(IsRecordingProperty); }
            private set { SetValue(IsRecordingPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey ElapsedPropertyKey =
            DependencyProperty.RegisterReadOnly("Elapsed", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty ElapsedProperty = ElapsedPropertyKey.DependencyProperty;

        public string Elapsed
        {
            get { return (string)GetValue(ElapsedProperty); }
            private set { SetValue(ElapsedPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey HasLastScreencastPropertyKey =
            DependencyProperty.RegisterReadOnly("HasLastScreencast", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        public static readonly DependencyProperty HasLastScreencastProperty = HasLastScreencastPropertyKey.DependencyProperty;

        public bool HasLastScreencast
        {
            get { return (bool)GetValue(HasLastScreencastProperty); }
            private set { SetValue(HasLastScreencastPropertyKey, value); }
        }

        private void StartRecording()
        {
            if (IsRecording)
                throw new InvalidOperationException("Already recording.");

            if (minimizeOnStart)
                WindowState = WindowState.Minimized;

            Elapsed = "00:00";
            HasLastScreencast = false;
            IsRecording = true;

            recordingStopwatch.Reset();
            recordingTimer.Start();

            lastFileName = System.IO.Path.Combine(outputFolder, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".avi");
            var bitRate = Mp3AudioEncoderLame.SupportedBitRates.OrderBy(br => br).ElementAt(audioQuality);
            recorder = new Recorder(lastFileName, 
                "X264", 70, 
                audioSourceIndex, audioWaveFormat, encodeAudio, bitRate);

            recordingStopwatch.Start();
        }

        private void StopRecording()
        {
            if (!IsRecording)
                throw new InvalidOperationException("Not recording.");

            try
            {
                if (recorder != null)
                {
                    recorder.Dispose();
                    recorder = null;
                }
            }
            finally
            {
                recordingTimer.Stop();
                recordingStopwatch.Stop();

                IsRecording = false;
                HasLastScreencast = true;

                WindowState = WindowState.Normal;
            }
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = recordingStopwatch.Elapsed;
            Elapsed = string.Format(
                "{0:00}:{1:00}", 
                Math.Floor(elapsed.TotalMinutes), 
                elapsed.Seconds);
        }

        #endregion


        #region Settings

        private string outputFolder;
        private FourCC encoder;
        private int encodingQuality;
        private int audioSourceIndex = -1;
        private SupportedWaveFormat audioWaveFormat;
        private bool encodeAudio;
        private int audioQuality;
        private bool minimizeOnStart;
        

        private void InitDefaultSettings()
        {
            var exePath = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location).LocalPath;
            outputFolder = System.IO.Path.GetDirectoryName(exePath);

            encoder = KnownFourCCs.Codecs.MicrosoftMpeg4V3;
            encodingQuality = 70;

            audioWaveFormat = SupportedWaveFormat.WAVE_FORMAT_44M16;
            encodeAudio = true;
            audioQuality = (Mp3AudioEncoderLame.SupportedBitRates.Length + 1) / 2;

            minimizeOnStart = false;
        }

        private void ShowSettingsDialog()
        {
            var dlg = new SettingsWindow()
            {
                Folder = outputFolder,
                SelectedAudioSourceIndex = audioSourceIndex,
                AudioWaveFormat = audioWaveFormat,
                EncodeAudio = encodeAudio,
                AudioQuality = audioQuality,
                MinimizeOnStart = minimizeOnStart
            };
            
            if (dlg.ShowDialog() == true)
            {
                outputFolder = dlg.Folder;
                encoder = dlg.Encoder;
                encodingQuality = dlg.Quality;
                audioSourceIndex = dlg.SelectedAudioSourceIndex;
                audioWaveFormat = dlg.AudioWaveFormat;
                encodeAudio = dlg.EncodeAudio;
                audioQuality = dlg.AudioQuality;
                minimizeOnStart = dlg.MinimizeOnStart;
            }
        }

        #endregion


        public void StartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                StartRecording();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting recording\r\n" + ex.ToString());
                StopRecording();
            }
        }

        public void StopRecording_Click(object sender, EventArgs e)
        {
            try
            {
                StopRecording();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping recording\r\n" + ex.ToString());
            }
        }

        private void GoToLastScreencast_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", string.Format("/select, \"{0}\"", lastFileName));
        }

        public void Settings_Click(object sender, EventArgs e)
        {
            ShowSettingsDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (IsRecording)
                StopRecording();

            Close();
        }
    }
}
