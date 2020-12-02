/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.UI.Util;

namespace personal_manage.UI.WebBrowser
{
    public partial class WebBrowserFrm : Form
    {
        //页面文件后缀名
        private static string tuijian = ConfigurationManager.AppSettings["recommends"].ToString();

        ChromiumWebBrowser webview;

        List<ComboBoxVo> tuijianLists;

        public WebBrowserFrm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                webview.Load(string.IsNullOrEmpty(this.WebLink.Text) ? "https://www.baidu.com": this.WebLink.Text);
                //this.webBrowser1.Navigate(this.RecommendWebs.Text ?? "https://www.baidu.com");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void RecommendWebs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string url = ((ComboBoxVo)this.RecommendWebs.SelectedItem).KeyValue ?? "https://www.baidu.com";
                webview.Load(url);
                this.WebLink.Text = url;
                // this.webBrowser1.Navigate(((ComboBoxVo)this.RecommendWebs.SelectedItem).KeyValue ?? "https://www.baidu.com");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void WebBrowserFrm_Load(object sender, EventArgs e)
        {
            try
            {
                this.panel2.Controls.Clear();
                webview = new ChromiumWebBrowser("https://www.baidu.com/");
                webview.Dock = DockStyle.Fill;
                this.panel2.Controls.Add(webview);

                *//*  //实例化控件
                  ChromiumWebBrowser wb = CefUtils.Instance().GetWebBrow("https://www.baidu.com/");
                  //设置停靠方式
                  wb.Dock = DockStyle.Fill;

                  //加入到当前窗体中
                  this.panel2.Controls.Add(wb);*//*

                tuijian = tuijian ?? "";

                this.RecommendWebs.DisplayMember = "keyName";
                this.RecommendWebs.ValueMember = "keyValue";


                tuijianLists = GetTuijian();
                this.RecommendWebs.DataSource = tuijianLists;
                this.timer1.Interval = 2000;
                this.timer1.Tick += SkipLink;
                this.timer1.Start();
                
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
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

        /// <summary>
        ///  默认跳转第一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipLink(object sender, EventArgs e)
        {
            if(tuijianLists != null && tuijianLists.Count > 0)
            {
               this.RecommendWebs.Text = tuijianLists[0].KeyName;
               webview.Load(tuijianLists[0].KeyValue);
               this.WebLink.Text = tuijianLists[0].KeyValue;
            }
            this.timer1.Stop();
        }
    }
}
*/