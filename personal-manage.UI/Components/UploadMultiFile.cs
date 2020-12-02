using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.vo;

namespace personal_manage.UI.Components
{
    public partial class UploadMultiFile : Form
    {

        public List<ComboBoxVo> selectType;
        
        // 通过弹窗工具类
        //public UploadCall successFunction;

        ///图片信息
        private List<SysFileInfo> fileList;

        private static string sqliteDbName = ConfigurationManager.AppSettings["sqliteDBName"].ToString();  //数据库名称
        private static string sqliteDbLocation = ConfigurationManager.AppSettings["sqliteDBLocation"].ToString(); //数据库存放路径


        //默认的上传类型==》图片
        public string filter = "文件 | *.png; *.jpg;";

        internal GridViewUploadProp viewUploadProp = new GridViewUploadProp();


        public string apiDelete = "public/deleteAttachs";


        public UploadMultiFile()
        {
            InitializeComponent();
        }

        private void UploadMultiFile_Load(object sender, EventArgs e)
        {
            FindSmallImages();

            //没有图片类型的选项
            if (selectType == null || selectType.Count <= 0)
            {
                Point point2 = this.groupBox1.Location;

                this.groupBox1.Visible = false;

                Point point3 = this.panel3.Location;
                point3.X = point2.X;
                this.panel3.Location = point3;
                return;
            }


            for (int i = 0; i < selectType.Count; i++)
            {
                this.typeComboBox.Items.Add(selectType[i]);
            }
            this.typeComboBox.SelectedIndex = 0;
            this.typeComboBox.ValueMember = "keyName";
        }

        /// <summary>
        ///  上传成功的回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadSuccessCall()
        {
            try
            {
                this.typeComboBox.Items.Clear();
                for (int i = 0; i < selectType.Count; i++)
                {
                    this.typeComboBox.Items.Add(selectType[i]);
                }
                this.typeComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
        }


        /// <summary>
        ///  查询已上传的缩略图
        /// </summary>
        private void FindSmallImages()
        {
           /* try
            {
                string fileSql = $"SELECT sys_file_info.* FROM sys_file_info where sys_file_info.RELATED_PAGE = '{viewUploadProp.CurrentRelatedPage}' and sys_file_info.RELATED_KEY = '{viewUploadProp.RelatedKey}' and sys_file_info.RELATED_ID = '{viewUploadProp.SelectDataId}'";
                fileList = SQLiteLibrary.SelectBySql<SysFileInfo>(sqliteDbLocation, sqliteDbName, fileSql);

                imageList1.Images.Clear();
                listView1.Items.Clear();

                string currentPath;
                for (int i = 0; i < fileList.Count; i++)
                {
                    currentPath = LocalFileUtil.GetPath(fileList[i].FilePath);
                    if (!File.Exists(currentPath))
                    {
                        imageList1.Images.Add(Properties.Resources.no_image1);
                    }
                    else
                    {
                        imageList1.Images.Add(Image.FromFile(currentPath));
                    }
                    //imageList1.Images.Add(Image.FromFile(currentPath));
                    listView1.Items.Add("", i);
                    listView1.Items[i].ImageIndex = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }


        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            /*try
            {
                string attachType = "";
                if (selectType != null && selectType.Count >= 0)
                {
                    ComboBoxVo selectComboBoxVo = (ComboBoxVo)this.typeComboBox.SelectedItem;
                    if ("".Equals(selectComboBoxVo.KeyValue) || selectComboBoxVo.KeyValue == null)
                    {
                        MessageBox.Show("请选择类型", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    filter = StringUtil.IsEmpty(selectComboBoxVo.ExtraField) ? filter : selectComboBoxVo.ExtraField;
                    attachType = selectComboBoxVo.KeyValue;
                }
                else
                {
                    attachType = viewUploadProp.AttachType;
                }

                DataGridView listDataGriddView = viewUploadProp.ListDataGriddView;

                R result = LocalFileUpLoad.CommonUpLoadNew(ref listDataGriddView, viewUploadProp.CurrentRelatedPage, attachType, viewUploadProp.Filter, viewUploadProp.SelectDataId, viewUploadProp.RelatedKey, viewUploadProp.ColumnIndex, null);

                //插入记录
                if (result.Successful)
                {
                    SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, SQLiteSqlUtils.CreateInsertSql((SysFileInfo)result.ResultValue));
                }

                //不是关闭上传触发的
                if (successFunction != null && result.Code != 204)
                {
                    //更新附件信息
                    FindSmallImages();
                    *//* SysFileInfo sysFileInfo = (SysFileInfo)result.ResultValue;
                     imageList1.Images.Add(Image.FromFile(LocalFileUtil.GetPath(sysFileInfo.FilePath)));
                     listView1.Items.Add("", listView1.Items.Count);
                     listView1.Items[listView1.Items.Count - 1].ImageIndex = listView1.Items.Count - 1;*//*
                    successFunction.Invoke(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*try
            {

                ListView.ListViewItemCollection listCollection = this.listView1.Items;

                *//* ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;*//*
                List<SysFileInfo> sysFiles = new List<SysFileInfo>();

                TransferEntityVo<object> transferEntityVo = new TransferEntityVo<object>();
                List<string> idList = new List<string>();

                for (int i = 0; i < listCollection.Count; i++)
                {
                    //是否被选中
                    if (listCollection[i].Selected)
                    {
                        idList.Add(fileList[i].Id);
                        fileList[i].RelatedId = "";
                        sysFiles.Add(fileList[i]);
                    }
                }

                if (sysFiles.Count <= 0)
                {
                    MessageBox.Show("请至少选择一条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                transferEntityVo.Ids = idList.ToArray();
                R r = WebRequestUtil.PostBasicEntityDataApi(apiDelete, transferEntityVo);
                if (!r.Successful)
                {
                    MessageBox.Show(r.ResultHint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateSql = SQLiteSqlUtils.CreateSelectUpdateSql(sysFiles, new string[] { "relatedId" }, new string[] { "id" });
                SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, updateSql);
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindSmallImages();
                if (successFunction != null)
                {
                    successFunction.Invoke(new R() { Successful = true, Code = 300 });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/

        }
    }
}
