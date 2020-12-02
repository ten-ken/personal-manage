using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.BLL.Purchase;
using personal_manage.Common.dto;
using personal_manage.Common.util;
using personal_manage.Models.entity;
using TX.Framework.WindowUI.Forms;

namespace personal_manage.UI
{
    //BaseForm
    public partial class FormDemoAdd : Form
    {
        private LogHelp log = new LogHelp(typeof(FormDemoAdd));

        //当前项目
        private OsZbPurchaseProjectInfo osZbPurchaseProjectInfo;

        //业务处理层
        private OsZbPurchaseProjectInfoBLL osZbPurchaseProjectInfoBLL =new OsZbPurchaseProjectInfoBLL();

        //刷新父页面
        public Action RefeshParentWindow { get; internal set; }

        public FormDemoAdd()
        {
            InitializeComponent();
        }

        public FormDemoAdd(OsZbPurchaseProjectInfo osZbPurchaseProjectInfo)
        {
            this.osZbPurchaseProjectInfo = osZbPurchaseProjectInfo;
            InitializeComponent();
        }

        private void FormDemoAdd_Load(object sender, EventArgs e)
        {
           
            FormHelp.SetRequireLabel(this.groupBox2,true,-3, true);
            LoadData();
        }

        private void LoadData()
        {
            if (osZbPurchaseProjectInfo != null)
            {
                FormHelp.SetControlsByEntity(osZbPurchaseProjectInfo, this.groupBox2);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 控件居中
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            FormHelp.ControlsToXCenter(this, this.groupBox2);
           /* //解决窗体第一次设置为最大化后，点击最大化按钮窗体无法居中问题
            int x = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Width - this.Width) * 0.5);
            int y = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Height - this.Height) * 0.5);
            this.SetBounds(x, y, this.Width, this.Height, BoundsSpecified.All);*/
        }

        private void txButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OsZbPurchaseProjectInfo projectInfo = FormHelp.GetEntityByControls<OsZbPurchaseProjectInfo>(this.groupBox2);
                osZbPurchaseProjectInfo = osZbPurchaseProjectInfo ?? new OsZbPurchaseProjectInfo();
                
                ObjectUtil.CopyPop(projectInfo, ref osZbPurchaseProjectInfo,"Id");

                VerifyMessage verifyMessage = VerifyUtil.Verify(osZbPurchaseProjectInfo);

                if (!string.IsNullOrWhiteSpace(verifyMessage.ErrorInfo))
                {
                    MessageBox.Show(verifyMessage.ErrorInfo,
                             "提示",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
                    return;                   
                }else if (!string.IsNullOrWhiteSpace(verifyMessage.PromptInfo))
                {
                    MessageBox.Show(verifyMessage.PromptInfo,
                                                "提示",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                }


                R result = osZbPurchaseProjectInfoBLL.SaveOrUpdate(osZbPurchaseProjectInfo, null, true, null);

                if (!result.Successful)
                {
                    MessageBox.Show(result.ResultHint,
                              "提示",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("操作成功",
                              "提示",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                    if (RefeshParentWindow != null)
                    {
                        RefeshParentWindow.Invoke();
                    }
                    this.Hide();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                log.AddLog(ex.Message,null);

                MessageBox.Show(ex.Message,
                             "提示",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void kenButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
