namespace personal_manage.UI.demo1
{
    partial class FromList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总额保险 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.采购项目编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.select_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelContent = new System.Windows.Forms.Panel();
            this.listDataGriddView = new System.Windows.Forms.DataGridView();
            this.detail_row = new System.Windows.Forms.DataGridViewLinkColumn();
            this.caiwu_mainPanelTools = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.projectNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).BeginInit();
            this.caiwu_mainPanelTools.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // REMARK
            // 
            this.REMARK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.REMARK.DataPropertyName = "REMARK";
            dataGridViewCellStyle5.NullValue = "0";
            this.REMARK.DefaultCellStyle = dataGridViewCellStyle5;
            this.REMARK.HeaderText = "备注";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TOTAL.DataPropertyName = "TOTAL";
            this.TOTAL.HeaderText = "总额";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // 总额保险
            // 
            this.总额保险.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.总额保险.DataPropertyName = "totalINSURE";
            this.总额保险.HeaderText = "总额保险";
            this.总额保险.Name = "总额保险";
            this.总额保险.ReadOnly = true;
            // 
            // totalMONEY
            // 
            this.totalMONEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalMONEY.DataPropertyName = "totalMONEY";
            this.totalMONEY.HeaderText = "总额-金额";
            this.totalMONEY.Name = "totalMONEY";
            this.totalMONEY.ReadOnly = true;
            // 
            // 采购项目编号
            // 
            this.采购项目编号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.采购项目编号.DataPropertyName = "projectNO";
            this.采购项目编号.HeaderText = "采购项目编号";
            this.采购项目编号.Name = "采购项目编号";
            this.采购项目编号.ReadOnly = true;
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
            this.panelContent.Controls.Add(this.listDataGriddView);
            this.panelContent.Controls.Add(this.caiwu_mainPanelTools);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1229, 594);
            this.panelContent.TabIndex = 5;
            // 
            // listDataGriddView
            // 
            this.listDataGriddView.AllowUserToAddRows = false;
            this.listDataGriddView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listDataGriddView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listDataGriddView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listDataGriddView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listDataGriddView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listDataGriddView.ColumnHeadersHeight = 30;
            this.listDataGriddView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_check,
            this.采购项目编号,
            this.totalMONEY,
            this.总额保险,
            this.TOTAL,
            this.REMARK,
            this.detail_row,
            this.id});
            this.listDataGriddView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDataGriddView.Location = new System.Drawing.Point(0, 61);
            this.listDataGriddView.Name = "listDataGriddView";
            this.listDataGriddView.ReadOnly = true;
            this.listDataGriddView.RowTemplate.Height = 23;
            this.listDataGriddView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGriddView.Size = new System.Drawing.Size(1229, 533);
            this.listDataGriddView.TabIndex = 17;
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
            // caiwu_mainPanelTools
            // 
            this.caiwu_mainPanelTools.Controls.Add(this.panel3);
            this.caiwu_mainPanelTools.Controls.Add(this.panel2);
            this.caiwu_mainPanelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.caiwu_mainPanelTools.Location = new System.Drawing.Point(0, 0);
            this.caiwu_mainPanelTools.Name = "caiwu_mainPanelTools";
            this.caiwu_mainPanelTools.Size = new System.Drawing.Size(1229, 61);
            this.caiwu_mainPanelTools.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SearchBtn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnAllCheck);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnRefesh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(601, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(628, 61);
            this.panel3.TabIndex = 12;
            // 
            // SearchBtn
            // 
            this.SearchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchBtn.Location = new System.Drawing.Point(221, 12);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(73, 38);
            this.SearchBtn.TabIndex = 8;
            this.SearchBtn.Text = "搜索";
            this.SearchBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Image = global::personal_manage.UI.Properties.Resources.import_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(127, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "导入";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Image = global::personal_manage.UI.Properties.Resources.save_20;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(31, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Image = global::personal_manage.UI.Properties.Resources.checkall_32;
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCheck.Location = new System.Drawing.Point(421, 12);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(77, 38);
            this.btnAllCheck.TabIndex = 9;
            this.btnAllCheck.Tag = "checkAll";
            this.btnAllCheck.Text = "全选";
            this.btnAllCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheck.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::personal_manage.UI.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(504, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除数据";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Image = global::personal_manage.UI.Properties.Resources.refresh_32;
            this.btnRefesh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefesh.Location = new System.Drawing.Point(309, 11);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(104, 38);
            this.btnRefesh.TabIndex = 8;
            this.btnRefesh.Text = " 刷新数据";
            this.btnRefesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefesh.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.projectName);
            this.panel2.Controls.Add(this.projectNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 61);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "采购项目名称";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(132, 21);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(150, 21);
            this.projectName.TabIndex = 3;
            // 
            // projectNo
            // 
            this.projectNo.Location = new System.Drawing.Point(386, 20);
            this.projectNo.Name = "projectNo";
            this.projectNo.Size = new System.Drawing.Size(178, 21);
            this.projectNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(292, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "采购项目编号";
            // 
            // FromList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 594);
            this.Controls.Add(this.panelContent);
            this.Name = "FromList";
            this.Text = "列表页";
            this.Load += new System.EventHandler(this.FromList_Load);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).EndInit();
            this.caiwu_mainPanelTools.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总额保险;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购项目编号;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_check;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_chk;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView listDataGriddView;
        private System.Windows.Forms.DataGridViewLinkColumn detail_row;
        private System.Windows.Forms.Panel caiwu_mainPanelTools;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.TextBox projectNo;
        private System.Windows.Forms.Label label2;
    }
}