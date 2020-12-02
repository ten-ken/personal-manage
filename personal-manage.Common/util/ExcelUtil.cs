using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using personal_manage.Common.attr;
using personal_manage.Common.dto;
using ExcelDataReader;
using personal_manage.Common.extendmethods;//扩展方法的引用

namespace personal_manage.Common.util
{
    //导入工具类
    public class ExcelUtil
    {

        //, Dictionary<string, string> dbListDict, string[] keys
        public static MessageInfo<T> ReadExcel<T>(int firstIndex)
        {
            MessageInfo<T> messageInfo = new MessageInfo<T>();
            FileStream fileStream = null;
            IExcelDataReader reader = null;
            DataSet result = null;

            try
            {
                //小于0 默认是第三行开始读取
                firstIndex = firstIndex < 0 ? 2 : firstIndex;

                OpenFileDialog fileImportDialog = new OpenFileDialog();
                fileImportDialog.Filter = "导入文件(*.xlsx)|*.xlsx";//扩展名
                fileImportDialog.FileName = "";
                if (fileImportDialog.ShowDialog() == DialogResult.OK)
                {
                    /*string saveTempPath = @System.AppDomain.CurrentDomain.BaseDirectory + "data\\receiveData\\";//临时存放的路径
                    if (!File.Exists(saveTempPath))
                    {
                        File.Create(saveTempPath);
                    }
                    string saveName = fileImportDialog.FileName.Substring(fileImportDialog.FileName.LastIndexOf("\\") + 1);
                    string dataPath = saveTempPath + saveName;//文件地址
                    File.Copy(fileImportDialog.FileNames[0], dataPath, true);*/

                    //解析处理  start
                    //stream = 
                    fileStream = File.Open(fileImportDialog.FileName, FileMode.Open, FileAccess.Read);
                    reader = ExcelReaderFactory.CreateReader(fileStream);

                    object[] curObject = new object[10];

                    result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                            ReadHeaderRow = (rowReader) =>
                            {
                                // 从第几行之后开始读取
                                int index = firstIndex;
                                if (index != rowReader.Depth)
                                {
                                    rowReader.Read();
                                }
                            }
                        }
                    });
                    DataTableCollection tableCollection = result.Tables;

                    //初步处理的数据
                    messageInfo = GetmessageInfo<T>(tableCollection[0], firstIndex);

                    //reader.Close();
                    return messageInfo;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("导入文件错误信息：" + ex.Message);
            }
            finally
            {
                //需要释放资源
                if (reader != null)
                {
                    reader.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (result != null)
                {
                    result.Clear();
                }
            }

            return messageInfo;
        }

        public static MessageInfo<T> GetmessageInfo<T>(DataTable dt, int firstIndex)
        {
            MessageInfo<T> messageInfo = new MessageInfo<T>();

            bool existError = false;

            int totalCount = dt.Rows.Count;

            int successCount = 0;

            //错误信息
            StringBuilder errorSb = new StringBuilder();

            //BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var list = new List<T>();
            Type type = typeof(T);

            ColumnInfoAttribute columnInfoAttr = null;

            //直接获取公有属性
            //FieldInfo[] fieldInfos = type.GetFields(bindingFlags);
            PropertyInfo[] propertyInfos = type.GetProperties();

            Dictionary<int, PropertyInfo> dictionAry = new Dictionary<int, PropertyInfo>();

            Dictionary<int, ColumnInfoAttribute> columnDic = new Dictionary<int, ColumnInfoAttribute>();

            //行属性 --- 需要修改
            for (int p = 0; p < propertyInfos.Length; p++)
            {
                columnInfoAttr = propertyInfos[p].GetCustomAttribute<ColumnInfoAttribute>();

                //propertyInfos[p].GetColumnAttriBute();
                if (columnInfoAttr != null)
                {
                    dictionAry.Add(columnInfoAttr.Index, propertyInfos[p]);
                    columnDic.Add(columnInfoAttr.Index, columnInfoAttr);
                }
            }

            PropertyInfo currentProp = null;

            //id属性
            PropertyInfo idProp = null;

            //实体
            T s;
            bool flag = false;

            int currentRow = firstIndex;

            foreach (DataRow item in dt.Rows)
            {
                currentRow++;

                s = Activator.CreateInstance<T>();

                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    if (dictionAry.ContainsKey(i))
                    {
                        currentProp = dictionAry[i];
                        columnInfoAttr = columnDic[i];
                        object v = null;

                        if (currentProp.PropertyType.ToString().Contains("System.Nullable"))
                        {
                            v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(currentProp.PropertyType));
                        }
                        else
                        {
                            v = Convert.ChangeType(item[i], currentProp.PropertyType);
                        }

                        //不可以为空==> 非空验证
                        if (!columnInfoAttr.Nullable && (v == null || v.ToString().Trim().Length <= 0))
                        {
                            //successCount++;
                            existError = true;
                            errorSb.Append("第" + currentRow + "行，" + dt.Columns[i].ColumnName + " 数据不得为空\n");
                            flag = true;
                        }

                        //不为空 超过了最大长度==> 长度验证
                        if (v != null && columnInfoAttr.Length < v.ToString().Length)
                        {
                            existError = true;
                            errorSb.Append("第" + currentRow + "行，" + dt.Columns[i].ColumnName + " 数据长度不得超过" + columnInfoAttr.Length + "个字符\n");
                            flag = true;
                        }

                        //正则验证部分==> 数据格式验证
                        if (v != null && columnInfoAttr.Pattern != null && columnInfoAttr.Pattern != "" && v.ToString().Trim().Length > 0)
                        {
                            //不匹配正则
                            if (!Regex.IsMatch(v.ToString().Trim(), columnInfoAttr.Pattern))
                            {
                                existError = true;
                                errorSb.Append("第" + currentRow + "行，" + dt.Columns[i].ColumnName + " 数据格式不正确");
                                flag = true;
                            }
                        }

                        //是否校验不合格
                        if (flag)
                        {
                            flag = false;
                            successCount++;
                            break;
                        }
                        currentProp.SetValue(s, v, null);

                    }

                }

                currentProp = dictionAry[-1];
                if (currentProp != null)
                {
                    currentProp.SetValue(s, currentRow, null);//设置excel的行列
                }
                currentProp = null;

                list.Add(s);
            }
            //返回的信息
            messageInfo.Record = list;
            messageInfo.ErrorInfo = errorSb.ToString();
            messageInfo.TotalCount = totalCount;
            messageInfo.ErrorCount = totalCount - successCount;
            messageInfo.SuccessCount = successCount;
            messageInfo.ExistError = existError;

            return messageInfo;
        }

    }
}
