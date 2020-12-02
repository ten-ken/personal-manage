using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Upgrade;

namespace updated_version
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] appProcess = Process.GetProcessesByName("online_bid_autoUpdate");
            if (appProcess.Length > 1)//防止多个线程运行
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoUpdateFrm());
        }
    }
}
