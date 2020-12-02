using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.dto;
using personal_manage.Common.util;
using personal_manage.Models.entity;
using personal_manage.Common.extendmethods;

namespace personal_manage.UI.Components
{
    public partial class ImportForm<T>: Form
    {

        private int firstIndex = 2;
        public int FirstIndex { get => firstIndex; set => firstIndex = value; }

        private string templateName = "";

        /// <summary>
        /// 导入事件
        /// </summary>
        public event EventHandler importEvent;

        /// <summary>
        /// 检验回调方法
        /// </summary>
        public Action<MessageInfo<T>> ImportCheck;

        public T t;

        

        private ImportForm()
        {
            InitializeComponent();
        } 
        
        public ImportForm(string templateName)
        {
            this.templateName = templateName;
            InitializeComponent();
            this.labelInfo.Visible = false;
        }

    

        private void ImportForm_Load(object sender, EventArgs e)
        {
            //this.SuccessCount.Click+=
        }



        /// <summary>
        ///  导出模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportTemplate_Click(object sender, EventArgs e)
        {
            LocalFileDownLoad.downLoadFile(templateName);
        }


        /// <summary>
        ///  导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (importEvent != null)
            {
                importEvent.Invoke(sender, e);
                return;
            }
            try
            {
                MessageInfo<T> messageInfo = ExcelUtil.ReadExcel<T>(firstIndex);

                if (messageInfo.ExistError)
                {
                    MessageBox.Show(messageInfo.ErrorInfo,
                               "提示",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                    return;
                }
                if (messageInfo.Record == null)
                {
                    return;
                }

                ImportCheck.Invoke(messageInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入项目文件错误信息：" + ex.Message);
            }

        }

        /// <summary>
        ///  导入后事件
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="count"></param>
        /// <param name="v2"></param>
        public void SetImportInfo(bool success, int successCount, int failCount)
        {
            try
            {

                this.SucessInfo.Text = $"{successCount} 条";
                this.FailInfo.Text = $"{failCount} 条";

                this.labelInfo.ForeColor = success ? Color.Green : Color.Red;
                this.labelInfo.Text = success ? "导入成功" : "导入失败";
                this.labelInfo.Visible = true;
            }
            catch (Exception)
            {
            }
        }


    }
}
