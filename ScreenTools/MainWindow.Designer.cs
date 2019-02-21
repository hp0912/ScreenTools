
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
            this.PlatformOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.AssetRun = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineList = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoConference = new System.Windows.Forms.ToolStripMenuItem();
            this.CorpLiveVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SettingS = new System.Windows.Forms.ToolStripDropDownButton();
            this.LiveVideoSet = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoConferenceSet = new System.Windows.Forms.ToolStripMenuItem();
            this.MonitorSet = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenCaptureSet = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioRecordSet = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.zh_CN = new System.Windows.Forms.ToolStripMenuItem();
            this.en_US = new System.Windows.Forms.ToolStripMenuItem();
            this.OSK = new System.Windows.Forms.ToolStripButton();
            this.ScreenShot = new System.Windows.Forms.ToolStripButton();
            this.ScreenRecord = new System.Windows.Forms.ToolStripButton();
            this.AudioRecord = new System.Windows.Forms.ToolStripButton();
            this.StopRecording = new System.Windows.Forms.ToolStripButton();
            this.RecordTimeTick = new System.Windows.Forms.ToolStripLabel();
            this.Minimize = new System.Windows.Forms.Button();
            this.Maximize = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 46);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(978, 283);
            this.webBrowser1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowItemReorder = true;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlatformOverview,
            this.AssetRun,
            this.ProductionLineList,
            this.ProductionLineMonitoring,
            this.VideoConference,
            this.CorpLiveVideo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(978, 36);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PlatformOverview
            // 
            this.PlatformOverview.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.PlatformOverview.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.PlatformOverview.Name = "PlatformOverview";
            this.PlatformOverview.Size = new System.Drawing.Size(81, 32);
            this.PlatformOverview.Text = "UCCP";
            this.PlatformOverview.Click += new System.EventHandler(this.PlatformOverview_Click);
            // 
            // AssetRun
            // 
            this.AssetRun.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.AssetRun.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AssetRun.Name = "AssetRun";
            this.AssetRun.Size = new System.Drawing.Size(171, 32);
            this.AssetRun.Text = "资产运行与运营";
            this.AssetRun.Click += new System.EventHandler(this.AssetRun_Click);
            // 
            // ProductionLineList
            // 
            this.ProductionLineList.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.ProductionLineList.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ProductionLineList.Name = "ProductionLineList";
            this.ProductionLineList.Size = new System.Drawing.Size(108, 32);
            this.ProductionLineList.Text = "产线一览";
            this.ProductionLineList.Click += new System.EventHandler(this.ProductionLineList_Click);
            // 
            // ProductionLineMonitoring
            // 
            this.ProductionLineMonitoring.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.ProductionLineMonitoring.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ProductionLineMonitoring.Name = "ProductionLineMonitoring";
            this.ProductionLineMonitoring.Size = new System.Drawing.Size(108, 32);
            this.ProductionLineMonitoring.Text = "产线监控";
            this.ProductionLineMonitoring.Click += new System.EventHandler(this.ProductionLineMonitoring_Click);
            // 
            // VideoConference
            // 
            this.VideoConference.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.VideoConference.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.VideoConference.Name = "VideoConference";
            this.VideoConference.Size = new System.Drawing.Size(108, 32);
            this.VideoConference.Text = "视频会议";
            this.VideoConference.Click += new System.EventHandler(this.VideoConference_Click);
            // 
            // CorpLiveVideo
            // 
            this.CorpLiveVideo.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.CorpLiveVideo.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.CorpLiveVideo.Name = "CorpLiveVideo";
            this.CorpLiveVideo.Size = new System.Drawing.Size(108, 32);
            this.CorpLiveVideo.Text = "企业直播";
            this.CorpLiveVideo.Click += new System.EventHandler(this.CorpLiveVideo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingS,
            this.OSK,
            this.ScreenShot,
            this.ScreenRecord,
            this.AudioRecord,
            this.StopRecording,
            this.RecordTimeTick});
            this.toolStrip1.Location = new System.Drawing.Point(0, 326);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(978, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SettingS
            // 
            this.SettingS.BackColor = System.Drawing.SystemColors.Control;
            this.SettingS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LiveVideoSet,
            this.VideoConferenceSet,
            this.MonitorSet,
            this.ScreenCaptureSet,
            this.AudioRecordSet,
            this.LanguageSet});
            this.SettingS.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.SettingS.Image = ((System.Drawing.Image)(resources.GetObject("SettingS.Image")));
            this.SettingS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SettingS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingS.MergeIndex = 0;
            this.SettingS.Name = "SettingS";
            this.SettingS.ShowDropDownArrow = false;
            this.SettingS.Size = new System.Drawing.Size(38, 36);
            this.SettingS.Text = "设置";
            this.SettingS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SettingS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SettingS.ToolTipText = "\r设置Settings";
            // 
            // LiveVideoSet
            // 
            this.LiveVideoSet.Name = "LiveVideoSet";
            this.LiveVideoSet.Size = new System.Drawing.Size(210, 32);
            this.LiveVideoSet.Text = "直播设置";
            // 
            // VideoConferenceSet
            // 
            this.VideoConferenceSet.Name = "VideoConferenceSet";
            this.VideoConferenceSet.Size = new System.Drawing.Size(210, 32);
            this.VideoConferenceSet.Text = "视频会议设置";
            this.VideoConferenceSet.Click += new System.EventHandler(this.VideoConferenceSet_Click);
            // 
            // MonitorSet
            // 
            this.MonitorSet.Name = "MonitorSet";
            this.MonitorSet.Size = new System.Drawing.Size(210, 32);
            this.MonitorSet.Text = "监控设置";
            this.MonitorSet.Click += new System.EventHandler(this.MonitorSet_Click);
            // 
            // ScreenCaptureSet
            // 
            this.ScreenCaptureSet.Name = "ScreenCaptureSet";
            this.ScreenCaptureSet.Size = new System.Drawing.Size(210, 32);
            this.ScreenCaptureSet.Text = "截屏设置";
            this.ScreenCaptureSet.Click += new System.EventHandler(this.ScreenCaptureSet_Click);
            // 
            // AudioRecordSet
            // 
            this.AudioRecordSet.Name = "AudioRecordSet";
            this.AudioRecordSet.Size = new System.Drawing.Size(210, 32);
            this.AudioRecordSet.Text = "录制设置";
            this.AudioRecordSet.Click += new System.EventHandler(this.AudioRecordSet_Click);
            // 
            // LanguageSet
            // 
            this.LanguageSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zh_CN,
            this.en_US});
            this.LanguageSet.Name = "LanguageSet";
            this.LanguageSet.Size = new System.Drawing.Size(210, 32);
            this.LanguageSet.Text = "语言设置";
            // 
            // zh_CN
            // 
            this.zh_CN.Name = "zh_CN";
            this.zh_CN.Size = new System.Drawing.Size(157, 32);
            this.zh_CN.Text = "中文";
            this.zh_CN.Click += new System.EventHandler(this.zh_CN_Click);
            // 
            // en_US
            // 
            this.en_US.Name = "en_US";
            this.en_US.Size = new System.Drawing.Size(157, 32);
            this.en_US.Text = "English";
            this.en_US.Click += new System.EventHandler(this.en_US_Click);
            // 
            // OSK
            // 
            this.OSK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OSK.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.OSK.Image = ((System.Drawing.Image)(resources.GetObject("OSK.Image")));
            this.OSK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OSK.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.OSK.Name = "OSK";
            this.OSK.Size = new System.Drawing.Size(58, 36);
            this.OSK.Text = "键盘";
            this.OSK.ToolTipText = "\r\n";
            this.OSK.Visible = false;
            this.OSK.Click += new System.EventHandler(this.OSK_Click);
            // 
            // ScreenShot
            // 
            this.ScreenShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScreenShot.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.ScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("ScreenShot.Image")));
            this.ScreenShot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScreenShot.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(39, 36);
            this.ScreenShot.Text = "截屏";
            this.ScreenShot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ScreenShot.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ScreenShot.ToolTipText = "\r\n截屏ScreenShot";
            this.ScreenShot.Click += new System.EventHandler(this.ScreenShot_Click);
            // 
            // ScreenRecord
            // 
            this.ScreenRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScreenRecord.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.ScreenRecord.Image = ((System.Drawing.Image)(resources.GetObject("ScreenRecord.Image")));
            this.ScreenRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScreenRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScreenRecord.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.ScreenRecord.Name = "ScreenRecord";
            this.ScreenRecord.Size = new System.Drawing.Size(40, 36);
            this.ScreenRecord.Text = "录屏";
            this.ScreenRecord.ToolTipText = "\r\n录屏ScreenRecord";
            this.ScreenRecord.Click += new System.EventHandler(this.ScreenRecord_Click);
            // 
            // AudioRecord
            // 
            this.AudioRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AudioRecord.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.AudioRecord.Image = ((System.Drawing.Image)(resources.GetObject("AudioRecord.Image")));
            this.AudioRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AudioRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AudioRecord.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.AudioRecord.Name = "AudioRecord";
            this.AudioRecord.Size = new System.Drawing.Size(39, 36);
            this.AudioRecord.Text = "录音";
            this.AudioRecord.ToolTipText = "\r\n录音AudioRecord";
            this.AudioRecord.Click += new System.EventHandler(this.AudioRecord_Click);
            // 
            // StopRecording
            // 
            this.StopRecording.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopRecording.Enabled = false;
            this.StopRecording.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.StopRecording.Image = ((System.Drawing.Image)(resources.GetObject("StopRecording.Image")));
            this.StopRecording.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopRecording.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(100, 36);
            this.StopRecording.Text = "停止录制";
            this.StopRecording.ToolTipText = "\r\n";
            this.StopRecording.Visible = false;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // RecordTimeTick
            // 
            this.RecordTimeTick.Font = new System.Drawing.Font("微软雅黑", 15.25F);
            this.RecordTimeTick.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.RecordTimeTick.Name = "RecordTimeTick";
            this.RecordTimeTick.Size = new System.Drawing.Size(65, 36);
            this.RecordTimeTick.Text = "00:00";
            this.RecordTimeTick.Visible = false;
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.AutoSize = true;
            this.Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Minimize.Image")));
            this.Minimize.Location = new System.Drawing.Point(802, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(58, 33);
            this.Minimize.TabIndex = 14;
            this.Minimize.UseVisualStyleBackColor = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Maximize
            // 
            this.Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Maximize.AutoSize = true;
            this.Maximize.Image = ((System.Drawing.Image)(resources.GetObject("Maximize.Image")));
            this.Maximize.Location = new System.Drawing.Point(861, 0);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(58, 33);
            this.Maximize.TabIndex = 15;
            this.Maximize.UseVisualStyleBackColor = true;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.Location = new System.Drawing.Point(920, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(58, 33);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(978, 365);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem PlatformOverview;
        private ToolStripMenuItem ProductionLineList;
        private ToolStripMenuItem ProductionLineMonitoring;
        private ToolStripMenuItem VideoConference;
        private ToolStrip toolStrip1;
        private ToolStripButton ScreenShot;
        private ToolStripButton ScreenRecord;
        private ToolStripButton AudioRecord;
        private ToolStripLabel RecordTimeTick;
        private ToolStripDropDownButton SettingS;
        private ToolStripMenuItem AudioRecordSet;
        private ToolStripMenuItem ScreenCaptureSet;
        private ToolStripMenuItem LanguageSet;
        private ToolStripMenuItem zh_CN;
        private ToolStripMenuItem en_US;
        private ToolStripMenuItem AssetRun;
        protected internal ToolStripButton StopRecording;
        private ToolStripButton OSK;
        private Button Minimize;
        private Button Maximize;
        private Button CloseButton;
        private ToolStripMenuItem CorpLiveVideo;
        private ToolStripMenuItem MonitorSet;
        private ToolStripMenuItem VideoConferenceSet;
        private ToolStripMenuItem LiveVideoSet;
    }
}

