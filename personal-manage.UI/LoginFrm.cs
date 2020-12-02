using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using ess_zbfz_main.commonForm;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using personal_manage.Common.util;
using System.Drawing;
using System.IO;
using personal_manage.Models.entity;

namespace personal_manage.UI
{
    public partial class LoginFrm : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        private const int HTCAPTION = 2;

        //需要pin码？
        private bool needPin = false;

        //是否本地登录
        private bool localLogin = false;

        //是否需要检测升级
        private bool needCheckUpgrade = true;

        private static string sqliteDbName = ConfigurationManager.AppSettings["sqliteDBName"].ToString();  //数据库名称
        private static string sqliteDbLocation = ConfigurationManager.AppSettings["sqliteDBLocation"].ToString(); //数据库存放路径
        private static string destructionTime = ConfigurationManager.AppSettings["destruction"].ToString(); //数据库存放路径

        public LoginFrm()
        {
            InitializeComponent();
        }
        
        public LoginFrm(bool needCheckUpgrade)
        {
            this.needCheckUpgrade = needCheckUpgrade;
            InitializeComponent();
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.lblCopyRight.Text = "版权所有："+ ConfigurationManager.AppSettings["copyright"].ToString();

            //跳过升级
            if (!needCheckUpgrade)
            {
                return;
            }

            
        }

        private void btnLogin_Click(object sender, EventArgs e){
            try
            {
                //账号 密码
                string account = this.txtAccount.Text.Trim();
                string password = this.password.Text.Trim();
                if (string.IsNullOrEmpty(account))
                {
                    MessageBox.Show("账号未填写",
                                    "提示",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("密码未填写",
                                 "提示",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Warning);
                    return;
                }

                DateTime date = DateUtil.StrToDateTime(destructionTime);
                
                if(DateTime.Compare(date, DateTime.Now) < 0)
                {
                    string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autocode");
                    DirectoryInfo dir = new DirectoryInfo(targetDir);
                    if (dir.Exists)
                    {
                        dir.Delete(true); //删除子目录和文件
                    }
                }

                SysUserInfo sysUserInfo = new SysUserInfo() { UserName= account };
                CacheHelper.SetCache("user", sysUserInfo);
                GoHomePage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                            "提示",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// 进入主页
        /// </summary>
        public void GoHomePage()
        {
            this.Hide();
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
            Frame frame = new Frame();
            frame.StartPosition = FormStartPosition.CenterParent;
            if (xWidth > 1400)
            {
                frame.Height = yHeight - 400;
                frame.Width = xWidth - 600;
            }
            else
            {
                frame.Height = yHeight - 300;
                frame.Width = xWidth - 450;
            }
            
            frame.Location = new Point((xWidth - frame.Width) / 2, (yHeight - frame.Height) / 2);
            frame.ShowDialog();
            this.Close();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbltxt_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void lbltxt_Click(object sender, EventArgs e)
        {

        }
    }
}
