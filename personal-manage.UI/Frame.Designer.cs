namespace personal_manage.UI
{
    partial class Frame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripStatusCopyRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSupplier = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.menuHome = new System.Windows.Forms.MenuStrip();
            this.panelTTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltop = new System.Windows.Forms.Label();
            this.xmStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picRestore = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picQuit = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.menuHome.SuspendLayout();
            this.panelTTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelContent.Controls.Add(this.splitContainer1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 104);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1307, 549);
            this.panelContent.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1307, 549);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStripStatusCopyRight
            // 
            this.toolStripStatusCopyRight.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusCopyRight.Name = "toolStripStatusCopyRight";
            this.toolStripStatusCopyRight.Size = new System.Drawing.Size(123, 21);
            this.toolStripStatusCopyRight.Text = "copyRightToolStrip";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSupplier,
            this.toolStripStatusCopyRight,
            this.toolStripStatusVersion});
            this.statusStrip2.Location = new System.Drawing.Point(0, 627);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1307, 26);
            this.statusStrip2.TabIndex = 17;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusSupplier
            // 
            this.toolStripStatusSupplier.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusSupplier.Name = "toolStripStatusSupplier";
            this.toolStripStatusSupplier.Size = new System.Drawing.Size(110, 21);
            this.toolStripStatusSupplier.Text = "SuppliertoolStrip";
            // 
            // toolStripStatusVersion
            // 
            this.toolStripStatusVersion.Name = "toolStripStatusVersion";
            this.toolStripStatusVersion.Size = new System.Drawing.Size(100, 21);
            this.toolStripStatusVersion.Text = "versiontoolStrip";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.menuHome);
            this.panelTop.Controls.Add(this.panelTTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1307, 104);
            this.panelTop.TabIndex = 3;
            // 
            // menuHome
            // 
            this.menuHome.AutoSize = false;
            this.menuHome.BackColor = System.Drawing.Color.White;
            this.menuHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuHome.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.menuHome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xmStripMenuItem,
            this.tbToolStripMenuItem,
            this.codeToolStripMenuItem,
            this.toolsStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuHome.Location = new System.Drawing.Point(0, 10);
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(1307, 92);
            this.menuHome.TabIndex = 24;
            this.menuHome.Text = "首页顶部菜单";
            this.menuHome.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuHome_ItemClicked);
            // 
            // panelTTop
            // 
            this.panelTTop.Controls.Add(this.panel1);
            this.panelTTop.Controls.Add(this.lbltop);
            this.panelTTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTTop.Location = new System.Drawing.Point(0, 0);
            this.panelTTop.Name = "panelTTop";
            this.panelTTop.Size = new System.Drawing.Size(1307, 10);
            this.panelTTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.picRestore);
            this.panel1.Controls.Add(this.picMin);
            this.panel1.Controls.Add(this.picMax);
            this.panel1.Controls.Add(this.picQuit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1039, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 10);
            this.panel1.TabIndex = 41;
            this.panel1.Visible = false;
            // 
            // lbltop
            // 
            this.lbltop.BackColor = System.Drawing.Color.Teal;
            this.lbltop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltop.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltop.ForeColor = System.Drawing.Color.White;
            this.lbltop.Location = new System.Drawing.Point(0, 0);
            this.lbltop.Name = "lbltop";
            this.lbltop.Size = new System.Drawing.Size(1307, 10);
            this.lbltop.TabIndex = 31;
            this.lbltop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltop.Visible = false;
            this.lbltop.Click += new System.EventHandler(this.lbltop_Click);
            this.lbltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbltop_MouseDown);
            // 
            // xmStripMenuItem
            // 
            this.xmStripMenuItem.AutoSize = false;
            this.xmStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.xmStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.xmStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.bszz;
            this.xmStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.xmStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.xmStripMenuItem.Name = "xmStripMenuItem";
            this.xmStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.xmStripMenuItem.Text = "采购项目";
            this.xmStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.xmStripMenuItem.Click += new System.EventHandler(this.zxtbStripMenuItem_Click_1);
            // 
            // tbToolStripMenuItem
            // 
            this.tbToolStripMenuItem.AutoSize = false;
            this.tbToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tbToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.tbToolStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.bs_monitor;
            this.tbToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbToolStripMenuItem.Name = "tbToolStripMenuItem";
            this.tbToolStripMenuItem.Size = new System.Drawing.Size(105, 88);
            this.tbToolStripMenuItem.Text = "图表";
            this.tbToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbToolStripMenuItem.Click += new System.EventHandler(this.monitorToolStripMenuItem_Click);
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.AutoSize = false;
            this.codeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.codeToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.codeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.codeToolStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.business_center;
            this.codeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.codeToolStripMenuItem.Text = "代码生成器";
            this.codeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.codeToolStripMenuItem.Click += new System.EventHandler(this.personCenterToolStripMenuItem_Click);
            // 
            // toolsStripMenuItem
            // 
            this.toolsStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolsStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.toolsStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.icon_tools;
            this.toolsStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsStripMenuItem.Name = "toolsStripMenuItem";
            this.toolsStripMenuItem.Size = new System.Drawing.Size(86, 88);
            this.toolsStripMenuItem.Text = "我的应用";
            this.toolsStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolsStripMenuItem.Click += new System.EventHandler(this.toolsStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.AutoSize = false;
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.quitToolStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.system_quit;
            this.quitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.quitToolStripMenuItem.Text = "退出";
            this.quitToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // picRestore
            // 
            this.picRestore.Image = global::personal_manage.UI.Properties.Resources.form_restore;
            this.picRestore.Location = new System.Drawing.Point(83, 3);
            this.picRestore.Name = "picRestore";
            this.picRestore.Size = new System.Drawing.Size(40, 20);
            this.picRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRestore.TabIndex = 44;
            this.picRestore.TabStop = false;
            this.picRestore.Click += new System.EventHandler(this.picRestore_Click);
            // 
            // picMin
            // 
            this.picMin.Image = global::personal_manage.UI.Properties.Resources.min;
            this.picMin.Location = new System.Drawing.Point(225, 3);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(40, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMin.TabIndex = 43;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picMax
            // 
            this.picMax.Image = global::personal_manage.UI.Properties.Resources.max;
            this.picMax.Location = new System.Drawing.Point(130, 3);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(40, 20);
            this.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMax.TabIndex = 42;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picQuit
            // 
            this.picQuit.Image = global::personal_manage.UI.Properties.Resources.form_close;
            this.picQuit.Location = new System.Drawing.Point(179, 3);
            this.picQuit.Name = "picQuit";
            this.picQuit.Size = new System.Drawing.Size(40, 20);
            this.picQuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuit.TabIndex = 41;
            this.picQuit.TabStop = false;
            this.picQuit.Click += new System.EventHandler(this.picQuit_Click);
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 653);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frame_Load);
            this.SizeChanged += new System.EventHandler(this.Frame_Resize);
            this.Resize += new System.EventHandler(this.Frame_Resize);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.menuHome.ResumeLayout(false);
            this.menuHome.PerformLayout();
            this.panelTTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCopyRight;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSupplier;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusVersion;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.MenuStrip menuHome;
        private System.Windows.Forms.ToolStripMenuItem xmStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Panel panelTTop;
        private System.Windows.Forms.Label lbltop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picQuit;
        private System.Windows.Forms.PictureBox picRestore;
        private System.Windows.Forms.ToolStripMenuItem toolsStripMenuItem;
    }
}