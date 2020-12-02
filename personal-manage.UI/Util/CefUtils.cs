/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using personal_manage.Common.util;

namespace personal_manage.UI.Util
{
    public class CefUtils
    {

        private static ChromiumWebBrowser chromeBrowser = null;
        /// <summary>
        /// 单例
        /// </summary>
        private static CefUtils instance = null;
        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns>实例</returns>
        public static CefUtils Instance()
        {
            if (instance == null)
            {
                instance = new CefUtils();
            }
            return instance;
        }
        public ChromiumWebBrowser GetWebBrow(string path)
        {
            try
            {
                chromeBrowser = GetWebBrowser(path);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
                //LogUtil.Error(ex);
            }
            return chromeBrowser;
        }
        /// <summary>
        /// 设置WebBrowser属性
        /// </summary>
        /// <returns></returns>
        private ChromiumWebBrowser GetWebBrowser(string path)
        {
            CefSettings settings = CefSets();
            if (!Cef.IsInitialized && !Cef.Initialize(settings))
            {
                throw new InvalidOperationException("Cef::Initialize() failed");
            }
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser(path);
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;
            return chromeBrowser;
        }
        /// <summary>
        /// 设置浏览器属性
        /// </summary>
        /// <returns></returns>
        private static CefSettings CefSets()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("MultiThreadedMessageLoop", "false");
            settings.CefCommandLineArgs.Add("LogFile", GetPath("CefGlue.log"));
            settings.CefCommandLineArgs.Add("Locale", "zh_CN");
            settings.CefCommandLineArgs.Add("LocalesDirPath", GetPath("locales"));
            settings.CefCommandLineArgs.Add("WindowlessRenderingEnabled", "true");
            //缓存路径
            settings.CachePath = GetPath("BrowserCache");
            //执行加载插件命令
            settings.CefCommandLineArgs.Add("debug-plugin-loading", "1");
            settings.CefCommandLineArgs.Add("allow-outdated-plugins", "1");
            settings.CefCommandLineArgs.Add("always-authorize-plugins", "1");
            settings.CefCommandLineArgs.Add("disable-web-security", "1");
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            settings.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";//浏览器内核
            settings.Locale = "zh-CN";
            return settings;

        }
        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string GetPath(string v)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, v));
        }
    }
}
*/