namespace personal_manage.UI.Mytools
{
    partial class AccoutEncFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PSEUDOCODE = new System.Windows.Forms.TextBox();
            this.ENCPWD = new System.Windows.Forms.TextBox();
            this.MGNPWD = new System.Windows.Forms.TextBox();
            this.InputPwd = new System.Windows.Forms.TextBox();
            this.DesButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SOURCE = new System.Windows.Forms.TextBox();
            this.ACCOUNT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.jiaoyanPwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SaveBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PSEUDOCODE);
            this.panel1.Controls.Add(this.ENCPWD);
            this.panel1.Controls.Add(this.MGNPWD);
            this.panel1.Controls.Add(this.jiaoyanPwd);
            this.panel1.Controls.Add(this.InputPwd);
            this.panel1.Controls.Add(this.DesButton);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SOURCE);
            this.panel1.Controls.Add(this.ACCOUNT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 433);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(540, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 87;
            this.label6.Text = "显示倒计时:10s";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(462, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 88;
            this.label3.Text = "【开户行/网站等】";
            // 
            // PSEUDOCODE
            // 
            this.PSEUDOCODE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSEUDOCODE.Location = new System.Drawing.Point(129, 219);
            this.PSEUDOCODE.Multiline = true;
            this.PSEUDOCODE.Name = "PSEUDOCODE";
            this.PSEUDOCODE.ReadOnly = true;
            this.PSEUDOCODE.Size = new System.Drawing.Size(327, 89);
            this.PSEUDOCODE.TabIndex = 84;
            // 
            // ENCPWD
            // 
            this.ENCPWD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ENCPWD.Location = new System.Drawing.Point(503, 181);
            this.ENCPWD.Name = "ENCPWD";
            this.ENCPWD.PasswordChar = '*';
            this.ENCPWD.Size = new System.Drawing.Size(96, 26);
            this.ENCPWD.TabIndex = 85;
            this.ENCPWD.Visible = false;
            // 
            // MGNPWD
            // 
            this.MGNPWD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MGNPWD.Location = new System.Drawing.Point(129, 178);
            this.MGNPWD.Name = "MGNPWD";
            this.MGNPWD.PasswordChar = '*';
            this.MGNPWD.Size = new System.Drawing.Size(327, 26);
            this.MGNPWD.TabIndex = 86;
            // 
            // InputPwd
            // 
            this.InputPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputPwd.Location = new System.Drawing.Point(129, 95);
            this.InputPwd.Name = "InputPwd";
            this.InputPwd.PasswordChar = '*';
            this.InputPwd.Size = new System.Drawing.Size(327, 26);
            this.InputPwd.TabIndex = 86;
            // 
            // DesButton
            // 
            this.DesButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DesButton.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesButton.Location = new System.Drawing.Point(474, 95);
            this.DesButton.Name = "DesButton";
            this.DesButton.Size = new System.Drawing.Size(54, 26);
            this.DesButton.TabIndex = 77;
            this.DesButton.Text = "解密";
            this.DesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DesButton.UseVisualStyleBackColor = false;
            this.DesButton.Visible = false;
            this.DesButton.Click += new System.EventHandler(this.DesButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(47, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 81;
            this.label7.Text = "管理密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(64, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "显示码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(78, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "账号来源";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(81, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 83;
            this.label4.Text = "账号";
            // 
            // SOURCE
            // 
            this.SOURCE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SOURCE.Location = new System.Drawing.Point(129, 26);
            this.SOURCE.Name = "SOURCE";
            this.SOURCE.Size = new System.Drawing.Size(327, 26);
            this.SOURCE.TabIndex = 78;
            // 
            // ACCOUNT
            // 
            this.ACCOUNT.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ACCOUNT.Location = new System.Drawing.Point(129, 61);
            this.ACCOUNT.Name = "ACCOUNT";
            this.ACCOUNT.Size = new System.Drawing.Size(327, 26);
            this.ACCOUNT.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(49, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "密码校验";
            // 
            // jiaoyanPwd
            // 
            this.jiaoyanPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jiaoyanPwd.Location = new System.Drawing.Point(129, 131);
            this.jiaoyanPwd.Name = "jiaoyanPwd";
            this.jiaoyanPwd.PasswordChar = '*';
            this.jiaoyanPwd.Size = new System.Drawing.Size(327, 26);
            this.jiaoyanPwd.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(462, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 12);
            this.label9.TabIndex = 87;
            this.label9.Text = "输入密码确认密码正确性";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Image = global::personal_manage.UI.Properties.Resources.select_confirm_20;
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(219, 331);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(129, 34);
            this.SaveBtn.TabIndex = 77;
            this.SaveBtn.Text = "加密并保存";
            this.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AccoutEncFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.panel1);
            this.Name = "AccoutEncFrm";
            this.ShowIcon = false;
            this.Text = "账号管理";
            this.Load += new System.EventHandler(this.AccoutEncFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PSEUDOCODE;
        private System.Windows.Forms.TextBox ENCPWD;
        private System.Windows.Forms.TextBox InputPwd;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SOURCE;
        private System.Windows.Forms.TextBox ACCOUNT;
        private System.Windows.Forms.TextBox MGNPWD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button DesButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox jiaoyanPwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
    }
}