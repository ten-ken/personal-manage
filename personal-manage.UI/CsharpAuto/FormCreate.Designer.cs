namespace personal_manage.UI.CsharpAuto
{
    partial class FormCreate
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.keyWord = new System.Windows.Forms.TextBox();
            this.codeFolder = new System.Windows.Forms.TextBox();
            this.TOP_LEVEL = new System.Windows.Forms.TextBox();
            this.ClearTables = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableNames = new System.Windows.Forms.TextBox();
            this.AUTHOR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbBiao = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.keyWord);
            this.panel1.Controls.Add(this.codeFolder);
            this.panel1.Controls.Add(this.TOP_LEVEL);
            this.panel1.Controls.Add(this.ClearTables);
            this.panel1.Controls.Add(this.OpenFolder);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tableNames);
            this.panel1.Controls.Add(this.AUTHOR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dbBiao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 572);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "生成路径";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(179, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 216);
            this.panel2.TabIndex = 59;
            // 
            // keyWord
            // 
            this.keyWord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyWord.Location = new System.Drawing.Point(177, 158);
            this.keyWord.Name = "keyWord";
            this.keyWord.Size = new System.Drawing.Size(238, 23);
            this.keyWord.TabIndex = 62;
            // 
            // codeFolder
            // 
            this.codeFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeFolder.Location = new System.Drawing.Point(179, 426);
            this.codeFolder.Name = "codeFolder";
            this.codeFolder.ReadOnly = true;
            this.codeFolder.Size = new System.Drawing.Size(462, 26);
            this.codeFolder.TabIndex = 62;
            // 
            // TOP_LEVEL
            // 
            this.TOP_LEVEL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TOP_LEVEL.Location = new System.Drawing.Point(177, 118);
            this.TOP_LEVEL.Name = "TOP_LEVEL";
            this.TOP_LEVEL.Size = new System.Drawing.Size(252, 26);
            this.TOP_LEVEL.TabIndex = 62;
            // 
            // ClearTables
            // 
            this.ClearTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearTables.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearTables.Location = new System.Drawing.Point(998, 36);
            this.ClearTables.Name = "ClearTables";
            this.ClearTables.Size = new System.Drawing.Size(48, 25);
            this.ClearTables.TabIndex = 58;
            this.ClearTables.Text = "清除";
            this.ClearTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearTables.UseVisualStyleBackColor = true;
            this.ClearTables.Click += new System.EventHandler(this.ClearTables_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFolder.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OpenFolder.Location = new System.Drawing.Point(659, 426);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(48, 25);
            this.OpenFolder.TabIndex = 58;
            this.OpenFolder.Text = "打开";
            this.OpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Image = global::personal_manage.UI.Properties.Resources.select_confirm_20;
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(567, 479);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(74, 34);
            this.SaveBtn.TabIndex = 58;
            this.SaveBtn.Text = "生成";
            this.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "顶层包名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "作者(覆盖原值)";
            // 
            // tableNames
            // 
            this.tableNames.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableNames.Location = new System.Drawing.Point(177, 21);
            this.tableNames.Multiline = true;
            this.tableNames.Name = "tableNames";
            this.tableNames.ReadOnly = true;
            this.tableNames.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tableNames.Size = new System.Drawing.Size(791, 59);
            this.tableNames.TabIndex = 50;
            // 
            // AUTHOR
            // 
            this.AUTHOR.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AUTHOR.Location = new System.Drawing.Point(177, 86);
            this.AUTHOR.Name = "AUTHOR";
            this.AUTHOR.Size = new System.Drawing.Size(148, 26);
            this.AUTHOR.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "数据库表名";
            // 
            // dbBiao
            // 
            this.dbBiao.AutoSize = true;
            this.dbBiao.Location = new System.Drawing.Point(94, 208);
            this.dbBiao.Name = "dbBiao";
            this.dbBiao.Size = new System.Drawing.Size(77, 12);
            this.dbBiao.TabIndex = 48;
            this.dbBiao.Text = "数据库表选择";
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1224, 572);
            this.Controls.Add(this.panel1);
            this.Name = "FormCreate";
            this.Text = "代码生成";
            this.Load += new System.EventHandler(this.FormCreate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dbBiao;
        private System.Windows.Forms.TextBox tableNames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TOP_LEVEL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AUTHOR;
        private System.Windows.Forms.TextBox keyWord;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeFolder;
        private System.Windows.Forms.Button ClearTables;
    }
}