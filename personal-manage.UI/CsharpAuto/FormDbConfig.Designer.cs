namespace personal_manage.UI.CsharpAuto
{
    partial class FormDbConfig
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.DbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DbConnect = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.DbName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DbType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DbConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 286);
            this.panel1.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Image = global::personal_manage.UI.Properties.Resources.save_20;
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(324, 227);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(74, 34);
            this.SaveBtn.TabIndex = 58;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // DbName
            // 
            this.DbName.Location = new System.Drawing.Point(107, 74);
            this.DbName.Name = "DbName";
            this.DbName.Size = new System.Drawing.Size(171, 21);
            this.DbName.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "数据库名称";
            // 
            // DbType
            // 
            this.DbType.FormattingEnabled = true;
            this.DbType.Location = new System.Drawing.Point(107, 39);
            this.DbType.Name = "DbType";
            this.DbType.Size = new System.Drawing.Size(171, 20);
            this.DbType.TabIndex = 49;
            this.DbType.SelectedIndexChanged += new System.EventHandler(this.dbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "数据库类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "数据库连接";
            // 
            // DbConnect
            // 
            this.DbConnect.Location = new System.Drawing.Point(107, 116);
            this.DbConnect.Multiline = true;
            this.DbConnect.Name = "DbConnect";
            this.DbConnect.Size = new System.Drawing.Size(596, 90);
            this.DbConnect.TabIndex = 45;
            // 
            // FormDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 286);
            this.Controls.Add(this.panel1);
            this.Name = "FormDbConfig";
            this.Text = "数据库配置";
            this.Load += new System.EventHandler(this.FormDbConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DbConnect;
        private System.Windows.Forms.ComboBox DbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DbName;
        private System.Windows.Forms.Button SaveBtn;
    }
}