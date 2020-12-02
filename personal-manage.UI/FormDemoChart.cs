using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using personal_manage.Common.util;

namespace personal_manage.UI
{
    public partial class FormDemoChart : Form
    {
        public delegate void RefreshChartDelegate(List<int> x, List<int> y, string type);

        private int y;

        public FormDemoChart()
        {
            InitializeComponent();
        }

        private void FormDemoChart_Load(object sender, EventArgs e)
        {
            //显示滚动条
            this.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new Size() { Width = 1181, Height = 723 };
            this.VerticalScroll.Visible = true;//竖的
            y = 0;
            this.VerticalScroll.Value = y;


            chart1.Series.Clear();
            ChartHelper.AddSeries(chart1, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
            ChartHelper.AddSeries(chart1, "曲线图", SeriesChartType.Spline, Color.Red, Color.Red);
            ChartHelper.SetTitle(chart1, "柱状图与曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
            ChartHelper.SetStyle(chart1, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            ChartHelper.SetXY(chart1, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            ChartHelper.SetMajorGrid(chart1, Color.Gray, 20, 2);

            chart2.Series.Clear();
            ChartHelper.AddSeries(chart2, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            ChartHelper.SetStyle(chart2, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart2, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            chart3.Series.Clear();
            ChartHelper.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            ChartHelper.SetTitle(chart3, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
            ChartHelper.SetStyle(chart3, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart3, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            ChartHelper.SetXY(chart3, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            ChartHelper.SetMajorGrid(chart3, Color.Gray, 20, 2);

            chart4.Series.Clear();
            ChartHelper.AddSeries(chart4, "饼状图", SeriesChartType.Funnel, Color.Lime, Color.Red, true);
            ChartHelper.SetStyle(chart4, Color.Transparent, Color.White);
            ChartHelper.SetLegend(chart4, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            RefreshData();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void RefreshData()
        {
            //数据
            List<int> x1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> y1 = new List<int>();
            Random ra = new Random();
            y1 = new List<int>() {
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10)
            };

            //刷新图表
            RefreshChart(x1, y1, "chart1");
            RefreshChart(x1, y1, "chart2");
            RefreshChart(x1, y1, "chart3");
            RefreshChart(x1, y1, "chart4");
        }


        private void RefreshChart(List<int> x, List<int> y, string type)
        {
            if (type == "chart1")
            {
                if (this.chart1.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart1.Series[0].Points.DataBindXY(x, y);
                    chart1.Series[1].Points.DataBindXY(x, y);
                }
            }
            else if (type == "chart2")
            {
                if (this.chart2.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart2.Series[0].Points.DataBindXY(x, y);
                    List<Color> colors = new List<Color>() {
                        Color.Red,
                        Color.DarkRed,
                        Color.IndianRed,
                        Color.MediumVioletRed,
                        Color.OrangeRed,
                        Color.PaleVioletRed,
                        Color.Purple,
                        Color.DarkOrange,
                        Color.Maroon,
                        Color.LightCoral,
                        Color.LightPink,
                        Color.Magenta
                    };
                    DataPointCollection points = chart2.Series[0].Points;
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].Color = colors[i];
                    }
                }
            }
            else if (type == "chart3")
            {
                if (this.chart3.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart3.Series[0].Points.DataBindXY(x, y);
                }
            }
            else if (type == "chart4")
            {
                if (this.chart4.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart4.Series[0].Points.DataBindXY(x, y);
                    List<Color> colors = new List<Color>() {
                        Color.Red,
                        Color.DarkRed,
                        Color.IndianRed,
                        Color.MediumVioletRed,
                        Color.OrangeRed,
                        Color.PaleVioletRed,
                        Color.Purple,
                        Color.DarkOrange,
                        Color.Maroon,
                        Color.LightCoral,
                        Color.LightPink,
                        Color.Magenta
                    };
                    DataPointCollection points = chart4.Series[0].Points;
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].Color = colors[i];
                    }
                }
            }
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }


        private void FormDemoChart_Paint(object sender, PaintEventArgs e)
        {
            this.VerticalScroll.Value = y;
        }

        private void FormDemoChart_Scroll(object sender, ScrollEventArgs e)
        {
            y = this.VerticalScroll.Value;
        }
    }
}
