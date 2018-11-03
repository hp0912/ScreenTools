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
        public FileSelectorSettings()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            //if(1 == 1) // 若是第一次打开
            //{

            //}
            //else // 若不是第一次打开
            //{
            //    if(1 == 1) // 上一次保存的目录路径下的文件无法执行，则需要重新选择目录
            //    {

            //    }
            //    else // 若可以执行则直接执行
            //    {

            //    }
            //}

            OpenFileDialog file = new OpenFileDialog(); //打开文件选择对话框
            file.Filter = "*|*.exe";   // 加入限制条件，只能选择后缀为.exe的文件
            file.RestoreDirectory = true;
            file.ShowDialog();
            //this.SelectedFilePath.Text = file.SafeFileName;
            Process process = null;

            //if (FileFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    process = new Process();
            //    process.StartInfo.FileName = Path.GetFullPath(file.FileName);
            //    process.Start(); // 启动选择的exe文件
            //}
            process = new Process();
            if(file.FileName != "")
            {
                process.StartInfo.FileName = Path.GetFullPath(file.FileName);
                process.Start(); // 启动选择的exe文件
            }
        }

        private void SelectedFilePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
