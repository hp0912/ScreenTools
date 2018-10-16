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

namespace ScreenTools
{

    public partial class MainWindow : Form
    {
        public ChromiumWebBrowser browser;
        SharpAvi.Sample.MainWindow ScreenRecording = null;
        private readonly DispatcherTimer recordingTimer;
        private readonly Stopwatch recordingStopwatch = new Stopwatch();
        private bool audioRecording = false;

        public MainWindow()
        {
            InitializeComponent();
            recordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            recordingTimer.Tick += recordingTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           

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
                recordingStopwatch.Reset();
                recordingTimer.Start();

                mciSendString("set wave bitpersample 8", "", 0, 0);
                mciSendString("set wave samplespersec 20000", "", 0, 0);
                mciSendString("set wave channels 2", "", 0, 0);
                mciSendString("set wave format tag pcm", "", 0, 0);
                mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
                mciSendString("record movie", "", 0, 0);
                
                recordingStopwatch.Start();
            }
            else
            {
                audioRecording = false;
                this.audioRecord.Text = "录音";
                recordingTimer.Stop();
                recordingStopwatch.Stop();

                confirmDir(Properties.Settings.Default.SoundRecorderPath);
                mciSendString("stop movie", "", 0, 0);
                mciSendString("save movie " + Properties.Settings.Default.SoundRecorderPath + "BepsunAudioRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav", "", 0, 0);
                mciSendString("close movie", "", 0, 0);
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
                confirmDir(Properties.Settings.Default.ScreenShotPath);
                string filePath = Path.Combine(Properties.Settings.Default.ScreenShotPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
                image.Save(filePath, ImageFormat.Jpeg);
            }

            if (!Visible)
            {
                Show();
            }
        }

        /// <summary>
        /// 检测目录是否存在，若不存在则创建
        /// </summary>
        public void confirmDir(string path)
        {
            String rootDir = System.IO.Path.GetDirectoryName(path);             //获取path所在的目录
            if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir); //若目录不存在则创建
        }
    }
}

