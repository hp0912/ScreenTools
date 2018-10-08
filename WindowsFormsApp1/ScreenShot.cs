using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ScreenTools
{
    /// <summary>
    /// 截屏控制参数
    /// </summary>
    class ScreenParam
    {
        public int x = 0, y = 0, width = -1, height = -1;   // 截取区域，当前设置值会替换为全屏
        public String savePath = "";                        // 截屏图像保存完整路径
        public bool haveCursor = true;                      // 是否包含鼠标
        public int delay_ms = 0;                            // 延时ms

        public bool programExit = false;    // 标识截屏完成后是否退出

        /// <summary>
        /// 截屏控制参数
        /// </summary>
        public ScreenParam(int x = 0, int y = 0, int width = -1, int height = -1, String savePath = "", bool haveCursor = true, int delay_ms = 0)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.savePath = savePath;
            this.haveCursor = haveCursor;
            this.delay_ms = delay_ms;
        }
    }

    class ScreenShot
    {
        # region 图像处理功能函数

        /// <summary>
        /// 按指定尺寸对图像pic进行非拉伸缩放
        /// </summary>
        public static Bitmap shrinkTo(Image pic, Size S, Boolean cutting)
        {
            //创建图像
            Bitmap tmp = new Bitmap(S.Width, S.Height);     //按指定大小创建位图

            //绘制
            Graphics g = Graphics.FromImage(tmp);           //从位图创建Graphics对象
            g.Clear(Color.FromArgb(0, 0, 0, 0));            //清空

            Boolean mode = (float)pic.Width / S.Width > (float)pic.Height / S.Height;   //zoom缩放
            if (cutting) mode = !mode;                      //裁切缩放

            //计算Zoom绘制区域             
            if (mode)
                S.Height = (int)((float)pic.Height * S.Width / pic.Width);
            else
                S.Width = (int)((float)pic.Width * S.Height / pic.Height);
            Point P = new Point((tmp.Width - S.Width) / 2, (tmp.Height - S.Height) / 2);

            g.DrawImage(pic, new Rectangle(P, S));

            return tmp;     //返回构建的新图像
        }


        //保存图像pic到文件fileName中，指定图像保存格式
        public static void SaveToFile(Image pic, string fileName, bool replace, ImageFormat format)    //ImageFormat.Jpeg
        {
            // 创建保存目录
            confirmDir(fileName);

            //若图像已存在，则删除
            if (System.IO.File.Exists(fileName) && replace)
                System.IO.File.Delete(fileName);

            //若不存在则创建
            if (!System.IO.File.Exists(fileName))
            {
                if (format == null) format = getFormat(fileName);   //根据拓展名获取图像的对应存储类型

                if (format == ImageFormat.MemoryBmp) pic.Save(fileName);
                else pic.Save(fileName, format);                    //按给定格式保存图像
            }
        }

        //根据文件拓展名，获取对应的存储类型
        public static ImageFormat getFormat(string filePath)
        {
            ImageFormat format = ImageFormat.MemoryBmp;
            String Ext = System.IO.Path.GetExtension(filePath).ToLower();

            if (Ext.Equals(".png")) format = ImageFormat.Png;
            else if (Ext.Equals(".jpg") || Ext.Equals(".jpeg")) format = ImageFormat.Jpeg;
            else if (Ext.Equals(".bmp")) format = ImageFormat.Bmp;
            else if (Ext.Equals(".gif")) format = ImageFormat.Gif;
            else if (Ext.Equals(".ico")) format = ImageFormat.Icon;
            else if (Ext.Equals(".emf")) format = ImageFormat.Emf;
            else if (Ext.Equals(".exif")) format = ImageFormat.Exif;
            else if (Ext.Equals(".tiff")) format = ImageFormat.Tiff;
            else if (Ext.Equals(".wmf")) format = ImageFormat.Wmf;
            else if (Ext.Equals(".memorybmp")) format = ImageFormat.MemoryBmp;

            return format;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        private const Int32 CURSOR_SHOWING = 0x00000001;
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        private static ScreenParam paramI = null;
        /// <summary>
        /// 延时截屏处理逻辑
        /// </summary>
        private static void ScreenShot_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop(); // 停止计时
            getScreen(paramI);       // 执行截屏
            paramI = null;
        }

        /// <summary>
        /// 根据param中的参数控制截屏
        /// </summary>
        public static void getScreen(ScreenParam param)
        {
            if (param == null) return;

            if (param.delay_ms > 0)
            {
                Timer timer = new Timer();
                timer.Interval = param.delay_ms;
                timer.Tick += ScreenShot_Tick;

                paramI = param;
                paramI.delay_ms = 0;

                timer.Enabled = true;
            }
            else getScreen(param.x, param.y, param.width, param.height, param.savePath, param.haveCursor, param.delay_ms, param.programExit);
        }

        /// <summary>
        /// 截取屏幕指定区域为Image，保存到路径savePath下，haveCursor是否包含鼠标
        /// </summary>
        public static Image getScreen(int x = 0, int y = 0, int width = -1, int height = -1, String savePath = "", bool haveCursor = true, int delay_ms = 0, bool exit = false)
        {
            // 延时截屏时无返回值
            if (delay_ms > 0)
            {
                getScreen(new ScreenParam(x, y, width, height, savePath, haveCursor, delay_ms));
                return null;
            }

            if (width == -1) width = SystemInformation.VirtualScreen.Width;
            if (height == -1) height = SystemInformation.VirtualScreen.Height;

            Bitmap tmp = new Bitmap(width, height);                 //按指定大小创建位图
            Graphics g = Graphics.FromImage(tmp);                   //从位图创建Graphics对象
            g.CopyFromScreen(x, y, 0, 0, new Size(width, height));  //绘制

            // 绘制鼠标
            if (haveCursor)
            {
                try
                {
                    CURSORINFO pci;
                    pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                    GetCursorInfo(out pci);
                    System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(pci.hCursor);
                    cur.Draw(g, new Rectangle(pci.ptScreenPos.x, pci.ptScreenPos.y, cur.Size.Width, cur.Size.Height));
                }
                catch (Exception ex) { }            // 若获取鼠标异常则不显示
            }

            if (savePath.Equals("")) savePath = JpgTmpPath();                   // 设置默认保存路径
            //Size halfSize = new Size((int)(tmp.Size.Width * 0.8), (int)(tmp.Size.Height * 0.8));  // 按一半尺寸存储图像
            if (!savePath.Equals("")) saveImage(tmp, tmp.Size, savePath);       // 保存到指定的路径下

            if (exit) System.Environment.Exit(0);   // 退出当前应用程序
            return tmp;     //返回构建的新图像
        }

        /// <summary>
        /// 缩放icon为指定的尺寸，并保存到路径PathName
        /// </summary>
        public static void saveImage(Image image, Size size, String PathName)
        {
            Image tmp = shrinkTo(image, size, false);
            SaveToFile(tmp, PathName, true, null);
        }


        // 生成jpg的临时保存路径
        public static String JpgTmpPath()
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss");
            string screenDir = System.AppDomain.CurrentDomain.BaseDirectory + @"screens";  // 截屏保存路径
            String pathName = screenDir + @"\" + dateTime + ".png";

            return pathName;
        }

        /// <summary>
        /// 检测目录是否存在，若不存在则创建
        /// </summary>
        public static void confirmDir(string path)
        {
            String rootDir = System.IO.Path.GetDirectoryName(path);             //获取path所在的目录
            if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir); //若目录不存在则创建
        }

        # endregion

    }
}
