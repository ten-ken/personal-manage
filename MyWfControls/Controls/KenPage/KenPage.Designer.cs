namespace MyWfControls
{
    partial class KenPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.KenToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.currentPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ToolPageReload = new System.Windows.Forms.ToolStripButton();
            this.ToolPageFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolPagePre = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolPageNext = new System.Windows.Forms.ToolStripButton();
            this.ToolPageLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showStrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.每页5条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每页10条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每页20条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每页50条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每页100条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KenToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // KenToolStrip
            // 
            this.KenToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.KenToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KenToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.currentPage,
            this.toolStripLabel2,
            this.ToolPageReload,
            this.ToolPageFirst,
            this.toolStripSeparator1,
            this.ToolPagePre,
            this.toolStripSeparator2,
            this.ToolPageNext,
            this.ToolPageLast,
            this.toolStripSeparator3,
            this.showStrip,
            this.toolStripSeparator5,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1});
            this.KenToolStrip.Location = new System.Drawing.Point(0, 0);
            this.KenToolStrip.Name = "KenToolStrip";
            this.KenToolStrip.Size = new System.Drawing.Size(714, 25);
            this.KenToolStrip.TabIndex = 21;
            this.KenToolStrip.Tag = "9999";
            this.KenToolStrip.Text = "分页";
            this.KenToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.KenToolStrip_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "第";
            // 
            // currentPage
            // 
            this.currentPage.AcceptsTab = true;
            this.currentPage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.currentPage.MaxLength = 12;
            this.currentPage.Name = "currentPage";
            this.currentPage.Size = new System.Drawing.Size(50, 25);
            this.currentPage.Text = "1";
            this.currentPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currentPage_KeyPress);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "页";
            // 
            // ToolPageReload
            // 
            this.ToolPageReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPageReload.Image = global::MyWfControls.Properties.Resources.page_reload;
            this.ToolPageReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPageReload.Name = "ToolPageReload";
            this.ToolPageReload.Size = new System.Drawing.Size(23, 22);
            this.ToolPageReload.Tag = "page-reload";
            this.ToolPageReload.Text = "返回";
            this.ToolPageReload.Click += new System.EventHandler(this.ToolPage_Click);
            // 
            // ToolPageFirst
            // 
            this.ToolPageFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPageFirst.Image = global::MyWfControls.Properties.Resources.page_first;
            this.ToolPageFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPageFirst.Name = "ToolPageFirst";
            this.ToolPageFirst.Size = new System.Drawing.Size(23, 22);
            this.ToolPageFirst.Tag = "page-first";
            this.ToolPageFirst.Text = "首页";
            this.ToolPageFirst.Click += new System.EventHandler(this.ToolPage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolPagePre
            // 
            this.ToolPagePre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPagePre.Image = global::MyWfControls.Properties.Resources.page_pre;
            this.ToolPagePre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPagePre.Name = "ToolPagePre";
            this.ToolPagePre.Size = new System.Drawing.Size(23, 22);
            this.ToolPagePre.Tag = "page-pre";
            this.ToolPagePre.Text = "下一页";
            this.ToolPagePre.Click += new System.EventHandler(this.ToolPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolPageNext
            // 
            this.ToolPageNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPageNext.Image = global::MyWfControls.Properties.Resources.page_next;
            this.ToolPageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPageNext.Name = "ToolPageNext";
            this.ToolPageNext.Size = new System.Drawing.Size(23, 22);
            this.ToolPageNext.Tag = "page-next";
            this.ToolPageNext.Text = "下一页";
            this.ToolPageNext.Click += new System.EventHandler(this.ToolPage_Click);
            // 
            // ToolPageLast
            // 
            this.ToolPageLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPageLast.Image = global::MyWfControls.Properties.Resources.page_last;
            this.ToolPageLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPageLast.Name = "ToolPageLast";
            this.ToolPageLast.Size = new System.Drawing.Size(23, 22);
            this.ToolPageLast.Tag = "page-last";
            this.ToolPageLast.Text = "末页";
            this.ToolPageLast.Click += new System.EventHandler(this.ToolPage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // showStrip
            // 
            this.showStrip.Name = "showStrip";
            this.showStrip.Size = new System.Drawing.Size(110, 22);
            this.showStrip.Text = "共1页（0条记录）";
            this.showStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(0, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.每页5条ToolStripMenuItem,
            this.每页10条ToolStripMenuItem,
            this.每页20条ToolStripMenuItem,
            this.每页50条ToolStripMenuItem,
            this.每页100条ToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(71, 22);
            this.toolStripDropDownButton1.Text = "每页10条";
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton1_DropDownItemClicked);
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // 每页5条ToolStripMenuItem
            // 
            this.每页5条ToolStripMenuItem.Name = "每页5条ToolStripMenuItem";
            this.每页5条ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.每页5条ToolStripMenuItem.Tag = "5";
            this.每页5条ToolStripMenuItem.Text = "每页5条";
            // 
            // 每页10条ToolStripMenuItem
            // 
            this.每页10条ToolStripMenuItem.Name = "每页10条ToolStripMenuItem";
            this.每页10条ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.每页10条ToolStripMenuItem.Tag = "10";
            this.每页10条ToolStripMenuItem.Text = "每页10条";
            // 
            // 每页20条ToolStripMenuItem
            // 
            this.每页20条ToolStripMenuItem.Name = "每页20条ToolStripMenuItem";
            this.每页20条ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.每页20条ToolStripMenuItem.Tag = "20";
            this.每页20条ToolStripMenuItem.Text = "每页20条";
            // 
            // 每页50条ToolStripMenuItem
            // 
            this.每页50条ToolStripMenuItem.Name = "每页50条ToolStripMenuItem";
            this.每页50条ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.每页50条ToolStripMenuItem.Tag = "50";
            this.每页50条ToolStripMenuItem.Text = "每页50条";
            // 
            // 每页100条ToolStripMenuItem
            // 
            this.每页100条ToolStripMenuItem.Name = "每页100条ToolStripMenuItem";
            this.每页100条ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.每页100条ToolStripMenuItem.Tag = "100";
            this.每页100条ToolStripMenuItem.Text = "每页100条";
            // 
            // KenPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KenToolStrip);
            this.Name = "KenPage";
            this.Size = new System.Drawing.Size(714, 27);
            this.KenToolStrip.ResumeLayout(false);
            this.KenToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip KenToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox currentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton ToolPageReload;
        private System.Windows.Forms.ToolStripButton ToolPageFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolPagePre;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ToolPageNext;
        private System.Windows.Forms.ToolStripButton ToolPageLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel showStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 每页5条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每页10条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每页20条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每页50条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每页100条ToolStripMenuItem;
    }
}
