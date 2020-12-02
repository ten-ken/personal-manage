namespace personal_manage.UI.CsharpAuto
{
    partial class AutoCodeConfigForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.TOP_LEVEL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AUTHOR = new System.Windows.Forms.TextBox();
            this.PRO_NAME = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PRO_SITE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDbConfig = new System.Windows.Forms.TabPage();
            this.tabPageTemplate = new System.Windows.Forms.TabPage();
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TOP_LEVEL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AUTHOR);
            this.panel1.Controls.Add(this.PRO_NAME);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PRO_SITE);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 71);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 59;
            this.label6.Text = "顶层包名";
            // 
            // TOP_LEVEL
            // 
            this.TOP_LEVEL.Location = new System.Drawing.Point(568, 42);
            this.TOP_LEVEL.Name = "TOP_LEVEL";
            this.TOP_LEVEL.Size = new System.Drawing.Size(238, 21);
            this.TOP_LEVEL.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "作者";
            // 
            // AUTHOR
            // 
            this.AUTHOR.Location = new System.Drawing.Point(568, 13);
            this.AUTHOR.Name = "AUTHOR";
            this.AUTHOR.Size = new System.Drawing.Size(148, 21);
            this.AUTHOR.TabIndex = 56;
            // 
            // PRO_NAME
            // 
            this.PRO_NAME.Location = new System.Drawing.Point(100, 13);
            this.PRO_NAME.Name = "PRO_NAME";
            this.PRO_NAME.Size = new System.Drawing.Size(271, 21);
            this.PRO_NAME.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "项目名称";
            // 
            // PRO_SITE
            // 
            this.PRO_SITE.Location = new System.Drawing.Point(100, 42);
            this.PRO_SITE.Name = "PRO_SITE";
            this.PRO_SITE.Size = new System.Drawing.Size(364, 21);
            this.PRO_SITE.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "项目位置";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1220, 572);
            this.panel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDbConfig);
            this.tabControl1.Controls.Add(this.tabPageTemplate);
            this.tabControl1.Controls.Add(this.tabPageCreate);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1220, 572);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageDbConfig
            // 
            this.tabPageDbConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageDbConfig.Name = "tabPageDbConfig";
            this.tabPageDbConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDbConfig.Size = new System.Drawing.Size(1212, 546);
            this.tabPageDbConfig.TabIndex = 0;
            this.tabPageDbConfig.Text = "数据库配置";
            this.tabPageDbConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageTemplate
            // 
            this.tabPageTemplate.Location = new System.Drawing.Point(4, 22);
            this.tabPageTemplate.Name = "tabPageTemplate";
            this.tabPageTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTemplate.Size = new System.Drawing.Size(1212, 546);
            this.tabPageTemplate.TabIndex = 1;
            this.tabPageTemplate.Text = "模板配置";
            this.tabPageTemplate.UseVisualStyleBackColor = true;
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPageCreate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Size = new System.Drawing.Size(1212, 546);
            this.tabPageCreate.TabIndex = 2;
            this.tabPageCreate.Text = "生成";
            // 
            // AutoCodeConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 643);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AutoCodeConfigForm";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.AutoCodeConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDbConfig;
        private System.Windows.Forms.TabPage tabPageTemplate;
        private System.Windows.Forms.TextBox PRO_SITE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PRO_NAME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AUTHOR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TOP_LEVEL;
        private System.Windows.Forms.TabPage tabPageCreate;
    }
}