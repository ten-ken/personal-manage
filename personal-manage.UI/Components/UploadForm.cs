using System;
using System.Collections.Generic;
using System.Windows.Forms;
using personal_manage.Common.vo;

namespace personal_manage.UI.Components
{
    public partial class UploadForm : Form
    {
        public List<ComboBoxVo> selectType;

        //默认的上传类型==》图片
        public string filter = "文件 | *.png; *.jpg;";

        public UploadForm()
        {
            InitializeComponent();
        }

        public UploadForm(List<ComboBoxVo> list)
        {
            this.selectType = list;          
            InitializeComponent();
        }

        public UploadForm(List<ComboBoxVo> list,string fileFilter)
        {
            this.selectType = list;
            this.filter = fileFilter;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            catch (Exception ex){
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            //this.typeComboBox.Height = 80;
            //this.typeComboBox.DataSource = selectType;
            for (int i = 0; i < selectType.Count; i++)
            {
                this.typeComboBox.Items.Add(selectType[i]);
            }

            this.typeComboBox.SelectedIndex = 0;
            this.typeComboBox.ValueMember = "keyName";
        }

        /// <summary>
        /// 点击上传按钮进行上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            /*try {
                ComboBoxVo selectComboBoxVo = (ComboBoxVo)this.typeComboBox.SelectedItem;
                if ("".Equals(selectComboBoxVo.KeyValue) || selectComboBoxVo.KeyValue == null)
                {
                    MessageBox.Show("请选择类型", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                filter = StringUtil.IsEmpty(selectComboBoxVo.ExtraField) ? filter : selectComboBoxVo.ExtraField;
              

                FileInfoVo fileInfoVo = LocalFileUpLoad.UpLoadFile(filter, selectComboBoxVo.KeyValue,null);

                if (fileInfoVo != null)
                {
                  //  this.txtUploadFilePath.Text = fileInfoVo.FilePath;
                    List<FileInfoVo> list = new List<FileInfoVo>();
                    list.Add(fileInfoVo);

                    UploadCommonIFS uploadCommonIFS = (UploadCommonIFS)this.Owner;
                    R r = uploadCommonIFS.CallBackUpload(list, uploadSuccessCall);
                    if (r.Successful)
                    {
                        MessageBox.Show("上传成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        //this.Close();// 让他手动关闭窗口
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
