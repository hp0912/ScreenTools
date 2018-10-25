using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Captura.Models;

namespace ScreenTools
{
    public partial class AudioRecordSettings : Form
    {
        public AudioRecordSettings(AudioSource source, string path)
        {
            InitializeComponent();

            this.AudioRecorderFilePath.Text = path;
            this.AudioFolderBrowserDialog.SelectedPath = path;
            
            this.AudioSource = source;
            this.SoundRecorderPath = path;

            this.RefreshDevice(false);
        }

        public string SoundRecorderPath { get; set; }
        public AudioSource AudioSource { get; set; }
        public int AudioDeviceCount { get; set; }

        private void CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb.Checked)
            {
                (cb.Tag as IAudioItem).Active = true;
                this.AudioDeviceCount++;
            }
            else
            {
                (cb.Tag as IAudioItem).Active = false;
                this.AudioDeviceCount--;
            }
        }

        private void browser_Click(object sender, EventArgs e)
        {
            if (AudioFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.SoundRecorderPath = this.AudioFolderBrowserDialog.SelectedPath;
                this.AudioRecorderFilePath.Text = this.SoundRecorderPath;
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

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.RefreshDevice(true);
        }

        private void RefreshDevice(bool refresh)
        {
            this.SoundcardPanel.Controls.Clear();
            this.MicrophonePanel.Controls.Clear();

            if (refresh)
            {
                this.AudioSource.Refresh();
                this.AudioDeviceCount = 0;
            }

            var data1 = this.AudioSource.AvailableLoopbackSources;
            if (data1.Count > 0)
            {
                for (int i = 0, len = data1.Count; i < len; i++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = data1[i].Name;
                    cb.Checked = data1[i].Active;
                    if (data1[i].Active) this.AudioDeviceCount++;
                    cb.Width = 300;
                    cb.Tag = data1[i];
                    cb.CheckedChanged += CheckedChanged;
                    this.SoundcardPanel.Controls.Add(cb);
                }
            }

            var data2 = this.AudioSource.AvailableRecordingSources;
            if (data2.Count > 0)
            {
                for (int i = 0, len = data2.Count; i < len; i++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = data2[i].Name;
                    cb.Checked = data2[i].Active;
                    if (data2[i].Active) this.AudioDeviceCount++;
                    cb.Width = 300;
                    cb.Tag = data2[i];
                    cb.CheckedChanged += CheckedChanged;
                    this.MicrophonePanel.Controls.Add(cb);
                }
            }
        }
    }
}
