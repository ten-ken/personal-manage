/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using System.Windows.Forms;
using ess_zbfz_main.commonForm;
using personal_manage.Common.dto;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.Models.entity;

namespace personal_manage.UI.Demo
{
    public partial class FrmBzjAdd : Form
    {
        private static string sqliteDbName = ConfigurationManager.AppSettings["sqliteDBName"].ToString();  //数据库名称
        private static string sqliteDbLocation = ConfigurationManager.AppSettings["sqliteDBLocation"].ToString(); //数据库存放路径

        //保存接口
        internal static string apiSave = "oszbsupplierdeposit/save";

      *//*  //删除
        internal static string apiDelete = "oszbsupplierdeposit/delete";*//*

        //更新附件信息
        internal static string apiUpdateFile = "oszbsupplierdeposit/updateFile";


        //当前的项目信息
        private OsZbPurchaseProjectInfo currentProjectInfo;


        //保证金信息
        private OsZbSupplierDeposit currentDeposit;

        //保证金详情信息
        private List<OsZbSupplierDepositDetail> detailList;

        //标下拉
        private List<ComboBoxVo> markList;

        // 声明 一个 CellEdit  
        public DataGridViewTextBoxEditingControl dgvTxt = null; 

        public FrmBzjAdd()
        {
            InitializeComponent();
        }

        public FrmBzjAdd(OsZbPurchaseProjectInfo currentProjectInfo, OsZbSupplierDeposit osZbSupplierDeposit)
        {
            this.currentProjectInfo = currentProjectInfo;
            this.currentDeposit = osZbSupplierDeposit;
            InitializeComponent();
        }


        private void FrmBzjAdd_Load(object sender, EventArgs e)
        {
            this.supplierName.Text = PublicVo.SupplyName;
            this.projectName.Text = currentProjectInfo.ProjectName;
            this.projectNo.Text = currentProjectInfo.ProjectNo;
            this.listDataGriddView.AutoGenerateColumns = false;
            LoadData(null);
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="flag"></param>
        public void LoadData(string flag)
        {
            try
            {
               *//*  if(this.Owner is FrmBzj)
                {
                    FrmBzj frmBzj= (FrmBzj)this.Owner;
                    //刷新父窗口的方法
                    frmBzj.RefreshSelf();
                }*//*

                 this.listDataGriddView.DataSource = null;
                //查询标下拉信息
                string markComboboxSql = "select OS_ZB_PURCHASE_PROJECT_INFO.MARK_NO as keyValue,OS_ZB_PURCHASE_PROJECT_INFO.MARK_NAME as keyName  from OS_ZB_PURCHASE_PROJECT_INFO where OS_ZB_PURCHASE_PROJECT_INFO.ID ='" + currentProjectInfo.Id + "' group by OS_ZB_PURCHASE_PROJECT_INFO.MARK_NO ";
                markList = null;
                    //SQLiteLibrary.SelectBySql<ComboBoxVo>(sqliteDbLocation, sqliteDbName, markComboboxSql);

                //修改页面
                if (currentDeposit != null)
                {
                    string mainSql = "SELECT OS_ZB_SUPPLIER_DEPOSIT.*,OS_ZB_PURCHASE_PROJECT_INFO.PROJECT_NAME,SYS_FILE_INFO.FILE_PATH FROM OS_ZB_SUPPLIER_DEPOSIT";
                    mainSql += " left join OS_ZB_PURCHASE_PROJECT_INFO ON OS_ZB_PURCHASE_PROJECT_INFO.PROJECT_NO =OS_ZB_SUPPLIER_DEPOSIT.PROJECT_NO";
                    mainSql += "  left join SYS_FILE_INFO on SYS_FILE_INFO.ID =OS_ZB_SUPPLIER_DEPOSIT.ATTACH_ID ";
                    mainSql += " where OS_ZB_SUPPLIER_DEPOSIT.id='" + currentDeposit.Id + "'";
                    //List<OsZbSupplierDeposit> lists = SQLiteLibrary.SelectBySql<OsZbSupplierDeposit>(sqliteDbLocation, sqliteDbName, mainSql);
                    
                    currentDeposit = lists.Count > 0 ? lists[0] : null;

                     
                    if ("baodan".Equals(currentDeposit.VoucherCategory))
                    {
                        currentDeposit.VoucherCategory = "保单";
                    }
                    else if ("huikuan".Equals(currentDeposit.VoucherCategory))
                    {
                        currentDeposit.VoucherCategory = "汇款";
                    }


                    //给主页面部分设置信息
                    SetPageMainInfo(this.groupBox1, currentDeposit);

                    //上传的图片
                   *//* if (!StringUtil.IsEmpty(currentDeposit.FilePath))
                    {
                        currentDeposit.FilePath =LocalFileUtil.GetPath(currentDeposit.FilePath);
                        Image image = new Bitmap(currentDeposit.FilePath);
                        this.pictureBox1.Image =new Bitmap(image, 300, 300);
                    }*//*

                    
                    //this.pictureBox1.Image = new 

                    this.totalMoney2.Text = currentDeposit.Total;

                    string secordSql = "select OS_ZB_SUPPLIER_DEPOSIT_DETAIL.*,'No' AS isAddRow from OS_ZB_SUPPLIER_DEPOSIT_DETAIL";
                    secordSql += " left join OS_ZB_SUPPLIER_DEPOSIT on OS_ZB_SUPPLIER_DEPOSIT.ID = OS_ZB_SUPPLIER_DEPOSIT_DETAIL.PARENT_ID";
                    secordSql += " where OS_ZB_SUPPLIER_DEPOSIT_DETAIL.PARENT_ID = '" + currentDeposit.Id + "'";

                    //detailList = SQLiteLibrary.SelectBySql<OsZbSupplierDepositDetail>(sqliteDbLocation, sqliteDbName, secordSql);

                    for (int i = 0; i < detailList.Count; i++)
                    {
                        detailList[i].DepositMoney = string.IsNullOrEmpty(detailList[i].DepositMoney) ? "0" : detailList[i].DepositMoney;
                        detailList[i].TotalMoney = string.IsNullOrEmpty(detailList[i].TotalMoney) ? "0" : detailList[i].TotalMoney;
                        detailList[i].DepositInsure = string.IsNullOrEmpty(detailList[i].DepositInsure) ? "0" : detailList[i].DepositInsure;
                    }

                
                }
                else
                {
                    this.panelActive.Visible = false;
                }


                //标的下拉选项
                DataGridViewColumn dataGridViewColumn = this.listDataGriddView.Columns[1];
                if (dataGridViewColumn is DataGridViewComboBoxColumn)
                {
                    DataGridViewComboBoxColumn comboBoxColum = (DataGridViewComboBoxColumn)dataGridViewColumn;

                    ComboBoxVo comboBoxVo = new ComboBoxVo("请选择", "");
                    markList.Insert(0, comboBoxVo);

                    comboBoxColum.DataSource = markList;

                    comboBoxColum.DisplayMember = "keyName";
                    comboBoxColum.ValueMember = "keyValue";
                }


                *//* if ("addRow".Equals(flag))
                 {
                     detailList.Add(new OsZbSupplierDepositDetail());
                 }*//*
             
                this.listDataGriddView.DataSource = detailList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        /// <summary>
        ///  主页面设置值
        /// </summary>
        /// <param name="mainControl"></param>
        /// <param name="currentDeposit"></param>
        private void SetPageMainInfo(Control mainControl, OsZbSupplierDeposit currentDeposit)
        {
            var allControls = mainControl.Controls;
            for (int i = 0; i < allControls.Count; i++){
                if (allControls[i] is TextBox || allControls[i] is DateTimePicker){
                    SetControlValueByEntity(currentDeposit, currentDeposit.GetType(), allControls[i]);
                }
            }
        }

        /// <summary>
        /// 给控件设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="type"></param>
        /// <param name="control"></param>
        private void SetControlValueByEntity<T>(T t, Type type, Control control)
        {
            string propName = StringUtil.UpperCaseFirst(control.Name);

            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            PropertyInfo propertyInfo = type.GetProperty(propName, bindingFlags);

            if (propertyInfo != null)
            {
                object value =propertyInfo.GetValue(t);
                control.Text = value!=null?value.ToString():null;

            }
           *//* else if (propertyInfo == null && "DepositInsure".Equals(propName))//保险可为0
            {
                propertyInfo.SetValue(t, "0");
            }*//*
        }




        /// <summary>
        ///  全选和全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //bool flag = Convert.ToBoolean(selectCheckCell.Value);
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




        /// <summary>
        ///  删除功能 --- UI删除行 不操作数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt16(listDataGriddView.Rows.Count.ToString());

                //物理新增的行
                List<int> deleteRows = new List<int>();             

                //绑定数据源的行
                List<OsZbSupplierDepositDetail> dataSourceRows = new List<OsZbSupplierDepositDetail>();

                for (int i = 0; i < count; i++)
                {
                    if ((bool)listDataGriddView.Rows[i].Cells[0].EditedFormattedValue == true)
                    {
                        if (detailList!=null && detailList.Count> i)
                        {
                            dataSourceRows.Add(detailList[i]);
                        }
                        else
                        {
                            deleteRows.Add(i);
                        }
                    }
                }

                if (deleteRows.Count <= 0 && dataSourceRows.Count<=0)
                {
                    MessageBox.Show("请选择需要删除的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                for (int i = 0; i < deleteRows.Count; i++)
                {
                    this.listDataGriddView.Rows.RemoveAt(deleteRows[i]);
                }

                for (int i = 0; i < dataSourceRows.Count; i++)
                {
                    detailList.Remove(dataSourceRows[i]);
                }

                if (dataSourceRows.Count > 0)
                {                   
                    this.listDataGriddView.DataSource = null;//必须要
                    this.listDataGriddView.DataSource = detailList;
                }

                //计算
                CalMoney(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除异常,错误信息:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //刷新
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadData(null);
        }



        /// <summary>
        ///  新增行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            object dataSource = this.listDataGriddView.DataSource;

            //this.listDataGriddView.AllowUserToAddRows = true;
            //如果绑定了数据源 需要先取消绑定
            if (dataSource is List<OsZbSupplierDepositDetail>)
            {
                //需要取消原先绑定
                this.listDataGriddView.DataSource = null;
                detailList.Add(new OsZbSupplierDepositDetail());
                this.listDataGriddView.DataSource = detailList;
            }
            else
            {
                this.listDataGriddView.Rows.Add();//新增行
            }            
        }



        /// <summary>
        ///  计算金额部分
        /// </summary>
        private void CalMoney(int curRow)
        {
            try
            {
                int rowCount = this.listDataGriddView.Rows.Count;

                //行--保证金总额
                Decimal rowTotal = new Decimal();

                //顶部统计 保证金总额  保险总额 总金额
                Decimal totalBzj = new Decimal();
                Decimal totalBx = new Decimal();
                Decimal total = new Decimal();

                for (int i = 0; i < rowCount; i++)
                {

                    rowTotal = AddCalByRows(this.listDataGriddView.Rows[i].Cells[3], this.listDataGriddView.Rows[i].Cells[4]);

                    totalBzj = Decimal.Add(totalBzj, GetFormateValue(this.listDataGriddView.Rows[i].Cells[3]));

                    totalBx = Decimal.Add(totalBx, GetFormateValue(this.listDataGriddView.Rows[i].Cells[4]));

                    total = Decimal.Add(total, rowTotal);

                    //改变事件的触发行 【不需要设置curRow写-1】
                    if (curRow == i)
                    {
                        this.listDataGriddView.Rows[i].Cells[5].Value = rowTotal;
                    }

                }

                this.totalMoney2.Text = totalBzj.ToString();

                this.totalInsure.Text = totalBx.ToString();

                this.total.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        /// <summary>
        ///  计算两个单元格值的和
        /// </summary>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <returns></returns>
        private decimal AddCalByRows(DataGridViewCell cell1, DataGridViewCell cell2)
        {

            return Decimal.Add(GetFormateValue(cell1), GetFormateValue(cell2));
        }


        /// <summary>
        ///  设置单元格的值
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private decimal GetFormateValue(DataGridViewCell cell)
        {
            Decimal val1 = Decimal.Zero;
            if (cell.Value != null)
            {
                val1 = Convert.ToDecimal(cell.Value.ToString());
            }
            return val1;
        }



        //单元格修改完毕
        private void listDataGriddView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                //计算
                CalMoney(e.RowIndex);

                if (e.ColumnIndex == 1)
                {
                    DataGridViewCell dataGridViewCell = this.listDataGriddView.CurrentRow.Cells[e.ColumnIndex];

                    object o = dataGridViewCell.Value;

                    if (o != null && o.ToString() != null && !"请选择".Equals(o.ToString()))
                    {
                        //分标名称

                        //查询标下拉信息
                        string packComboboxSql = "select OS_ZB_PURCHASE_PROJECT_INFO.PACK_NO as keyName,OS_ZB_PURCHASE_PROJECT_INFO.PACK_NAME as keyValue  from OS_ZB_PURCHASE_PROJECT_INFO where OS_ZB_PURCHASE_PROJECT_INFO.MARK_NO ='" + o.ToString() + "' and OS_ZB_PURCHASE_PROJECT_INFO.SIGN_UP='YES'";
                        List<ComboBoxVo> packList = new List<ComboBoxVo>();
                            //SQLiteLibrary.SelectBySql<ComboBoxVo>(sqliteDbLocation, sqliteDbName, packComboboxSql);

                        DataGridViewColumn column = this.listDataGriddView.Columns[2];

                        if (column is DataGridViewComboBoxColumn)
                        {
                            DataGridViewComboBoxCell boxCell = new DataGridViewComboBoxCell();

                            DataGridViewComboBoxColumn comboBoxColum = (DataGridViewComboBoxColumn)column;
                            List<string> pklist = new List<string>();
                            for (int i = 0; i < packList.Count; i++)
                            {
                                pklist.Add(packList[i].KeyValue);
                            }

                            if(pklist!=null && pklist.Count > 0)
                            {
                                pklist.Insert(0, "请选择");
                            }
                            else
                            {
                                pklist.Insert(0, "暂无数据");
                            }
                            

                            boxCell.DataSource = pklist;
                            //分包信息
                            this.listDataGriddView.CurrentRow.Cells[2] = boxCell;

                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        //修改之前
        private void listDataGriddView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }





        /// <summary>
        /// 保存提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            R result = null;

            //结束编辑
            this.listDataGriddView.EndEdit();
            this.btnSave.Focus();
            *//*
             * if (editstatus)
            {
                MessageBox.Show("请先结束编辑", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*//*

            try
            {
                //主键id
                string primaryKey = System.Guid.NewGuid().ToString("N");

                //修改
                if (currentDeposit != null && currentDeposit.Id!=null)
                {
                    primaryKey = currentDeposit.Id;
                }


                var controls = this.groupBox1.Controls;

                OsZbSupplierDeposit osZbSupplierDeposit = new OsZbSupplierDeposit();

                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i] is TextBox)
                    {
                        SetValueByControl(osZbSupplierDeposit, osZbSupplierDeposit.GetType(), controls[i]);
                    }
                }
                osZbSupplierDeposit.SupplierId = PublicVo.SupplyId;
                osZbSupplierDeposit.Id = primaryKey;
                osZbSupplierDeposit.TotalMoney = this.totalMoney2.Text;
                if (currentDeposit != null && currentDeposit.Id != null)
                {
                    osZbSupplierDeposit.AttachId = currentDeposit.AttachId;
                }

                List<OsZbSupplierDepositDetail> detailList = GetDataGridInfo(primaryKey,true);

                if(osZbSupplierDeposit.Remark != null && osZbSupplierDeposit.Remark.Length > 500)
                {
                    MessageBox.Show("备注内容长度最大为500个字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (detailList.Count <= 0)
                {
                    MessageBox.Show("至少需要填写一条详情数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //验证
                VerifyMessage verifyMessage = VerifyUtil.Verify(detailList, "baozhengjin", true, "");


                Dictionary<string, string> checkRepeat = new Dictionary<string, string>();

                StringBuilder sbfInfo = new StringBuilder();

                for (var i=0; i< detailList.Count;i++)
                {
                    if(checkRepeat.ContainsKey(detailList[i].MarkNo + "-" + detailList[i].PackName))
                    {
                        sbfInfo.Append($"第{i + 1}行 该包信息的重复填写\n");
                    }
                    else
                    {
                        checkRepeat.Add(detailList[i].MarkNo + "-" + detailList[i].PackName, "");
                    }
                }
                verifyMessage.ErrorInfo += sbfInfo.ToString();

        *//*        if (verifyMessage.ExistError && !StringUtil.IsBlack(verifyMessage.ErrorInfo))
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }*//*

                osZbSupplierDeposit.ListData = detailList;

                //result = WebRequestUtil.PostBasicEntityDataApi(apiSave, osZbSupplierDeposit);

                if (!result.Successful)
                {
                    MessageBox.Show(result.ResultHint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string mainSql = "";

                //修改
                *//*if (currentDeposit != null && currentDeposit.Id != null)
                {
                    mainSql = SQLiteSqlUtils.CreateUpdateSql(osZbSupplierDeposit, new string[] { "id" });
                    

                    //删除副表信息
                    string deleteDetailSql = "delete  from OS_ZB_SUPPLIER_DEPOSIT_DETAIL where OS_ZB_SUPPLIER_DEPOSIT_DETAIL.PARENT_ID='"+ primaryKey + "'";
                    string insertDetailSql = SQLiteSqlUtils.CreateInsertSql(detailList);

                    SQLiteLibrary.ExecuteSqlByTransaction(sqliteDbLocation, sqliteDbName, new string[] { mainSql, deleteDetailSql });
                    SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, insertDetailSql);
                }
                else
                {
                    //新增
                    mainSql = SQLiteSqlUtils.CreateInsertSql(osZbSupplierDeposit);
                    string insertDetailSql = SQLiteSqlUtils.CreateInsertSql(detailList);

                    // SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, mainSql);
                    //SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, insertDetailSql);

                    SQLiteLibrary.ExecuteSqlByTransaction(sqliteDbLocation, sqliteDbName, new string[] { mainSql, insertDetailSql });
                }
*//*
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(null);

                this.Hide();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        ///  获取datagridView的值
        /// </summary>
        /// <returns></returns>
        private List<OsZbSupplierDepositDetail> GetDataGridInfo(string relPrimaryKey,bool idAuto)
        {
            List<OsZbSupplierDepositDetail> detailList = new List<OsZbSupplierDepositDetail>();
            try
            {
                DataGridView dataGridView = this.listDataGriddView;
                BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic;

                PropertyInfo propertyInfo = null;

                int rowCount = dataGridView.Rows.Count;

                int columCount = dataGridView.Columns.Count;

                OsZbSupplierDepositDetail depositDetail = null;
                //行
                for (int i = 0; i < rowCount; i++)
                {
                    depositDetail = new OsZbSupplierDepositDetail();
                    //列
                    for (int k = 0; k < columCount; k++)
                    {
                        SetObjValue(depositDetail, depositDetail.GetType(),
                            dataGridView.Columns[k].Name, dataGridView.Rows[i].Cells[k]);
                    }


                    //设置主键的值
                    *//*if (!StringUtil.IsEmpty(relPrimaryKey))
                    {

                        propertyInfo = depositDetail.GetType().GetProperty("ParentId", bindingFlags);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(depositDetail, relPrimaryKey);
                        }
                    }*//*

                    //注解自动设置
                    if (idAuto)
                    {
                        propertyInfo = depositDetail.GetType().GetProperty("Id", bindingFlags);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(depositDetail, System.Guid.NewGuid().ToString("N"));
                        }
                    }

                    detailList.Add(depositDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return detailList;
        }

        /// <summary>
        ///  datagridView 取值 封装成数组对象=== 一行一行的设置
        /// </summary>
        /// <param name="depositDetail"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="dataGridViewCell"></param>
        private void SetObjValue<T>(T t, Type type, string name, DataGridViewCell dataGridViewCell)
        {
            string propName = StringUtil.UpperCaseFirst(name);

            if (dataGridViewCell.Value != null)
            {
                string textValue = dataGridViewCell.Value.ToString();

                BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

                PropertyInfo propertyInfo = type.GetProperty(propName, bindingFlags);

                if (propertyInfo != null)
                {
                    if ("DepositInsure".Equals(propName))//保险可为0
                    {
                        propertyInfo.SetValue(t, "0");
                    }
                    else
                    {
                        propertyInfo.SetValue(t, textValue);
                    }  
                }
         
            }
        }


        /// <summary>
        /// 给对象设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="type"></param>
        /// <param name="control"></param>
        private void SetValueByControl<T>(T t, Type type, Control control)
        {
            string propName = StringUtil.UpperCaseFirst(control.Name);

            string textValue = control.Text;

            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            PropertyInfo propertyInfo = type.GetProperty(propName, bindingFlags);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(t, textValue);

            }
            else if (propertyInfo == null && "DepositInsure".Equals(propName))//保险可为0
            {
                propertyInfo.SetValue(t, "0");
            }
        }



        private void listDataGriddView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs ev)
        {
            

        }


        /// <summary>
        ///  重新定义编辑框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDataGriddView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.Controls.Clear();

            int colum = this.listDataGriddView.CurrentCell.ColumnIndex;
            string columName = this.listDataGriddView.Columns[colum].Name;

            if (e.Control is DataGridViewTextBoxEditingControl && colum == 6)
            {
                DateTimePicker btn = new DateTimePicker();
                e.Control.Controls.Add(btn);
                btn.Dock = DockStyle.Fill;
                btn.Cursor = Cursors.Default;
                btn.Format = DateTimePickerFormat.Custom;
                btn.CustomFormat = "yyyy-MM-dd";
                TableVo tableVo = new TableVo(this.listDataGriddView.CurrentCell.RowIndex, colum);
                btn.Tag = tableVo;//记录编辑的行和列
                btn.ValueChanged += SetCellValue;

                var cellValue = this.listDataGriddView.CurrentCell.Value;
                //btn.MaxDate = DateTime.Now;

                string pattern = @"\d{4}[/-]\d{1,2}[/-]\d{1,2}";
                Regex regex = new Regex(pattern);
               
                var defaultValue = DateTime.Now.ToString();
                defaultValue = regex.IsMatch(defaultValue) ? regex.Match(defaultValue).Groups[0].ToString() : defaultValue;
                this.listDataGriddView.CurrentCell.Value = cellValue != null ? cellValue : defaultValue;
                btn.Value = Convert.ToDateTime(this.listDataGriddView.CurrentCell.Value.ToString());
                //this.listDataGriddView.Rows[].Cells[this.listDataGriddView.CurrentColumn].Value = curValue;

            }
            else if (e.Control is DataGridViewTextBoxEditingControl && ("depositMoney".Equals(columName)||
                "depositInsure".Equals(columName)|| "totalMoney".Equals(columName))
                )
            {
                dgvTxt = (DataGridViewTextBoxEditingControl)e.Control; // 赋值  
                //dgvTxt.SelectAll();
                dgvTxt.KeyPress+=Cells_KeyPress; // 绑定到事件   

                //先让编辑框聚焦
                dgvTxt.Focus();
                //设置光标的位置到文本尾
                dgvTxt.Select(dgvTxt.TextLength, 0);
                //滚动到控件光标处
                dgvTxt.ScrollToCaret();

            }
        }

        /// <summary>
        ///  自定义的日历 改变值事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetCellValue(object sender, EventArgs e)
        {
            DateTimePicker btn = (DateTimePicker)sender;
            if(btn.Tag is TableVo)
            {
                TableVo tableVo = (TableVo)btn.Tag;
                object value = btn.Value;
                string curValue = "";
                Console.WriteLine("当前值:"+ value);
                if (value != null)
                {
                    string pattern = @"\d{4}[/-]\d{1,2}[/-]\d{1,2}";
                    Regex regex = new Regex(pattern);

                    curValue = btn.Value.ToString();

                    curValue = regex.IsMatch(curValue) ? regex.Match(curValue).Groups[0].ToString() : curValue;

                    Console.WriteLine("当前值:" + curValue);

                   
                }
                this.listDataGriddView.Rows[tableVo.CurrentRow].Cells[tableVo.CurrentColumn].Value = curValue;
            }        
        }

        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {

            int start = dgvTxt.SelectionStart;
            int len = dgvTxt.SelectionLength;

            string text = "";
            if (len > 0)
            {
                text = dgvTxt.Text.Substring(0, start)+ e.KeyChar.ToString() + dgvTxt.Text.Substring(start+ len-1, dgvTxt.Text.Length-start-len);
            }
            else
            {
                text = dgvTxt.Text + e.KeyChar.ToString();
            }

            string pattern = @"^([1-9]\d{0,12}|0)(\.\d{0,3})?$";

            if ("\b".Equals(e.KeyChar.ToString()) || "\r".Equals(e.KeyChar.ToString()) || "\t".Equals(e.KeyChar.ToString()))
            {
                return;
            }

            if (!Regex.IsMatch(text, pattern))
            {
                e.Handled = true;
            }

            *//*//允许输入数字、小数点、删除键和负号
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if ((sender as TextBox).Text != "")
                {
                    e.Handled = true;
                }
            }
            //小数点只能输入一次
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            //第一位不能为小数点
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            //第一位是0，第二位必须为小数点
            if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            {
                e.Handled = true;
            }
            //第一位是负号，第二位不能为小数点
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                e.Handled = true;
            }*//*
        }

        /// <summary>
        ///  行增加事件===>多级联动 [需要把dataPropetyName值移除]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void listDataGriddView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs ev)
        {
            DataGridView dgv = (DataGridView)sender;
            //当前行 不能超过数据的最大行
            if (ev.RowIndex < dgv.Rows.Count)
            {
                if (dgv.Columns[1].Name == "markNo" && detailList!=null)
                {
                    string packComboboxSql = "select OS_ZB_PURCHASE_PROJECT_INFO.PACK_NO as keyName,OS_ZB_PURCHASE_PROJECT_INFO.PACK_NAME as keyValue  from OS_ZB_PURCHASE_PROJECT_INFO where OS_ZB_PURCHASE_PROJECT_INFO.MARK_NO ='" + detailList[ev.RowIndex].MarkNo + "'";

                    List<ComboBoxVo> packList = SQLiteLibrary.SelectBySql<ComboBoxVo>(sqliteDbLocation, sqliteDbName, packComboboxSql);

                    DataGridViewColumn column = this.listDataGriddView.Columns[2];
                    if (column is DataGridViewComboBoxColumn)
                    {
                        List<string> pklist = new List<string>();
                        for (int i = 0; i < packList.Count; i++)
                        {
                            pklist.Add(packList[i].KeyValue);
                        }
                        pklist.Insert(0, "请选择");
                        DataGridViewComboBoxCell boxCell = new DataGridViewComboBoxCell();

                        boxCell.DataSource = pklist;
                        //分包信息
                        this.listDataGriddView.Rows[ev.RowIndex].Cells[2] = boxCell;
                        boxCell.Value = detailList[ev.RowIndex].PackName;
                    }
                }

            }
        }

        /// <summary>
        ///  单元格验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDataGriddView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColum = this.listDataGriddView.Columns[e.ColumnIndex];
            string columName= currentColum.Name;

            if("depositMoney".Equals(columName) || "depositInsure".Equals(columName) || "totalMoney".Equals(columName) )
            {
                var value = this.listDataGriddView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if(value!=null && value.ToString().EndsWith("."))
                {
                    this.listDataGriddView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.ToString().Substring(0, value.ToString().Length - 1);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploadForm upload = new UploadForm(GetSelectType(), "文件|*.jpg;*.png;*bpm,*pdf;*PDF");
            DialogUtil.ShowDialog(upload, this, 800, 500, new FormWindowProp(false, false, FormBorderStyle.FixedSingle));
        }

        /// <summary>
        ///  下拉框信息[原经营异常名录==》变为企业信用查询报告 严重违法企业名单==》该类型删除]
        /// </summary>
        /// <returns></returns>
        private List<ComboBoxVo> GetSelectType()
        {
            List<ComboBoxVo> list = new List<ComboBoxVo>();
            ComboBoxVo v0 = new ComboBoxVo("请选择", "");
            ComboBoxVo v1 = new ComboBoxVo("保单", "baodan", "文件|" + ConstantVo.FILE_TYPE_IMAGE_2);
            ComboBoxVo v3 = new ComboBoxVo("汇款", "huikuan", "文件|" + ConstantVo.FILE_TYPE_IMAGE_2);
            list.Add(v0);
            list.Add(v1);
            list.Add(v3);
            return list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfoList"></param>
        /// <param name="childCallBack">子页面回调方法</param>
        /// <returns></returns>
        public R CallBackUpload(List<FileInfoVo> fileInfoList, Action childCallBack)
        {
            R resultR = new R();
            try
            {
                //上传完了写入数据库
                FileInfoVo fileInfoVo = fileInfoList[0];

                currentDeposit.AttachId = fileInfoVo.EnclosureId;//附件id
                currentDeposit.VoucherCategory = fileInfoVo.AttachType;

                SysFileInfo sysFile = new SysFileInfo();
                ObjectUtil.CopyPop(fileInfoVo, ref sysFile);
                sysFile.Id = fileInfoVo.EnclosureId;


                //单纯的数据存储
                resultR = WebRequestUtil.PostBasicEntityDataApi(apiUpdateFile, currentDeposit);
                if (!resultR.Successful)
                {
                    MessageBox.Show(resultR.ResultHint, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return resultR;
                }

                //附件信息
                SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, SQLiteSqlUtils.CreateInsertSql(sysFile));

                SQLiteLibrary.ExcuteSql(SQLiteSqlUtils.CreateUpdateSql(currentDeposit,new string[] {"id"}));

                resultR.Successful = true;

                //重新加载数据
                LoadData(null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return resultR;
            }
            finally { }
            return resultR;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void voucherCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void Remark_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }

}*/