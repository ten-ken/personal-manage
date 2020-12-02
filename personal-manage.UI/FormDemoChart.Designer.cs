namespace personal_manage.UI
{
    partial class FormDemoChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart4);
            this.panel1.Controls.Add(this.chart3);
            this.panel1.Controls.Add(this.chart2);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 684);
            this.panel1.TabIndex = 0;
            // 
            // chart4
            // 
            chartArea13.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart4.Legends.Add(legend13);
            this.chart4.Location = new System.Drawing.Point(693, 356);
            this.chart4.Name = "chart4";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chart4.Series.Add(series13);
            this.chart4.Size = new System.Drawing.Size(354, 300);
            this.chart4.TabIndex = 1;
            this.chart4.Text = "chart1";
            // 
            // chart3
            // 
            chartArea14.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chart3.Legends.Add(legend14);
            this.chart3.Location = new System.Drawing.Point(127, 356);
            this.chart3.Name = "chart3";
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chart3.Series.Add(series14);
            this.chart3.Size = new System.Drawing.Size(337, 300);
            this.chart3.TabIndex = 2;
            this.chart3.Text = "chart1";
            // 
            // chart2
            // 
            chartArea15.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.chart2.Legends.Add(legend15);
            this.chart2.Location = new System.Drawing.Point(693, 35);
            this.chart2.Name = "chart2";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chart2.Series.Add(series15);
            this.chart2.Size = new System.Drawing.Size(344, 294);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart1";
            // 
            // chart1
            // 
            chartArea16.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea16);
            legend16.Name = "Legend1";
            this.chart1.Legends.Add(legend16);
            this.chart1.Location = new System.Drawing.Point(117, 29);
            this.chart1.Name = "chart1";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(347, 300);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // FormDemoChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(1165, 684);
            this.Controls.Add(this.panel1);
            this.Name = "FormDemoChart";
            this.Text = "FormDemoChart";
            this.Load += new System.EventHandler(this.FormDemoChart_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormDemoChart_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDemoChart_Paint);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}