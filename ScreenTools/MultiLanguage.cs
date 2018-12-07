using System;
using System.Windows.Forms;

namespace ScreenTools
{
    class MultiLanguage
    {
        //当前默认语言
        public static string DefaultLanguage = Properties.Settings.Default.DefaultLanguage;

        /// <summary>
        /// 修改默认语言
        /// </summary>
        /// <param name="str"></param>
        public static void SetDefaultLanguage(String lang) {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            DefaultLanguage = lang;
            Properties.Settings.Default.DefaultLanguage = lang;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 加载语言
        /// </summary>
        /// <param name="form">加载语言的窗口</param>
        /// <param name="formType">窗口的类型</param>
        public static void LoadLanguage(Form form, Type formType) {
            if (form != null) {
                System.ComponentModel.ComponentResourceManager resourceManager = new System.ComponentModel.ComponentResourceManager(formType);
                resourceManager.ApplyResources(form, "$this");
                Loading(form, resourceManager);
            }
        }

        /// <summary>
        /// 加载语言
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="resourceManager">语言资源</param>
        public static void Loading(Control control, System.ComponentModel.ComponentResourceManager resourceManager) {
            foreach (Control c in control.Controls) {
                if (c is MenuStrip)
                {
                    //将资源与控件相对应
                    resourceManager.ApplyResources(c, c.Name);
                    MenuStrip menuStrip = (MenuStrip)c;
                    if (menuStrip.Items.Count > 0)
                    {
                        foreach (ToolStripMenuItem item in menuStrip.Items)
                        {
                            //遍历菜单
                            Loading(item, resourceManager);
                        }
                    }
                }

                if (c is ToolStrip)
                {
                    resourceManager.ApplyResources(c, c.Name);
                    foreach (ToolStripItem toolStripItem in ((ToolStrip)c).Items)
                    {
                        if (toolStripItem is ToolStripDropDownButton)
                        {
                            resourceManager.ApplyResources(toolStripItem, toolStripItem.Name);
                            var a = (toolStripItem as ToolStripDropDownButton).DropDownItems;
                            foreach (ToolStripDropDownItem tt in a)
                            {
                                Loading(tt, resourceManager);
                            }
                        }
                        else
                        {
                            resourceManager.ApplyResources(toolStripItem, toolStripItem.Name);
                        }
                    }
                    //Loading(toolStripItem, resourceManager);
                }
                

                resourceManager.ApplyResources(c, c.Name);
                Loading(c, resourceManager);
            }
        }

        /// <summary>
        /// 遍历菜单
        /// </summary>
        /// <param name="toolStripMenuItem"></param>
        /// <param name="resourceManager"></param>
        private static void Loading(ToolStripDropDownItem toolStripMenuItem, System.ComponentModel.ComponentResourceManager resourceManager) {
            if (toolStripMenuItem is ToolStripDropDownItem) {
                resourceManager.ApplyResources(toolStripMenuItem, toolStripMenuItem.Name);
                ToolStripMenuItem item1 = (ToolStripMenuItem)toolStripMenuItem;
                if (item1.DropDownItems.Count > 0) {
                    foreach (ToolStripMenuItem c in item1.DropDownItems) {
                        Loading(c, resourceManager);
                    }
                }
            }
        }

        /// <summary>
        /// 遍历菜单
        /// </summary>
        /// <param name = "toolStripMenuItem" ></ param >
        /// < param name="resourceManager"></param>
        private static void Loading(ToolStripMenuItem toolStripItem, System.ComponentModel.ComponentResourceManager resourceManager)
        {
            resourceManager.ApplyResources(toolStripItem, toolStripItem.Name);
            ToolStripMenuItem item1 = (ToolStripMenuItem)toolStripItem;
            if (item1.DropDownItems.Count > 0)
            {
                foreach (ToolStripMenuItem c in item1.DropDownItems)
                {
                    Loading(c, resourceManager);
                }
            }
        }

        /// <summary>
        /// 为所有窗体加载语言配置
        /// </summary>
        /// <param name="form"></param>
        public static void LoadAll(Form form)
        {
            if (form.Name == "MainWindow")
            {
                LoadLanguage(form, typeof(MainWindow));
            }
            else if (form.Name == "AudioRecordSettings")
            {
                LoadLanguage(form, typeof(AudioRecordSettings));
            }
            else if (form.Name == "ScreenShotSettings")
            {
                LoadLanguage(form, typeof(ScreenShotSettings));
            }
            else if (form.Name == "FileSelectorSettings")
            {
                LoadLanguage(form, typeof(FileSelectorSettings));
            }
        }

        public static void LoadCurrentFromLanguage(String LanguageClass) {
            SetDefaultLanguage(LanguageClass);
            //对所有打开的窗口重新加载语言
            foreach (Form form in Application.OpenForms)
            {
                LoadAll(form);
            }
        }
    }
}
