using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.jysoft.ess.zbfz.entity;
using personal_manage.BLL.Sys;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.util;

namespace personal_manage.UI.Mytools
{
    public partial class AccoutEncFrm : Form
    {
        string key = "17656328";

        string iv = "19861956";

        private AppAccountMgnBLL appAccountMgnBLL = new AppAccountMgnBLL();

        private AppAccountMgn appAccountMgn = new AppAccountMgn();

        private int downTime = 60;//60秒

        public Action RefeshParentWindow;

        public AccoutEncFrm()
        {
            InitializeComponent();
        }

        public AccoutEncFrm(AppAccountMgn appAccountMgn)
        {
            this.appAccountMgn = appAccountMgn;
            InitializeComponent();
        }

        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AppAccountMgn saveItem = FormHelp.GetEntityByControls<AppAccountMgn>(this.panel1);
                if (!string.IsNullOrEmpty(appAccountMgn.MGNPWD))
                {
                   DialogResult dialogResult = MessageBox.Show("是否以原管理密码保存", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                   if(dialogResult== DialogResult.OK)
                    {
                        saveItem.MGNPWD = appAccountMgn.MGNPWD;
                    }
                }

                VerifyMessage verifyMessage = VerifyUtil.Verify(saveItem);

                
                if (saveItem.JiaoyanPwd != saveItem.InputPwd)
                {
                    verifyMessage.ExistError = true;
                    verifyMessage.ErrorInfo += "\n两次输入密码不一致,请重新输入";
                }


                if (verifyMessage.ExistError)
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } 

                //string iv = saveItem.ACCOUNT.ToString().PadLeft(8, 'u');
                string enc = DesHelper.DESEncrypt(saveItem.InputPwd, key, iv);
                this.ENCPWD.Text = enc;//真实密码
                saveItem.ENCPWD = enc;//真实密码

                saveItem.PSEUDOCODE = Md5Util.Md5(enc);//掩码
                this.PSEUDOCODE.Text = saveItem.PSEUDOCODE;

                R r = appAccountMgnBLL.SaveOrUpdateBySelf(saveItem, null, false);

                if (r.Successful)
                {
                    string msg = saveItem.ID <= 0 ? "新增" : "修改";
                    MessageBox.Show($"{msg}成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();

                    //更新列表页
                    if (this.Owner is AccoutEncFrmList)
                    {
                        ((AccoutEncFrmList)this.Owner).LoadData();
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
                MessageHelper.ShowError(ex);
            }
            
        }

        public void LoadData()
        {
            try
            {
                AppAccountMgn selectItem = new AppAccountMgn();
                selectItem.ID = appAccountMgn.ID;

                List<AppAccountMgn> lists = appAccountMgnBLL.SelectList(selectItem, null, "ID", WhereType.Columns);
                
                if(lists != null  && lists.Count > 0)
                {
                    appAccountMgn = lists[0];
                    //加密码和管理密码不对外展示
                    ObjectUtil.CopyPop(appAccountMgn,ref selectItem, "ENCPWD", "MGNPWD");
                    FormHelp.SetControlsByEntity(selectItem, this.panel1);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void AccoutEncFrm_Load(object sender, EventArgs e)
        {

            if (appAccountMgn.ID > 0)
            {
                this.DesButton.Visible = true;
                //this.SaveBtn.
            }
            else
            {
                this.DesButton.Visible = false;
            }


            LoadData();
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.MGNPWD.Text))
                {
                    MessageHelper.ShowWarn("管理密码不能为空");
                    return;
                }


                if (appAccountMgn.MGNPWD != this.MGNPWD.Text)
                {
                    MessageHelper.ShowWarn("管理密码不正确");
                    return;
                }
                else
                {
                    //string iv = this.ACCOUNT.Text.PadLeft(8, 'u');
                    string des = DesHelper.DESDecrypt(appAccountMgn.ENCPWD, key, iv);
                    this.InputPwd.Text = des;
                    this.InputPwd.PasswordChar = new char();

                    downTime = 60;
                    timer1.Enabled = true;
                    this.timer1.Interval = 1000;
                    this.timer1.Tick+= DownTimeHide;
                    this.timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        /// <summary>
        ///  倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownTimeHide(object sender, EventArgs e)
        {
            try
            {
                this.label6.Visible = true;
                this.label6.Text = string.Format("倒计时显示:{0}s", downTime);
                if (downTime <= 0)
                {
                    this.timer1.Stop();
                    this.label6.Text ="";
                    this.InputPwd.PasswordChar = '*';
                    //this.InputPwd.Text = "***reset***";
                    this.label6.Visible = false;
                }
                downTime--;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
