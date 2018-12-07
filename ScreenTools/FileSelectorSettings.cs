using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ScreenTools
{
    public partial class FileSelectorSettings : Form
    {
        public FileSelectorSettings(string path)
        {
            InitializeComponent();

            SelectedFilePath.Text = path;
            this.FileSelectorBrowserDialog.FileName = path;
            this.FileSelectorBrowserDialog.Filter = "*|*.exe";   // 加入限制条件，只能选择后缀为.exe的文件
            this.FileSelectorBrowserDialog.RestoreDirectory = true; // 自动保存选择的路径

            this.FileSelectorPath = path;
        }

        public string FileSelectorPath { get; set; }

        private void Confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Process process = null;
            String excutePath = SelectedFilePath.Text;
            if (File.Exists(excutePath))
            {
                process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(excutePath);
                startInfo.UseShellExecute = false; //不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false; //不重定向输入
                startInfo.RedirectStandardOutput = true; //重定向输出
                //process.StartInfo = startInfo;
                process.StartInfo.FileName = Path.GetFullPath(excutePath);
                process.Start();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please check path：" + excutePath);
            }

            /*DialogResult = DialogResult.OK;

            OpenFileDialog file = new OpenFileDialog(); //打开文件选择对话框
            file.Filter = "*|*.exe";   // 加入限制条件，只能选择后缀为.exe的文件
            file.RestoreDirectory = true;
            file.ShowDialog();

            //if (FileFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    process = new Process();
            //    process.StartInfo.FileName = Path.GetFullPath(file.FileName);
            //    process.Start(); // 启动选择的exe文件
            //}

            if (this.SelectedFilePath.Text != "")
            {
                process = new Process();
                process.StartInfo.FileName = Path.GetFullPath(this.SelectedFilePath.Text);
                process.Start(); // 启动选择的exe文件
            }*/
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 点击浏览文件夹目录, 并选择要运行的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browse_Click(object sender, EventArgs e)
        {
            if (FileSelectorBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.FileSelectorPath = Path.GetFullPath(this.FileSelectorBrowserDialog.FileName);
                this.SelectedFilePath.Text = this.FileSelectorPath;
            }
        }
        
        private void FileSelectorSettings_Load(object sender, EventArgs e)
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
                    break;
                default:
                    MultiLanguage.LoadCurrentFromLanguage("zh-CN");
                    break;
            }
        }
    }
}
