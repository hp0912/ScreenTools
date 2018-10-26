
using CefSharp.WinForms;
using System.Windows.Forms;

namespace ScreenTools
{
    partial class MainWindow
    {
        
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingS = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.ZH_CN = new System.Windows.Forms.ToolStripMenuItem();
            this.en_US = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenCaptureSet = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioRecordSet = new System.Windows.Forms.ToolStripMenuItem();
            this.PlatformOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineList = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoConference = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AudioRecordTimeTick = new System.Windows.Forms.Label();
            this.StopAudioRecord = new System.Windows.Forms.Button();
            this.ScreenRecordTimeTick = new System.Windows.Forms.Label();
            this.AudioRecord = new System.Windows.Forms.Button();
            this.StopScreenRecord = new System.Windows.Forms.Button();
            this.ScreenRecord = new System.Windows.Forms.Button();
            this.ScreenShot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 27);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1094, 519);
            this.webBrowser1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlatformOverview,
            this.ProductionLineList,
            this.ProductionLineMonitoring,
            this.VideoConference,
            this.SettingS});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 26);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingS
            // 
            this.SettingS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageSet,
            this.ScreenCaptureSet,
            this.AudioRecordSet});
            this.SettingS.Font = new System.Drawing.Font("宋体", 9F);
            this.SettingS.MergeIndex = 0;
            this.SettingS.Name = "SettingS";
            this.SettingS.Padding = new System.Windows.Forms.Padding(3);
            this.SettingS.Size = new System.Drawing.Size(39, 22);
            this.SettingS.Text = "设置";
            // 
            // LanguageSet
            // 
            this.LanguageSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZH_CN,
            this.en_US});
            this.LanguageSet.Name = "LanguageSet";
            this.LanguageSet.Size = new System.Drawing.Size(180, 22);
            this.LanguageSet.Text = "语言设置";
            // 
            // ZH_CN
            // 
            this.ZH_CN.Name = "ZH_CN";
            this.ZH_CN.Size = new System.Drawing.Size(112, 22);
            this.ZH_CN.Text = "中文";
            this.ZH_CN.Click += new System.EventHandler(this.ZH_CN_Click);
            // 
            // en_US
            // 
            this.en_US.Name = "en_US";
            this.en_US.Size = new System.Drawing.Size(112, 22);
            this.en_US.Text = "English";
            this.en_US.Click += new System.EventHandler(this.en_US_Click);
            // 
            // ScreenCaptureSet
            // 
            this.ScreenCaptureSet.Font = new System.Drawing.Font("宋体", 9F);
            this.ScreenCaptureSet.Name = "ScreenCaptureSet";
            this.ScreenCaptureSet.Size = new System.Drawing.Size(180, 22);
            this.ScreenCaptureSet.Text = "截屏设置";
            this.ScreenCaptureSet.Click += new System.EventHandler(this.ScreenCaptureSet_Click);
            // 
            // AudioRecordSet
            // 
            this.AudioRecordSet.Name = "AudioRecordSet";
            this.AudioRecordSet.Size = new System.Drawing.Size(180, 22);
            this.AudioRecordSet.Text = "录制设置";
            this.AudioRecordSet.Click += new System.EventHandler(this.AudioRecordSet_Click);
            // 
            // PlatformOverview
            // 
            this.PlatformOverview.Font = new System.Drawing.Font("宋体", 9F);
            this.PlatformOverview.Name = "PlatformOverview";
            this.PlatformOverview.Size = new System.Drawing.Size(65, 22);
            this.PlatformOverview.Text = "平台总览";
            this.PlatformOverview.Click += new System.EventHandler(this.PlatformOverview_Click);
            // 
            // ProductionLineList
            // 
            this.ProductionLineList.Font = new System.Drawing.Font("宋体", 9F);
            this.ProductionLineList.Name = "ProductionLineList";
            this.ProductionLineList.Size = new System.Drawing.Size(65, 22);
            this.ProductionLineList.Text = "产线一览";
            this.ProductionLineList.Click += new System.EventHandler(this.ProductionLineList_Click);
            // 
            // ProductionLineMonitoring
            // 
            this.ProductionLineMonitoring.Font = new System.Drawing.Font("宋体", 9F);
            this.ProductionLineMonitoring.Name = "ProductionLineMonitoring";
            this.ProductionLineMonitoring.Size = new System.Drawing.Size(65, 22);
            this.ProductionLineMonitoring.Text = "产线监控";
            // 
            // VideoConference
            // 
            this.VideoConference.Font = new System.Drawing.Font("宋体", 9F);
            this.VideoConference.Name = "VideoConference";
            this.VideoConference.Size = new System.Drawing.Size(65, 22);
            this.VideoConference.Text = "视频会议";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.AudioRecordTimeTick);
            this.panel1.Controls.Add(this.StopAudioRecord);
            this.panel1.Controls.Add(this.ScreenRecordTimeTick);
            this.panel1.Controls.Add(this.AudioRecord);
            this.panel1.Controls.Add(this.StopScreenRecord);
            this.panel1.Controls.Add(this.ScreenRecord);
            this.panel1.Controls.Add(this.ScreenShot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 34);
            this.panel1.TabIndex = 16;
            // 
            // AudioRecordTimeTick
            // 
            this.AudioRecordTimeTick.BackColor = System.Drawing.Color.Transparent;
            this.AudioRecordTimeTick.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AudioRecordTimeTick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioRecordTimeTick.Location = new System.Drawing.Point(414, 2);
            this.AudioRecordTimeTick.Name = "AudioRecordTimeTick";
            this.AudioRecordTimeTick.Size = new System.Drawing.Size(80, 28);
            this.AudioRecordTimeTick.TabIndex = 6;
            this.AudioRecordTimeTick.Text = "00:00";
            this.AudioRecordTimeTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AudioRecordTimeTick.Visible = false;
            // 
            // StopAudioRecord
            // 
            this.StopAudioRecord.BackColor = System.Drawing.Color.Transparent;
            this.StopAudioRecord.Enabled = false;
            this.StopAudioRecord.FlatAppearance.BorderSize = 0;
            this.StopAudioRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StopAudioRecord.Location = new System.Drawing.Point(334, 2);
            this.StopAudioRecord.Name = "StopAudioRecord";
            this.StopAudioRecord.Size = new System.Drawing.Size(80, 30);
            this.StopAudioRecord.TabIndex = 5;
            this.StopAudioRecord.Text = "停止录音";
            this.StopAudioRecord.UseVisualStyleBackColor = false;
            this.StopAudioRecord.Visible = false;
            this.StopAudioRecord.Click += new System.EventHandler(this.StopAudioRecord_Click);
            // 
            // ScreenRecordTimeTick
            // 
            this.ScreenRecordTimeTick.BackColor = System.Drawing.Color.Transparent;
            this.ScreenRecordTimeTick.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ScreenRecordTimeTick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ScreenRecordTimeTick.Location = new System.Drawing.Point(248, 2);
            this.ScreenRecordTimeTick.Name = "ScreenRecordTimeTick";
            this.ScreenRecordTimeTick.Size = new System.Drawing.Size(80, 28);
            this.ScreenRecordTimeTick.TabIndex = 4;
            this.ScreenRecordTimeTick.Text = "00:00";
            this.ScreenRecordTimeTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ScreenRecordTimeTick.Visible = false;
            // 
            // AudioRecord
            // 
            this.AudioRecord.FlatAppearance.BorderSize = 0;
            this.AudioRecord.Location = new System.Drawing.Point(334, 2);
            this.AudioRecord.Name = "AudioRecord";
            this.AudioRecord.Size = new System.Drawing.Size(160, 30);
            this.AudioRecord.TabIndex = 2;
            this.AudioRecord.Tag = "false";
            this.AudioRecord.Text = "录音";
            this.AudioRecord.UseVisualStyleBackColor = true;
            this.AudioRecord.Click += new System.EventHandler(this.AudioRecord_Click);
            // 
            // StopScreenRecord
            // 
            this.StopScreenRecord.BackColor = System.Drawing.Color.Transparent;
            this.StopScreenRecord.Enabled = false;
            this.StopScreenRecord.FlatAppearance.BorderSize = 0;
            this.StopScreenRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StopScreenRecord.Location = new System.Drawing.Point(168, 2);
            this.StopScreenRecord.Name = "StopScreenRecord";
            this.StopScreenRecord.Size = new System.Drawing.Size(80, 30);
            this.StopScreenRecord.TabIndex = 3;
            this.StopScreenRecord.Text = "停止录屏";
            this.StopScreenRecord.UseVisualStyleBackColor = false;
            this.StopScreenRecord.Visible = false;
            this.StopScreenRecord.Click += new System.EventHandler(this.StopScreenRecord_Click);
            // 
            // ScreenRecord
            // 
            this.ScreenRecord.FlatAppearance.BorderSize = 0;
            this.ScreenRecord.Location = new System.Drawing.Point(168, 2);
            this.ScreenRecord.Name = "ScreenRecord";
            this.ScreenRecord.Size = new System.Drawing.Size(160, 30);
            this.ScreenRecord.TabIndex = 1;
            this.ScreenRecord.Text = "录屏";
            this.ScreenRecord.UseVisualStyleBackColor = true;
            this.ScreenRecord.Click += new System.EventHandler(this.ScreenRecord_Click);
            // 
            // ScreenShot
            // 
            this.ScreenShot.FlatAppearance.BorderSize = 0;
            this.ScreenShot.Location = new System.Drawing.Point(2, 2);
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(160, 30);
            this.ScreenShot.TabIndex = 0;
            this.ScreenShot.Text = "截屏";
            this.ScreenShot.UseVisualStyleBackColor = true;
            this.ScreenShot.Click += new System.EventHandler(this.ScreenShot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(946, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1094, 581);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "智慧云屏";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem SettingS;
        private ToolStripMenuItem LanguageSet;
        private ToolStripMenuItem ScreenCaptureSet;
        private ToolStripMenuItem PlatformOverview;
        private ToolStripMenuItem ProductionLineList;
        private ToolStripMenuItem ProductionLineMonitoring;
        private ToolStripMenuItem VideoConference;
        private Panel panel1;
        private Button AudioRecord;
        private Button ScreenRecord;
        private Button ScreenShot;
        private ToolStripMenuItem ZH_CN;
        private ToolStripMenuItem en_US;
        private ToolStripMenuItem AudioRecordSet;
        private Button StopScreenRecord;
        private Label ScreenRecordTimeTick;
        private Label AudioRecordTimeTick;
        private Button StopAudioRecord;
        private Button button1;
    }
}

