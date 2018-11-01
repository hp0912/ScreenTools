namespace ScreenTools
{
    partial class AudioRecordSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SoundcardGroup = new System.Windows.Forms.GroupBox();
            this.SoundcardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MicrophoneGroup = new System.Windows.Forms.GroupBox();
            this.MicrophonePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SavePath = new System.Windows.Forms.Label();
            this.AudioRecorderFilePath = new System.Windows.Forms.TextBox();
            this.AudioFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browser = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.ensure = new System.Windows.Forms.Button();
            this.RefreshDev = new System.Windows.Forms.Button();
            this.SoundcardGroup.SuspendLayout();
            this.MicrophoneGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoundcardGroup
            // 
            this.SoundcardGroup.Controls.Add(this.SoundcardPanel);
            this.SoundcardGroup.Location = new System.Drawing.Point(12, 32);
            this.SoundcardGroup.Name = "SoundcardGroup";
            this.SoundcardGroup.Size = new System.Drawing.Size(380, 129);
            this.SoundcardGroup.TabIndex = 0;
            this.SoundcardGroup.TabStop = false;
            this.SoundcardGroup.Text = "声卡";
            // 
            // SoundcardPanel
            // 
            this.SoundcardPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SoundcardPanel.Location = new System.Drawing.Point(6, 20);
            this.SoundcardPanel.Name = "SoundcardPanel";
            this.SoundcardPanel.Size = new System.Drawing.Size(368, 100);
            this.SoundcardPanel.TabIndex = 0;
            // 
            // MicrophoneGroup
            // 
            this.MicrophoneGroup.Controls.Add(this.MicrophonePanel);
            this.MicrophoneGroup.Location = new System.Drawing.Point(398, 32);
            this.MicrophoneGroup.Name = "MicrophoneGroup";
            this.MicrophoneGroup.Size = new System.Drawing.Size(380, 129);
            this.MicrophoneGroup.TabIndex = 1;
            this.MicrophoneGroup.TabStop = false;
            this.MicrophoneGroup.Text = "麦克风";
            // 
            // MicrophonePanel
            // 
            this.MicrophonePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MicrophonePanel.Location = new System.Drawing.Point(6, 20);
            this.MicrophonePanel.Name = "MicrophonePanel";
            this.MicrophonePanel.Size = new System.Drawing.Size(368, 100);
            this.MicrophonePanel.TabIndex = 1;
            // 
            // SavePath
            // 
            this.SavePath.AutoSize = true;
            this.SavePath.Location = new System.Drawing.Point(12, 175);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(77, 12);
            this.SavePath.TabIndex = 2;
            this.SavePath.Text = "音频保存路径";
            // 
            // AudioRecorderFilePath
            // 
            this.AudioRecorderFilePath.Location = new System.Drawing.Point(95, 172);
            this.AudioRecorderFilePath.Name = "AudioRecorderFilePath";
            this.AudioRecorderFilePath.ReadOnly = true;
            this.AudioRecorderFilePath.Size = new System.Drawing.Size(584, 21);
            this.AudioRecorderFilePath.TabIndex = 3;
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(685, 171);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(75, 23);
            this.browser.TabIndex = 4;
            this.browser.Text = "浏览";
            this.browser.UseVisualStyleBackColor = true;
            this.browser.Click += new System.EventHandler(this.browser_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(319, 199);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ensure
            // 
            this.ensure.Location = new System.Drawing.Point(399, 199);
            this.ensure.Name = "ensure";
            this.ensure.Size = new System.Drawing.Size(75, 23);
            this.ensure.TabIndex = 5;
            this.ensure.Text = "确定";
            this.ensure.UseVisualStyleBackColor = true;
            this.ensure.Click += new System.EventHandler(this.ensure_Click);
            // 
            // RefreshDev
            // 
            this.RefreshDev.Location = new System.Drawing.Point(703, 6);
            this.RefreshDev.Name = "RefreshDev";
            this.RefreshDev.Size = new System.Drawing.Size(75, 23);
            this.RefreshDev.TabIndex = 7;
            this.RefreshDev.Text = "刷新设备";
            this.RefreshDev.UseVisualStyleBackColor = true;
            this.RefreshDev.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // AudioRecordSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 229);
            this.Controls.Add(this.RefreshDev);
            this.Controls.Add(this.ensure);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.AudioRecorderFilePath);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.MicrophoneGroup);
            this.Controls.Add(this.SoundcardGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioRecordSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录制设置";
            this.Load += new System.EventHandler(this.AudioRecordSettings_Load);
            this.SoundcardGroup.ResumeLayout(false);
            this.MicrophoneGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SoundcardGroup;
        private System.Windows.Forms.GroupBox MicrophoneGroup;
        private System.Windows.Forms.Label SavePath;
        private System.Windows.Forms.TextBox AudioRecorderFilePath;
        private System.Windows.Forms.FolderBrowserDialog AudioFolderBrowserDialog;
        private System.Windows.Forms.Button browser;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ensure;
        private System.Windows.Forms.FlowLayoutPanel SoundcardPanel;
        private System.Windows.Forms.FlowLayoutPanel MicrophonePanel;
        private System.Windows.Forms.Button RefreshDev;
    }
}