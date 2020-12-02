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
using personal_manage.Common.constant;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.Models.entity;

namespace personal_manage.UI.CsharpAuto
{
    public partial class FormDbConfig : Form
    {

        private CodeProjectDbConfigInfoBLL codeProjectDbConfigInfoBLL = new CodeProjectDbConfigInfoBLL();

        private CodeProjectDbConfigInfo codeProjectDbConfigInfo = new CodeProjectDbConfigInfo();

        private CodeProjectInfo codeProjectInfo;

        public FormDbConfig()
        {
            InitializeComponent();
        }

        public FormDbConfig(CodeProjectInfo codeProjectInfo)
        {
            this.codeProjectInfo = codeProjectInfo;
            InitializeComponent();
        }

        private void FormDbConfig_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(190, 248, 174);
            this.BackColor = Color.FromName("InactiveCaption");
            InitCompValueAndStyle();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                codeProjectDbConfigInfo.ProjectId = codeProjectInfo.ID;
                List<CodeProjectDbConfigInfo> lists = codeProjectDbConfigInfoBLL.SelectList(codeProjectDbConfigInfo,null, "ProjectId", WhereType.Columns);
            
                if(lists!=null && lists.Count > 0)
                {
                    codeProjectDbConfigInfo = lists[0];
                }

                //CacheHelper.RemoveCacheByKey(CacheConstant.DBCONFIG);
                //缓存7天
                CacheHelper.SetCache(CacheConstant.DBCONFIG, codeProjectDbConfigInfo,60*60*24*7);

                FormHelp.SetControlsByEntity(codeProjectDbConfigInfo, this.panel1);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  初始化组件的值和样式
        /// </summary>
        private void InitCompValueAndStyle()
        {
            List<ComboBoxVo> dbComboxs = new List<ComboBoxVo>();
            ComboBoxVo comboBoxVo1 = new ComboBoxVo("请选择","");
            ComboBoxVo comboBoxVo2 = new ComboBoxVo("Mysql", "Mysql");
            ComboBoxVo comboBoxVo3 = new ComboBoxVo("Oracle", "Oracle");
            ComboBoxVo comboBoxVo4 = new ComboBoxVo("SQLServer", "SQLServer");
            ComboBoxVo comboBoxVo5 = new ComboBoxVo("Sqlite", "Sqlite");
            dbComboxs.Add(comboBoxVo1);
            dbComboxs.Add(comboBoxVo2);
            dbComboxs.Add(comboBoxVo3);
            dbComboxs.Add(comboBoxVo4);
            dbComboxs.Add(comboBoxVo5);
            this.DbType.DataSource = dbComboxs;
            this.DbType.DisplayMember = "keyName";
            this.DbType.ValueMember = "keyValue";
        }

        private void dbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(this.DbType.SelectedItem is ComboBoxVo))
            {
                return;
            }


            ComboBoxVo comboBoxVo = (ComboBoxVo)this.DbType.SelectedItem;
            if(comboBoxVo.KeyValue== "Sqlite")
            {
                this.DbConnect.Text = $@"data source=sqlite文件具体位置";
            }
            else if (comboBoxVo.KeyValue == "Mysql")
            {
                this.DbConnect.Text = $@"server=ip地址;port=端口号;database=数据库;user=账号;password=密码";
            }
            else if (comboBoxVo.KeyValue == "Oracle")
            {
                //this.DbConnect.Text = $@"Provider=OraOLEDB.Oracle.1;User ID=IFSAPP;Password=IFSAPP;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.201)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = RACE)))";
                this.DbConnect.Text = $@"Provider=OraOLEDB.Oracle.1;User ID=map2020;Password=map2020;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.201)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = ORCL)))";
            }
            else if (comboBoxVo.KeyValue == "SQLServer")
            {

            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CodeProjectDbConfigInfo saveItem = FormHelp.GetEntityByControls<CodeProjectDbConfigInfo>(this.panel1);
                saveItem.ID = codeProjectDbConfigInfo.ID;
                saveItem.ProjectId = codeProjectInfo.ID;

                VerifyMessage verifyMessage = VerifyUtil.Verify(saveItem);
                if (verifyMessage.ExistError)
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                R r= codeProjectDbConfigInfoBLL.SaveOrUpdate(saveItem, null,false,null);

                if (r.Successful)
                {
                    string msg = saveItem.ID <= 0 ? "新增" : "修改";
                    MessageBox.Show($"{msg}成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(r.ResultHint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
