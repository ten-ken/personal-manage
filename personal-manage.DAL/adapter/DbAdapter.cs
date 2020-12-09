using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.DAL;
using personal_manage.Common.dto;
using personal_manage.Common.util;
using personal_manage.DAL.Util;

namespace personal_manage.DAL.adapter
{
    public class DbAdapter
    {

     /*   /// <summary>
        ///  mysql 查询数据库所有表
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static List<TableFieldInfo> SelectByMySql(string connectionStr, string tableName, string dbName)
        {
            string sql = "SELECT COLUMN_NAME as ColumnName,CHARACTER_MAXIMUM_LENGTH as MaxLength,COLUMN_COMMENT as Comment,DATA_TYPE as DataType,COLUMN_KEY as ColumnKey,EXTRA as Extra FROM";
            sql += $" INFORMATION_SCHEMA.COLUMNS WHERE 1=1";
            if (!string.IsNullOrEmpty(tableName))
            {
               sql+=$" and table_name in ({tableName}) ";
            }
            sql += $" and TABLE_SCHEMA = '{dbName}";
            sql += $" INFORMATION_SCHEMA.COLUMNS WHERE 1=1";
            MySqlHelper.connectionString = connectionStr;
            DataTable dataTable = MySqlHelper.ExecuteDataTable(sql, false, null);
            List<TableFieldInfo> lists = DbConvert.TableToList<TableFieldInfo>(dataTable);
            return lists;
        }*/

 


        /// <summary>
        ///  mysql 查询数据库表的字段 备注 数据库类型 长度 等数据
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<TableFieldInfo> SelectTableFieldsByMySql(string dbConnect, string dbName, string tableName)
        {
            string sql = "SELECT COLUMN_NAME as ColumnName,CHARACTER_MAXIMUM_LENGTH as MaxLength,COLUMN_COMMENT as Comments,DATA_TYPE as DataType,COLUMN_KEY as ColumnKey,EXTRA as Extra FROM";
            sql += $" INFORMATION_SCHEMA.COLUMNS WHERE 1=1";
            sql += $" and table_name ='{tableName}' and TABLE_SCHEMA = '{dbName}'";
            MySqlHelper.connectionString = dbConnect;
            DataTable dataTable = MySqlHelper.ExecuteDataTable(sql, false, null);
            List<TableFieldInfo> lists = DbConvert.TableToList<TableFieldInfo>(dataTable);
            return lists;
        }

    


        /// <summary>
        /// 通过mysql 及条件 查询所有表
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableKeyword"></param>
        /// <returns></returns>

        public static List<TableInfo> SelectTableNameByMySql(string connectionStr,string dbName, string tableKeyword)
        {
            //List<string> lists = new List<string>();

            string sql = $"select TABLE_NAME,TABLE_COMMENT,TABLE_COLLATION,ENGINE from information_schema.tables where table_schema='{dbName}'";
            if (!string.IsNullOrEmpty(tableKeyword))
            {
                sql += $" and TABLE_NAME like '%{tableKeyword}%'";
            }
            MySqlHelper.connectionString = connectionStr;
            DataTable dataTable = MySqlHelper.ExecuteDataTable(sql, false, null);
            /*for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                lists.Add(dataTable.Rows[i]["TABLE_NAME"].ToString());
            }*/
            return DbConvert.TableToList<TableInfo>(dataTable);
        }


        /// <summary>
        /// 通过oracle 及条件 查询所有表
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableKeyword"></param>
        /// <returns></returns>
        public static List<TableInfo> SelectTableNameByOracle(string dbConnect, string dbName, string tableKeyword)
        {

            StringBuilder sbf = new StringBuilder();
            sbf.Append("SELECT A.TABLE_NAME as TABLE_NAME,b.COMMENTS TABLE_COMMENT FROM user_tables A,user_tab_comments b ");
            sbf.Append("WHERE   A.TABLE_NAME = b.TABLE_NAME ");
            if (!string.IsNullOrEmpty(tableKeyword))
            {
                sbf.Append($" and A .TABLE_NAME = '{tableKeyword}'");
            }
            sbf.Append(" ORDER BY TABLE_NAME");
            OracleHelper.connectionString = dbConnect;
            DataTable dataTable = OracleHelper.ExecuteDataTable(sbf.ToString(), false, null);
            List<TableInfo> lists = DbConvert.TableToList<TableInfo>(dataTable);
            return lists;
        }


        /// <summary>
        ///  oracle 查询数据库表的字段 备注 数据库类型 长度 等数据
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<TableFieldInfo> SelectTableFieldsByOracle(string dbConnect, string dbName, string tableName)
        {
            StringBuilder mainSbf = new StringBuilder();
            mainSbf.Append(" SELECT user_tab_columns.column_name AS ColumnName,");
            mainSbf.Append(" user_tab_columns.DATA_TYPE AS DataType,user_tab_columns.DATA_LENGTH AS MaxLength,");
            mainSbf.Append(" user_tab_columns.NULLABLE AS Nullable,user_tab_columns.NULLABLE as Nullable,");
            mainSbf.Append(" user_col_comments.Comments as Comments FROM user_tab_columns");
            mainSbf.Append(" inner join user_col_comments on user_col_comments.column_name = user_tab_columns.column_name ");
            mainSbf.Append($" WHERE user_tab_columns.table_name = '{tableName}'  and user_col_comments.table_name = '{tableName}'");


            MySqlHelper.connectionString = dbConnect;
            DataTable dataTable = OracleHelper.ExecuteDataTable(mainSbf.ToString(), false, null);
            List<TableFieldInfo> lists = new List<TableFieldInfo>();
            TableFieldInfo tableFieldInfo;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableFieldInfo = new TableFieldInfo();
                tableFieldInfo.ColumnName = dataTable.Rows[i].Field<string>("COLUMNNAME");
                tableFieldInfo.DataType = dataTable.Rows[i].Field<string>("DATATYPE");
                tableFieldInfo.MaxLength = Int32.Parse(dataTable.Rows[i]["MAXLENGTH"].ToString());
                tableFieldInfo.Nullable = dataTable.Rows[i].Field<string>("Nullable");
                tableFieldInfo.Comment = dataTable.Rows[i].Field<string>("COMMENTS");
                lists.Add(tableFieldInfo);
            }
            StringBuilder sbfPri = new StringBuilder();
            sbfPri.Append("select col.column_name as ColumnName  from user_constraints con, user_cons_columns col where");
            sbfPri.Append($" con.constraint_name = col.constraint_name and con.constraint_type = 'P' and col.table_name = '{tableName}'");

            DataTable dataTable2 = OracleHelper.ExecuteDataTable(sbfPri.ToString(), false, null);
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                for (int k = 0; k < lists.Count; k++)
                {
                    if (dataTable2.Rows[i].Field<string>("COLUMNNAME") == lists[k].ColumnName)
                    {
                        lists[k].ColumnKey = "PRI";
                        break;
                    }
                }
            }

            return lists;
        }



        /// <summary>
        ///  sqlite 查询数据库所有表
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<TableInfo> SelectTableNameBySqlite(string dbConnect, string dbName, string tableKeyword)
        {
            List<TableInfo> lists = new List<TableInfo>();
            try
            {
                string sqlAllTable = "SELECT name as TABLE_NAME FROM sqlite_master WHERE type='table' and name!='sqlite_sequence' ";
                if (!string.IsNullOrEmpty(tableKeyword))
                {
                    sqlAllTable += $" and name like '%{tableKeyword}%'";
                }
                sqlAllTable += " ORDER BY name";

                SQLiteHelper.connectionString = dbConnect;
                DataTable dataTable = SQLiteHelper.ExecuteDataTable(sqlAllTable, false, null);
                lists = DbConvert.TableToList<TableInfo>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SQLiteHelper.connectionString = $@"data source={AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["dbRootFolder"].ToString()}\{ConfigurationManager.AppSettings["dbName"].ToString()}";

            }
            return lists;
        }

        /// <summary>
        ///  sqlite 查询数据库表的字段 备注 数据库类型 长度 等数据
        /// </summary>
        /// <param name="dbConnect"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<TableFieldInfo> SelectTableFieldsBySqlite(string dbConnect, string dbName, string tableName)
        {
            List<TableFieldInfo> lists = new List<TableFieldInfo>();
            try
            {
                string sql = $"PRAGMA  table_info('{tableName}');";
                SQLiteHelper.connectionString = dbConnect;
                DataTable dataTable = SQLiteHelper.ExecuteDataTable(sql, false, null);
                //List<TableInfo> lists = DbConvert.TableToList<TableInfo>(dataTable);
                TableFieldInfo tableFieldInfo;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    tableFieldInfo = new TableFieldInfo();
                    tableFieldInfo.ColumnName = dataTable.Rows[i].Field<string>("name");
                    tableFieldInfo.DataType = dataTable.Rows[i].Field<string>("type");
                    tableFieldInfo.MaxLength = 50;//默认
                    tableFieldInfo.Nullable = dataTable.Rows[i]["notnull"].ToString() == "1" ? "YES" : "NO";
                    tableFieldInfo.ColumnKey = dataTable.Rows[i]["pk"].ToString() == "1" ? "PRI" : "";
                    lists.Add(tableFieldInfo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SQLiteHelper.connectionString = $@"data source={AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["dbRootFolder"].ToString()}\{ConfigurationManager.AppSettings["dbName"].ToString()}";

            }



            return lists;
        }

    }
}
