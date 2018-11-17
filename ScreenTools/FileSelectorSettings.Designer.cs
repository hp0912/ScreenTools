namespace ScreenTools
{
    partial class FileSelectorSettings
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
            this.Browse = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.Label();
            this.SelectedFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(684, 66);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "浏览";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(309, 129);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(390, 129);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "确定";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // FilePath
            // 
            this.FilePath.AutoSize = true;
            this.FilePath.Location = new System.Drawing.Point(23, 70);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(53, 12);
            this.FilePath.TabIndex = 4;
            this.FilePath.Text = "文件路径";
            // 
            // SelectedFilePath
            // 
            this.SelectedFilePath.Location = new System.Drawing.Point(98, 67);
            this.SelectedFilePath.Name = "SelectedFilePath";
            this.SelectedFilePath.Size = new System.Drawing.Size(575, 21);
            this.SelectedFilePath.TabIndex = 5;
            this.SelectedFilePath.TextChanged += new System.EventHandler(this.SelectedFilePath_TextChanged);
            // 
            // FileSelectorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(781, 170);
            this.Controls.Add(this.SelectedFilePath);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSelectorSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件选择设置";
            this.Load += new System.EventHandler(this.FileSelectorSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.TextBox SelectedFilePath;
    }
}