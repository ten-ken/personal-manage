using MiniBlinkPinvoke;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace personal_manage.UI
{

    public partial class WebBrowserForm : Form
    {
        private int removeInd = -1;


        public WebBrowserForm()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (removeInd<0)
            {
                ChangeTab(0);
                removeInd = -1;
            }
            else
            {
                removeInd = -1;
            }
           
        }

        /// <summary>
        /// 切换页
        /// </summary>
        /// <param name="type">0 ，切换选项卡 1 跳转地址</param>
        private void ChangeTab(int type)
        {
            var tab = tabControl1.SelectedTab;

            if (tab != null && tab.Controls.Count != 0)
            {
                var browser = tab.Controls[0] as BlinkBrowser;
                if (browser != null)
                {
                    if (type == 0)
                    {
                        textBox1.Text = browser.Url;
                    }
                    else if (type == 1)
                    {
                        browser.Url = textBox1.Text;
                    }
                }
            }
        }

        private IntPtr BlinkBrowser1_OnCreateViewEvent(IntPtr webView, IntPtr param, MiniBlinkPinvoke.wkeNavigationType navigationType, string url)
        {
            return CreateNewTab().handle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeTab(1);
        }

        private void TabForm_Load(object sender, EventArgs e)
        {
            this.Show();
            List<ComboBoxVo> lists = GetTuijian();
            this.ComboBoxTuijian.DataSource = lists;
            this.ComboBoxTuijian.DisplayMember = "keyName";
            this.ComboBoxTuijian.ValueMember = "keyValue";
            tabControl1.MouseClick -= TabControl_MouseClick;
            tabControl1.MouseClick += TabControl_MouseClick;
            BlinkBrowser browser = CreateNewTab();
            browser.Url = textBox1.Text;
        }

        private BlinkBrowser CreateNewTab()
        {
            var tabPage = new TabPage() { Text = "" };
            string _title = "空白页";
            MiniBlinkPinvoke.BlinkBrowser browser = new MiniBlinkPinvoke.BlinkBrowser();
            tabPage.Controls.Add(browser);
            browser.OnCreateViewEvent += BlinkBrowser1_OnCreateViewEvent;

            browser.OnTitleChangeCall += (title) =>
            {
                tabPage.Invoke((EventHandler)delegate
                {
                    _title = title ?? "空白页";
                    tabPage.Text = title??"空白页";
                });
            };
            browser.OnUrlChange2Call += (nowUrl) =>
            {
                tabPage.Invoke((EventHandler)delegate
                {
                    if (tabControl1.SelectedTab == tabPage)
                    {
                        textBox1.Invoke((EventHandler)delegate
                        {
                            textBox1.Text = nowUrl;
                        });
                    }
                });
            };
            browser.Dock = DockStyle.Fill;
            tabPage.Text = _title;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            return browser;
        }

        private void TabControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    removeInd = this.tabControl1.SelectedIndex;
                    contextMenuStrip1.Show(this.tabControl1.TabPages[removeInd],new Point(e.X/2, e.Y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 关闭右侧标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = tabControl1.TabPages.Count;
            List<TabPage> lists = new List<TabPage>();
            for (int i = 0; i < count; i++)
            {
                if (removeInd < i)
                {
                    lists.Add(tabControl1.TabPages[i]);
                }
            }

            for (int k = 0; k< lists.Count;k++)
            {
                tabControl1.TabPages.Remove(lists[k]);
            }

            removeInd = -1;
            if (tabControl1.TabPages.Count <= 0)
            {
                CreateNewTab();
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(removeInd);
            removeInd = -1;
            if (tabControl1.TabPages.Count <= 0)
            {
                CreateNewTab();
            }
        }

        //打开开发者工具
        private void ButtonDevTool_Click(object sender, EventArgs e)
        {
            var blinkBrowser1 = (BlinkBrowser)tabControl1.SelectedTab.Controls[0];
            blinkBrowser1.ShowDevtools(Application.StartupPath + @"\front_end\inspector.html");
        }

        //截图
        private void ButtonSubstrImg_Click(object sender, EventArgs e)
        {
            var blinkBrowser1 = (BlinkBrowser)tabControl1.SelectedTab.Controls[0];
            IntPtr mainFrameId = BlinkBrowserPInvoke.wkeWebFrameGetMainFrame(blinkBrowser1.handle);
            int width = BlinkBrowserPInvoke.wkeGetContentWidth(blinkBrowser1.handle);
            int height = BlinkBrowserPInvoke.wkeGetContentHeight(blinkBrowser1.handle);
            wkeScreenshotSettings settings = new wkeScreenshotSettings
            {
                height = height,
                width = width
            };
            settings.structSize = System.Runtime.InteropServices.Marshal.SizeOf(settings);
            var bf = BlinkBrowserPInvoke.wkePrintToBitmap(blinkBrowser1.handle, mainFrameId, settings);
            if (bf != IntPtr.Zero)
            {

                var data = (wkeMemBuf)Marshal.PtrToStructure(bf, typeof(wkeMemBuf));
                if (data.data != IntPtr.Zero && data.length != 0)
                {
                    byte[] ys = new byte[data.length];
                    Marshal.Copy(data.data, ys, 0, ys.Length);

                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = Path.Combine(folderBrowser.SelectedPath, Guid.NewGuid().ToString("n") + ".bmp");
                        File.WriteAllBytes(fileName, ys);
                        MessageBox.Show("截图保存成功，图片地址为：" + fileName);
                    }

                   
                }
                else
                {
                    MessageBox.Show("截图失败，数据解析失败。");
                }
            }
            else
            {
                MessageBox.Show("截图失败，返回空。");
            }
        }


        private List<ComboBoxVo> GetTuijian()
        {
            List<ComboBoxVo> list = new List<ComboBoxVo>();
            ComboBoxVo comboBoxVo0 = new ComboBoxVo("合工大-考试专用", "http://cdn.webjyh.com/hfut/");
            //this.RecommendWebs.Items.Add(comboBoxVo0);
            list.Add(comboBoxVo0);

            ComboBoxVo comboBoxVo1 = new ComboBoxVo("作者--掘金网址", "https://juejin.cn/user/3940246036173485");
            //this.RecommendWebs.Items.Add(comboBoxVo1);
            list.Add(comboBoxVo1);


            ComboBoxVo comboBoxVo2 = new ComboBoxVo("作者--CSDN网址", "https://blog.csdn.net/jikuicui7402");
            //this.RecommendWebs.Items.Add(comboBoxVo2);
            list.Add(comboBoxVo2);


            ComboBoxVo comboBoxVo3 = new ComboBoxVo("b站", "https://www.bilibili.com/");
            //this.RecommendWebs.Items.Add(comboBoxVo3);
            list.Add(comboBoxVo3);


            ComboBoxVo comboBoxVo4 = new ComboBoxVo("spring-cloud从入门到精通", "http://blog.didispace.com/spring-cloud-learning/");
            //this.RecommendWebs.Items.Add(comboBoxVo4);
            list.Add(comboBoxVo4);


            ComboBoxVo comboBoxVo5 = new ComboBoxVo("语雀", "https://www.yuque.com/");
            //this.RecommendWebs.Items.Add(comboBoxVo5);
            list.Add(comboBoxVo5);

            return list;
        }

        private void ComboBoxTuijian_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string url = ((ComboBoxVo)this.ComboBoxTuijian.SelectedItem).KeyValue ?? "https://www.baidu.com";
                this.textBox1.Text = url;
                this.buttonSkip.Focus();
                ChangeTab(1);
                // this.webBrowser1.Navigate(((ComboBoxVo)this.RecommendWebs.SelectedItem).KeyValue ?? "https://www.baidu.com");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }
    }
}
