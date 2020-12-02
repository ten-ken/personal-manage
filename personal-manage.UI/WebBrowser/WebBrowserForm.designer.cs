namespace personal_manage.UI
{
    partial class WebBrowserForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭右侧标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonSubstrImg = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ComboBoxTuijian = new System.Windows.Forms.ComboBox();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(979, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem,
            this.关闭右侧标签ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 48);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.关闭ToolStripMenuItem.Text = "关闭当前页";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 关闭右侧标签ToolStripMenuItem
            // 
            this.关闭右侧标签ToolStripMenuItem.Name = "关闭右侧标签ToolStripMenuItem";
            this.关闭右侧标签ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.关闭右侧标签ToolStripMenuItem.Text = "关闭右侧标签页";
            this.关闭右侧标签ToolStripMenuItem.Click += new System.EventHandler(this.关闭右侧标签ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 40);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ButtonSubstrImg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(693, 0);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel3.Size = new System.Drawing.Size(285, 40);
            this.panel3.TabIndex = 15;
            // 
            // ButtonSubstrImg
            // 
            this.ButtonSubstrImg.Location = new System.Drawing.Point(6, 10);
            this.ButtonSubstrImg.Name = "ButtonSubstrImg";
            this.ButtonSubstrImg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonSubstrImg.Size = new System.Drawing.Size(80, 24);
            this.ButtonSubstrImg.TabIndex = 14;
            this.ButtonSubstrImg.Text = "截图";
            this.ButtonSubstrImg.UseVisualStyleBackColor = true;
            this.ButtonSubstrImg.Click += new System.EventHandler(this.ButtonSubstrImg_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ComboBoxTuijian);
            this.panel2.Controls.Add(this.buttonSkip);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 40);
            this.panel2.TabIndex = 14;
            // 
            // ComboBoxTuijian
            // 
            this.ComboBoxTuijian.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxTuijian.FormattingEnabled = true;
            this.ComboBoxTuijian.Location = new System.Drawing.Point(73, 12);
            this.ComboBoxTuijian.Name = "ComboBoxTuijian";
            this.ComboBoxTuijian.Size = new System.Drawing.Size(150, 22);
            this.ComboBoxTuijian.TabIndex = 16;
            this.ComboBoxTuijian.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTuijian_SelectedIndexChanged);
            // 
            // buttonSkip
            // 
            this.buttonSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSkip.Location = new System.Drawing.Point(608, 10);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonSkip.Size = new System.Drawing.Size(79, 24);
            this.buttonSkip.TabIndex = 15;
            this.buttonSkip.Text = "跳转";
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(295, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 23);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "https://www.baidu.com/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "推荐网站：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "当前地址：";
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网址大全";
            this.Load += new System.EventHandler(this.TabForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭右侧标签ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.Button ButtonSubstrImg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxTuijian;
    }
}