using System;
using System.Collections.Generic;
using Aspose.Cells;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace personal_manage.Common.util
{
    public class AsposeExcel
    {

        


        #region 导出execl
        public static void AddExcel(string path)
        {
            Workbook workbook = new Workbook(); //工作簿
            workbook.Save(path);
        }

        /// <summary> 
        /// 导出数据到本地 
        /// </summary> 
        /// <param name="dt">要导出的数据</param> 
        /// <param name="ExlTittleName">表格标题</param> 
        /// <param name="path">保存路径</param> 
        public static void OutFileToDisk(DataTable dt, string ExlNExlTittleNameame, string path)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            //setColumnWithAuto(sheet);//////统一设置列宽
            Cells cells = sheet.Cells;//单元格 

            //sheet.AutoFitRows();
            //cells.SetColumnWidth(0, 25);//设置列宽 
            sheet.Protection.AllowSelectingLockedCell = false;//设置只能选择解锁单元格  
            sheet.Protection.AllowFormattingColumn = true;//设置可以调整列  
            sheet.Protection.AllowFormattingRow = true;//设置可以调整行 

            //为标题设置样式     
            Style styleTitle = workbook.CreateStyle();//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center;
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 8;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Style style2 = workbook.CreateStyle();//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style2.VerticalAlignment = TextAlignmentType.Center;
            style2.ForegroundColor = System.Drawing.Color.Silver;//背景颜色
            style2.Pattern = BackgroundType.Solid;
            style2.Font.IsBold = true;
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 8;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style style3 = workbook.CreateStyle();//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.VerticalAlignment = TextAlignmentType.Center;
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 8;//文字大小 
            style3.IsTextWrapped = true;//单元格内容自动换行 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 

            //生成行1 标题行    
            cells.Merge(0, 0, 1, Colnum);//合并单元格 
            cells[0, 0].PutValue(ExlNExlTittleNameame);//填写内容 
            cells[0, 0].SetStyle(styleTitle);
            //cells.SetRowHeight(0, 38);

            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[1, i].PutValue(dt.Columns[i].ColumnName);
                cells[1, i].SetStyle(style2);
                cells.SetColumnWidth(i, dt.Columns[i].ColumnName.Length * 3);//设置列宽 s
                //cells.SetRowHeight(1, 25);
            }

            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                    cells[2 + i, k].SetStyle(style3);
                }
                //cells.SetRowHeight(2 + i, 24);
            }

            workbook.Save(path);
        }


        public static void OutFileToDisk(DataTable dt, string path)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            //setColumnWithAuto(sheet);//////统一设置列宽
            Cells cells = sheet.Cells;//单元格 

            //sheet.AutoFitRows();
            //cells.SetColumnWidth(0, 25);//设置列宽 
            sheet.Protection.AllowSelectingLockedCell = false;//设置只能选择解锁单元格  
            sheet.Protection.AllowFormattingColumn = true;//设置可以调整列  
            sheet.Protection.AllowFormattingRow = true;//设置可以调整行 

            //为标题设置样式     
            Style styleTitle = workbook.CreateStyle();//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center;
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 8;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Style style2 = workbook.CreateStyle();//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style2.VerticalAlignment = TextAlignmentType.Center;
            style2.ForegroundColor = System.Drawing.Color.Silver;//背景颜色
            style2.Pattern = BackgroundType.Solid;
            style2.Font.IsBold = true;
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 8;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style style3 = workbook.CreateStyle();//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.VerticalAlignment = TextAlignmentType.Center;
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 8;//文字大小 
            style3.IsTextWrapped = true;//单元格内容自动换行 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 


            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[0, i].PutValue(dt.Columns[i].ColumnName);
                cells[0, i].SetStyle(style2);
                cells.SetColumnWidth(i, dt.Columns[i].ColumnName.Length * 3);//设置列宽 s
                //cells.SetRowHeight(1, 25);
            }

            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    if (dt.Rows[i][k].ToString().Length > 32000)
                    {
                        cells[1 + i, k].PutValue(dt.Rows[i][k].ToString().Substring(0, 32000));
                    }
                    else
                    {
                        cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                    }
                    cells[1 + i, k].SetStyle(style3);
                }
            }

            workbook.Save(path);
        }


        public static void OutFileToDiskWithhyperlink(DataTable dt, Dictionary<string, Dictionary<string, List<string>>> dic_imgPath, string path)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            //setColumnWithAuto(sheet);//////统一设置列宽
            Cells cells = sheet.Cells;//单元格 

            //sheet.AutoFitRows();
            //cells.SetColumnWidth(0, 25);//设置列宽 
            sheet.Protection.AllowSelectingLockedCell = false;//设置只能选择解锁单元格  
            sheet.Protection.AllowFormattingColumn = true;//设置可以调整列  
            sheet.Protection.AllowFormattingRow = true;//设置可以调整行 

            #region 样式设置

            //为标题设置样式     
            Style styleTitle = workbook.CreateStyle();//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center;
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 8;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Style style2 = workbook.CreateStyle();//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style2.VerticalAlignment = TextAlignmentType.Center;
            style2.ForegroundColor = System.Drawing.Color.Silver;//背景颜色
            style2.Pattern = BackgroundType.Solid;
            style2.Font.IsBold = true;
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 8;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style style3 = workbook.CreateStyle();//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.VerticalAlignment = TextAlignmentType.Center;
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 8;//文字大小 
            style3.IsTextWrapped = true;//单元格内容自动换行 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            //样式4 超链接央视
            Style style4 = workbook.CreateStyle();//新增样式 
            style4.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style4.VerticalAlignment = TextAlignmentType.Center;
            style4.Font.Name = "宋体";//文字字体 
            style4.Font.Size = 8;//文字大小 
            style4.Font.Color = System.Drawing.Color.Blue;//文字大小 
            style4.IsTextWrapped = true;//单元格内容自动换行 
            style4.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style4.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style4.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style4.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;


            #endregion

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 


            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[0, i].PutValue(dt.Columns[i].ColumnName);
                cells[0, i].SetStyle(style2);
                cells.SetColumnWidth(i, dt.Columns[i].ColumnName.Length * 3);//设置列宽 

            }

            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    string colName = dt.Columns[k].ColumnName;
                    if (colName.Contains("商品图片"))//判断是否超链接行
                    {
                        cells[1 + i, k].SetStyle(style4);

                        string WSCGSQH = dt.Rows[i][1].ToString();
                        string BH = dt.Rows[i][3].ToString();

                        Dictionary<string, List<string>> keyValuePairs = dic_imgPath[WSCGSQH];
                        List<string> imgPath = keyValuePairs[BH];
                        if (imgPath.Count > k - 19)
                        {
                            cells[1 + i, k].PutValue(colName);///给单元格赋值
                            int offset = imgPath[k - 19].LastIndexOf('\\');//获得左后一个目录
                            offset = imgPath[k - 19].LastIndexOf('\\', offset - 1);//获得倒数第二个目录
                            string filePath = "." + imgPath[k - 19].Substring(offset, imgPath[k - 19].Length - offset);//修改为相对路径
                            sheet.Hyperlinks.Add(1 + i, k, 1, 1, filePath);////给单元格添加超链接
                        }
                    }
                    else
                    {
                        cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                        cells[1 + i, k].SetStyle(style3);
                    }

                }
            }

            workbook.Save(path);
        }


        #region 技术生成excel
        public static bool TecFileToDisk(DataTable dt, string tableName, string path, bool IsSetAutoHeight)
        {
            bool bl = false;
            try
            {
                Workbook workbook = new Workbook(); //工作簿 
                Worksheet sheet = workbook.Worksheets[0]; //工作表 
                                                          //setColumnWithAuto(sheet);//////统一设置列宽
                Cells cells = sheet.Cells;//单元格 

                //sheet.AutoFitRows();
                //cells.SetColumnWidth(0, 25);//设置列宽 
                sheet.Protection.AllowSelectingLockedCell = false;//设置只能选择解锁单元格  
                sheet.Protection.AllowFormattingColumn = true;//设置可以调整列  
                sheet.Protection.AllowFormattingRow = true;//设置可以调整行 

                //为标题设置样式     
                Style styleTitle = workbook.CreateStyle();//新增样式 
                styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                styleTitle.VerticalAlignment = TextAlignmentType.Center;
                styleTitle.Font.Name = "宋体";//文字字体 
                styleTitle.Font.Size = 8;//文字大小 
                styleTitle.Font.IsBold = true;//粗体 

                //样式2 
                Style style2 = workbook.CreateStyle();//新增样式 
                style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
                style2.VerticalAlignment = TextAlignmentType.Center;
                style2.ForegroundColor = System.Drawing.Color.Silver;//背景颜色
                style2.Pattern = BackgroundType.Solid;
                style2.Font.IsBold = true;
                style2.Font.Name = "宋体";//文字字体 
                style2.Font.Size = 8;//文字大小 
                style2.Font.IsBold = true;//粗体 
                style2.IsTextWrapped = true;//单元格内容自动换行 
                style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                //样式3 
                Style style3 = workbook.CreateStyle();//新增样式 
                style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                style3.VerticalAlignment = TextAlignmentType.Center;
                style3.Font.Name = "宋体";//文字字体 
                style3.Font.Size = 8;//文字大小 
                style3.IsTextWrapped = true;//单元格内容自动换行 
                style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                int Colnum = dt.Columns.Count;//表格列数 
                int Rownum = dt.Rows.Count;//表格行数 

                //生成行1 标题行    
                cells.Merge(0, 0, 1, Colnum);//合并单元格 
                cells[0, 0].PutValue(tableName);//填写内容 
                cells[0, 0].SetStyle(styleTitle);
                cells.SetRowHeight(0, 30);

                //生成行2 列名行 
                for (int i = 0; i < Colnum; i++)
                {
                    cells[1, i].PutValue(dt.Columns[i].ColumnName);
                    cells[1, i].SetStyle(style2);
                    if (i == 8 || i == 9 || i == 10)
                    {
                        //cells.SetColumnWidth(i, 12);//设置列宽 sk
                        cells.SetColumnWidthPixel(i, 70);
                    }
                    else
                    {
                        //cells.SetColumnWidth(i, 7);//设置列宽 sk
                        cells.SetColumnWidthPixel(i, 50);
                    }
                    if (IsSetAutoHeight)
                    {
                        cells.SetRowHeight(1, 60);
                    }

                }

                //生成数据行 
                for (int i = 0; i < Rownum; i++)
                {
                    for (int k = 0; k < Colnum; k++)
                    {
                        cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                        cells[2 + i, k].SetStyle(style3);
                        if (IsSetAutoHeight)
                        {
                            cells.SetRowHeight(2 + i, 60);
                        }
                    }

                }

                workbook.Save(path);
                bl = true;

            }
            catch (Exception ex)
            {
            }
            return bl;
        }
        #endregion

        #region 商务生成excel
        public static bool ComFileToDisk(DataTable dt, string tableName, string path, bool isSetAutoHeight)
        {
            bool bl = false;
            try
            {
                Workbook workbook = new Workbook(); //工作簿 
                Worksheet sheet = workbook.Worksheets[0]; //工作表 
                                                          //setColumnWithAuto(sheet);//////统一设置列宽
                Cells cells = sheet.Cells;//单元格 

                //sheet.AutoFitRows();
                //cells.SetColumnWidth(0, 25);//设置列宽 
                sheet.Protection.AllowSelectingLockedCell = false;//设置只能选择解锁单元格  
                sheet.Protection.AllowFormattingColumn = true;//设置可以调整列  
                sheet.Protection.AllowFormattingRow = true;//设置可以调整行 

                //为标题设置样式     
                Style styleTitle = workbook.CreateStyle();//新增样式 
                styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                styleTitle.VerticalAlignment = TextAlignmentType.Center;
                styleTitle.Font.Name = "宋体";//文字字体 
                styleTitle.Font.Size = 8;//文字大小 
                styleTitle.Font.IsBold = true;//粗体 

                //样式2 
                Style style2 = workbook.CreateStyle();//新增样式 
                style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中
                style2.VerticalAlignment = TextAlignmentType.Center;
                style2.ForegroundColor = System.Drawing.Color.Silver;//背景颜色
                style2.Pattern = BackgroundType.Solid;
                style2.Font.IsBold = true;
                style2.Font.Name = "宋体";//文字字体 
                style2.Font.Size = 8;//文字大小 
                style2.Font.IsBold = true;//粗体 
                style2.IsTextWrapped = true;//单元格内容自动换行 
                style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                //样式3 
                Style style3 = workbook.CreateStyle();//新增样式 
                style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                style3.VerticalAlignment = TextAlignmentType.Center;
                style3.Font.Name = "宋体";//文字字体 
                style3.Font.Size = 8;//文字大小 
                style3.IsTextWrapped = true;//单元格内容自动换行 
                style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                int Colnum = dt.Columns.Count;//表格列数 
                int Rownum = dt.Rows.Count;//表格行数 

                //生成行1 标题行    
                cells.Merge(0, 0, 1, Colnum);//合并单元格 
                cells[0, 0].PutValue(tableName);//填写内容 
                cells[0, 0].SetStyle(styleTitle);
                cells.SetRowHeight(0, 30);

                //生成行2 列名行 
                for (int i = 0; i < Colnum; i++)
                {
                    cells[1, i].PutValue(dt.Columns[i].ColumnName);
                    cells[1, i].SetStyle(style2);
                    if (i == 6 || i == 11)
                    {
                        cells.SetColumnWidthPixel(i, 70);
                    }
                    else
                    {
                        cells.SetColumnWidthPixel(i, 40);
                    }
                    if (isSetAutoHeight)
                    {
                        cells.SetRowHeight(1, 60);
                    }

                }

                //生成数据行 
                for (int i = 0; i < Rownum; i++)
                {
                    for (int k = 0; k < Colnum; k++)
                    {
                        cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                        cells[2 + i, k].SetStyle(style3);
                        if (isSetAutoHeight)
                        {
                            //cells.SetColumnWidth(i, 7);
                            cells.SetRowHeight(2 + i, 60);
                        }
                    }

                }
                workbook.Save(path);
                bl = true;

            }
            catch (Exception ex)
            {
            }
            return bl;
        }
        #endregion 

        #region 设置行高
        private static void setColumnWithAuto(Worksheet sheet)
        {
            Cells cells = sheet.Cells;
            int columnCount = cells.MaxColumn;  //获取表页的最大列数
            int rowCount = cells.MaxRow;        //获取表页的最大行数

            for (int col = 0; col < columnCount; col++)
            {
                cells.SetColumnWidthPixel(col, 20);
            }
            for (int col = 0; col < rowCount; col++)
            {
                cells.SetRowHeightPixel(col, 30);
            }
        }
        #endregion

        /// <summary>
        /// 根据模板生成数据
        /// </summary>
        /// <param name="TemplatePath">模板文件路径</param>
        /// <param name="Name">文件名称</param>
        /// <param name="dt">数据源（DataTable）</param>
        /// <param name="SavePath">保存文件的路径</param>
        public static void TemplateExcel(string TemplatePath, string Name, DataTable dt, string SavePath)
        {
            //  打开 Excel 模板
            Workbook CurrentWorkbook = File.Exists(TemplatePath) ? new Workbook(TemplatePath) : new Workbook();

            //  打开第一个sheet
            Worksheet DetailSheet = CurrentWorkbook.Worksheets[0];

            //  写入数据的起始位置
            string cell_start_region = "C1";
            //  获得开始位置的行号                    
            int startRow = DetailSheet.Cells[cell_start_region].Row;
            //  获得开始位置的列号  
            int startColumn = DetailSheet.Cells[cell_start_region].Column;

            //  写入Excel。参数说明，直接查阅文章底部文档链接
            DetailSheet.Cells.ImportDataTable(dt, false, startRow, startColumn, true, true);

            //  设置执行公式计算 - 如果代码中用到公式，需要设置计算公式，导出的报表中，公式才会自动计算
            CurrentWorkbook.CalculateFormula(true);

            //  保存文件
            CurrentWorkbook.Save(SavePath, SaveFormat.Xlsx);
        }

        public MemoryStream OutFileToStream(DataTable dt, string tableName)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 

            //为标题设置样式     
            Style styleTitle = workbook.CreateStyle();//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 18;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Style style2 = workbook.CreateStyle();//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 14;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style style3 = workbook.CreateStyle();//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 12;//文字大小 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 

            //生成行1 标题行    
            cells.Merge(0, 0, 1, Colnum);//合并单元格 
            cells[0, 0].PutValue(tableName);//填写内容 
            cells[0, 0].SetStyle(styleTitle);
            cells.SetRowHeight(0, 38);

            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[1, i].PutValue(dt.Columns[i].ColumnName);
                cells[1, i].SetStyle(style2);
                cells.SetRowHeight(1, 25);
            }

            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                    cells[2 + i, k].SetStyle(style3);
                }
                cells.SetRowHeight(2 + i, 24);
            }

            MemoryStream ms = workbook.SaveToStream();
            return ms;
        }
        #endregion

        #region 读取Excel文本数据
        public static string ExportToDataTableAsSingelRow(string excelFilePath)
        {
            Workbook workbook = new Workbook(excelFilePath);
            Cells cells = workbook.Worksheets[0].Cells;

            System.Data.DataTable dataTable2 = cells.ExportDataTableAsString(0, 0, 1, 1, true);//showTitle
            return dataTable2.Columns[0].ColumnName;
        }

        /// <summary>
        /// 读取exeel文本数据
        /// </summary>
        /// <param name="excelFilePath">物理路径地址</param>
        /// <param name="showTitle">是否包含标题(不是表头不是列明)</param>
        /// <returns></returns>
        public static DataTable ExportToDataTableAsString(string excelFilePath, bool showTitle = true)
        {
            Workbook workbook = new Workbook(excelFilePath);
            Cells cells = workbook.Worksheets[0].Cells;

            //System.Data.DataTable dataTable2 = cells.ExportDataTableAsString(1, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, showTitle);//showTitle
            System.Data.DataTable dataTable2;
            if (showTitle)
            {
                dataTable2 = cells.ExportDataTableAsString(1, 0, cells.MaxDataRow, cells.MaxColumn + 1, showTitle);//showTitle
            }
            else
            {
                dataTable2 = cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, showTitle);//showTitle
            }
            return dataTable2;
        }


        public static DataTable ExportToDataTableAsString(string excelFilePath, int skipRowCount, bool showTitle = true)
        {
            Workbook workbook = new Workbook(excelFilePath);
            Cells cells = workbook.Worksheets[0].Cells;








            System.Data.DataTable dataTable2 = cells.ExportDataTableAsString(0 + skipRowCount, 0, cells.MaxDataRow + 1 - skipRowCount, cells.MaxColumn + 1, showTitle);//showTitle
            return dataTable2;
        }
        /// <summary>
        /// 读取excel文本数据
        /// </summary>
        /// <param name="stream">文件流数据</param>
        /// <param name="showTitle">是否读取标题</param>
        /// <returns></returns>
        public static DataTable ExportToDataTableAsString(Stream stream, bool showTitle = true)
        {
            Workbook workbook = new Workbook(stream);
            //workbook.Open(stream);
            Cells cells = workbook.Worksheets[0].Cells;

            System.Data.DataTable dataTable2 = cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1, showTitle);//showTitle
            return dataTable2;
        }
        #endregion
    }

}
