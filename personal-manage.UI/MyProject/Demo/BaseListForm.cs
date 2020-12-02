using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.UI.MyProject.Demo
{
    public partial class BaseListForm : Form
    {
        public BaseListForm():base()
        {           
            InitializeComponent();
            this.SuspendLayout();

            // 
            // MainForm
            // 
            /*this.ClientSize = new System.Drawing.Size(500, 350);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);*/
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
