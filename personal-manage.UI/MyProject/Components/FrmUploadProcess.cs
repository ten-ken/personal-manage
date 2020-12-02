using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ess_zbfz_main.commonForm
{
    public partial class FrmUploadProcess : Form
    {
        public FrmUploadProcess()
        {
            InitializeComponent();
        }

        private void FrmUploadProcess_Load(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));
            fThread.Start();
        }
        private void SetTextMesssage(int ipos, string vinfo)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMesssage);
                this.Invoke(setpos, new object[] { ipos, vinfo });
            }
            else
            {
                this.lblUploadProcess.Text = ipos.ToString() + "/1000";
                this.progressBarUpload.Value = Convert.ToInt32(ipos);
                this.textBox1.AppendText(vinfo);
            }
        }
        private void SleepT()
        {
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(10);
                SetTextMesssage(100 * i / 500, i.ToString() + "\r\n");
            }
        }
        private delegate void SetPos(int ipos, string vinfo);//代理
    }
}
