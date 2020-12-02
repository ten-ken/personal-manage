using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.UI.demo1
{
    public partial class FromList : Form
    {
        public FromList()
        {
            InitializeComponent();
        }

        private void FromList_Load(object sender, EventArgs e)
        {
            this.listDataGriddView.AutoGenerateColumns = false;
            this.listDataGriddView.Height = 30;
            //this.WindowState = FormWindowState.Maximized;
            this.listDataGriddView.RowsDefaultCellStyle.Font = new Font("楷体", 15, FontStyle.Regular);
            this.listDataGriddView.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.listDataGriddView.RowsDefaultCellStyle.BackColor = Color.White;
        }
    }
}
