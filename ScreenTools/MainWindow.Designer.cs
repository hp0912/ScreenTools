
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
            this.ScreenRecordSet = new System.Windows.Forms.ToolStripMenuItem();
            this.PlatformOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineList = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionLineMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoConference = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AudioRecord = new System.Windows.Forms.Button();
            this.ScreenRecord = new System.Windows.Forms.Button();
            this.ScreenShot = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingS,
            this.PlatformOverview,
            this.ProductionLineList,
            this.ProductionLineMonitoring,
            this.VideoConference});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // SettingS
            // 
            this.SettingS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageSet,
            this.ScreenCaptureSet,
            this.AudioRecordSet,
            this.ScreenRecordSet});
            resources.ApplyResources(this.SettingS, "SettingS");
            this.SettingS.MergeIndex = 0;
            this.SettingS.Name = "SettingS";
            this.SettingS.Padding = new System.Windows.Forms.Padding(3);
            // 
            // LanguageSet
            // 
            this.LanguageSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZH_CN,
            this.en_US});
            this.LanguageSet.Name = "LanguageSet";
            resources.ApplyResources(this.LanguageSet, "LanguageSet");
            // 
            // ZH_CN
            // 
            this.ZH_CN.Name = "ZH_CN";
            resources.ApplyResources(this.ZH_CN, "ZH_CN");
            this.ZH_CN.Click += new System.EventHandler(this.ZH_CN_Click);
            // 
            // en_US
            // 
            this.en_US.Name = "en_US";
            resources.ApplyResources(this.en_US, "en_US");
            this.en_US.Click += new System.EventHandler(this.en_US_Click);
            // 
            // ScreenCaptureSet
            // 
            resources.ApplyResources(this.ScreenCaptureSet, "ScreenCaptureSet");
            this.ScreenCaptureSet.Name = "ScreenCaptureSet";
            this.ScreenCaptureSet.Click += new System.EventHandler(this.ScreenCaptureSet_Click);
            // 
            // AudioRecordSet
            // 
            this.AudioRecordSet.Name = "AudioRecordSet";
            resources.ApplyResources(this.AudioRecordSet, "AudioRecordSet");
            this.AudioRecordSet.Click += new System.EventHandler(this.AudioRecordSet_Click);
            // 
            // ScreenRecordSet
            // 
            this.ScreenRecordSet.Name = "ScreenRecordSet";
            resources.ApplyResources(this.ScreenRecordSet, "ScreenRecordSet");
            this.ScreenRecordSet.Click += new System.EventHandler(this.ScreenRecordSet_Click);
            // 
            // PlatformOverview
            // 
            resources.ApplyResources(this.PlatformOverview, "PlatformOverview");
            this.PlatformOverview.Name = "PlatformOverview";
            this.PlatformOverview.Click += new System.EventHandler(this.PlatformOverview_Click);
            // 
            // ProductionLineList
            // 
            resources.ApplyResources(this.ProductionLineList, "ProductionLineList");
            this.ProductionLineList.Name = "ProductionLineList";
            this.ProductionLineList.Click += new System.EventHandler(this.ProductionLineList_Click);
            // 
            // ProductionLineMonitoring
            // 
            resources.ApplyResources(this.ProductionLineMonitoring, "ProductionLineMonitoring");
            this.ProductionLineMonitoring.Name = "ProductionLineMonitoring";
            // 
            // VideoConference
            // 
            resources.ApplyResources(this.VideoConference, "VideoConference");
            this.VideoConference.Name = "VideoConference";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.AudioRecord);
            this.panel1.Controls.Add(this.ScreenRecord);
            this.panel1.Controls.Add(this.ScreenShot);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // AudioRecord
            // 
            this.AudioRecord.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.AudioRecord, "AudioRecord");
            this.AudioRecord.Name = "AudioRecord";
            this.AudioRecord.Tag = "false";
            this.AudioRecord.UseVisualStyleBackColor = true;
            this.AudioRecord.Click += new System.EventHandler(this.AudioRecord_Click);
            // 
            // ScreenRecord
            // 
            this.ScreenRecord.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.ScreenRecord, "ScreenRecord");
            this.ScreenRecord.Name = "ScreenRecord";
            this.ScreenRecord.UseVisualStyleBackColor = true;
            this.ScreenRecord.Click += new System.EventHandler(this.ScreenRecord_Click);
            // 
            // ScreenShot
            // 
            this.ScreenShot.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.ScreenShot, "ScreenShot");
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.UseVisualStyleBackColor = true;
            this.ScreenShot.Click += new System.EventHandler(this.ScreenShot_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
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
        private ToolStripMenuItem ScreenRecordSet;
    }
}

