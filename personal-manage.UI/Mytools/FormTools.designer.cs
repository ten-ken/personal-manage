namespace personal_manage.UI.Mytools

{
    partial class FormTools
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuOut = new System.Windows.Forms.MenuStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuInner = new System.Windows.Forms.MenuStrip();
            this.innerBrowerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccoutEncStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileEncStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.outBrowerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dzqzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicInfoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuOut.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 39);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1032, 2);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuOut);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 241);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "外部应用";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // menuOut
            // 
            this.menuOut.AutoSize = false;
            this.menuOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuOut.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.menuOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outBrowerMenuItem,
            this.dzqzToolStripMenuItem,
            this.monitorToolStripMenuItem,
            this.basicInfoStripMenuItem});
            this.menuOut.Location = new System.Drawing.Point(3, 17);
            this.menuOut.Name = "menuOut";
            this.menuOut.Size = new System.Drawing.Size(1026, 92);
            this.menuOut.TabIndex = 25;
            this.menuOut.Text = "首页顶部菜单";
            this.menuOut.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuOut_ItemClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.menuInner);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 361);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内部应用";
            // 
            // menuInner
            // 
            this.menuInner.AutoSize = false;
            this.menuInner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuInner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuInner.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.menuInner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuInner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.innerBrowerMenuItem,
            this.AccoutEncStripMenuItem,
            this.FileEncStripMenuItem,
            this.ProcessStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.menuInner.Location = new System.Drawing.Point(3, 17);
            this.menuInner.Name = "menuInner";
            this.menuInner.Size = new System.Drawing.Size(1026, 92);
            this.menuInner.TabIndex = 26;
            this.menuInner.Text = "首页顶部菜单";
            this.menuInner.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuInner_ItemClicked);
            // 
            // innerBrowerMenuItem
            // 
            this.innerBrowerMenuItem.AutoSize = false;
            this.innerBrowerMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.innerBrowerMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.innerBrowerMenuItem.Image = global::personal_manage.UI.Properties.Resources.brower;
            this.innerBrowerMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.innerBrowerMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.innerBrowerMenuItem.Name = "innerBrowerMenuItem";
            this.innerBrowerMenuItem.Size = new System.Drawing.Size(100, 88);
            this.innerBrowerMenuItem.Text = "网站大全";
            this.innerBrowerMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // AccoutEncStripMenuItem
            // 
            this.AccoutEncStripMenuItem.AutoSize = false;
            this.AccoutEncStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.AccoutEncStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.AccoutEncStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.encryption;
            this.AccoutEncStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AccoutEncStripMenuItem.Name = "AccoutEncStripMenuItem";
            this.AccoutEncStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.AccoutEncStripMenuItem.Text = "账号管理";
            this.AccoutEncStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FileEncStripMenuItem
            // 
            this.FileEncStripMenuItem.AutoSize = false;
            this.FileEncStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.FileEncStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.FileEncStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.icon_file_mgn;
            this.FileEncStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FileEncStripMenuItem.Name = "FileEncStripMenuItem";
            this.FileEncStripMenuItem.Size = new System.Drawing.Size(105, 88);
            this.FileEncStripMenuItem.Text = "文件加密";
            this.FileEncStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ProcessStripMenuItem
            // 
            this.ProcessStripMenuItem.AutoSize = false;
            this.ProcessStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.ProcessStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.ProcessStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.icon_process;
            this.ProcessStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ProcessStripMenuItem.Name = "ProcessStripMenuItem";
            this.ProcessStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.ProcessStripMenuItem.Text = "待开发";
            this.ProcessStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.AutoSize = false;
            this.toolStripMenuItem6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.toolStripMenuItem6.Image = global::personal_manage.UI.Properties.Resources.business_center;
            this.toolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(100, 88);
            this.toolStripMenuItem6.Text = "待开发";
            this.toolStripMenuItem6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.AutoSize = false;
            this.toolStripMenuItem7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.toolStripMenuItem7.Image = global::personal_manage.UI.Properties.Resources.business_basic;
            this.toolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 88);
            this.toolStripMenuItem7.Text = "待开发";
            this.toolStripMenuItem7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // outBrowerMenuItem
            // 
            this.outBrowerMenuItem.AutoSize = false;
            this.outBrowerMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.outBrowerMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.outBrowerMenuItem.Image = global::personal_manage.UI.Properties.Resources.brower;
            this.outBrowerMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.outBrowerMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.outBrowerMenuItem.Name = "outBrowerMenuItem";
            this.outBrowerMenuItem.Size = new System.Drawing.Size(100, 88);
            this.outBrowerMenuItem.Text = "网站大全";
            this.outBrowerMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.outBrowerMenuItem.Click += new System.EventHandler(this.zxtbStripMenuItem_Click);
            // 
            // dzqzToolStripMenuItem
            // 
            this.dzqzToolStripMenuItem.AutoSize = false;
            this.dzqzToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.dzqzToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.dzqzToolStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.business_dzqz;
            this.dzqzToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dzqzToolStripMenuItem.Name = "dzqzToolStripMenuItem";
            this.dzqzToolStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.dzqzToolStripMenuItem.Text = "待开发";
            this.dzqzToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.AutoSize = false;
            this.monitorToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.monitorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.monitorToolStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.bs_monitor;
            this.monitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(105, 88);
            this.monitorToolStripMenuItem.Text = "待开发";
            this.monitorToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // basicInfoStripMenuItem
            // 
            this.basicInfoStripMenuItem.AutoSize = false;
            this.basicInfoStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.basicInfoStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(149)))), ((int)(((byte)(127)))));
            this.basicInfoStripMenuItem.Image = global::personal_manage.UI.Properties.Resources.business_basic;
            this.basicInfoStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.basicInfoStripMenuItem.Name = "basicInfoStripMenuItem";
            this.basicInfoStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.basicInfoStripMenuItem.Text = "待开发";
            this.basicInfoStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FormTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 641);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormTools";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormTools_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuOut.ResumeLayout(false);
            this.menuOut.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuInner.ResumeLayout(false);
            this.menuInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuOut;
        private System.Windows.Forms.ToolStripMenuItem outBrowerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dzqzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicInfoStripMenuItem;
        private System.Windows.Forms.MenuStrip menuInner;
        private System.Windows.Forms.ToolStripMenuItem innerBrowerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccoutEncStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProcessStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileEncStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.Label label1;
    }
}