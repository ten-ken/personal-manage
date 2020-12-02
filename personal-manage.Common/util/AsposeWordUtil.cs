using Aspose.Words;
using Aspose.Words.Drawing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using personal_manage.Common.extendmethods;//扩展方法的引用

namespace personal_manage.Common.util
{
    public class AsposeWordUtil
    {
        static Document doc;
        static DocumentBuilder builder;

        private static string sqliteDbName = ConfigurationManager.AppSettings["sqliteDBName"].ToString();  //数据库名称
        private static string sqliteDbLocation = ConfigurationManager.AppSettings["sqliteDBLocation"].ToString(); //数据库存放路径


        public static void CreateTable(string bookName, DataTable dt)
        {
            try
            {
                builder.MoveToBookmark(bookName);
                //builder.StartTable();//开始画Table              

                Aspose.Words.Tables.Table table = builder.StartTable();
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center; // RowAlignment.Center;                  

                string str = string.Empty;

                builder.RowFormat.Height = 20;
                //builder.RowFormat.HeightRule = HeightRule.Auto;

                //添加列头  
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    builder.InsertCell();
                    //Table单元格边框线样式  
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    //Table此单元格宽度  
                    builder.CellFormat.Width = 500;

                    //此单元格中内容垂直对齐方式  
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;
                    builder.CellFormat.HorizontalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    //字体大小  
                    builder.Font.Size = 10;
                    //是否加粗  
                    builder.Bold = true;
                    //向此单元格中添加内容  
                    builder.Write(dt.Columns[i].ColumnName);
                }
                builder.EndRow();

                //添加每行数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    builder.RowFormat.HeightRule = HeightRule.Auto;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        str = dt.Rows[i][j].ToString();
                        //插入Table单元格  
                        builder.InsertCell();

                        //Table单元格边框线样式  
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;

                        //Table此单元格宽度 跟随列头宽度  
                        builder.CellFormat.Width = 500;

                        //此单元格中内容垂直对齐方式  
                        builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        builder.CellFormat.HorizontalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;

                        //字体大小  
                        builder.Font.Size = 10;
                        //是否加粗  
                        builder.Bold = false;

                        //向此单元格中添加内容  
                        builder.Write(str);

                    }

                    //Table行结束  
                    builder.EndRow();

                }
                table.AutoFit(Aspose.Words.Tables.AutoFitBehavior.FixedColumnWidths);///设置表格宽度   适应设置的宽度
                builder.EndTable();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                //addLog("插入表格出现 " + ex.Message);
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bookName"></param>
        /// <param name="list"></param>
        /// <param name="columNames"></param>
        /// <param name="propNames"></param>
        public static void CreateTable<T>(string bookName, List<T> list, string[] columNames, string[] propNames)
        {
            try
            {
                Type tbc = typeof(T);
                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
                PropertyInfo[] propInfos = tbc.GetProperties(bindingFlags);

                builder.MoveToBookmark(bookName);
                builder.StartTable();//开始画Table              

                Aspose.Words.Tables.Table table = builder.StartTable();
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center; // RowAlignment.Center;                  

                string str = string.Empty;

                builder.RowFormat.Height = 20;
                //builder.RowFormat.HeightRule = HeightRule.Auto;

                PropertyInfo propertyInfo;
                //添加列头  
                for (int i = 0; i < columNames.Length; i++)
                {
                    builder.InsertCell();
                    //Table单元格边框线样式  
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    //Table此单元格宽度  
                    builder.CellFormat.Width = 500;

                    //此单元格中内容垂直对齐方式  
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;
                    builder.CellFormat.HorizontalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    //字体大小  
                    builder.Font.Size = 10;
                    //是否加粗  
                    builder.Bold = true;
                    //向此单元格中添加内容  
                    //builder.Write(dt.Columns[i].ColumnName);
                    builder.Write(columNames[i]);
                }
                builder.EndRow();


                object cellV = null;
                //添加每行数据  
                for (int i = 0; i < list.Count; i++)
                {
                    builder.RowFormat.HeightRule = HeightRule.Auto;


                    foreach (string propName in propNames)
                    {
                        propertyInfo = tbc.GetProperty(propName.UpperCaseFirst());
                        if (propertyInfo != null)
                        {
                            cellV = propertyInfo.GetValue(list[i]);

                        }
                        str = (cellV == null || "".Equals(cellV.ToString())) ? " " : cellV.ToString();

                        //dt.Rows[i][j].ToString();

                        //插入Table单元格  
                        builder.InsertCell();

                        //Table单元格边框线样式  
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;

                        //Table此单元格宽度 跟随列头宽度  
                        builder.CellFormat.Width = 500;

                        //此单元格中内容垂直对齐方式  
                        builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

                        builder.CellFormat.HorizontalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;

                        //字体大小  
                        builder.Font.Size = 10;
                        //是否加粗  
                        builder.Bold = false;

                        //向此单元格中添加内容  
                        builder.Write(str);
                    }
                    //Table行结束  
                    builder.EndRow();

                }
                //table.AutoFit(Aspose.Words.Tables.AutoFitBehavior.FixedColumnWidths);///设置表格宽度   适应设置的宽度
                builder.EndTable();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                // addLog("插入表格出现 " + ex.Message);
            }
        }


        public static void SetBookVal(string bookName, string Values)
        {
            if (Values != null)
            {
                doc.Range.Bookmarks[bookName].Text = Values;
            }
        }


        public static void SetBookImg(string bookName, string imgPath, double Width = 650, double Height = 850)
        {
            builder.MoveToBookmark(bookName);

            Image img = Image.FromFile(imgPath);

            builder.InsertImage(img, RelativeHorizontalPosition.Margin, 20, RelativeVerticalPosition.Paragraph, 0, Width, Height, WrapType.Square);

            for (int i = 0; i < 25; i++)
            {
                builder.Writeln();
            }
        }




        /// <summary>
        /// 宽度永远比高度长
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="imgPath"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public static void SetBookCrossImg(string bookName, string imgPath, double Width = 300, double Height = 450)
        {
            try
            {
                builder.MoveToBookmark(bookName);
                builder.InsertBreak(BreakType.SectionBreakNewPage);
                builder.PageSetup.PaperSize = PaperSize.A4;

                //设置纸张大小：
                //    builder.PageSetup.PaperSize = PaperSize.A4;
                //         插入纵页：
                //    builder.PageSetup.Orientation = Aspose.Words.Orientation.Portrait;
                //         插入横页：
                //    builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
                double a = 600, b = 850;

                //double a = 300, b = 450;

                double ConfigWidth = 0, ConfigHeight = 0;
                using (Image img = Image.FromFile(imgPath))
                {
                    if (img.Height > img.Width)
                    {
                        ConfigHeight = Height;
                        ConfigWidth = Width;
                        builder.PageSetup.Orientation = Aspose.Words.Orientation.Portrait;
                    }
                    else
                    {
                        ConfigHeight = Width;
                        ConfigWidth = Height;
                        builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
                    }
                    builder.InsertImage(img, RelativeHorizontalPosition.Margin, 20, RelativeVerticalPosition.Paragraph, 0, ConfigWidth, ConfigHeight, WrapType.Square);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public static void CreateFile(byte[] buffs, string fullPathWithExtension)
        {
            //写二进制文件
            BinaryWriter bw;
            //创建一个二进制文件

            FileStream fs = new FileStream(fullPathWithExtension, FileMode.Create, FileAccess.Write);
            bw = new BinaryWriter(fs);//初始化一个BinaryWriter
            bw.Write(buffs);//写入
            bw.Close();//关闭
        }



    }
}