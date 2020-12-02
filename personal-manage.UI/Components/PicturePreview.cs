using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ess_zbfz_main.commonForm
{
    public partial class PicturePreview : Form
    {
        //文件地址
        public string filePath;


        public PicturePreview()
        {
            InitializeComponent();
        }

        public PicturePreview(string filePath)
        {
            this.filePath = filePath;          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PicturePreview_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Width = this.groupBox1.Width - 80; 
            this.pictureBox1.Height = this.groupBox1.Height - 40;
            this.pictureBox1.Image = GetImage(filePath);
        }


        public Image GetImage(string path)
        {
            try
            {
                // && FileUtil.IsImage(path)
                if (File.Exists(path))
                {
                    Image result = new Bitmap(path);
                    //result = new Bitmap(result, 300, 300);
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
            return null;
        }
    }
}
