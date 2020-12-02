using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.BLL.adapter;
using personal_manage.BLL.Base;
using personal_manage.BLL.Sys;
using personal_manage.Common.constant;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.util;
using personal_manage.Common.vo;
using personal_manage.Models.entity;
using personal_manage.UI.Components;

namespace personal_manage.UI.CsharpAuto
{
    public partial class FormCreate : Form
    {
        /// <summary>
        /// 数据库业务处理 --
        /// </summary>
        private DbBLL dbBLL = new DbBLL();

        /// <summary>
        /// sqlite 数据库业务处理
        /// </summary>
        private CreateBLL createBLL =new CreateBLL();

        private CodeProjectDbConfigInfo codeProjectDbConfigInfo = new CodeProjectDbConfigInfo();

        private CodeProjectInfo codeProjectInfo;

        /// <summary>
        ///  弹窗
        /// </summary>
        public static DialogForm dialogForm;


        /// <summary>
        /// 表名字典
        /// </summary>
        public static Dictionary<string,TableInfo> tablesDicts = new Dictionary<string, TableInfo>();

        public FormCreate()
        {
            InitializeComponent();
        }

        public FormCreate(CodeProjectInfo codeProjectInfo)
        {
            this.codeProjectInfo = codeProjectInfo;
            InitializeComponent();
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(190, 248, 174);
            this.BackColor = Color.FromName("InactiveCaption");
            //显示滚动条
            this.panel2.AutoScroll = true;
            this.panel2.VerticalScroll.Visible = true;//竖的
            this.panel2.AutoScrollMinSize = new Size() { Width = 853, Height = 216 };
            this.panel2.VerticalScroll.Value = this.panel1.VerticalScroll.Minimum;
            //设置panel垂直滚动条到后
            this.panel2.VerticalScroll.Value = this.panel1.VerticalScroll.Maximum;

            //默认值
            this.AUTHOR.Text = codeProjectInfo.AUTHOR;
            this.TOP_LEVEL.Text = codeProjectInfo.TOP_LEVEL;

            //InitCompValueAndStyle();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                object obj = CacheHelper.GetCache(CacheConstant.DBCONFIG);
                if (obj != null)
                {
                    codeProjectDbConfigInfo = (CodeProjectDbConfigInfo)obj;
                }
                
                if(codeProjectDbConfigInfo.DbType == "Sqlite")
                {
                    SetPannelTablesBySqlite();
                }else
                {
                    SetPannelTables(keyWord.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SetPannelTables(string tableKeyword)
        {
            List<TableInfo> lists = dbBLL.SelectTableList(codeProjectDbConfigInfo, tableKeyword);
            CheckBox checkBox;

            int defaultX = 10;
            int x = 0;
            int y = 0;

            int curRow = 0;
            this.panel2.Controls.Clear();

            tablesDicts = new Dictionary<string, TableInfo>();
            for (int i = 0; i < lists.Count; i++)
            {
                curRow = (int)(i / 3) + 1;//一行最多4个

                if ((curRow - 1) * 3 == i)//换行时  第一位x坐标保存一致
                {
                    x = defaultX;
                }
                else
                {
                    x += 290;
                }

                y = (curRow - 1) * 25 + 25; //只有换行了  y轴才有变化

                checkBox = new CheckBox();
                checkBox.Click += CheckBox_Click;
                checkBox.Location = new Point(x, y);
                checkBox.Font = new Font("宋体",13);
                //checkBox.Tag = i;
                checkBox.Size = new Size(290, 25);
                checkBox.Text = lists[i].TableName;
                //dataTable.Rows[i].Field<string>("name");
                tablesDicts.Add(lists[i].TableName, lists[i]);
                this.panel2.Controls.Add(checkBox);
            }

        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            StringBuilder sbf = new StringBuilder();
            string txt = tableNames.Text ?? "";
            if (checkBox.CheckState == CheckState.Checked)
            {
                sbf.Append(string.IsNullOrEmpty(txt)? "" : $"{txt},");
                sbf.Append($"{checkBox.Text}");
            }
            else
            {
                sbf.Append(txt.Replace($",{checkBox.Text}","").Replace($"{checkBox.Text}", ""));
            }
            tableNames.Text = sbf.ToString().StartsWith(",")? sbf.ToString().Substring(1): sbf.ToString();
        }

        private void SetPannelTablesBySqlite()
        {

            List<TableInfo> lists = dbBLL.SelectTableList(codeProjectDbConfigInfo, keyWord.Text);
                //createBLL.SelectData(sqlAllTable);
            CheckBox checkBox;

            int defaultX = 10;
            int x = 0;
            int y = 0;

            int curRow = 0;

            for (int i = 0; i < lists.Count; i++)
            {
                curRow = (int)(i / 3) + 1;//一行最多4个

                if ((curRow - 1) * 3 == i)//换行时  第一位x坐标保存一致
                {
                    x = defaultX;
                }
                else
                {
                    x += 290;
                }

                y = (curRow - 1) * 25 + 25; //只有换行了  y轴才有变化

                checkBox = new CheckBox();
                checkBox.Click += CheckBox_Click;
                checkBox.Location = new Point(x, y);
                checkBox.Font = new Font("宋体", 13);
                checkBox.Tag = curRow;
                checkBox.Size = new Size(290, 25);
                checkBox.Text = lists[i].TableName;
                this.panel2.Controls.Add(checkBox);
            }
        }

       
     

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string temSql = $"select * from CODE_PROJECT_TEMPLATE_CONFIG_INFO where PROJECT_ID ='{codeProjectInfo.ID}'";
                DataTable dataTable1 = createBLL.SelectData(temSql);

                List<CodeProjectTemplateConfigInfo> templateConfigInfos = DbConvert.TableToList<CodeProjectTemplateConfigInfo>(dataTable1);

                if (string.IsNullOrEmpty(this.tableNames.Text))
                {
                    MessageHelper.ShowWarn("表名不能为空，至少选择一个表");
                    return;
                }

                if (string.IsNullOrEmpty(this.TOP_LEVEL.Text))
                {
                    MessageHelper.ShowWarn("顶级包名不能为空");
                    return;
                }
                if (templateConfigInfos==null || templateConfigInfos.Count <= 0)
                {
                    MessageHelper.ShowWarn("未检出到任何模板");
                    return;
                }

                string[] tableArr = this.tableNames.Text.Split(',');
                List<CsProjectCode> projectCodes = new List<CsProjectCode>();
                List<TableFieldInfo> lists = null;
                CsProjectCode csProjectCode = null;
                CodeProjectInfo codeProjectInfoEdit = null;

                if (this.TopLevelControl is AutoCodeConfigForm)
                {
                    codeProjectInfoEdit = ((AutoCodeConfigForm)this.TopLevelControl).GetTopTextBoxInfo();
                }

                string outFileFolder="",outFilePath,projectCodePath="";
                Dictionary<string, object> dicKv;
                StringBuilder sbf = new StringBuilder();
                string projectSite = null;
                for (int i = 0; i < tableArr.Length; i++)
                {
                   

                    csProjectCode = new CsProjectCode(tableArr[i]) { Author = AUTHOR.Text,TopLevel = TOP_LEVEL.Text,Version= codeProjectInfo.VERSION};

                    lists = dbBLL.SelectTableFields(codeProjectDbConfigInfo, tableArr[i]);
                    csProjectCode.TableFieldInfos = lists;
                    projectCodes.Add(csProjectCode);
                    dicKv = new Dictionary<string, object>();

                    dicKv.Add("tableName", csProjectCode.TableName);//表名
                    if (tablesDicts.ContainsKey(csProjectCode.TableName))
                    {
                        dicKv.Add("tableComment", tablesDicts[csProjectCode.TableName].TableComment);//表备注
                    }
                    dicKv.Add("entityName", csProjectCode.EntityName);//实体名
                    dicKv.Add("projectCode", csProjectCode);//项目表信息
                    if (codeProjectInfoEdit != null)
                    {
                        dicKv.Add("projectName", codeProjectInfoEdit.PRO_NAME);//项目名称
                        projectSite = codeProjectInfoEdit.PRO_SITE;
                    }

                    for (int k = 0; k < templateConfigInfos.Count; k++)
                    {
                        projectCodePath = projectSite ?? codeProjectInfo.PRO_SITE;
                            //templateConfigInfos[k].TemplatePath.Replace("{tableName}", "");
                        outFileFolder = templateConfigInfos[k].TemplatePath.Replace("{projectSite}", projectCodePath).Replace("{tableName}", csProjectCode.EntityName);
                        outFilePath = Path.Combine(outFileFolder, $"{csProjectCode.EntityName}{templateConfigInfos[k].OverlayName}{templateConfigInfos[k].Suffix}");
                        NvelocityUtil.WriteTemplateByString(outFilePath, templateConfigInfos[k].TemplateContent, dicKv);
                        sbf.Append($"表:{csProjectCode.TableName}  ,模板【{templateConfigInfos[k].TemplateName}{templateConfigInfos[k].Suffix}】生成成功\n");
                    }

                }

                MessageHelper.ShowSuccess(sbf.ToString());
                //MessageHelper.ShowSuccess("生成完毕");
                this.codeFolder.Text = projectCodePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 开启多线程
        /// </summary>
        private void AsyMessage()
        {
            /*if (dialogForm != null)
            {
                dialogForm.ShowDialog();
            }*/
         
        }

        /// <summary>
        ///  关闭
        /// </summary>
        private static void CloseAsyMessage()
        {
            //上传等待取消
            if (dialogForm != null)
            {
                dialogForm.Close();
                dialogForm.Dispose();
            }
        }

        /// <summary>
        /// 打开生成文件位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(codeFolder.Text))
                {
                    MessageBox.Show("路径不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Directory.Exists(codeFolder.Text))
                {
                    MessageBox.Show("路径暂时没有生成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Process.Start("explorer.exe", Path.Combine(codeFolder.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  清除文本表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTables_Click(object sender, EventArgs e)
        {
            this.tableNames.Clear();

            Control.ControlCollection controlCollection = this.panel2.Controls;
            for (int i = 0; i < controlCollection.Count; i++)
            {
                if(controlCollection[i] is CheckBox)
                {
                    ((CheckBox)controlCollection[i]).Checked = false;
                    ((CheckBox)controlCollection[i]).CheckState = CheckState.Unchecked;
                }
            }

        }
    }
}
