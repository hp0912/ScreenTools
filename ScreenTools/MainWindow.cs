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
        static SharpAvi.Sample.MainWindow sample = new SharpAvi.Sample.MainWindow();
        private bool AudioRecording = false;
        private bool ScreenRecording = false;

        public MainWindow()
        {
            InitializeComponent();
            AudioRecordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            AudioRecordingTimer.Tick += AudioRecordingTimer_Tick;

            ScreenRecordTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            ScreenRecordTimer.Tick += ScreenRecordTimer_Tick;

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
            Properties.Settings.Default.Save();
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


        private void AudioRecord_Click(object sender, EventArgs e)
        {
            if (AudioRecording == false)
            {              
                recordingStopwatch.Reset();
                AudioRecordingTimer.Start();
                AudioRecording = true;

                MciSendString("set wave bitpersample 8", "", 0, 0);
                MciSendString("set wave samplespersec 20000", "", 0, 0);
                MciSendString("set wave channels 2", "", 0, 0);
                MciSendString("set wave format tag pcm", "", 0, 0);
                MciSendString("open new type WAVEAudio alias movie", "", 0, 0);
                MciSendString("record movie", "", 0, 0);
                
                recordingStopwatch.Start();
            }
            else
            {
                this.AudioRecord.Text = "录音";
                AudioRecordingTimer.Stop();
                recordingStopwatch.Stop();

                confirmDir(Properties.Settings.Default.SoundRecorderPath);
                MciSendString("stop movie", "", 0, 0);
                MciSendString("save movie " + Properties.Settings.Default.SoundRecorderPath + "BepsunAudioRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav", "", 0, 0);
                MciSendString("close movie", "", 0, 0);
                AudioRecording = false;
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
                confirmDir(Properties.Settings.Default.ScreenShotPath);
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
            if (ScreenRecording == false)
            {
                recordingStopwatch.Reset();
                ScreenRecordTimer.Start();
                ScreenRecording = true;
                sample.StartRecording_Click(sender, e);
                recordingStopwatch.Start();
            }
            else{
                sample.StopRecording_Click(sender, e);
                ScreenRecordTimer.Stop();
                recordingStopwatch.Stop();
                ScreenRecording = false;
                this.ScreenRecord.Text = "录屏";
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
            sample.Settings_Click(sender, e);
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

