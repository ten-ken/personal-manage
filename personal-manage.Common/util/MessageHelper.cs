using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.Common.util
{
    public class MessageHelper
    {
        /// <summary>
        ///  错误
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowError(Exception ex)
        {
            ShowError(ex, "");
        }

        /// <summary>
        ///  错误
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowError(Exception ex,string prefix)
        {
            MessageBox.Show(prefix+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowSuccess(string title, string msg)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowSuccess(string msg)
        {
            ShowSuccess("提示", msg);
        }


        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowWarn(string title, string msg)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowWarn(string msg)
        {
            ShowWarn("提示", msg);
        }

    }
}
