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
                this.HideTheMainForm.Checked = true;
            }
            else
            {
                this.HideTheMainForm.Checked = false;
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
            if (this.HideTheMainForm.Checked)
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

        private void ScreenShotSettings_Load(object sender, EventArgs e)
        {
            //设置默认语言
            String Language = Properties.Settings.Default.DefaultLanguage;
            switch (Language)
            {
                case "zh-CN":
                    MultiLanguage.LoadCurrentFromLanguage("zh-CN");
                    break;
                case "en-US":
                    MultiLanguage.LoadCurrentFromLanguage("en-US");
                    //目前使用的遍历控件方式暂时不能刷新到Label标签，并且只有一个label有汉语，所以Label强刷
                    HideTheMainForm.Text =  "Hide The MainForm";
                    break;
                default:
                    MultiLanguage.LoadCurrentFromLanguage("zh-CN");
                    break;
            }
        }
    }
}
