namespace personal_manage.UI.Mytools
{
    partial class FormCrypt
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
            this.btnEncFile = new System.Windows.Forms.Button();
            this.txtCryPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDesFIle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEncFile
            // 
            this.btnEncFile.Enabled = false;
            this.btnEncFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEncFile.Location = new System.Drawing.Point(105, 186);
            this.btnEncFile.Name = "btnEncFile";
            this.btnEncFile.Size = new System.Drawing.Size(162, 31);
            this.btnEncFile.TabIndex = 8;
            this.btnEncFile.Text = "加密";
            this.btnEncFile.UseVisualStyleBackColor = true;
            this.btnEncFile.Click += new System.EventHandler(this.btnCryFile_Click);
            // 
            // txtCryPath
            // 
            this.txtCryPath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCryPath.Location = new System.Drawing.Point(120, 125);
            this.txtCryPath.Name = "txtCryPath";
            this.txtCryPath.Size = new System.Drawing.Size(582, 23);
            this.txtCryPath.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "加密后的文件";
            // 
            // btnDesFIle
            // 
            this.btnDesFIle.Enabled = false;
            this.btnDesFIle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDesFIle.Location = new System.Drawing.Point(406, 186);
            this.btnDesFIle.Name = "btnDesFIle";
            this.btnDesFIle.Size = new System.Drawing.Size(162, 31);
            this.btnDesFIle.TabIndex = 13;
            this.btnDesFIle.Text = "解密";
            this.btnDesFIle.UseVisualStyleBackColor = true;
            this.btnDesFIle.Click += new System.EventHandler(this.btnEncryFIle_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(120, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(545, 23);
            this.textBox1.TabIndex = 16;
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(36, 66);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 15;
            this.select.Text = "选择路径";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "操作类型";
            // 
            // Type
            // 
            this.Type.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "加密",
            "解密"});
            this.Type.Location = new System.Drawing.Point(120, 17);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(134, 22);
            this.Type.TabIndex = 17;
            this.Type.SelectedIndexChanged += new System.EventHandler(this.Type_SelectedIndexChanged);
            // 
            // FormCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 266);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.select);
            this.Controls.Add(this.btnDesFIle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCryPath);
            this.Controls.Add(this.btnEncFile);
            this.Name = "FormCrypt";
            this.ShowIcon = false;
            this.Text = "文件加解密";
            this.Load += new System.EventHandler(this.FrmCryptTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEncFile;
        private System.Windows.Forms.TextBox txtCryPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDesFIle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Type;
    }
}