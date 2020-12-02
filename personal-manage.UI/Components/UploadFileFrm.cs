using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace personal_manage.UI.Components
{
    public partial class UploadFileFrm : Form
    {
        private string tag;

        private string filter;

        private Action<object, EventArgs> btnUploadClick;

        public UploadFileFrm()
        {
            InitializeComponent();
        }

        public UploadFileFrm(string tag,string filter)
        {
            InitializeComponent();
            this.tag = tag;
            this.filter = filter;
        }


        public UploadFileFrm(string tag, string filter, Action<object, EventArgs> btnUploadClick) : this(tag, filter)
        {
            this.btnUploadClick = btnUploadClick;
        }

        private void UploadBidFrm_Load(object sender, EventArgs e)
        {

        }

        private void txtEncrypt_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExt1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.filePath.Text = fileName;
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.filePath.Text))
            {
  
                MessageBox.Show("请先选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*if (this.Owner is ZbFileUpload)
            {
                ZbFileUpload zbFileUpload = (ZbFileUpload)this.Owner;
                zbFileUpload.FilePath = this.filePath.Text;
            }
            btnUploadClick.Invoke(null,null);*/
        }
    }
}
