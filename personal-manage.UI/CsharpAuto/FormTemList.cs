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
using personal_manage.Models.entity;

namespace personal_manage.UI.CsharpAuto
{
    public partial class FormTemList : Form
    {
        private CodeProjectInfo codeProjectInfo;

       // private CodeProjectTemplateConfigInfo codeProjectTemplateConfigInfo = new CodeProjectTemplateConfigInfo();

        private CodeProjectTemplateConfigInfoBLL codeProjectTemplateConfigInfoBLL = new CodeProjectTemplateConfigInfoBLL();


        private List<CodeProjectTemplateConfigInfo> lists;

        public FormTemList()
        {
            InitializeComponent();
        }

        public FormTemList(CodeProjectInfo codeProjectInfo)
        {
            this.codeProjectInfo = codeProjectInfo;
            InitializeComponent();
        }
        
        private void FormTemList_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(190, 248, 174);
            this.BackColor = Color.FromName("InactiveCaption");
            //SystemColors.InactiveCaption
            //this.listDataGriddView.Columns[listDataGriddView.Columns.Count - 1].Width = 100;
            this.listDataGriddView.Columns[listDataGriddView.Columns.Count - 3].Width = 150;
            this.listDataGriddView.Columns[listDataGriddView.Columns.Count - 2].Width = 400;
            this.listDataGriddView.Columns[listDataGriddView.Columns.Count-1].Width = 100;
           // this.listDataGriddView.Columns[listDataGriddView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            /*this.listDataGriddView.Columns[0].Width = 100;
            this.listDataGriddView.Columns[1].Width = 200;
            this.listDataGriddView.Columns[2].Width = 60;
            this.listDataGriddView.Columns[3].Width = 300;*/
            this.listDataGriddView.AutoGenerateColumns = false;
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                CodeProjectTemplateConfigInfo codeProjectTemplateConfigInfo = new CodeProjectTemplateConfigInfo();
                codeProjectTemplateConfigInfo.ProjectId = codeProjectInfo.ID;
                lists = codeProjectTemplateConfigInfoBLL.SelectList(codeProjectTemplateConfigInfo, null, "ProjectId", WhereType.Columns);
                this.listDataGriddView.DataSource = lists;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            FormTemAdd formTemAdd = new FormTemAdd(codeProjectInfo, 0);
            DialogUtil.ShowDialog(formTemAdd, this, formTemAdd.Width, formTemAdd.Height, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
        }

        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            string tag = this.btnAllCheck.Tag.ToString();
            //结束编辑
            this.listDataGriddView.EndEdit();
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
                this.btnAllCheck.Image = Properties.Resources.all_uncheck_20;
                this.btnAllCheck.Width += 6;
            }
            else
            {
                this.btnAllCheck.Text = "全选";
                this.btnAllCheck.Tag = "checkAll";
                this.btnAllCheck.Image = Properties.Resources.all_check_20;
                this.btnAllCheck.Width -= 6;
            }
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
                        listDels.Add(lists[i].ID);
                    }
                }

                if (listDels.Count <= 0)
                {
                    MessageHelper.ShowWarn("至少需要选择一条记录进行删除");
                    return;
                }

                R r = codeProjectTemplateConfigInfoBLL.Delete<CodeProjectTemplateConfigInfo>(listDels, null);
                if (r.Successful)
                {
                    MessageHelper.ShowSuccess("删除成功");
                    LoadData();
                }
                else
                {
                    MessageHelper.ShowWarn(r.ResultHint);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
                //MessageBox.Show("刪除异常,错误信息:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (columnName == "detail_row")
                {
                    FormTemAdd itemForm = new FormTemAdd(codeProjectInfo,lists[e.RowIndex].ID);
                    DialogUtil.ShowDialog(itemForm, this, itemForm.Width, itemForm.Height, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
