using System;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;

namespace ScreenTools
{

    public partial class MainWindow : Form
    {
        public ChromiumWebBrowser browser;

        public MainWindow()
        {
            InitializeComponent();
            this.开始录音ToolStripMenuItem.Enabled = true;
            this.停止录音ToolStripMenuItem.Enabled = false;
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
            this.视频监控ToolStripMenuItem.Text = "视频监控";

        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.语言设置ToolStripMenuItem.Text = "Language Settings";
            this.平台总览ToolStripMenuItem.Text = "Platform Overview";
            this.产线一览ToolStripMenuItem.Text = "Production Line List";
            this.产线监控ToolStripMenuItem.Text = "Production Line Monitoring";
            this.视频监控ToolStripMenuItem.Text = "Video Surveillance";                      
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

        private void 截取当前窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             ScreenShot.getScreen(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height, Properties.Settings.Default.ScreenShotPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
            
        }

        private void 截取当前屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.截屏时隐藏当前窗口ToolStripMenuItem.Checked)
            {
                this.Hide();
                Thread.Sleep(1000);
                ScreenShot.getScreen(0, 0, -1, -1, Properties.Settings.Default.ScreenShotPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
                this.Show();
            }
            else
            {
                ScreenShot.getScreen(0, 0, -1, -1, Properties.Settings.Default.ScreenShotPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
            }
            
        }
        private void 截取选择部分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HideCurrentWindow)
            {
                this.Hide();
                Thread.Sleep(1000);
            }
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            ScreenShotWindow ssw = new ScreenShotWindow();
            ssw.BackgroundImage = img;
            ssw.FormClosed += ScreenShotWindow_FormClosed;
            ssw.Show();
        }

        private void ScreenShotWindow_FormClosed(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HideCurrentWindow)
            {
                this.Show();
            }
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

        private void 开始录音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.开始录音ToolStripMenuItem.Enabled = false;
            this.停止录音ToolStripMenuItem.Enabled = true;

            mciSendString("set wave bitpersample 8", "", 0, 0);
            mciSendString("set wave samplespersec 20000", "", 0, 0);
            mciSendString("set wave channels 2", "", 0, 0);
            mciSendString("set wave format tag pcm", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
            mciSendString("record movie", "", 0, 0);
        }

        private void 停止录音ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.开始录音ToolStripMenuItem.Enabled = true;
            this.停止录音ToolStripMenuItem.Enabled = false;

            ScreenShot.confirmDir(Properties.Settings.Default.SoundRecorderPath);
            mciSendString("stop movie", "", 0, 0);
            mciSendString("save movie " + Properties.Settings.Default.SoundRecorderPath + "BepsunSoundRecorder-" + DateTime.Now.ToFileTime().ToString() + ".wav", "", 0, 0);
            mciSendString("close movie", "", 0, 0);
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );
    }
}

