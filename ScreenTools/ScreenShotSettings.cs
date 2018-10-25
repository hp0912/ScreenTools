using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTools
{
    public partial class ScreenShotSettings : Form
    {
        public ScreenShotSettings(bool hideCurrentWindow, string screenShotPath)
        {
            InitializeComponent();

            if (hideCurrentWindow)
            {
                this.checkBox1.Checked = true;
            }
            else
            {
                this.checkBox1.Checked = false;
            }

            ScreenShotFilePath.Text = screenShotPath;
            this.folderBrowserDialog.SelectedPath = screenShotPath;

            this.HideCurrentWindow = hideCurrentWindow;
            this.ScreenShotPath = screenShotPath;
        }

        public bool HideCurrentWindow { get; set; }
        public string ScreenShotPath { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                HideCurrentWindow = true;
            }
            else
            {
                HideCurrentWindow = false;
            }
        }

        private void browser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ScreenShotPath = this.folderBrowserDialog.SelectedPath;
                this.ScreenShotFilePath.Text = this.ScreenShotPath;
            }
        }

        private void ensure_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
