using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.util;
using personal_manage.Models.entity;

namespace personal_manage.UI.CsharpAuto
{
    public partial class AutoCodeConfigForm : Form
    {
        private CodeProjectInfo codeProjectInfo;

        public AutoCodeConfigForm()
        {
            InitializeComponent();
        }


        public AutoCodeConfigForm(CodeProjectInfo codeProjectInfo)
        {
            this.codeProjectInfo = codeProjectInfo;
            InitializeComponent();
        }

        private void AutoCodeConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                SetHeadInfo();

                DialogUtil.ShowTabContent(this.tabPageDbConfig, new FormDbConfig(codeProjectInfo), null);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }


        }

        private void SetHeadInfo()
        {
            try
            {
                this.PRO_NAME.Text = codeProjectInfo.PRO_NAME;
                this.AUTHOR.Text = codeProjectInfo.AUTHOR;
                this.PRO_SITE.Text = codeProjectInfo.PRO_SITE;
                this.TOP_LEVEL.Text = codeProjectInfo.TOP_LEVEL;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string currentTabName = this.tabControl1.SelectedTab.Name;
                Form formTab = null;
                //数据库配置
                if (currentTabName == "tabPageDbConfig")
                {
                    formTab = new FormDbConfig(codeProjectInfo);
                    DialogUtil.ShowTabContent(this.tabPageDbConfig, formTab, null);
                }
                //模板配置列表
                else if (currentTabName == "tabPageTemplate")
                {
                    formTab = new FormTemList(codeProjectInfo);
                    DialogUtil.ShowTabContent(this.tabPageTemplate, formTab, null);
                }
                //其他配置和代码生成
                else if (currentTabName == "tabPageCreate")
                {
                    formTab = new FormCreate(codeProjectInfo);
                    DialogUtil.ShowTabContent(this.tabPageCreate, formTab, null);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        /// <summary>
        ///  获取顶部信息
        /// </summary>

        public CodeProjectInfo GetTopTextBoxInfo()
        {
            CodeProjectInfo codeProjectInfo1 = null;
            try
            {
                 codeProjectInfo1 = FormHelp.GetEntityByControls<CodeProjectInfo>(this.panel1);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
            return codeProjectInfo1;
        }


    }
}
