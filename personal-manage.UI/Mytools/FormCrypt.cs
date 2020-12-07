
using System;
using System.IO;
using System.Windows.Forms;
using personal_manage.Common.dto;
using personal_manage.Common.util;

namespace personal_manage.UI.Mytools
{
    public partial class FormCrypt : Form
    {
        //测试证书公钥证书base64字符串
        private string txtPublicKey = "MIIDjjCCAnagAwIBAgIFEwISWHIwDQYJKoZIhvcNAQEFBQAwITELMAkGA1UEBhMCQ04xEjAQBgNVBAoTCUNGQ0EgT0NBMTAeFw0yMDA5MDIwOTQwNDhaFw0yMzA5MDIwOTQwNDhaMH4xCzAJBgNVBAYTAmNuMRIwEAYDVQQKEwlDRkNBIE9DQTExDTALBgNVBAsTBFNHQ0MxFDASBgNVBAsTC0VudGVycHJpc2VzMTYwNAYDVQQDDC0wNDFATjkxMTExMTExMTExMTExMTExMUDmtYvor5Xor4HkuaZAMDAwMDAwMDEwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAIsycpcX5fxHDsXTrsC9vq307Opxlkn73U/1o1O19SShBuYlP/MMEqjsC7mdmYDisX7MYMFdt/HSh2x2VD4Vt/9oUffXjRBrL5I3tCcKPUIpiXSvXPNjYPGtMuapGbr20ubfKwarKEIVYHX32IX4bd3dynT6h4tX9p7+b7JrzxyNAgMBAAGjgfMwgfAwHwYDVR0jBBgwFoAU0dvpiILl3RqPTKoAjL588qsb9tkwSAYDVR0gBEEwPzA9BghggRyG7yoBATAxMC8GCCsGAQUFBwIBFiNodHRwOi8vd3d3LmNmY2EuY29tLmNuL3VzL3VzLTE0Lmh0bTA4BgNVHR8EMTAvMC2gK6AphidodHRwOi8vY3JsLmNmY2EuY29tLmNuL1JTQS9jcmwyNTM3MC5jcmwwCwYDVR0PBAQDAgPoMB0GA1UdDgQWBBRtmWLON7v/e2Ld8DoVj4NL03tbzjAdBgNVHSUEFjAUBggrBgEFBQcDAgYIKwYBBQUHAwQwDQYJKoZIhvcNAQEFBQADggEBAG1TftXLQk+fPT0mvk5UeOn+IQtkM/AY83cFbc8UxUaZvjgPntH1KLpiqBUzjGM8V5y5cZIfhtXmSNvWFxTixI2s9gn43/ONiAiq6nN/Tnifm/2QpyJTUdF9f4WNzfW7GyGLMl/e62/1TfgsxRpe3MTF/erQDSuKLYokNNdJuCtsGfC8QIsHHLB7LQv94csyg3L+YbZlWS03TWoZypV85vSTyMisyeEAuDmGlA0YzgW525y28Qzat75qcRjgg3YGJNXZ7Nx3CL2sfPKQtltrKB0tM3UAFo+32Oi2o13aYpMQR+kS4J1F2ktAl7648vzq5cK0xBbjNz/0oM401dKMs3o=";


        public FormCrypt()
        {
            InitializeComponent();
        }



        private void FrmCryptTest_Load(object sender, EventArgs e)
        {
   
        }
        //加密
        private void btnCryFile_Click(object sender, EventArgs e)
        {
            try
            {

                string outFile = Path.Combine(Path.GetDirectoryName(this.textBox1.Text), Path.GetFileName(this.textBox1.Text) + ".enc"); ;
                MySecurity mySecurity = new MySecurity();
                mySecurity.EncryptFile(this.textBox1.Text, outFile,"");
                MessageBox.Show("加密成功,文件位置:" + outFile);
                this.txtCryPath.Text = outFile;

                /*UKResult uKResult = UTHelper.FileEncryption(this.textBox1.Text, txtPublicKey);
                if (uKResult.Code == "0")
                {
                    MessageBox.Show("加密成功," + uKResult.Result);
                    this.txtCryPath.Text = uKResult.Result;
                }
                else
                {
                    MessageBox.Show("加密失败," + uKResult.Message);
                }*/
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
        }

        //解密
        private void btnEncryFIle_Click(object sender, EventArgs e)
        {
            try
            {
                string outFile = Path.Combine(Path.GetDirectoryName(this.textBox1.Text), @"decry\" + Path.GetFileName(this.textBox1.Text).Replace(".enc", ""));
                FileInfo file = new FileInfo(outFile);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                MySecurity mySecurity = new MySecurity();
                mySecurity.DecryptFile(this.textBox1.Text, outFile, "");
                this.txtCryPath.Text = outFile;
 
                /*UKResult uKResult = UTHelper.FileDecryption(this.textBox1.Text);
                if (uKResult.Code == "0")
                {
                    MessageBox.Show("解密成功," + uKResult.Result);
                    this.txtCryPath.Text = uKResult.Result;
                }
                else
                {
                    MessageBox.Show("解密失败," + uKResult.Message);
                }*/
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex);
            }
         
        }

        private void select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileImportDialog = new OpenFileDialog();
            if (fileImportDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = fileImportDialog.FileName;
            }
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
           string type = this.Type.Text;

            if (type == "加密")
            {
                label3.Text = "加密后的文件";
                btnEncFile.Enabled = true;
                btnDesFIle.Enabled = false;
                this.txtCryPath.Clear();
            }
            else if (type == "解密")
            {
                label3.Text = "解密后的文件";
                btnDesFIle.Enabled = true;
                btnEncFile.Enabled = false;
                this.txtCryPath.Clear();
            }
        }
    }

  
}
