using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ess_zbfz_main.commonForm;
using personal_manage.BLL.Sys;
using personal_manage.Common.dto;
using personal_manage.Common.util;
using personal_manage.Models.entity;

namespace personal_manage.UI
{
    public partial class CodeProjectAdd : Form
    {

        private CodeProjectInfoBLL codeProjectInfoBLL = new CodeProjectInfoBLL();

        private CodeProjectInfo codeProjectInfo = new CodeProjectInfo();

        //页面文件后缀名
        private static string viewSuffix = ConfigurationManager.AppSettings["viewSuffix"].ToString(); 

        //c#/java/python等文件后缀名
        private static string hdSuffix = ConfigurationManager.AppSettings["hdSuffix"].ToString(); 


        //默认配置路径
        private string autoConfigPath = "autocode\\config";

        //默认模板文件路径
        private string autoTemPath = "autocode\\temp";

        //自动生成代码根路径 相对路径
        private string autoPath = "autocode";

        public CodeProjectAdd()
        {
            InitializeComponent();
        }

        public CodeProjectAdd(int ID)
        {
            codeProjectInfo.ID = ID;
            InitializeComponent();
            this.VIEW_SUFFIX.Items.Clear();
            this.HD_SUFFIX.Items.Clear();

            string[] viewSuffixArr = viewSuffix.Split(new char[] { ',' });
            ComboBox comboBox = null;
            for (int i = 0; i < viewSuffixArr.Length; i++)
            {
                this.VIEW_SUFFIX.Items.Add(viewSuffixArr[i]);
            }
        

            string[] hdSuffixArr = hdSuffix.Split(new char[] { ',' });
            for (int i = 0; i < hdSuffixArr.Length; i++)
            {
                this.HD_SUFFIX.Items.Add(hdSuffixArr[i]);
            }

        }

       

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CodeProjectInfo codeProjectInfo = FormHelp.GetEntityByControls<CodeProjectInfo>(this.panel1);
                codeProjectInfo.ID = this.codeProjectInfo.ID;
                VerifyMessage verifyMessage = VerifyUtil.Verify(codeProjectInfo);
                if (verifyMessage.ExistError)
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                R r = codeProjectInfoBLL.SaveOrUpdateBySelf(codeProjectInfo, null, false);

                if (r.Successful)
                {
                    MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();               
                    //更新列表页
                    if(this.Owner is CodeProjectList)
                    {
                        ((CodeProjectList)this.Owner).LoadData();
                    }
                }
                else
                {
                    MessageBox.Show(r.ResultHint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private void CreateCode_Load(object sender, EventArgs e)
        {
            FormHelp.SetRequireLabel(this.panel1,true,-1,true, "label13", "label14", "label16", "labelbb");
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (codeProjectInfo.ID> 0)
                {
                    List<CodeProjectInfo> lists = codeProjectInfoBLL.SelectList(codeProjectInfo, null, "ID", Common.enums.WhereType.Columns);
                    if (lists != null && lists.Count > 0)
                    {
                        codeProjectInfo = lists[0];
                    }
                }
                else
                {
                    string templatePath = Path.Combine(@System.AppDomain.CurrentDomain.BaseDirectory, autoTemPath);
                    codeProjectInfo.TEMPLATE_FOLDER = templatePath;
                    //this.TEMPLATE_FOLDER.Text = templatePath;
                }
               
                this.BtnCreate.Visible = codeProjectInfo.ID > 0;
                FormHelp.SetControlsByEntity(codeProjectInfo, this.panel1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 生成配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CodeProjectInfo codeProjectInfo = FormHelp.GetEntityByControls<CodeProjectInfo>(this.panel1);
                VerifyMessage verifyMessage = VerifyUtil.Verify(codeProjectInfo);
                if (verifyMessage.ExistError)
                {
                    MessageBox.Show(verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Type type = codeProjectInfo.GetType();
                System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
                StringBuilder sbf = new StringBuilder();
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    if (propertyInfos[i].Name != "ID")
                    {
                        if( propertyInfos[i].Name == "JAVAFODER"
                            || propertyInfos[i].Name == "VIEWFOLDER"
                            || propertyInfos[i].Name == "PRO_SITE")
                        {
                            sbf.Append($"{propertyInfos[i].Name}={propertyInfos[i].GetValue(codeProjectInfo).ToString().Replace("\\","\\\\")}\r\n");
                        }else if(propertyInfos[i].Name == "TEMPLATE_FOLDER")
                        {
                            sbf.Append($"{propertyInfos[i].Name}={propertyInfos[i].GetValue(codeProjectInfo).ToString().Replace("\\", "\\\\")+"\\\\"}\r\n");
                        }
                        else
                        {
                            sbf.Append($"{propertyInfos[i].Name}={propertyInfos[i].GetValue(codeProjectInfo)}\r\n");
                        }
                    }
                }
                string configPath = Path.Combine(@System.AppDomain.CurrentDomain.BaseDirectory, autoConfigPath);
                configPath = Path.Combine(configPath, "basic.properties");
                File.WriteAllText(configPath, sbf.ToString());

                //调用bat命令
                string targetDir = Path.Combine(@System.AppDomain.CurrentDomain.BaseDirectory, autoPath);
                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "命令.bat";
                proc.StartInfo.Arguments = string.Format("30");
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

 
        /// <summary>
        /// 选择路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Select(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox.Text;
            //RootFolder
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = fbd.SelectedPath;
            }
        }


        /// <summary>
        /// 显示参考图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCkt_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(@System.AppDomain.CurrentDomain.BaseDirectory, "Images\\CKT.png");
                PicturePreview formT = new PicturePreview(filePath);
                DialogUtil.ShowDialog(formT, this, formT.Width+300, formT.Height + 300, new Common.prop.FormWindowProp(false, false, FormBorderStyle.FixedDialog));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        /// <summary>
        ///  打开项目位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PRO_SITE.Text))
                {
                    MessageBox.Show("项目路径不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Directory.Exists(PRO_SITE.Text))
                {
                    MessageBox.Show("项目路径暂时没有生成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Process.Start("explorer.exe", Path.Combine(PRO_SITE.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
        }

        private void VIEW_SUFFIX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TEMPLATE_FOLDER_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
