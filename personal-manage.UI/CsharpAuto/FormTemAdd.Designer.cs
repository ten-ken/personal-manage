namespace personal_manage.UI.CsharpAuto
{
    partial class FormTemAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTemAdd));
            this.panel1 = new System.Windows.Forms.Panel();
            this.templateContent = new System.Windows.Forms.RichTextBox();
            this.suffix = new System.Windows.Forms.ComboBox();
            this.CopyTemName = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.overlayName = new System.Windows.Forms.TextBox();
            this.templateName = new System.Windows.Forms.TextBox();
            this.templatePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.文件叠加名 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.templateContent);
            this.panel1.Controls.Add(this.suffix);
            this.panel1.Controls.Add(this.CopyTemName);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.overlayName);
            this.panel1.Controls.Add(this.templateName);
            this.panel1.Controls.Add(this.templatePath);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.文件叠加名);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 829);
            this.panel1.TabIndex = 1;
            // 
            // templateContent
            // 
            this.templateContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.templateContent.Location = new System.Drawing.Point(107, 154);
            this.templateContent.Name = "templateContent";
            this.templateContent.Size = new System.Drawing.Size(682, 609);
            this.templateContent.TabIndex = 60;
            this.templateContent.Text = resources.GetString("templateContent.Text");
            // 
            // suffix
            // 
            this.suffix.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.suffix.FormattingEnabled = true;
            this.suffix.Location = new System.Drawing.Point(583, 101);
            this.suffix.Name = "suffix";
            this.suffix.Size = new System.Drawing.Size(206, 24);
            this.suffix.TabIndex = 59;
            // 
            // CopyTemName
            // 
            this.CopyTemName.BackColor = System.Drawing.Color.SeaShell;
            this.CopyTemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyTemName.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CopyTemName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.CopyTemName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CopyTemName.Location = new System.Drawing.Point(299, 107);
            this.CopyTemName.Name = "CopyTemName";
            this.CopyTemName.Size = new System.Drawing.Size(89, 25);
            this.CopyTemName.TabIndex = 58;
            this.CopyTemName.Text = "使用模板名";
            this.CopyTemName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CopyTemName.UseVisualStyleBackColor = false;
            this.CopyTemName.Click += new System.EventHandler(this.CopyTemName_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Image = global::personal_manage.UI.Properties.Resources.save_20;
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(400, 783);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(74, 34);
            this.SaveBtn.TabIndex = 58;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // overlayName
            // 
            this.overlayName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.overlayName.Location = new System.Drawing.Point(107, 105);
            this.overlayName.Name = "overlayName";
            this.overlayName.Size = new System.Drawing.Size(177, 26);
            this.overlayName.TabIndex = 50;
            // 
            // templateName
            // 
            this.templateName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.templateName.Location = new System.Drawing.Point(107, 26);
            this.templateName.Name = "templateName";
            this.templateName.Size = new System.Drawing.Size(177, 26);
            this.templateName.TabIndex = 50;
            // 
            // templatePath
            // 
            this.templatePath.Enabled = false;
            this.templatePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.templatePath.Location = new System.Drawing.Point(107, 64);
            this.templatePath.Name = "templatePath";
            this.templatePath.ReadOnly = true;
            this.templatePath.Size = new System.Drawing.Size(682, 26);
            this.templatePath.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "文件后缀名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(411, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "注意使用的是Nvelocity模板,模板名称为英文 且首字母大小";
            // 
            // 文件叠加名
            // 
            this.文件叠加名.AutoSize = true;
            this.文件叠加名.Location = new System.Drawing.Point(33, 108);
            this.文件叠加名.Name = "文件叠加名";
            this.文件叠加名.Size = new System.Drawing.Size(65, 12);
            this.文件叠加名.TabIndex = 48;
            this.文件叠加名.Text = "文件叠加名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "模板位置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "模板名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "模板内容";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(411, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(455, 14);
            this.label6.TabIndex = 48;
            this.label6.Text = "模板位置变量解释: {projectSite} 项目位置，{tableName} 表的实体名";
            // 
            // FormTemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 829);
            this.Controls.Add(this.panel1);
            this.Name = "FormTemAdd";
            this.ShowIcon = false;
            this.Text = "模板配置";
            this.Load += new System.EventHandler(this.FormTemAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox templatePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox templateName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox overlayName;
        private System.Windows.Forms.Label 文件叠加名;
        private System.Windows.Forms.Button CopyTemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox suffix;
        private System.Windows.Forms.RichTextBox templateContent;
        private System.Windows.Forms.Label label6;
    }
}