using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using personal_manage.Common.util;
using personal_manage.Models.entity;
using personal_manage.UI.Mytools;

namespace personal_manage.UI
{

    public partial class Frame : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        private const int HTCAPTION = 2;


        private Form contentFrmCurrent;

        float xvalues;
        float yvalues;


        public Frame()
        {
            InitializeComponent();
        }

        private void TreeView1_Click(object sender, EventArgs e)
        {

        }

        private void TreeView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void Frame_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            //this.MaximizeBox = false;//使最大化窗口失效

            xvalues = this.Width;//记录窗体初始大小
            yvalues = this.Height;
            SysUserInfo sysUser = (SysUserInfo)CacheHelper.GetCache("user");
            this.toolStripStatusSupplier.Text = "当前登录用户:" + sysUser.UserName;
            this.toolStripStatusCopyRight.Text = "版权所有：" + ConfigurationManager.AppSettings["copyright"].ToString();
            this.toolStripStatusVersion.Text = "版本号：" + ConfigurationManager.AppSettings["version"].ToString();

            this.Enabled = true;

            this.codeToolStripMenuItem.BackColor = Color.LightBlue;
            contentFrmCurrent = new CodeProjectList();
            this.Text = "代码生成器";
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }



        private void zxtbStripMenuItem_Click(object sender, EventArgs e)
        {
            contentFrmCurrent = new FormDemoList();
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }


        /// <summary>
        ///  退出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //如有子页面全部关闭
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                {
                    myForm.Close();
                }
            }
            CacheHelper.RemoveAllCache();
            this.Dispose();
            DialogUtil.Show(new LoginFrm(false));
            //Application.Exit();
        }

        private void Frame_Resize(object sender, EventArgs e)
        {
            if (contentFrmCurrent != null)
            {
                DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null, true);
                //DialogUtil.ShowTabContent(contentFrmCurrent)
                //ToShowRightFrm(contentFrmCurrent);
            }
        }


        private void lbltop_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void picQuit_Click(object sender, EventArgs e)
        {
            //如有子页面全部关闭
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                {
                    myForm.Close();
                }
            }
            this.Dispose();
            DialogUtil.Show(new LoginFrm(false));
            //Application.Exit();
        }

        private void lbltop_Click(object sender, EventArgs e)
        {

        }

        private void picRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }



        private void menuHome_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SetItemBgColor(sender);
        }

        private void zxtbStripMenuItem_Click_1(object sender, EventArgs e)
        {
            contentFrmCurrent = new FormDemoList();
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentFrmCurrent = new FormDemoChart();
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void personCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SetItemBgColor(sender);
            contentFrmCurrent = new CodeProjectList();
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }

        /// <summary>
        ///  设置选择item的背景色
        /// </summary>
        /// <param name="sender"></param>
        private void SetItemBgColor(object sender)
        {
            try
            {
                //ToolStripMenuItem current = (ToolStripMenuItem)sender;               
                ToolStripItemCollection items = this.menuHome.Items;
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].BackColor = Color.White;
                    if (items[i].Selected)
                    {
                        this.Text = items[i].Text;
                        items[i].BackColor = Color.LightBlue;
                    }
                   /* if (current.Name == items[i].Name)
                    {
                        items[i].BackColor = Color.LightBlue;
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void toolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //contentFrmCurrent = new WebBrowserFrm();
            //contentFrmCurrent = new BrowserForm();
            contentFrmCurrent = new FormTools();
            DialogUtil.ShowTabContent(this.splitContainer1.Panel2, contentFrmCurrent, null);
        }

       
    }
}
