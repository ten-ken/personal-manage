using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MyWfControls.dto;

namespace MyWfControls
{
    public delegate void LoadPageData();

    //{ get; set; }
    public partial class KenPage : UserControl
    {

        public PageInfo pageInfo =new PageInfo() { CurrentCount=300, TotalPage=10 };


        public LoadPageData loadPageData;

        /// <summary>
        /// 页下拉
        /// </summary>
        private int[] pageSizes = new int[] {10,20,50,100};


        public KenPage()
        {
            InitializeComponent();
            //隐藏toolscrip左侧的点
            this.KenToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            SetPageSizeTool(pageSizes);
        }


        /// <summary>
        /// 键盘按键【回车键】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(sender is TextBox || sender is ToolStripTextBox))
                {
                    return;
                }
                ToolStripTextBox currentBox = (ToolStripTextBox)sender;

                int start = currentBox.SelectionStart;
                int len = currentBox.SelectionLength;

                string text = "";

                //过滤的输入键
                if (!"\r".Equals(e.KeyChar.ToString()))
                {
                    if (len > 0)
                    {
                        text = currentBox.Text.Substring(0, start) + e.KeyChar.ToString() + currentBox.Text.Substring(start + len - 1, currentBox.Text.Length - start - len);
                    }
                    else
                    {
                        text = currentBox.Text + e.KeyChar.ToString();
                    }
                }
                else
                {
                    text = currentBox.Text;
                }


                string pattern = @"^([1-9]\d{0,12})?$";

                //删除键
                if ("\b".Equals(e.KeyChar.ToString()) || "\t".Equals(e.KeyChar.ToString()))
                {
                    return;
                }
                //回车键
                if ("\r".Equals(e.KeyChar.ToString()))
                {


                    if (string.IsNullOrEmpty(text))
                    {
                        pageInfo.CurrentPage = 1;
                        this.currentPage.Text = pageInfo.CurrentPage.ToString();
                    }
                    else
                    {
                        pageInfo.CurrentPage = Convert.ToInt32(text);
                        this.currentPage.Text = pageInfo.CurrentPage.ToString();
                        /*int addWidth = text.Length > 8 ? 3 : 0;
                        this.currentPage.Width=50+(text.Length - 8) * addWidth;*/
                    }

                    if (loadPageData != null)
                    {
                        loadPageData.Invoke();
                    }
                    return;
                }
                if (!Regex.IsMatch(text, pattern))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// 分页工具点击事件 上一页 下一页 首页 末尾点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(sender is ToolStripButton))
                {
                    return;
                }
                ToolStripButton sendButton = (ToolStripButton)sender;
                string tag = sendButton.Tag != null ? sendButton.Tag.ToString() : "";

                if ("page-reload" == tag)
                {
                    if (loadPageData != null)
                    {
                        loadPageData.Invoke();
                    }
                    return;
                }

                switch (tag)
                {
                    case "page-first":
                        pageInfo.CurrentPage = 1;
                        break;
                    case "page-pre":
                        pageInfo.CurrentPage = pageInfo.CurrentPage - 1 >0 ? pageInfo.CurrentPage - 1 : 1;
                        break;
                    case "page-next":
                        pageInfo.CurrentPage = pageInfo.CurrentPage + 1 < pageInfo.TotalPage ? pageInfo.CurrentPage + 1 : pageInfo.TotalPage;
                        break;
                    case "page-last":
                        pageInfo.CurrentPage = pageInfo.TotalPage;
                        break;
                        //default:
                }

                pageInfo.CurrentPage = pageInfo.CurrentPage <= 0 ? 1 : pageInfo.CurrentPage;
                this.currentPage.Text = pageInfo.CurrentPage.ToString();

                if (loadPageData != null)
                {
                    loadPageData.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// 页大小选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                ToolStripDropDownButton toolStripDropDownButton = (ToolStripDropDownButton)sender;
                ToolStripItem clickedItem = e.ClickedItem;
                int pageSize = Convert.ToInt32(clickedItem.Tag);
                pageInfo.PageSize = pageSize;
                toolStripDropDownButton.Text = clickedItem.Text;
               /* this.currentPage.Text = "1";//重置页码
                */
                SetPageToolSelect();
                if (loadPageData != null)
                {
                    loadPageData.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        ///  页大小勾选
        /// </summary>
        private void SetPageToolSelect()
        {
            try
            {
                ToolStripItemCollection toolStripItem = this.toolStripDropDownButton1.DropDownItems;
                for (int i = 0; i < toolStripItem.Count; i++)
                {
                    if (toolStripItem[i] is ToolStripMenuItem)
                    {
                        ToolStripMenuItem item = (ToolStripMenuItem)toolStripItem[i];
                        if (item.Text == this.toolStripDropDownButton1.Text)
                        {
                            item.Checked = true;
                        }
                        else
                        {
                            item.Checked = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //long total, long records
        /// <summary>
        ///  显示内容
        /// </summary>
        public void SetShowText()
        {
            this.showStrip.Text = string.Format("共{0}页({1}条记录)", pageInfo.TotalPage, pageInfo.CurrentCount);
        }


        /// <summary>
        /// 设置页大小【列表】
        /// </summary>
        /// <param name="pageSizes"></param>
        public void SetPageSizeTool(int[] pageSizes)
        {
            this.pageSizes = pageSizes;
            this.toolStripDropDownButton1.DropDownItems.Clear();
            ToolStripMenuItem toolStripMenuItem = null;
            for (int i = 0; i < this.pageSizes.Length; i++)
            {
                if (i == 0)
                {
                    this.toolStripDropDownButton1.Text = $"每页{this.pageSizes[i]}条";
                    //this.toolStripDropDownButton1
                }
                toolStripMenuItem = new ToolStripMenuItem() { Tag = this.pageSizes[i], Text = $"每页{this.pageSizes[i]}条",Name= $"toolPageSize{this.pageSizes[i]}" };
                this.toolStripDropDownButton1.DropDownItems.Add(toolStripMenuItem);
            }
            SetPageToolSelect();
        }

        /// <summary>
        ///  设置刷新 首页 上一页 下一页 末页 的图片
        /// </summary>
        /// <param name="reload"></param>
        /// <param name="first"></param>
        /// <param name="pre"></param>
        /// <param name="next"></param>
        /// <param name="last"></param>
        public void SetPageButtonImages(Image reload,Image first, Image pre, Image next,Image last)
        {
            if (reload != null)
            {
                this.ToolPageReload.Image = reload;
            }
            if (first != null)
            {
                this.ToolPageFirst.Image = first;
            }
            if (pre != null)
            {
                this.ToolPagePre.Image = pre;
            }
            if (next != null)
            {
                this.ToolPageNext.Image = next;
            }
            if (last != null)
            {
                this.ToolPageLast.Image = last;
            }
        }


        private void KenToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
