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
    public partial class UpLoadLoading : Form
    {
        public UpLoadLoading()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private string frmTitle= "附件上传中,请耐心等待...";
        private void UpLoadLoading_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.lblMsg.Text = frmTitle;
            this.Text = frmTitle;
        }
        public  UpLoadLoading(string _frmTitle)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.frmTitle = _frmTitle;

        }
    }
}
