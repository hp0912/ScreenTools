using System;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
using CSharpWin_JD.CaptureImage;
using NAudio.Wave;
using Captura.Audio;
using Captura.Models;
using Captura;
using Screna;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScreenTools
{

    public partial class MainWindow : Form
    {

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int MciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );
        public ChromiumWebBrowser Browser;
       
        private readonly DispatcherTimer AudioRecordingTimer;
        private readonly DispatcherTimer ScreenRecordTimer;
        private readonly Stopwatch recordingStopwatch = new Stopwatch();
        
        private bool ScreenRecording = false;

        private bool audioRecording = false;
        private IWaveIn captureDevice;
        private WaveFileWriter writer;
        string SoundRecorderPath;

        readonly AudioSource _audioSource;
        IRecorder _recorder;
        AudioSettings _AudioSettings;
        public MainWindow()
        {
            InitializeComponent();

            AudioRecordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            AudioRecordingTimer.Tick += AudioRecordingTimer_Tick;

            ScreenRecordTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            ScreenRecordTimer.Tick += ScreenRecordTimer_Tick;

            SoundRecorderPath = Properties.Settings.Default.SoundRecorderPath;
            Directory.CreateDirectory(SoundRecorderPath);
            _AudioSettings = new AudioSettings();
            _audioSource = new BassAudioSource(_AudioSettings);

            if (_audioSource.AvailableRecordingSources.Count > 0) {
                _audioSource.AvailableRecordingSources[0].Active = true;
            }
            if (_audioSource.AvailableLoopbackSources.Count > 0)
            {
                _audioSource.AvailableLoopbackSources[0].Active = true;
            }

            if (Properties.Settings.Default.HideCurrentWindow)
            {
                this.SCS_HideCurrentWindow.Checked = true;
            }
            else
            {
                this.SCS_HideCurrentWindow.Checked = false;
            }
            
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioRecordCleanup();
        }

        /// <summary>
        /// 初始化Cef
        /// </summary>
        /// <param name="path"></param>
        public void InitBrowser(String path)
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            settings.AcceptLanguageList = "zh-CN";
            Cef.Initialize(settings);
            Browser = new ChromiumWebBrowser(path);
            Browser.Dock = DockStyle.Fill;
            this.webBrowser1.Controls.Add(Browser);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
             InitBrowser("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");
             FlushWindowState();
        }

        private void PlatformOverview_Click(object sender, EventArgs e)
        {
             Browser.Load("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");

        }

        private void ProductionLineList_Click(object sender, EventArgs e)
        {
             Browser.Load("https://www.uccp520.com/bibbam-res/uil/bam/res/line/balinall.vm?stm=4110000_1@0");
        }

        /// <summary>
        /// 截屏时是否隐藏当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCS_HideCurrentWindow_Click(object sender, EventArgs e)
        {
            if (this.SCS_HideCurrentWindow.Checked)
            {
                Properties.Settings.Default.HideCurrentWindow = true;
            }
            else
            {
                Properties.Settings.Default.HideCurrentWindow = false;
            }
        }
        
        private async void AudioRecord_Click(object sender, EventArgs e)
        {
            if (audioRecording == false)
            {
                audioRecording = true;

                /*
                AudioRecordCleanup();
                captureDevice = new WasapiLoopbackCapture(true);
                captureDevice.DataAvailable += OnAudioDataAvailable;
                captureDevice.RecordingStopped += OnAudioRecordingStopped;
                writer = new WaveFileWriter(Path.Combine(SoundRecorderPath, "BepsunAudioRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav"), new WaveFormat(captureDevice.WaveFormat.SampleRate, 16, captureDevice.WaveFormat.Channels));
                captureDevice.StartRecording();
                */

                IAudioProvider audioProvider = null;
                try
                {
                    audioProvider = _audioSource.GetMixedAudioProvider();
                }
                catch (Exception ex)
                {
                    ServiceProvider.MessageProvider.ShowException(ex, ex.Message);
                }

                _recorder = new Recorder(
                                WaveItem.Instance.GetAudioFileWriter(Path.Combine(SoundRecorderPath, "BepsunAudioRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav"), audioProvider?.WaveFormat,
                                    50), audioProvider);
                _recorder.Start();

                recordingStopwatch.Reset();
                AudioRecordingTimer.Start();
                recordingStopwatch.Start();
            }
            else
            {
                //captureDevice?.StopRecording();
                await StopAudioRecording();

                audioRecording = false;
                this.AudioRecord.Text = "录音";
                AudioRecordingTimer.Stop();
                recordingStopwatch.Stop();
            }
        }

        public async Task StopAudioRecording()
        {
            // Reference Recorder as it will be set to null
            var rec = _recorder;
            var task = Task.Run(() => rec.Dispose());

            _recorder = null;

            try
            {
                await task;
            }
            catch (Exception e)
            {
                ServiceProvider.MessageProvider.ShowException(e, "Error occurred when stopping recording.\nThis might sometimes occur if you stop recording just as soon as you start it.");

                return;
            }
        }

        private void ScreenShot_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HideCurrentWindow)
            {
                Hide();
                Thread.Sleep(30);
            }

            CaptureImageTool capture = new CaptureImageTool();

            capture.SelectCursor = CursorManager.Arrow;
            capture.DrawCursor = CursorManager.Cross;

            if (capture.ShowDialog() == DialogResult.OK)
            {
                Image image = capture.Image;
                Directory.CreateDirectory(Properties.Settings.Default.ScreenShotPath);
                string filePath = Path.Combine(Properties.Settings.Default.ScreenShotPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
                image.Save(filePath, ImageFormat.Jpeg);
            }

            if (!Visible)
            {
                Show();
            }
        }

        private void ScreenRecord_Click(object sender, EventArgs e)
        {          
            
        }

        void OnAudioDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnAudioDataAvailable), sender, e);
            }
            else
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        void OnAudioRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnAudioRecordingStopped), sender, e);
            }
            else
            {
                writer?.Dispose();
                writer = null;
                if (e.Exception != null)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("A problem was encountered during recording {0}", e.Exception.Message));
                }
            }
        }

        private void AudioRecordCleanup()
        {
            captureDevice?.Dispose();
            captureDevice = null;
            writer?.Dispose();
            writer = null;
        }

        /// <summary>
        /// 录音时长的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioRecordingTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.AudioRecord.Text = "停止录音[" + string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds) + "]";
        }
       
        /// <summary>
        /// 录屏时长的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenRecordTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.ScreenRecord.Text = "停止录屏[" + string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds) + "]";
        }

        private void ScreenRecordSet_Click(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //设置默认语言
            String Language = Properties.Settings.Default.DefaultLanguage;
            MultiLanguage.LoadLanguage(this, typeof(MainWindow));
        }

        private void ZH_CN_Click(object sender, EventArgs e)
        {
            MultiLanguage.SetDefaultLanguage("zh-CN");
            //对所有打开的窗口重新加载语言
            foreach (Form form in Application.OpenForms)
            {
                LoadAll(form);
            }
        }

        private void en_US_Click(object sender, EventArgs e)
        {

            MultiLanguage.SetDefaultLanguage("en-US");
            //对所有打开的窗口重新加载语言
            foreach (Form form in Application.OpenForms)
            {
                LoadAll(form);
            }
        }

        /// <summary>
        /// 为所有窗体加载语言配置，当前只有一个窗体
        /// </summary>
        /// <param name="form"></param>
        private void LoadAll(Form form)
        {
            if (form.Name == "MainWindow")
            {
                MultiLanguage.LoadLanguage(form, typeof(MainWindow));
            }
            FlushWindowState();

        }

        /// <summary>
        /// 将当前窗口最大化变化一次
        /// </summary>
        private void FlushWindowState() {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}

