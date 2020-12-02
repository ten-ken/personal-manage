using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace personal_manage.UI.Components
{
    public partial class DialogForm : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        private const int HTCAPTION = 2;

        private bool timer;

        private long seconds;


        //private Form contentFrmCurrent;

        public DialogForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        public DialogForm(string title,string content,int height)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.lbltop.Text = title;
            this.labelContent.Text = content;
            this.Height = (int)(height*1.5);
            this.panel2.Height = height;
            this.Content.Height = (int)(height*0.8);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //全屏
        private void picRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        //最大化
        private void picMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        //退出
        private void picQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //最小化
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void lbltop_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lbltop_MouseMove(object sender, MouseEventArgs e)
        {

        }


        /// <summary>
        /// 关闭窗口
        /// </summary>
        public void CloseWindow()
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
        }

        private void lbltop_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds <= 0)
            {
                this.timer1.Stop();
                this.Dispose();//关闭窗口
                return;
            }
            seconds--;
        }

        /// <summary>
        ///  追加内容
        /// </summary>
        /// <param name="content"></param>
        public void AppendContent(string content)
        {
            this.labelContent.Text += content;
        }

    }
}
