namespace personal_manage.UI.CsharpAuto
{
    partial class FormTemList
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listDataGriddView = new System.Windows.Forms.DataGridView();
            this.select_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.模板名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模板位置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail_row = new System.Windows.Forms.DataGridViewLinkColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAllCheck);
            this.panel1.Controls.Add(this.AddBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(202, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 30);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCheck.Location = new System.Drawing.Point(127, 12);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(63, 30);
            this.btnAllCheck.TabIndex = 21;
            this.btnAllCheck.Tag = "checkAll";
            this.btnAllCheck.Text = "全选";
            this.btnAllCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheck.UseVisualStyleBackColor = true;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddBtn.Location = new System.Drawing.Point(44, 12);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(68, 30);
            this.AddBtn.TabIndex = 20;
            this.AddBtn.Text = "新增";
            this.AddBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listDataGriddView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1222, 454);
            this.panel2.TabIndex = 0;
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
            this.模板名称,
            this.模板位置,
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
            this.listDataGriddView.Size = new System.Drawing.Size(1222, 454);
            this.listDataGriddView.TabIndex = 19;
            this.listDataGriddView.Tag = "999";
            this.listDataGriddView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListDataGriddView_CellClick);
            // 
            // select_check
            // 
            this.select_check.FalseValue = "false";
            this.select_check.HeaderText = "选择";
            this.select_check.Name = "select_check";
            this.select_check.ReadOnly = true;
            this.select_check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select_check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select_check.TrueValue = "true";
            this.select_check.Width = 51;
            // 
            // 模板名称
            // 
            this.模板名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.模板名称.DataPropertyName = "templateName";
            this.模板名称.HeaderText = "模板名称[英文]";
            this.模板名称.Name = "模板名称";
            this.模板名称.ReadOnly = true;
            // 
            // 模板位置
            // 
            this.模板位置.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.模板位置.DataPropertyName = "templatePath";
            this.模板位置.HeaderText = "模板位置";
            this.模板位置.Name = "模板位置";
            this.模板位置.ReadOnly = true;

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
            // FormTemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormTemList";
            this.Text = "模板列表";
            this.Load += new System.EventHandler(this.FormTemList_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGriddView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView listDataGriddView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模板名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模板位置;
        private System.Windows.Forms.DataGridViewLinkColumn detail_row;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}