namespace personal_manage.UI
{
    partial class LoginFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblpwd = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.lbltxt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.lblpwd);
            this.groupBox1.Controls.Add(this.lblAccount);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Location = new System.Drawing.Point(54, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户登录";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(338, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(165, 186);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 36);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblpwd
            // 
            this.lblpwd.AutoSize = true;
            this.lblpwd.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpwd.Location = new System.Drawing.Point(104, 133);
            this.lblpwd.Name = "lblpwd";
            this.lblpwd.Size = new System.Drawing.Size(95, 19);
            this.lblpwd.TabIndex = 3;
            this.lblpwd.Text = "登录密码:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAccount.Location = new System.Drawing.Point(104, 75);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(95, 19);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "登录账号:";
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(210, 128);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(205, 29);
            this.password.TabIndex = 1;
            this.password.Text = "admin";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccount.Location = new System.Drawing.Point(210, 70);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(205, 29);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Text = "admin";
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AutoSize = true;
            this.lblCopyRight.Font = new System.Drawing.Font("华文仿宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCopyRight.Location = new System.Drawing.Point(125, 373);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(90, 22);
            this.lblCopyRight.TabIndex = 10;
            this.lblCopyRight.Text = "版权所有";
            this.lblCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltxt
            // 
            this.lbltxt.BackColor = System.Drawing.Color.CadetBlue;
            this.lbltxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltxt.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltxt.ForeColor = System.Drawing.Color.White;
            this.lbltxt.Location = new System.Drawing.Point(0, 0);
            this.lbltxt.Name = "lbltxt";
            this.lbltxt.Size = new System.Drawing.Size(716, 60);
            this.lbltxt.TabIndex = 11;
            this.lbltxt.Text = "管理工具";
            this.lbltxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltxt.Click += new System.EventHandler(this.lbltxt_Click);
            this.lbltxt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbltxt_MouseDown);
            // 
            // LoginFrm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(716, 414);
            this.ControlBox = false;
            this.Controls.Add(this.lbltxt);
            this.Controls.Add(this.lblCopyRight);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblpwd;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbltxt;
    }
}