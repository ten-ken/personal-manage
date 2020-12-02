namespace ess_zbfz_main.commonForm
{
    partial class FrmUploadProcess
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
            this.lblUploadProcess = new System.Windows.Forms.Label();
            this.progressBarUpload = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUploadProcess
            // 
            this.lblUploadProcess.AutoSize = true;
            this.lblUploadProcess.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUploadProcess.Location = new System.Drawing.Point(203, 40);
            this.lblUploadProcess.Name = "lblUploadProcess";
            this.lblUploadProcess.Size = new System.Drawing.Size(143, 18);
            this.lblUploadProcess.TabIndex = 1;
            this.lblUploadProcess.Text = "附件上传进度22%";
            // 
            // progressBarUpload
            // 
            this.progressBarUpload.Location = new System.Drawing.Point(86, 92);
            this.progressBarUpload.Name = "progressBarUpload";
            this.progressBarUpload.Size = new System.Drawing.Size(380, 23);
            this.progressBarUpload.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // FrmUploadProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 147);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBarUpload);
            this.Controls.Add(this.lblUploadProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUploadProcess";
            this.Text = "上传进度";
            this.Load += new System.EventHandler(this.FrmUploadProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUploadProcess;
        private System.Windows.Forms.ProgressBar progressBarUpload;
        private System.Windows.Forms.TextBox textBox1;
    }
}