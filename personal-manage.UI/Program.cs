using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniBlinkPinvoke;
using personal_manage.Common.util;
using personal_manage.UI.CsharpAuto;
using personal_manage.UI.Mytools;
using WindowsTest;


namespace personal_manage.UI
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
            BlinkBrowserPInvoke.ResourceAssemblys.Add("个人管理", System.Reflection.Assembly.GetExecutingAssembly());
            Application.Run(new LoginFrm());
        }

        /* /// <summary>
        /// 检测并更新
        /// </summary>
        public static void CheckUpdate()
        {
            //主程序在调用 
            Process[] appProcess = Process.GetProcessesByName(Application.ProductName);
            if (appProcess.Length > 1)//防止多次点击exe
            {
                return;
            }

            //升级程序在调用
            Process[] updateProcess = Process.GetProcessesByName("personal_manage.Upgrade");
            if (updateProcess.Length > 0)
            {
                return;
            }

            R back = AutoUpdateUtils.CheckUpdate();
            //需要更新
            if (back.Successful)
            {
                foreach (Process prc in appProcess)
                {
                    //启动 调用更新程序
                    string updateExe = $@"{AppDomain.CurrentDomain.BaseDirectory}personal_manage.Upgrade.exe";
                    if (File.Exists(updateExe))
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = updateExe;
                        info.Arguments = "";
                        info.WindowStyle = ProcessWindowStyle.Minimized;
                        Process.Start(info);
                    }
                    prc.Kill();
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginFrm());
            }
        }*/
    }
}
