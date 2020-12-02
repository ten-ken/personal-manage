namespace personal_manage.UI.Components
{
    partial class UploadFileFrm
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
            this.filePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpLoad = new BaseControlExt.ButtonExt();
            this.buttonExt1 = new BaseControlExt.ButtonExt();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.CausesValidation = false;
            this.filePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath.Location = new System.Drawing.Point(79, 12);
            this.filePath.Multiline = true;
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(505, 41);
            this.filePath.TabIndex = 6;
            this.filePath.TextChanged += new System.EventHandler(this.txtEncrypt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文件路径";
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpLoad.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpLoad.ControlState = BaseControlExt.ControlState.Normal;
            this.btnUpLoad.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpLoad.ForeColor = System.Drawing.Color.White;
            this.btnUpLoad.Image = global::personal_manage.UI.Properties.Resources.upload_32;
            this.btnUpLoad.ImageWidth = 45;
            this.btnUpLoad.Location = new System.Drawing.Point(326, 73);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Radius = 10;
            this.btnUpLoad.RoundStyle = BaseControlExt.RoundStyle.All;
            this.btnUpLoad.Size = new System.Drawing.Size(107, 38);
            this.btnUpLoad.TabIndex = 9;
            this.btnUpLoad.Text = "上传";
            this.btnUpLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpLoad.UseVisualStyleBackColor = true;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // buttonExt1
            // 
            this.buttonExt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExt1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonExt1.ControlState = BaseControlExt.ControlState.Normal;
            this.buttonExt1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExt1.ForeColor = System.Drawing.Color.White;
            this.buttonExt1.ImageWidth = 1;
            this.buttonExt1.Location = new System.Drawing.Point(138, 73);
            this.buttonExt1.Name = "buttonExt1";
            this.buttonExt1.Radius = 10;
            this.buttonExt1.RoundStyle = BaseControlExt.RoundStyle.All;
            this.buttonExt1.Size = new System.Drawing.Size(138, 38);
            this.buttonExt1.TabIndex = 9;
            this.buttonExt1.Text = "选择待上传的文件";
            this.buttonExt1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExt1.UseVisualStyleBackColor = true;
            this.buttonExt1.Click += new System.EventHandler(this.buttonExt1_Click);
            // 
            // UploadBidFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 130);
            this.Controls.Add(this.buttonExt1);
            this.Controls.Add(this.btnUpLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePath);
            this.Name = "UploadBidFrm";
            this.Text = "上传";
            this.Load += new System.EventHandler(this.UploadBidFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label label1;
        private BaseControlExt.ButtonExt btnUpLoad;
        private BaseControlExt.ButtonExt buttonExt1;
    }
}