using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
//using SharpAvi.Codecs;

namespace ScreenTools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set LAME DLL path for MP3 encoder
            var asmDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
#if FX45
            var is64BitProcess = Environment.Is64BitProcess;
#else
            var is64BitProcess = IntPtr.Size * 8 == 64;
#endif
            //var dllName = string.Format("lameenc{0}.dll", is64BitProcess ? "64" : "32");
            //Mp3AudioEncoderLame.SetLameDllLocation(Path.Combine(asmDir, dllName));

            Application.Run(new MainWindow());
        }
    }
}
