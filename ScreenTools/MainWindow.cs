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
using System.Windows;

namespace ScreenTools
{

    public partial class MainWindow : Form
    {
        public ChromiumWebBrowser Browser; // hp谷歌浏览器内核

        private readonly DispatcherTimer ScreenRecordTimer; // 定时器
        private readonly Stopwatch recordingStopwatch = new Stopwatch();

        private bool audioRecording = false; // 判断有没有录屏/录音状态值
        private bool screenRecording = false;
        readonly AudioSource _audioSource; // 录音设备来源（包含设备详情数据，声卡麦克风等）
        IRecorder _recorder; 
        AudioSettings _AudioSettings; // 录音设置
        MyRecordingViewModel _MyRecordingViewModel; // 录屏
        int AudioDeviceCount = 0; // 外接设备数量
        String RecorderPath = Properties.Settings.Default.SoundRecorderPath;
        String ShotPath = Properties.Settings.Default.ScreenShotPath;

        public MainWindow()
        {
            InitializeComponent();

            ScreenRecordTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            ScreenRecordTimer.Tick += RecordTimeTick_Tick;

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
            }
            _MyRecordingViewModel = new MyRecordingViewModel(_audioSource);
        }

        /// <summary>
        /// 初始化Cef
        /// </summary>
        /// <param name="path"></param>
        public void InitBrowser(String path)
        {
            CefSettings settings = new CefSettings
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN"
            };
            Cef.Initialize(settings);
            Browser = new ChromiumWebBrowser(path)
            {
                Dock = DockStyle.Fill
            };
            this.webBrowser1.Controls.Add(Browser);
        }
        /// <summary>
        /// 一开始进入软件的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            InitBrowser("https://www.uccp520.com/bibwdf-logprv/uil/wdf/logreg/wdsignin.vm");
        }
        /// <summary>
        /// 点击"UCCP"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlatformOverview_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.uccp520.com/bibcor-byitem/uil/cor/byitem/coiall.vm?stm=1110000_1@0");
        }
        /// <summary>
        /// 点击"资产运行与运营"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionLineList_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.uccp520.com/bibbam-res/uil/bam/res/line/balinall.vm?stm=4110000_1@0");
        }
        /// <summary>
        /// 点击"产线一览"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssetRun_Click(object sender, EventArgs e)
        {
            Browser.Load("https://www.uccp520.com/bibcor-asttrack/uil/cor/asttrack/coastsift.vm?stm=1711000_1@0");
        }

        /// <summary>
        /// 点击"产线监控"按钮，调用客户选择的相应目录下面的.exe文件，进行监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionLineMonitoring_Click(object sender, EventArgs e)
        {
            var FileSelectorSettings = new FileSelectorSettings();
            FileSelectorSettings.ShowDialog();
        }
        /// <summary>
        /// 点击"视频会议"按钮，调用酷虎选择的相应目录下面的.exe文件，进行视频会议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoConference_Click(object sender, EventArgs e)
        {
            //StartProcess(System.Windows.Forms.Application.StartupPath + "\\osk.exe", "osk");
        }


        private void OSK_Click(object sender, EventArgs e) // 虚拟键盘相关接口函数
        {
            //StartProcess(System.Windows.Forms.Application.StartupPath + "\\osk.exe", "osk");
            //if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\osk.exe"))
            //{
            //    ProcessStartInfo startInfo = new ProcessStartInfo(System.Windows.Forms.Application.StartupPath + "\\osk.exe");
            //    Process process = new Process();

            //    startInfo.UseShellExecute = false; //不使用系统外壳程序启动
            //    startInfo.RedirectStandardInput = false; //不重定向输入
            //    startInfo.RedirectStandardOutput = true; //重定向输出

            //    process.StartInfo = startInfo;
            //    Process[] qqs = Process.GetProcessesByName("osk");
            //    if (qqs.Length == 0)
            //    {
            //        process.Start();
            //    }
            //    else
            //    {
            //        qqs[0].Kill();
            //    }
            //}   
            //else {
            //    System.Windows.Forms.MessageBox.Show(System.Windows.Forms.Application.StartupPath + "请将\"osk.exe\"置于安装目录下");
            //}
        }
     
        /// <summary>
        /// 点击录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioRecord_Click(object sender, EventArgs e)
        {
            if (false == Directory.Exists(RecorderPath))
            {
                Directory.CreateDirectory(RecorderPath);
            }
            if (AudioDeviceCount == 0) 
            {
                //if (_audiosource.availablerecordingsources.count <= 0&& _audiosource.availableloopbacksources.count <= 0)
                //{
                //    system.windows.forms.messagebox.show("未找到音频设备.");
                //    return;
                //}
                System.Windows.Forms.MessageBox.Show("未找到音频设备.");
                return;
            }

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
                var fileName = Path.Combine(RecorderPath, "BAR-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".wav");
                _recorder = new Recorder(WaveItem.Instance.GetAudioFileWriter(fileName, audioProvider?.WaveFormat,50), audioProvider);
                _recorder.Start();
                recordingStopwatch.Reset();
                ScreenRecordTimer.Start();
                recordingStopwatch.Start();

                ScreenRecord.Enabled = false; // 禁用/启用
                ScreenRecord.Visible = false;
                AudioRecord.Enabled = false;
                AudioRecord.Visible = false;
                StopRecording.Enabled = true;
                StopRecording.Visible = true;
                RecordTimeTick.Visible = true;
            }
        }
        /// <summary>
        /// 点击停止录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StopAudioRecord_Click(object sender, EventArgs e)
        {
            if (audioRecording == true)
            {
                await _MyRecordingViewModel.StopAudioRecording(_recorder);
                audioRecording = false;
                ScreenRecordTimer.Stop();
                recordingStopwatch.Stop();

                AudioRecord.Enabled = true; // 禁用/启用
                AudioRecord.Visible = true;
                ScreenRecord.Enabled = true;
                ScreenRecord.Visible = true;
                StopRecording.Enabled = false;
                StopRecording.Visible = false;
                RecordTimeTick.Visible = false;
                RecordTimeTick.Text = "00:00";
            }
        }
        /// <summary>
        /// 点击截屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenShot_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HideCurrentWindow)
            {
                Hide();
                Thread.Sleep(70);
            }

            CaptureImageTool capture = new CaptureImageTool
            {
                SelectCursor = CursorManager.Arrow,
                DrawCursor = CursorManager.Cross
            };

            if (capture.ShowDialog() == DialogResult.OK)
            {
                Image image = capture.Image;

                if (false == Directory.Exists(ShotPath))
                {
                    //创建pic文件夹
                    Directory.CreateDirectory(ShotPath);
                }
                string filePath = Path.Combine(ShotPath, "BSS-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
                image.Save(filePath, ImageFormat.Jpeg);
            }

            if (!Visible)
            {
                Show();
            }
        }
        /// <summary>
        /// 点击停止截屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenRecord_Click(object sender, EventArgs e)
        {
            if (false == Directory.Exists(RecorderPath))
            {
                Directory.CreateDirectory(RecorderPath);
            }
            if (screenRecording == false)
            {
                _MyRecordingViewModel.StartRecoding(RecorderPath);
                screenRecording = true;
                recordingStopwatch.Reset();
                ScreenRecordTimer.Start();
                recordingStopwatch.Start();

                AudioRecord.Enabled = false;
                AudioRecord.Visible = false;
                ScreenRecord.Enabled = false;
                ScreenRecord.Visible = false;
                StopRecording.Enabled = true;
                StopRecording.Visible = true;
                RecordTimeTick.Visible = true;
            }

        }
        /// <summary>
        /// 点击停止录屏
        /// async异步无返回值，与await共同使用，在后者返回状态值后执行下面的代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StopScreenRecord_Click(object sender, EventArgs e)
        {
            if (screenRecording == true)
            {
                await _MyRecordingViewModel.StopAudioRecording();
                screenRecording = false;
                ScreenRecordTimer.Stop();
                recordingStopwatch.Stop();

                AudioRecord.Enabled = true;
                AudioRecord.Visible = true;
                ScreenRecord.Enabled = true;
                ScreenRecord.Visible = true;
                StopRecording.Enabled = false;
                StopRecording.Visible = false;
                RecordTimeTick.Visible = false;
                RecordTimeTick.Text = "00:00";
            }

        }

        /// <summary>
        /// 录制时长的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordTimeTick_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = recordingStopwatch.Elapsed;
            this.RecordTimeTick.Text = string.Format(
                "{0:00}:{1:00}",
                Math.Floor(elapsed.TotalMinutes),
                elapsed.Seconds);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            String Language = Properties.Settings.Default.DefaultLanguage; // 设置默认语言
            if (Language == "zh-CN")
            {
                zh_CN_Click(sender, e);
            }
            else
            {
                en_US_Click(sender, e);
            }
        }
        /// <summary>
        /// 点击切换中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zh_CN_Click(object sender, EventArgs e)
        {
            MultiLanguage.LoadCurrentFromLanguage("zh-CN");
        }
        /// <summary>
        /// 点击切换英文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void en_US_Click(object sender, EventArgs e)
        {
            MultiLanguage.LoadCurrentFromLanguage("en-US");
        }
        /// <summary>
        /// 点击截屏设置
        /// 1、隐藏当前窗口
        /// 2、截图保存路径
        /// var：隐式类型，一旦声明必须赋值，否则会报错
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
        /// 点击设置录音录屏
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
        /// <summary>
        /// 主屏幕关闭事件---停止录制(音频/视频)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopRecording_Click(sender, e);
        }
        /// <summary>
        /// 点击停止录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopRecording_Click(object sender, EventArgs e)
        {

            if (screenRecording == true)
            {
                StopScreenRecord_Click(sender, e);
            }
            if (audioRecording == true)
            {
                StopAudioRecord_Click(sender, e);
            }
        }
        /// <summary>
        /// 点击"最小化"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimize_Click(object sender, EventArgs e)
        {
            if (!this.ShowInTaskbar)
            {
                this.Hide();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        /// <summary>
        /// 点击"最大化与还原"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 点击"关闭"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 启动关闭特定的可执行文件 --- 调用虚拟键盘/系统文件
        /// </summary>
        /// <param name="executePath"></param>exe文件的绝对路径
        /// <param name="excuteName"></param>exe文件的名字，不带扩展名
        /// <returns></returns>
        private bool StartProcess(String executePath, String excuteName) {
            Boolean flag = false;
            if (File.Exists(executePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(executePath);
                Process process = new Process();
                startInfo.UseShellExecute = false; //不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false; //不重定向输入
                startInfo.RedirectStandardOutput = true; //重定向输出
                process.StartInfo = startInfo;
                Process[] qqs = Process.GetProcessesByName(excuteName);
                if (qqs.Length == 0)
                {
                    flag = process.Start();
                }
                else
                {
                    qqs[0].Kill();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please check path："+ executePath);
            }
            return flag;
        }

        private void 参数配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

