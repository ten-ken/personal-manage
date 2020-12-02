using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class FormTemAdd : Form
    {
        private CodeProjectInfo codeProjectInfo;

        private CodeProjectTemplateConfigInfo codeProjectTemplateConfigInfo = new CodeProjectTemplateConfigInfo();

        private CodeProjectTemplateConfigInfoBLL codeProjectTemplateConfigInfoBLL = new CodeProjectTemplateConfigInfoBLL();

        //页面文件后缀名
        private static string viewSuffix = ConfigurationManager.AppSettings["viewSuffix"].ToString();

        //c#/java/python等文件后缀名
        private static string hdSuffix = ConfigurationManager.AppSettings["hdSuffix"].ToString();

        public FormTemAdd()
        {
            InitializeComponent();
        }  
        
        public FormTemAdd(CodeProjectInfo codeProjectInfo,int ID)
        {
            this.codeProjectInfo = codeProjectInfo;
            codeProjectTemplateConfigInfo.ID = ID;
            InitializeComponent();
        }

        private void FormTemAdd_Load(object sender, EventArgs e)
        {

            string[] suffixArr = (viewSuffix+","+ hdSuffix).Split(new char[] { ',' });
            ComboBox comboBox = null;
            for (int i = 0; i < suffixArr.Length; i++)
            {
                this.suffix.Items.Add(suffixArr[i]);
            }

            //codeProjectInfo.PRO_SITE
            codeProjectTemplateConfigInfo.TemplatePath = Path.Combine("{projectSite}", "my_code\\{tableName}");
            //this.templatePath.Text = Path.Combine(codeProjectInfo.PRO_SITE, "my_code/{tableName}");
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CodeProjectTemplateConfigInfo> lists = codeProjectTemplateConfigInfoBLL.SelectList(codeProjectTemplateConfigInfo, null, "ID", WhereType.Columns);

                if (lists != null && lists.Count > 0)
                {
                    codeProjectTemplateConfigInfo = lists[0];
                }
                else
                {
                    codeProjectTemplateConfigInfo.TemplateContent = this.templateContent.Text??"";
                }
                FormHelp.SetControlsByEntity(codeProjectTemplateConfigInfo, this.panel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CodeProjectTemplateConfigInfo saveItem = FormHelp.GetEntityByControls<CodeProjectTemplateConfigInfo>(this.panel1);
                saveItem.ID = codeProjectTemplateConfigInfo.ID;
                saveItem.ProjectId = codeProjectInfo.ID;

                VerifyMessage verifyMessage = VerifyUtil.Verify(saveItem);
                if (verifyMessage.ExistError)
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                R r = codeProjectTemplateConfigInfoBLL.SaveOrUpdateBySelf(saveItem, null, false);

                if (r.Successful)
                {
                    string msg = saveItem.ID <= 0 ? "新增" : "修改";
                    MessageBox.Show($"{msg}成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();

                    //更新列表页
                    if (this.Owner is FormTemList)
                    {
                        ((FormTemList)this.Owner).LoadData();
                    }
                    this.Hide();
                    this.Dispose(true);
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

        private void CopyTemName_Click(object sender, EventArgs e)
        {
            this.overlayName.Text = this.templateName.Text;
        }
    }
}
