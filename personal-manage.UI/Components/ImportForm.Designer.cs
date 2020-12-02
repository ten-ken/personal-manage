namespace personal_manage.UI.Components
{
    partial class ImportForm<T>
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
            this.FailInfo = new System.Windows.Forms.Label();
            this.FailCount = new System.Windows.Forms.Label();
            this.SucessInfo = new System.Windows.Forms.Label();
            this.SuccessCount = new System.Windows.Forms.Label();
            this.ExportTemplate = new BaseControlExt.ButtonExt();
            this.btnImport = new BaseControlExt.ButtonExt();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.FailInfo);
            this.panel1.Controls.Add(this.FailCount);
            this.panel1.Controls.Add(this.SucessInfo);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.SuccessCount);
            this.panel1.Controls.Add(this.ExportTemplate);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Location = new System.Drawing.Point(37, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 207);
            this.panel1.TabIndex = 0;
            // 
            // FailInfo
            // 
            this.FailInfo.AutoSize = true;
            this.FailInfo.ForeColor = System.Drawing.Color.Red;
            this.FailInfo.Location = new System.Drawing.Point(244, 179);
            this.FailInfo.Name = "FailInfo";
            this.FailInfo.Size = new System.Drawing.Size(23, 12);
            this.FailInfo.TabIndex = 6;
            this.FailInfo.Text = "0条";
            // 
            // FailCount
            // 
            this.FailCount.AutoSize = true;
            this.FailCount.ForeColor = System.Drawing.Color.Red;
            this.FailCount.Location = new System.Drawing.Point(173, 179);
            this.FailCount.Name = "FailCount";
            this.FailCount.Size = new System.Drawing.Size(65, 12);
            this.FailCount.TabIndex = 7;
            this.FailCount.Text = "导入失败：";
            // 
            // SucessInfo
            // 
            this.SucessInfo.AutoSize = true;
            this.SucessInfo.ForeColor = System.Drawing.Color.Green;
            this.SucessInfo.Location = new System.Drawing.Point(244, 149);
            this.SucessInfo.Name = "SucessInfo";
            this.SucessInfo.Size = new System.Drawing.Size(23, 12);
            this.SucessInfo.TabIndex = 8;
            this.SucessInfo.Text = "0条";
            // 
            // SuccessCount
            // 
            this.SuccessCount.AutoSize = true;
            this.SuccessCount.ForeColor = System.Drawing.Color.Green;
            this.SuccessCount.Location = new System.Drawing.Point(173, 149);
            this.SuccessCount.Name = "SuccessCount";
            this.SuccessCount.Size = new System.Drawing.Size(65, 12);
            this.SuccessCount.TabIndex = 9;
            this.SuccessCount.Text = "导入成功：";
            // 
            // ExportTemplate
            // 
            this.ExportTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportTemplate.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExportTemplate.ControlState = BaseControlExt.ControlState.Normal;
            this.ExportTemplate.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExportTemplate.ForeColor = System.Drawing.Color.White;
            this.ExportTemplate.Image = global::personal_manage.UI.Properties.Resources.download_white_32;
            this.ExportTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportTemplate.ImageWidth = 25;
            this.ExportTemplate.Location = new System.Drawing.Point(171, 22);
            this.ExportTemplate.Name = "ExportTemplate";
            this.ExportTemplate.Radius = 10;
            this.ExportTemplate.RoundStyle = BaseControlExt.RoundStyle.All;
            this.ExportTemplate.Size = new System.Drawing.Size(103, 32);
            this.ExportTemplate.TabIndex = 4;
            this.ExportTemplate.Text = "下载模板";
            this.ExportTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportTemplate.UseVisualStyleBackColor = true;
            this.ExportTemplate.Click += new System.EventHandler(this.ExportTemplate_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnImport.ControlState = BaseControlExt.ControlState.Normal;
            this.btnImport.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Image = global::personal_manage.UI.Properties.Resources.import_white_32;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.ImageWidth = 25;
            this.btnImport.Location = new System.Drawing.Point(171, 73);
            this.btnImport.Name = "btnImport";
            this.btnImport.Radius = 10;
            this.btnImport.RoundStyle = BaseControlExt.RoundStyle.All;
            this.btnImport.Size = new System.Drawing.Size(103, 32);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "导入数据";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Green;
            this.labelInfo.Location = new System.Drawing.Point(191, 121);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(82, 14);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "导入成功：";
            this.labelInfo.Visible = false;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 244);
            this.Controls.Add(this.panel1);
            this.Name = "ImportForm";
            this.ShowIcon = false;
            this.Text = "导入";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label FailInfo;
        private System.Windows.Forms.Label FailCount;
        private System.Windows.Forms.Label SucessInfo;
        private System.Windows.Forms.Label SuccessCount;
        private BaseControlExt.ButtonExt ExportTemplate;
        private BaseControlExt.ButtonExt btnImport;
        private System.Windows.Forms.Label labelInfo;
    }
}