namespace personal_manage.UI
{
    partial class FormDemoList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listDataGriddView = new System.Windows.Forms.DataGridView();
            this.select_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.采购项目编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail_row = new System.Windows.Forms.DataGridViewLinkColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caiwu_mainPanelTools = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.projectNo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.select_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelContent = new System.Windows.Forms.Panel();
            this.kenPage1 = new MyWfControls.KenPage();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).BeginInit();
            this.caiwu_mainPanelTools.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listDataGriddView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 343);
            this.panel1.TabIndex = 19;
            // 
            // listDataGriddView
            // 
            this.listDataGriddView.AllowUserToAddRows = false;
            this.listDataGriddView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.listDataGriddView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listDataGriddView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listDataGriddView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listDataGriddView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listDataGriddView.ColumnHeadersHeight = 30;
            this.listDataGriddView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_check,
            this.项目名称,
            this.采购项目编号,
            this.markNo,
            this.markName,
            this.packName,
            this.detail_row,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listDataGriddView.DefaultCellStyle = dataGridViewCellStyle2;
            this.listDataGriddView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDataGriddView.Location = new System.Drawing.Point(0, 0);
            this.listDataGriddView.Name = "listDataGriddView";
            this.listDataGriddView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listDataGriddView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listDataGriddView.RowTemplate.Height = 23;
            this.listDataGriddView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGriddView.Size = new System.Drawing.Size(1216, 343);
            this.listDataGriddView.TabIndex = 18;
            this.listDataGriddView.Tag = "999";
            // 
            // select_check
            // 
            this.select_check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.select_check.FalseValue = "false";
            this.select_check.HeaderText = "选择";
            this.select_check.Name = "select_check";
            this.select_check.ReadOnly = true;
            this.select_check.TrueValue = "true";
            this.select_check.Width = 50;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "projectName";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            this.项目名称.Width = 61;
            // 
            // 采购项目编号
            // 
            this.采购项目编号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.采购项目编号.DataPropertyName = "projectNO";
            this.采购项目编号.HeaderText = "采购项目编号";
            this.采购项目编号.Name = "采购项目编号";
            this.采购项目编号.ReadOnly = true;
            // 
            // markNo
            // 
            this.markNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.markNo.DataPropertyName = "MarkNo";
            this.markNo.HeaderText = "标编号";
            this.markNo.Name = "markNo";
            this.markNo.ReadOnly = true;
            // 
            // markName
            // 
            this.markName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.markName.DataPropertyName = "markName";
            this.markName.HeaderText = "标名称";
            this.markName.Name = "markName";
            this.markName.ReadOnly = true;
            // 
            // packName
            // 
            this.packName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.packName.DataPropertyName = "packName";
            this.packName.HeaderText = "包名称";
            this.packName.Name = "packName";
            this.packName.ReadOnly = true;
            // 
            // detail_row
            // 
            this.detail_row.ActiveLinkColor = System.Drawing.Color.Blue;
            this.detail_row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detail_row.HeaderText = "操作";
            this.detail_row.Name = "detail_row";
            this.detail_row.ReadOnly = true;
            this.detail_row.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detail_row.Text = "修改";
            this.detail_row.UseColumnTextForLinkValue = true;
            this.detail_row.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 42;
            // 
            // caiwu_mainPanelTools
            // 
            this.caiwu_mainPanelTools.Controls.Add(this.label1);
            this.caiwu_mainPanelTools.Controls.Add(this.projectNo);
            this.caiwu_mainPanelTools.Controls.Add(this.panel3);
            this.caiwu_mainPanelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.caiwu_mainPanelTools.Location = new System.Drawing.Point(0, 0);
            this.caiwu_mainPanelTools.Name = "caiwu_mainPanelTools";
            this.caiwu_mainPanelTools.Size = new System.Drawing.Size(1216, 61);
            this.caiwu_mainPanelTools.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "采购项目编号";
            // 
            // projectNo
            // 
            this.projectNo.Location = new System.Drawing.Point(107, 19);
            this.projectNo.Name = "projectNo";
            this.projectNo.Size = new System.Drawing.Size(150, 21);
            this.projectNo.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SearchBtn);
            this.panel3.Controls.Add(this.ImportBtn);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnAllCheck);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(548, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(668, 61);
            this.panel3.TabIndex = 12;
            this.panel3.Tag = "9999";
            // 
            // select_chk
            // 
            this.select_chk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.select_chk.FalseValue = "false";
            this.select_chk.Frozen = true;
            this.select_chk.HeaderText = "选择";
            this.select_chk.Name = "select_chk";
            this.select_chk.ReadOnly = true;
            this.select_chk.TrueValue = "true";
            this.select_chk.Width = 50;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.kenPage1);
            this.panelContent.Controls.Add(this.panel1);
            this.panelContent.Controls.Add(this.caiwu_mainPanelTools);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1216, 490);
            this.panelContent.TabIndex = 9;
            // 
            // kenPage1
            // 
            this.kenPage1.Location = new System.Drawing.Point(40, 411);
            this.kenPage1.Name = "kenPage1";
            this.kenPage1.Size = new System.Drawing.Size(714, 27);
            this.kenPage1.TabIndex = 20;
            this.kenPage1.Load += new System.EventHandler(this.kenPage1_Load);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Image = global::personal_manage.UI.Properties.Resources.refresh_32;
            this.SearchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchBtn.Location = new System.Drawing.Point(378, 8);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(73, 45);
            this.SearchBtn.TabIndex = 13;
            this.SearchBtn.Text = "搜索";
            this.SearchBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // ImportBtn
            // 
            this.ImportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImportBtn.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImportBtn.Image = global::personal_manage.UI.Properties.Resources.save_20;
            this.ImportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportBtn.Location = new System.Drawing.Point(195, 8);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(81, 45);
            this.ImportBtn.TabIndex = 12;
            this.ImportBtn.Text = "导入";
            this.ImportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Image = global::personal_manage.UI.Properties.Resources.save_20;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(287, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 45);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "新增";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Image = global::personal_manage.UI.Properties.Resources.checkall_32;
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCheck.Location = new System.Drawing.Point(457, 8);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(77, 45);
            this.btnAllCheck.TabIndex = 15;
            this.btnAllCheck.Tag = "checkAll";
            this.btnAllCheck.Text = "全选";
            this.btnAllCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheck.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::personal_manage.UI.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(553, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 45);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "删除数据";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormDemoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 490);
            this.Controls.Add(this.panelContent);
            this.Name = "FormDemoList";
            this.Text = "列表";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).EndInit();
            this.caiwu_mainPanelTools.ResumeLayout(false);
            this.caiwu_mainPanelTools.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView listDataGriddView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购项目编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn markNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn markName;
        private System.Windows.Forms.DataGridViewTextBoxColumn packName;
        private System.Windows.Forms.DataGridViewLinkColumn detail_row;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Panel caiwu_mainPanelTools;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_chk;
        private System.Windows.Forms.Panel panelContent;
        private MyWfControls.KenPage kenPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectNo;
        private System.Windows.Forms.Button ImportBtn;
    }
}
