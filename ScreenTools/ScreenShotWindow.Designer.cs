namespace ScreenTools
{
    partial class ScreenShotWindow
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
            this.SuspendLayout();
            // 
            // ScreenShotWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenShotWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ScreenShotWindow";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScreenShotWindow_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScreenShotWindow_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenShotWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenShotWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenShotWindow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}