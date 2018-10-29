
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
            this.ProductionLineList = new System.Windows.Forms.ToolStripMenuItem();
            this.AssetRun = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoConference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SettingS = new System.Windows.Forms.ToolStripDropDownButton();
            this.AudioRecordSet = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenCaptureSet = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.zh_CN = new System.Windows.Forms.ToolStripMenuItem();
            this.en_US = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenShot = new System.Windows.Forms.ToolStripButton();
            this.ScreenRecord = new System.Windows.Forms.ToolStripButton();
            this.AudioRecord = new System.Windows.Forms.ToolStripButton();
            this.StopRecording = new System.Windows.Forms.ToolStripButton();
            this.RecordTimeTick = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 63);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1358, 475);
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
            this.VideoConference});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1358, 60);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PlatformOverview
            // 
            this.PlatformOverview.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlatformOverview.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.PlatformOverview.Name = "PlatformOverview";
            this.PlatformOverview.Size = new System.Drawing.Size(143, 56);
            this.PlatformOverview.Text = "UCCP";
            this.PlatformOverview.Click += new System.EventHandler(this.PlatformOverview_Click);
            // 
            // ProductionLineList
            // 
            this.ProductionLineList.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductionLineList.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.ProductionLineList.Name = "ProductionLineList";
            this.ProductionLineList.Size = new System.Drawing.Size(195, 56);
            this.ProductionLineList.Text = "产线一览";
            this.ProductionLineList.Click += new System.EventHandler(this.ProductionLineList_Click);
            // 
            // AssetRun
            // 
            this.AssetRun.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AssetRun.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.AssetRun.Name = "AssetRun";
            this.AssetRun.Size = new System.Drawing.Size(315, 56);
            this.AssetRun.Text = "资产运行与运营";
            // 
            // ProductionLineMonitoring
            // 
            this.ProductionLineMonitoring.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductionLineMonitoring.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.ProductionLineMonitoring.Name = "ProductionLineMonitoring";
            this.ProductionLineMonitoring.Size = new System.Drawing.Size(195, 56);
            this.ProductionLineMonitoring.Text = "产线监控";
            // 
            // VideoConference
            // 
            this.VideoConference.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VideoConference.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.VideoConference.Name = "VideoConference";
            this.VideoConference.Size = new System.Drawing.Size(195, 56);
            this.VideoConference.Text = "视频会议";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingS,
            this.ScreenShot,
            this.ScreenRecord,
            this.AudioRecord,
            this.StopRecording,
            this.RecordTimeTick});
            this.toolStrip1.Location = new System.Drawing.Point(0, 532);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1358, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SettingS
            // 
            this.SettingS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SettingS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AudioRecordSet,
            this.ScreenCaptureSet,
            this.LanguageSet});
            this.SettingS.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SettingS.Image = ((System.Drawing.Image)(resources.GetObject("SettingS.Image")));
            this.SettingS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingS.MergeIndex = 0;
            this.SettingS.Name = "SettingS";
            this.SettingS.Size = new System.Drawing.Size(82, 39);
            this.SettingS.Text = "设置";
            // 
            // AudioRecordSet
            // 
            this.AudioRecordSet.Name = "AudioRecordSet";
            this.AudioRecordSet.Size = new System.Drawing.Size(198, 40);
            this.AudioRecordSet.Text = "录制设置";
            this.AudioRecordSet.Click += new System.EventHandler(this.AudioRecordSet_Click);
            // 
            // ScreenCaptureSet
            // 
            this.ScreenCaptureSet.Name = "ScreenCaptureSet";
            this.ScreenCaptureSet.Size = new System.Drawing.Size(198, 40);
            this.ScreenCaptureSet.Text = "截屏设置";
            this.ScreenCaptureSet.Click += new System.EventHandler(this.ScreenCaptureSet_Click);
            // 
            // LanguageSet
            // 
            this.LanguageSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zh_CN,
            this.en_US});
            this.LanguageSet.Name = "LanguageSet";
            this.LanguageSet.Size = new System.Drawing.Size(198, 40);
            this.LanguageSet.Text = "语言设置";
            // 
            // zh_CN
            // 
            this.zh_CN.Name = "zh_CN";
            this.zh_CN.Size = new System.Drawing.Size(183, 40);
            this.zh_CN.Text = "中文";
            this.zh_CN.Click += new System.EventHandler(this.zh_CN_Click);
            // 
            // en_US
            // 
            this.en_US.Name = "en_US";
            this.en_US.Size = new System.Drawing.Size(183, 40);
            this.en_US.Text = "English";
            this.en_US.Click += new System.EventHandler(this.en_US_Click);
            // 
            // ScreenShot
            // 
            this.ScreenShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScreenShot.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(73, 39);
            this.ScreenShot.Text = "截屏";
            this.ScreenShot.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ScreenShot.Click += new System.EventHandler(this.ScreenShot_Click);
            // 
            // ScreenRecord
            // 
            this.ScreenRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScreenRecord.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScreenRecord.Image = ((System.Drawing.Image)(resources.GetObject("ScreenRecord.Image")));
            this.ScreenRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScreenRecord.Name = "ScreenRecord";
            this.ScreenRecord.Size = new System.Drawing.Size(73, 39);
            this.ScreenRecord.Text = "录屏";
            this.ScreenRecord.Click += new System.EventHandler(this.ScreenRecord_Click);
            // 
            // AudioRecord
            // 
            this.AudioRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AudioRecord.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AudioRecord.Image = ((System.Drawing.Image)(resources.GetObject("AudioRecord.Image")));
            this.AudioRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AudioRecord.Name = "AudioRecord";
            this.AudioRecord.Size = new System.Drawing.Size(73, 39);
            this.AudioRecord.Text = "录音";
            this.AudioRecord.Click += new System.EventHandler(this.AudioRecord_Click);
            // 
            // StopRecording
            // 
            this.StopRecording.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopRecording.Enabled = false;
            this.StopRecording.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopRecording.Image = ((System.Drawing.Image)(resources.GetObject("StopRecording.Image")));
            this.StopRecording.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(127, 39);
            this.StopRecording.Text = "停止录制";
            this.StopRecording.Visible = false;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // RecordTimeTick
            // 
            this.RecordTimeTick.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RecordTimeTick.Name = "RecordTimeTick";
            this.RecordTimeTick.Size = new System.Drawing.Size(86, 39);
            this.RecordTimeTick.Text = "00:00";
            this.RecordTimeTick.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "146544";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1358, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
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
        private Label label1;
        protected internal ToolStripButton StopRecording;
    }
}

