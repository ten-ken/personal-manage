using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyWfControls.Controls.KenGroupBox
{
    public partial class KenGroupBox : GroupBox
    {
        private Color _BorderColor = Color.Black;

        [Browsable(true), Description("边框颜色"), Category("自定义分组")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                this.Invalidate();
            }
        }

        public KenGroupBox()
        {
            InitializeComponent();
        }

        public KenGroupBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 重写Onpaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var vSize = e.Graphics.MeasureString(this.Text, this.Font);

            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 10, 1);
            Pen vPen = new Pen(this._BorderColor);
            e.Graphics.DrawLine(vPen, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(vPen, vSize.Width + 8, vSize.Height / 2, this.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(vPen, 1, vSize.Height / 2, 1, this.Height - 2);
            e.Graphics.DrawLine(vPen, 1, this.Height - 2, this.Width - 2, this.Height - 2);
            e.Graphics.DrawLine(vPen, this.Width - 2, vSize.Height / 2, this.Width - 2, this.Height - 2);
        }
    }
}
