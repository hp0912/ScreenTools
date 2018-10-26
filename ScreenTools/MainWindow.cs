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


        private bool audioRecording = false;
        private bool screenRecording = false;
        readonly AudioSource _audioSource;
        IRecorder _recorder;
        AudioSettings _AudioSettings;
        MyRecordingViewModel _MyRecordingViewModel;
        int AudioDeviceCount = 0;


        public MainWindow()
        {
            InitializeComponent();

            AudioRecordingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            AudioRecordingTimer.Tick += AudioRecordingTimer_Tick;

            ScreenRecordTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            ScreenRecordTimer.Tick += ScreenRecordTimer_Tick;

            _AudioSettings = new AudioSettings();
            _audioSource = new BassAudioSource(_AudioSettings);
            if (AudioDeviceCount == 0)
            {
                if (_audioSource.AvailableRecordingSources.Count > 0)
                {
                    _audioSource.AvailableRecordingSources[0].Active = true;
                }
                else if (_audioSource.AvailableLoopbackSources.Count > 0)
                {
                    _audioSource.AvailableLoopbackSources[0].Active = true;
                }
                else
                {
                    MessageBox.Show("未找到音频设备.");
                    return;
                }
            }
            _MyRecordingViewModel = new MyRecordingViewModel(_audioSource);
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
            MultiLanguage.FlushWindowState( this);
        }

        private void PlatformOverview_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");

        }

        private void ProductionLineList_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.uccp520.com/bibbam-res/uil/bam/res/line/balinall.vm?stm=4110000_1@0");
        }

        private void AudioRecord_Click(object sender, EventArgs e)
        {
            if (audioRecording == false)
            {
                audioRecording = true;
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
                                WaveItem.Instance.GetAudioFileWriter(Path.Combine(Properties.Settings.Default.SoundRecorderPath, "BAR-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".wav"), audioProvider?.WaveFormat,
                                    50), audioProvider);
                _recorder.Start();
                recordingStopwatch.Reset();
                AudioRecordingTimer.Start();
                recordingStopwatch.Start();

                AudioRecord.Enabled = false;
                AudioRecord.Visible = false;
                StopAudioRecord.Enabled = true;
                StopAudioRecord.Visible = true;
                AudioRecordTimeTick.Visible = true;
            }
        }

        private async void StopAudioRecord_Click(object sender, EventArgs e)
        {
            if (audioRecording == true)
            {
                await _MyRecordingViewModel.StopAudioRecording(_recorder);
                audioRecording = false;
                AudioRecordingTimer.Stop();
                recordingStopwatch.Stop();

                AudioRecord.Enabled = true;
                AudioRecord.Visible = true;
                StopAudioRecord.Enabled = false;
                StopAudioRecord.Visible = false;
                AudioRecordTimeTick.Visible = false;
                AudioRecordTimeTick.Text = "00:00";
            }
        }

        private void ScreenShot_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HideCurrentWindow)
            {
                Hide();
                Thread.Sleep(70);
            }

            CaptureImageTool capture = new CaptureImageTool();

            capture.SelectCursor = CursorManager.Arrow;
            capture.DrawCursor = CursorManager.Cross;

            if (capture.ShowDialog() == DialogResult.OK)
            {
                Image image = capture.Image;
                Directory.CreateDirectory(Properties.Settings.Default.ScreenShotPath);
                string filePath = Path.Combine(Properties.Settings.Default.ScreenShotPath, "BSS-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
                image.Save(filePath, ImageFormat.Jpeg);
            }

            if (!Visible)
            {
                Show();
            }
        }

        private void ScreenRecord_Click(object sender, EventArgs e)
        {
            if (screenRecording == false)
            {
                _MyRecordingViewModel.StartRecoding(Properties.Settings.Default.SoundRecorderPath);
                screenRecording = true;
                recordingStopwatch.Reset();
                ScreenRecordTimer.Start();
                recordingStopwatch.Start();
                ScreenRecord.Enabled = false;
                ScreenRecord.Visible = false;
                StopScreenRecord.Enabled = true;
                StopScreenRecord.Visible = true;
                ScreenRecordTimeTick.Visible = true;
            }

        }

        private async void StopScreenRecord_Click(object sender, EventArgs e)
        {
            if (screenRecording == true)
            {
                await _MyRecordingViewModel.StopAudioRecording();
                screenRecording = false;
                ScreenRecordTimer.Stop();
                recordingStopwatch.Stop();
                ScreenRecord.Enabled = true;
                ScreenRecord.Visible = true;
                StopScreenRecord.Enabled = false;
                StopScreenRecord.Visible = false;
                ScreenRecordTimeTick.Visible = false;
                ScreenRecordTimeTick.Text = "00:00";
            }

        }

        /// <summary>
        /// 录屏时长的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenRecordTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.ScreenRecordTimeTick.Text = string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds);
        }

        /// <summary>
        /// 录音时长的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioRecordingTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.AudioRecordTimeTick.Text = string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //设置默认语言
            String Language = Properties.Settings.Default.DefaultLanguage;
            if(Language== "zh-CN"){
                ZH_CN_Click(sender, e);
            }
            else {
                en_US_Click(sender, e);
            }
        }

        private void ZH_CN_Click(object sender, EventArgs e)
        {
            MultiLanguage.LoadCurrentFromLanguage("zh-CN");
        }

        private void en_US_Click(object sender, EventArgs e)
        {
            MultiLanguage.LoadCurrentFromLanguage("en-US");
        }
        /// <summary>
        /// 截屏设置
        /// 1、隐藏当前窗口
        /// 2、截图保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenCaptureSet_Click(object sender, EventArgs e)
        {
            var HideCurrentWindow = Properties.Settings.Default.HideCurrentWindow;
            var ScreenShotPath = Properties.Settings.Default.ScreenShotPath;

            var dlg = new ScreenShotSettings(HideCurrentWindow, ScreenShotPath);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.HideCurrentWindow = dlg.HideCurrentWindow;
                Properties.Settings.Default.ScreenShotPath = dlg.ScreenShotPath;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 设置录音录屏
        /// 1、选取可用设备
        /// 2、文件保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioRecordSet_Click(object sender, EventArgs e)
        {
            var SoundRecorderPath = Properties.Settings.Default.SoundRecorderPath;

            var dlg = new AudioRecordSettings(_audioSource, SoundRecorderPath);
            dlg.FormClosed += (object s, FormClosedEventArgs ev) => {
                this.AudioDeviceCount = dlg.AudioDeviceCount;
            };
            var res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                Properties.Settings.Default.SoundRecorderPath = dlg.SoundRecorderPath;
                Properties.Settings.Default.Save();
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (screenRecording == true)
            {
                StopScreenRecord_Click(sender, e);
            }
            if (audioRecording == true) {
                StopAudioRecord_Click(sender, e);
            }
        }
    }
}

