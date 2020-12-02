using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.BLL.Sys;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.Models.entity;
using personal_manage.UI.CsharpAuto;

namespace personal_manage.UI
{
    public partial class CodeProjectList : Form
    {
        List<CodeProjectInfo> listData = new List<CodeProjectInfo>();

        PageInfo<CodeProjectInfo> pageInfo = new PageInfo<CodeProjectInfo>();

        private CodeProjectInfoBLL projectInfoBLL = new CodeProjectInfoBLL();

        public CodeProjectList()
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }


        //自定义组件加载
        private void kenPage1_Load(object sender, EventArgs e)
        {
            //设置分页页大小
            //this.kenPage1.SetPageSizeTool(new int[] { 10, 50, 100, 200, 500 });

            //设置分页按钮的图片样式 ==>这里只修改了第一个【刷新】按钮的样式
            //this.kenPage1.SetPageButtonImages(Properties.Resources.back,null,null,null,null);
            //设置加载数据的回调
            //this.kenPage1.loadPageData = LoadData;
        }

        private void CodeProjectList_Load(object sender, EventArgs e)
        {

            int width = 0;
            for (int i = 0; i < listDataGriddView.Columns.Count; i++)
            {              
                
                
                if (i== listDataGriddView.Columns.Count - 1)
                {
                    listDataGriddView.Columns[i].Width = listDataGriddView.Width - (listDataGriddView.Columns.Count - 1)* width;
                    //
                    listDataGriddView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    width = listDataGriddView.Width / listDataGriddView.Columns.Count;
                    listDataGriddView.Columns[i].Width = width;
                    //listDataGriddView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
               

            }
            /*for (int i = 0; i < listDataGriddView.Columns.Count; i++)
            {
                listDataGriddView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }*/
            

            SetStyleOrEven();
            //SetPageToolSelect();
            this.listDataGriddView.Tag = 9999;
            this.listDataGriddView.RowsDefaultCellStyle.Font = new Font("楷体", 15, FontStyle.Regular);
            this.listDataGriddView.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.listDataGriddView.RowsDefaultCellStyle.BackColor = Color.White;
            LoadData();
        }


        private void SetStyleOrEven()
        {
            //全选 全不选
            this.btnAllCheck.Click += BtnAllCheck_Click;

            //查询事件
            this.SearchBtn.Click += Search;

            /*            //刷新事件
                        this.btnRefesh.Click += Search;*/

            //默认居中 列表字段不自动添加
            this.listDataGriddView.AutoGenerateColumns = false;
            //线上行号
            this.listDataGriddView.RowPostPaint += ListDataGriddView_RowPostPaint;

            //单元格点击事件
            this.listDataGriddView.CellClick += ListDataGriddView_CellClick;
        }



        //查询
        private void Search(object sender, EventArgs e)
        {
            LoadData();
        }



        /// <summary>
        /// 全选--全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllCheck_Click(object sender, EventArgs e)
        {
            //结束编辑
            this.listDataGriddView.EndEdit();

            string tag = this.btnAllCheck.Tag.ToString();

            bool check = false;
            //全选
            if (tag == "checkAll")
            {
                check = true;
            }

            int count = Convert.ToInt16(listDataGriddView.Rows.Count.ToString());


            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell selectCheckCell = (DataGridViewCheckBoxCell)listDataGriddView.Rows[i].Cells["select_check"];
                selectCheckCell.Value = check;
            }

            //
            if (tag == "checkAll")
            {
                this.btnAllCheck.Text = "全不选";
                this.btnAllCheck.Tag = "unAllcheck";
                this.btnAllCheck.Image = Properties.Resources.uncheck_32;
                this.btnAllCheck.Width += 12;
                var location = this.btnDelete.Location;
                location.X += 12;
                this.btnDelete.Location = location;
            }
            else
            {
                this.btnAllCheck.Text = "全选";
                this.btnAllCheck.Tag = "checkAll";
                this.btnAllCheck.Image = Properties.Resources.checkall_32;
                this.btnAllCheck.Width -= 12;
                var location = this.btnDelete.Location;
                location.X -= 12;
                this.btnDelete.Location = location;
            }
        }


        /// <summary>
        /// 数据加载
        /// </summary>
        public void LoadData()
        {
            try
            {
                CodeProjectInfo info = new CodeProjectInfo();
                pageInfo.PageSize = 100;
                pageInfo.ParamsSearch = info;
                pageInfo = projectInfoBLL.SelectPage(pageInfo, null, $" PRO_NAME like '%{this.keyWord.Text}%'", WhereType.SQL);

                listData = pageInfo.Records;
                this.listDataGriddView.DataSource = listData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ListDataGriddView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }

                if (e.ColumnIndex == 0)
                {  //单选
                   //checkbox
                    if ((bool)listDataGriddView.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                    {
                        listDataGriddView.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        listDataGriddView.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }

                string columnName = listDataGriddView.Columns[e.ColumnIndex].Name;
                //删除
                if (columnName == "java_row")
                {
                    CodeProjectAdd createCode = new CodeProjectAdd(listData[e.RowIndex].ID);
                    DialogUtil.ShowDialog(createCode, this, createCode.Width, createCode.Height, new Common.prop.FormWindowProp(false,false,FormBorderStyle.FixedDialog));
                }
                else if (columnName == "csharp_row")
                {
                    AutoCodeConfigForm autoCodeConfigForm = new AutoCodeConfigForm(listData[e.RowIndex]);
                    DialogUtil.ShowDialog(autoCodeConfigForm, this, autoCodeConfigForm.Width, autoCodeConfigForm.Height, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDataGriddView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, listDataGriddView.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), listDataGriddView.RowHeadersDefaultCellStyle.Font, rectangle, listDataGriddView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // 刷新父页面
        public void BtnRefesh_ParentWindow()
        {
            LoadData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRowCollection rows = listDataGriddView.Rows;
                List<int> listDels = new List<int>();

                int count = listDataGriddView.Rows.Count;
                //Convert.ToInt16(listDataGriddView.Rows.Count.ToString());
                for (int i = 0; i < count; i++)
                {
                    if ((bool)listDataGriddView.Rows[i].Cells[0].EditedFormattedValue == true)
                    {
                        listDels.Add(listData[i].ID);
                    }
                }

                R r = projectInfoBLL.Delete<CodeProjectInfo>(listDels, null);

                if (r.Successful)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            CodeProjectAdd createCode = new CodeProjectAdd();
            DialogUtil.ShowDialog(createCode, this, createCode.Width, createCode.Height, new Common.prop.FormWindowProp(false,false,FormBorderStyle.FixedDialog));
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void listDataGriddView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copy_Click(object sender, EventArgs e)
        {

            try
            {

                CodeProjectInfo codeProject = new CodeProjectInfo();
                codeProject.AUTHOR = "admin";
                codeProject.PRO_NAME = "项目名称" + Guid.NewGuid().ToString("N");

                DataGridViewRowCollection rows = listDataGriddView.Rows;
                List<CodeProjectInfo> listCopys = new List<CodeProjectInfo>();

                int count = listDataGriddView.Rows.Count;
                //Convert.ToInt16(listDataGriddView.Rows.Count.ToString());
                for (int i = 0; i < count; i++)
                {
                    if ((bool)listDataGriddView.Rows[i].Cells[0].EditedFormattedValue == true)
                    {
                        listCopys.Add(listData[i]);
                    }
                }

                if(listCopys==null || listCopys.Count <= 0)
                {
                    MessageHelper.ShowWarn("未选择复制的项目 按随机的信息生成一个不完整的项目");
                }
                else
                {
                    if (listCopys.Count > 1)
                    {
                        MessageHelper.ShowWarn("请选择一个而不是多个项目进行复制");
                        return;
                    }
                    else
                    {
                        codeProject = listCopys[0];
                        codeProject.ID = 0;
                        codeProject.PRO_NAME = "项目名称" + Guid.NewGuid().ToString("N");
                    }
                }


                R r = projectInfoBLL.SaveOrUpdate(codeProject,null,false,null);

                if (r.Successful)
                {
                    MessageHelper.ShowSuccess("复制成功");
                }
                else
                {
                    MessageHelper.ShowSuccess("复制失败，"+ r.ResultHint);
                }

                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
