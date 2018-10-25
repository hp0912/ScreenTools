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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScreenShotFilePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browser = new System.Windows.Forms.Button();
            this.ensure = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "截图时隐藏主窗体";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "截图保存路径";
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenShotSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "截图设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ScreenShotFilePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button browser;
        private System.Windows.Forms.Button ensure;
        private System.Windows.Forms.Button cancel;
    }
}