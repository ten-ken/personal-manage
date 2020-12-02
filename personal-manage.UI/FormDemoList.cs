using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyWfControls;
using personal_manage.BLL.Purchase;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.prop;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.Models.entity;
using personal_manage.UI.Components;

namespace personal_manage.UI
{
    //
    public partial class FormDemoList : Form
    {
        List<OsZbPurchaseProjectInfo> listData = new List<OsZbPurchaseProjectInfo>();

        PageInfo<OsZbPurchaseProjectInfo> pageInfo = new PageInfo<OsZbPurchaseProjectInfo>();

        private OsZbPurchaseProjectInfoBLL projectInfoBLL = new OsZbPurchaseProjectInfoBLL();

        //导入窗口
        private ImportForm<OsZbPurchaseProjectInfo> importForm;

        public FormDemoList()
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
            this.kenPage1.loadPageData = LoadData;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

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
        private void LoadData()
        {
            try
            {
               
                OsZbPurchaseProjectInfo info = new OsZbPurchaseProjectInfo();

                //info.ProjectName = this.projectNo.Text;

                pageInfo.ParamsSearch = info;

                //需要这个把 组件的分页信息赋值当前页面全局变量
                ObjectUtil.CopyPop(this.kenPage1.pageInfo,ref pageInfo);

                pageInfo = projectInfoBLL.SelectPage(pageInfo, null, $" PROJECT_NO like '%{this.projectNo.Text}%'", WhereType.SQL);

                listData = pageInfo.Records;

               
                //this.showStrip.Text = string.Format("共{0}页({1}条记录)", pageInfo.CurrentPage, pageInfo.TotalPage);
                this.listDataGriddView.DataSource = listData;

                //分页部分
                var item = new MyWfControls.dto.PageInfo() {CurrentPage= pageInfo .CurrentPage>0? pageInfo.CurrentPage:1, CurrentCount= pageInfo.CurrentCount,PageSize= pageInfo .PageSize,TotalPage= pageInfo.TotalPage};
                this.kenPage1.pageInfo = item;
                this.kenPage1.SetShowText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormDemoAdd formDemoAdd = new FormDemoAdd();
            formDemoAdd.RefeshParentWindow = BtnRefesh_ParentWindow;
            DialogUtil.ShowDialog(formDemoAdd, this, 883, 519, new FormWindowProp(false, false, FormBorderStyle.FixedSingle));
            //DialogUtil.ShowWithPWin(formDemoAdd,this, 150, 100,new FormWindowProp(false,false, FormBorderStyle.FixedSingle));
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
                if (columnName == "detail_row")
                {
                    FormDemoAdd formDemoAdd = new FormDemoAdd(listData[e.RowIndex]);

                    DialogUtil.ShowDialog(formDemoAdd, this, formDemoAdd.Width, formDemoAdd.Height, null);
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
                        listDels.Add(listData[i].Id);
                    }
                }

                R r = projectInfoBLL.Delete<OsZbPurchaseProjectInfo>(listDels, null);

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


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FormDemoAdd formDemoAdd = new FormDemoAdd();
            formDemoAdd.RefeshParentWindow = BtnRefesh_ParentWindow;
            DialogUtil.ShowDialog(formDemoAdd, this, 883, 519, new FormWindowProp(false, false, FormBorderStyle.FixedSingle));
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            importForm = new ImportForm<OsZbPurchaseProjectInfo>("项目信息导出表.xlsx");
            //importForm.importEvent += btnImportProject_Click;
            importForm.ImportCheck = ImportCheck;
            DialogUtil.ShowDialog(importForm, this, importForm.Width, importForm.Height, new FormWindowProp(false, false, FormBorderStyle.FixedDialog));
        }


        private void btnImportProject_Click(object sender, EventArgs e)
        {
            try
            {
                int firstIndex = 2;

                MessageInfo<OsZbPurchaseProjectInfo> messageInfo = ExcelUtil.ReadExcel<OsZbPurchaseProjectInfo>(firstIndex);

                if (messageInfo.ExistError)
                {
                    MessageBox.Show(messageInfo.ErrorInfo,
                               "提示",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Warning);
                    return;
                }
                if (messageInfo.Record == null)
                {
                    return;
                }

                // 表中已存在的数据ID集合
                Dictionary<string, string> containDic = new Dictionary<string, string>();
                OsZbPurchaseProjectInfo osZbPurchaseProjectInfo = new OsZbPurchaseProjectInfo();
         
                List<OsZbPurchaseProjectInfo> dbLList = projectInfoBLL.SelectList(osZbPurchaseProjectInfo, null, null, WhereType.Columns);

                foreach (OsZbPurchaseProjectInfo itemInfo in dbLList)
                {
                    if (!containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                    {
                        containDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo, "");
                    }
                }

                List<OsZbPurchaseProjectInfo> record = messageInfo.Record;

                if (record == null)
                {
                    return;
                }

                StringBuilder errorSbf = new StringBuilder();

                HashSet<string> dbcompare = new HashSet<string>();

                // 表中已存在的数据ID集合
                Dictionary<string, string> excelDic = new Dictionary<string, string>();

                //需要修改的数据
                List<OsZbPurchaseProjectInfo> updateList = new List<OsZbPurchaseProjectInfo>();

                foreach (OsZbPurchaseProjectInfo itemInfo in record)
                {

                    //excel 重复性验证
                    if (!excelDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                    {
                        excelDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo, "");
                    }
                    else
                    {
                        dbcompare.Add("第" + itemInfo.CurExcelIndex + "行,该项目信息在excel中重复\n");
                    }


                    if (containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                    {
                        updateList.Add(itemInfo);
                    }

                }

                foreach (string str in dbcompare)
                {
                    errorSbf.Append(str);
                    messageInfo.ExistError = true;
                }

                errorSbf.Append(messageInfo.ErrorInfo);
                messageInfo.ErrorInfo = errorSbf.ToString();


                if (messageInfo.ExistError)
                {
                    MessageBox.Show(messageInfo.ErrorInfo,
                                   "提示",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Warning);
                    return;
                }

                record.RemoveAll(it => updateList.Contains(it));//移除集合中匹配项

                if (record.Count > 0)
                {
                    //projectInfoBLL.SaveOrUpdate()
                    projectInfoBLL.SaveList(record,null,true,null);
                    //SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, SQLiteSqlUtils.CreateInsertSql(record));
                }

                //修改原数据
                if (updateList.Count > 0)
                {
                    projectInfoBLL.UpdateList(updateList, null, "projectNo,markNo,packName", WhereType.Columns,null);
                    /*string updateSql = SQLiteSqlUtils.CreateSelectUpdateSql(updateList, new string[] { "businessFileWay", "skillFileWay", "markName" }, new string[] { "projectNo", "markNo", "packName" });
                    SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, updateSql);*/
                }
                MessageBox.Show("导入成功",
                               "提示",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入项目文件错误信息：" + ex.Message);
            }

        }

        public void ImportCheck(MessageInfo<OsZbPurchaseProjectInfo> messageInfo)
        {
            R result = null;

            // 表中已存在的数据ID集合
            Dictionary<string, string> containDic = new Dictionary<string, string>();
            OsZbPurchaseProjectInfo osZbPurchaseProjectInfo = new OsZbPurchaseProjectInfo();

            List<OsZbPurchaseProjectInfo> dbLList = projectInfoBLL.SelectList(osZbPurchaseProjectInfo, null, null, WhereType.Columns);

            foreach (OsZbPurchaseProjectInfo itemInfo in dbLList)
            {
                if (!containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                {
                    containDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo, "");
                }
            }

            List<OsZbPurchaseProjectInfo> record = messageInfo.Record;

            if (record == null)
            {
                return;
            }

            StringBuilder errorSbf = new StringBuilder();

            HashSet<string> dbcompare = new HashSet<string>();

            // 表中已存在的数据ID集合
            Dictionary<string, string> excelDic = new Dictionary<string, string>();

            //需要修改的数据
            List<OsZbPurchaseProjectInfo> updateList = new List<OsZbPurchaseProjectInfo>();

            foreach (OsZbPurchaseProjectInfo itemInfo in record)
            {
                //excel 重复性验证
                if (!excelDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                {
                    excelDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo, "");
                }
                else
                {
                    dbcompare.Add("第" + itemInfo.CurExcelIndex + "行,该项目信息在excel中重复\n");
                }

                if (containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo))
                {
                    updateList.Add(itemInfo);
                }

            }

            foreach (string str in dbcompare)
            {
                errorSbf.Append(str);
                messageInfo.ExistError = true;
            }

            errorSbf.Append(messageInfo.ErrorInfo);
            messageInfo.ErrorInfo = errorSbf.ToString();


            if (messageInfo.ExistError)
            {
                MessageBox.Show(messageInfo.ErrorInfo,
                               "提示",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            record.RemoveAll(it => updateList.Contains(it));//移除集合中匹配项
            
            if (record.Count > 0)
            {
                //projectInfoBLL.SaveOrUpdate()
                 result = projectInfoBLL.SaveList(record, null, true, null);
                //SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, SQLiteSqlUtils.CreateInsertSql(record));
            }

            //修改原数据
            if (updateList.Count > 0)
            {
                result = projectInfoBLL.UpdateList(updateList, null, "ProjectNo,MarkNo,PackName", WhereType.Columns, null);
            }

            if (result.Successful)
            {
                importForm.SetImportInfo(true,messageInfo.Record.Count+ updateList.Count, 0);
                MessageBox.Show("导入成功",
                         "提示",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                importForm.SetImportInfo(false, 0, messageInfo.Record.Count + updateList.Count);
                MessageBox.Show("导入失败","提示",MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }

          
        }
    }
}