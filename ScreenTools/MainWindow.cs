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
using System.Windows;
using System.IO;
using CSharpWin_JD.CaptureImage;
using NAudio.Wave;

namespace ScreenTools
{

    public partial class MainWindow : Form
    {
        public ChromiumWebBrowser browser;
        SharpAvi.Sample.MainWindow ScreenRecording = null;
        private readonly DispatcherTimer recordingTimer;
        private readonly Stopwatch recordingStopwatch = new Stopwatch();
        private bool audioRecording = false;
        private IWaveIn captureDevice;
        private WaveFileWriter writer;
        string SoundRecorderPath;

        public MainWindow()
        {
            InitializeComponent();
            recordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            recordingTimer.Tick += recordingTimer_Tick;
            SoundRecorderPath = Properties.Settings.Default.SoundRecorderPath;
            Directory.CreateDirectory(SoundRecorderPath);

            if (Properties.Settings.Default.HideCurrentWindow)
            {
                this.截屏时隐藏当前窗口ToolStripMenuItem.Checked = true;
            }
            else
            {
                this.截屏时隐藏当前窗口ToolStripMenuItem.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {           

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioRecordCleanup();
        }

        public void InitBrowser(String path)
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            settings.AcceptLanguageList = "zh-CN";
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser(path);
            browser.Dock = DockStyle.Fill;
            this.webBrowser1.Controls.Add(browser);
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.语言设置ToolStripMenuItem.Text = "语言设置";
            this.平台总览ToolStripMenuItem.Text = "平台总览";
            this.产线一览ToolStripMenuItem.Text = "产线一览";
            this.产线监控ToolStripMenuItem.Text = "产线监控";
            this.视频会议ToolStripMenuItem.Text = "视频会议";

        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.语言设置ToolStripMenuItem.Text = "Language Settings";
            this.平台总览ToolStripMenuItem.Text = "Platform Overview";
            this.产线一览ToolStripMenuItem.Text = "Production Line List";
            this.产线监控ToolStripMenuItem.Text = "Production Line Monitoring";
            this.视频会议ToolStripMenuItem.Text = "Video Conference";                      
        }

        private void 平台总览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browser == null)
            { 
                InitBrowser("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");
            }
            else
            {
                browser.Load("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");
            }
            //browser.Load("http://www.baidu.com");
        }

        private void 产线一览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browser == null)
            {
                InitBrowser("https://www.uccp520.com/bibbam-res/uil/bam/res/line/balinall.vm?stm=4110000_1@0");
            }
            else
            {
                browser.Load("https://www.uccp520.com/bibbam-res/uil/bam/res/line/balinall.vm?stm=4110000_1@0");
            }
        }

        private void 检测内核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browser == null)
            {
                InitBrowser("chrome://extensions/");
            }
            else
            {
                browser.Load("https://ie.icoa.cn/");
            }
            //browser.Load("https://ie.icoa.cn/");
            //this.webBrowser1.Navigate("https://ie.icoa.cn/");
        }
        
        private void 截屏时隐藏当前窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.截屏时隐藏当前窗口ToolStripMenuItem.Checked)
            {
                Properties.Settings.Default.HideCurrentWindow = true;
            }
            else
            {
                Properties.Settings.Default.HideCurrentWindow = false;
            }
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );

        private void 录屏ToolStripMenuItem_Click(object sender, EventArgs e)        
        {           
            if (ScreenRecording == null)
            {
                ScreenRecording = new SharpAvi.Sample.MainWindow();

                ScreenRecording.Show();
            }
            else {
                ScreenRecording.Close();
                ScreenRecording = null;
            } 
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.audioRecord.Text = "停止录音[" + string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds) + "]";
        }

        private void audioRecord_Click(object sender, EventArgs e)
        {
            if (audioRecording == false)
            {
                audioRecording = true;

                AudioRecordCleanup();
                captureDevice = new WasapiLoopbackCapture(true);
                captureDevice.DataAvailable += OnAudioDataAvailable;
                captureDevice.RecordingStopped += OnAudioRecordingStopped;
                writer = new WaveFileWriter(Path.Combine(SoundRecorderPath, "BepsunAudioRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav"), new WaveFormat(captureDevice.WaveFormat.SampleRate, 16, captureDevice.WaveFormat.Channels));
                captureDevice.StartRecording();

                recordingStopwatch.Reset();
                recordingTimer.Start();
                recordingStopwatch.Start();
            }
            else
            {
                captureDevice?.StopRecording();

                audioRecording = false;
                this.audioRecord.Text = "录音";
                recordingTimer.Stop();
                recordingStopwatch.Stop();
            }
        }

        private void screenShot_Click(object sender, EventArgs e)
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
    }
}

