using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.util;

namespace personal_manage.UI.Mytools
{
    public partial class FormTools : Form
    {

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public FormTools()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 外部应用点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOut_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SetItemBgColor(sender);
        }

        /// <summary>
        /// 内部应用点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuInner_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SetItemBgColor(sender);
        }


        /// <summary>
        ///  设置选择item的背景色
        /// </summary>
        /// <param name="sender"></param>
        private void SetItemBgColor(object sender)
        {
            try
            {
                MenuStrip menuStrip = (MenuStrip)sender;
                ToolStripItemCollection items = menuStrip.Items;
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].BackColor = Color.WhiteSmoke;
                    if (items[i].Selected)
                    {
                        items[i].BackColor = Color.LightBlue;
                        //点击事件
                        ClickItemEventFunc(items[i], menuStrip);
                        /*if(items[i].BackColor != Color.LightBlue)
                        {
                            //this.Text = items[i].Text;
                            items[i].BackColor = Color.LightBlue;
                            //点击事件
                            ClickItemEventFunc(items[i]);
                        }
                        else
                        {
                            //this.Text = items[i].Text;
                            items[i].BackColor = Color.White;
                        }*/
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 图标工具点击事件
        /// </summary>
        /// <param name="toolStripItem"></param>
        private void ClickItemEventFunc(ToolStripItem toolStripItem, MenuStrip menuStrip)
        {
            try
            {
                Form form;

                MenuStrip menu = new MenuStrip();
                if ("menuOut" == menuStrip.Name)
                {
                    menu = this.menuInner;
                }
                else if ("menuInner" == menuStrip.Name)
                {
                    menu = this.menuOut;
                }
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    menu.Items[i].BackColor = Color.WhiteSmoke;
                }
                if (toolStripItem.Name == "outBrowerMenuItem")
                {
                    //调用系统默认的浏览器
                    Process.Start("https://www.baidu.com/");
                    /*Process[] appProcess = Process.GetProcessesByName("MiniBlinkPinvokeDemo");
                    foreach (Process prc in appProcess)
                    {
                        prc.Kill();
                    }
                    string updateExe = $@"{AppDomain.CurrentDomain.BaseDirectory}tools\MiniBlinkPinvokeDemo.exe";
                    if (File.Exists(updateExe))
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = updateExe;
                        if (p.Start())
                        {
                            ((Form)this.TopLevelControl).WindowState = FormWindowState.Minimized;
                            SetForegroundWindow(p.MainWindowHandle);
                        }
                    }*/
                }
                else if (toolStripItem.Name == "innerBrowerMenuItem")
                {
                    form = new WebBrowserForm();
                    DialogUtil.ShowDialog(form, this, form.Width, form.Height, new Common.prop.FormWindowProp(true, false, FormBorderStyle.FixedDialog));
                }
                else if (toolStripItem.Name == "AccoutEncStripMenuItem")//账号管理
                {
                    form = new AccoutEncFrmList();
                    DialogUtil.ShowDialog(form, this, form.Width, form.Height, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
                }else if (toolStripItem.Name == "FileEncStripMenuItem")//文件加解密
                {
                    form = new FormCrypt();
                    DialogUtil.ShowDialog(form, this, form.Width, form.Height, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void FormTools_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zxtbStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
