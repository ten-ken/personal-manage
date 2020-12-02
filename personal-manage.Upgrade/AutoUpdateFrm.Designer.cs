namespace personal_manage.Upgrade
{
    partial class AutoUpdateFrm
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
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnAllCheckedCancle = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.buttonOver = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.Location = new System.Drawing.Point(12, 44);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(426, 23);
            this.progressBarUpdate.TabIndex = 0;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(19, 13);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(35, 12);
            this.lblPercent.TabIndex = 1;
            this.lblPercent.Text = "进度:";
            // 
            // btnAllCheckedCancle
            // 
            this.btnAllCheckedCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAllCheckedCancle.Image = global::personal_manage.Upgrade.Properties.Resources.all_uncheck_20;
            this.btnAllCheckedCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCheckedCancle.Location = new System.Drawing.Point(255, 91);
            this.btnAllCheckedCancle.Name = "btnAllCheckedCancle";
            this.btnAllCheckedCancle.Size = new System.Drawing.Size(59, 30);
            this.btnAllCheckedCancle.TabIndex = 12;
            this.btnAllCheckedCancle.Text = "取消";
            this.btnAllCheckedCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheckedCancle.UseVisualStyleBackColor = true;
            this.btnAllCheckedCancle.Visible = false;
            this.btnAllCheckedCancle.Click += new System.EventHandler(this.btnAllCheckedCancle_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAllCheck.Image = global::personal_manage.Upgrade.Properties.Resources.all_check_20;
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCheck.Location = new System.Drawing.Point(171, 91);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(63, 30);
            this.btnAllCheck.TabIndex = 11;
            this.btnAllCheck.Text = "更新";
            this.btnAllCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheck.UseVisualStyleBackColor = true;
            this.btnAllCheck.Visible = false;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // buttonOver
            // 
            this.buttonOver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOver.Image = global::personal_manage.Upgrade.Properties.Resources.all_check_20;
            this.buttonOver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOver.Location = new System.Drawing.Point(375, 91);
            this.buttonOver.Name = "buttonOver";
            this.buttonOver.Size = new System.Drawing.Size(63, 30);
            this.buttonOver.TabIndex = 11;
            this.buttonOver.Text = "完成";
            this.buttonOver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOver.UseVisualStyleBackColor = true;
            this.buttonOver.Visible = false;
            this.buttonOver.Click += new System.EventHandler(this.buttonOver_Click);
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(52, 13);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(0, 12);
            this.labelProcess.TabIndex = 1;
            // 
            // AutoUpdateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 133);
            this.Controls.Add(this.btnAllCheckedCancle);
            this.Controls.Add(this.buttonOver);
            this.Controls.Add(this.btnAllCheck);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.progressBarUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在线投标工具-版本更新";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoUpdateFrm_FormClosing);
            this.Load += new System.EventHandler(this.AutoUpdateFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarUpdate;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btnAllCheckedCancle;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.Button buttonOver;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelProcess;
    }
}