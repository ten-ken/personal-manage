namespace personal_manage.UI.Components
{
    partial class DialogForm
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
            this.lbltop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picQuit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Content = new System.Windows.Forms.Panel();
            this.labelContent = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).BeginInit();
            this.panel2.SuspendLayout();
            this.Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltop
            // 
            this.lbltop.BackColor = System.Drawing.Color.Teal;
            this.lbltop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltop.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltop.ForeColor = System.Drawing.Color.White;
            this.lbltop.Location = new System.Drawing.Point(0, 0);
            this.lbltop.Name = "lbltop";
            this.lbltop.Size = new System.Drawing.Size(590, 43);
            this.lbltop.TabIndex = 32;
            this.lbltop.Text = "提示";
            this.lbltop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltop.Click += new System.EventHandler(this.lbltop_Click);
            this.lbltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbltop_MouseDown);
            this.lbltop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbltop_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.picQuit);
            this.panel1.Location = new System.Drawing.Point(601, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 28);
            this.panel1.TabIndex = 43;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // picQuit
            // 
            this.picQuit.Image = global::personal_manage.UI.Properties.Resources.form_close;
            this.picQuit.Location = new System.Drawing.Point(11, 4);
            this.picQuit.Name = "picQuit";
            this.picQuit.Size = new System.Drawing.Size(40, 20);
            this.picQuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuit.TabIndex = 42;
            this.picQuit.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.Content);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 102);
            this.panel2.TabIndex = 45;
            // 
            // Content
            // 
            this.Content.Controls.Add(this.labelContent);
            this.Content.Location = new System.Drawing.Point(45, 14);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(491, 70);
            this.Content.TabIndex = 0;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelContent.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelContent.Location = new System.Drawing.Point(0, 0);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(0, 19);
            this.labelContent.TabIndex = 0;
            this.labelContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 145);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogForm";
            this.Text = "DialogForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.Content.ResumeLayout(false);
            this.Content.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.PictureBox picQuit;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Timer timer1;
    }
}