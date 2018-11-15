namespace ScreenTools
{
    partial class ArgumentsSettings
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
            this.MonitorPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LinePath = new System.Windows.Forms.TextBox();
            this.MeetingPath = new System.Windows.Forms.TextBox();
            this.LineBrowse = new System.Windows.Forms.Button();
            this.MeetingBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MonitorPath
            // 
            this.MonitorPath.AutoSize = true;
            this.MonitorPath.Location = new System.Drawing.Point(43, 48);
            this.MonitorPath.Name = "MonitorPath";
            this.MonitorPath.Size = new System.Drawing.Size(77, 12);
            this.MonitorPath.TabIndex = 0;
            this.MonitorPath.Text = "产线监控路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "视频会议路径";
            // 
            // LinePath
            // 
            this.LinePath.Location = new System.Drawing.Point(126, 45);
            this.LinePath.Name = "LinePath";
            this.LinePath.Size = new System.Drawing.Size(248, 21);
            this.LinePath.TabIndex = 2;
            // 
            // MeetingPath
            // 
            this.MeetingPath.Location = new System.Drawing.Point(126, 95);
            this.MeetingPath.Name = "MeetingPath";
            this.MeetingPath.Size = new System.Drawing.Size(248, 21);
            this.MeetingPath.TabIndex = 3;
            // 
            // LineBrowse
            // 
            this.LineBrowse.Location = new System.Drawing.Point(383, 44);
            this.LineBrowse.Name = "LineBrowse";
            this.LineBrowse.Size = new System.Drawing.Size(75, 23);
            this.LineBrowse.TabIndex = 4;
            this.LineBrowse.Text = "浏览";
            this.LineBrowse.UseVisualStyleBackColor = true;
            // 
            // MeetingBrowse
            // 
            this.MeetingBrowse.Location = new System.Drawing.Point(383, 94);
            this.MeetingBrowse.Name = "MeetingBrowse";
            this.MeetingBrowse.Size = new System.Drawing.Size(75, 23);
            this.MeetingBrowse.TabIndex = 5;
            this.MeetingBrowse.Text = "浏览";
            this.MeetingBrowse.UseVisualStyleBackColor = true;
            // 
            // ArgumentsSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 170);
            this.Controls.Add(this.MeetingBrowse);
            this.Controls.Add(this.LineBrowse);
            this.Controls.Add(this.MeetingPath);
            this.Controls.Add(this.LinePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MonitorPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArgumentsSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArgumentsSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MonitorPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LinePath;
        private System.Windows.Forms.TextBox MeetingPath;
        private System.Windows.Forms.Button LineBrowse;
        private System.Windows.Forms.Button MeetingBrowse;
    }
}