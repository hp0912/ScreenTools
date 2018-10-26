namespace ScreenTools
{
    partial class ScreenShotSettings
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
            this.HideTheMainForm = new System.Windows.Forms.CheckBox();
            this.SavePath = new System.Windows.Forms.Label();
            this.ScreenShotFilePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browser = new System.Windows.Forms.Button();
            this.ensure = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HideTheMainForm
            // 
            this.HideTheMainForm.AutoSize = true;
            this.HideTheMainForm.Location = new System.Drawing.Point(12, 12);
            this.HideTheMainForm.Name = "HideTheMainForm";
            this.HideTheMainForm.Size = new System.Drawing.Size(120, 16);
            this.HideTheMainForm.TabIndex = 0;
            this.HideTheMainForm.Text = "截图时隐藏主窗体";
            this.HideTheMainForm.UseVisualStyleBackColor = true;
            this.HideTheMainForm.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SavePath
            // 
            this.SavePath.AutoSize = true;
            this.SavePath.Location = new System.Drawing.Point(13, 47);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(77, 12);
            this.SavePath.TabIndex = 1;
            this.SavePath.Text = "截图保存路径";
            // 
            // ScreenShotFilePath
            // 
            this.ScreenShotFilePath.Location = new System.Drawing.Point(96, 44);
            this.ScreenShotFilePath.Name = "ScreenShotFilePath";
            this.ScreenShotFilePath.ReadOnly = true;
            this.ScreenShotFilePath.Size = new System.Drawing.Size(285, 21);
            this.ScreenShotFilePath.TabIndex = 2;
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(386, 43);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(75, 23);
            this.browser.TabIndex = 3;
            this.browser.Text = "浏览";
            this.browser.UseVisualStyleBackColor = true;
            this.browser.Click += new System.EventHandler(this.browser_Click);
            // 
            // ensure
            // 
            this.ensure.Location = new System.Drawing.Point(244, 78);
            this.ensure.Name = "ensure";
            this.ensure.Size = new System.Drawing.Size(75, 21);
            this.ensure.TabIndex = 4;
            this.ensure.Text = "确定";
            this.ensure.UseVisualStyleBackColor = true;
            this.ensure.Click += new System.EventHandler(this.ensure_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(163, 78);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 21);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ScreenShotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 105);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ensure);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.ScreenShotFilePath);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.HideTheMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenShotSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "截图设置";
            this.Load += new System.EventHandler(this.ScreenShotSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox HideTheMainForm;
        private System.Windows.Forms.Label SavePath;
        private System.Windows.Forms.TextBox ScreenShotFilePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button browser;
        private System.Windows.Forms.Button ensure;
        private System.Windows.Forms.Button cancel;
    }
}