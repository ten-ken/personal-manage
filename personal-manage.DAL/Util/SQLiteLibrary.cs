using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using personal_manage.Common.attr;
using System.IO;

namespace personal_manage.DAL.Util
{
    /// <summary>
    /// cuis
    /// </summary>
    public static class SQLiteLibrary
    {
        private static string sqliteDbName = "zbfz.sqlite";  //数据库名称
        private static string sqliteDbLocation = "database"; //数据库存放路径

        /// <summary>
        /// 创建数据库 支持x64的环境
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        public static void CreateDB(String dbLocation, String dbName)
        {
            //位置需要指定
            SQLiteConnection conn = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                //Directory.Exists(dbPath)
                conn = new SQLiteConnection("data source=" + dbPath);
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        ///  删除数据库
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        public static void DeleteDB(String dbLocation, String dbName)
        {
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                if (System.IO.File.Exists(dbPath))
                {
                    System.IO.File.Delete(dbPath);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }

        /// <summary>
        ///  创建表
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        public static void CreateTestTable(String dbLocation, String dbName)
        {
            SQLiteConnection conn = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                // cmd.CommandText = "CREATE TABLE t1(id varchar(4),score int)";
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS test(id varchar(4),score int)";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        /// <param name="tableName">表名</param>
        public static void DeleteTable(String dbLocation, String dbName, String tableName)
        {
            SQLiteConnection conn = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DROP TABLE IF EXISTS  " + tableName;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// 执行删除语句
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        /// <param name="deleteSql">删除语句</param>
        public static void DeleteBySql(String dbLocation, String dbName, String deleteSql)
        {
            SQLiteConnection conn = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = deleteSql;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// 通过insert into语句向数据库中插入数据
        /// </summary>
        /// <param name="dbLocation">数据库路径</param>
        /// <param name="dbName">数据库表</param>
        /// <param name="insertSql">insert 语句</param>
        public static void insertData(String dbLocation, String dbName, String insertSql)
        {
            SQLiteConnection conn = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 根据指定字段删除数据记录
        /// </summary>
        /// <param name="dbLocation"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <param name="filedName">字段名</param>
        /// <param name="value">字段值</param>
        public static void deleteDataByField(String dbLocation, String dbName, String tableName, String filedName, String value)
        {
            SQLiteConnection conn = null;
            try
            {

                String dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM " + tableName + " WHERE " + filedName + "='" + value + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// 根据sql语句查询数据
        /// </summary>
        /// <param name="dbLocation"></param>
        /// <param name="dbName"></param>
        /// <param name="selectSql"></param>
        /// <returns></returns>
        public static DataTable selectDataBySql(String dbLocation, String dbName, String selectSql)
        {
            SQLiteConnection dbConnection = null;
            try
            {
                String dbPath = dbLocation + @"\" + dbName;
                dbConnection = new SQLiteConnection("data source=" + dbPath);
                if (dbConnection.State != System.Data.ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                SQLiteCommand sqlcmd = new SQLiteCommand(selectSql, dbConnection);//sql查询语句
                sqlcmd.CommandTimeout = 120;
                SQLiteDataReader reader = sqlcmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (reader != null)
                {
                    dt.Load(reader, LoadOption.PreserveChanges, null);
                }
                return dt;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (dbConnection != null)
                {
                    dbConnection.Close();
                }
            }
        }



        /// <summary>
        ///  新增 语句
        /// </summary>
        /// <param name="insertSql"></param>
        public static void InsertBySql(string insertSql)
        {
            ExcuteSql(insertSql);
        }

        /// <summary>
        ///  修改 语句
        /// </summary>
        /// <param name="updateSql"></param>
        public static void UpdateSql(string updateSql)
        {
            ExcuteSql(updateSql);
        }


        /// <summary>
        ///  删除 语句
        /// </summary>
        /// <param name="deteleBySql"></param>
        public static void DeteleBySql(string deleteSql)
        {
            ExcuteSql(deleteSql);

        }

        /// <summary>
        /// 执行 新增修改 删除的公共方法
        /// </summary>
        /// <param name="insertSql"></param>
        public static void ExcuteSql(string insertSql)
        {
            //String dbLocation, String dbName,
            SQLiteConnection conn = null;
            try
            {
                string dbPath = sqliteDbLocation + @"\" + sqliteDbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("发送异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// 执行 新增修改 删除的公共方法
        /// </summary>
        /// <param name="insertSql"></param>
        public static void ExcuteSql(string dbLocation, string dbName, string sql)
        {
            //String dbLocation, String dbName,
            SQLiteConnection conn = null;
            try
            {
                string dbPath = dbLocation + @"\" + dbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("发送异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbLocation"></param>
        /// <param name="dbName"></param>
        /// <param name="selectSql"></param>
        /// <returns></returns>
        public static List<T> SelectBySql<T>(String dbLocation, String dbName, String selectSql)
        {
            var list = new List<T>();
            SQLiteConnection dbConnection = null;
            try
            {
                BindingFlags comm = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
                Type tbc = typeof(T);

                FieldInfo[] fields = tbc.GetFields(comm);

                //  PropertyInfo[] propertyInfos = tbc.GetProperties(comm);

                Dictionary<string, PropertyInfo> fieldDic = new Dictionary<string, PropertyInfo>();

                object currentValue = null;
                string currentField = null;
                IEnumerable<TableFieldAttribute> enumerable = null;

                for (int ind = 0; ind < fields.Length; ind++)
                {
                    enumerable = fields[ind].GetCustomAttributes<TableFieldAttribute>();

                    foreach (TableFieldAttribute attr in enumerable)
                    {
                        if (attr != null && attr.ColumName != null && !"".Equals(attr.ColumName))
                        {
                            fieldDic.Add(attr.ColumName, tbc.GetProperty(UpperCaseFirst(fields[ind].Name)));
                            //table.Add(fieldInfos[i].Name, attr);
                        }

                    }
                }

                string dbPath = dbLocation + @"\" + dbName;
                dbConnection = new SQLiteConnection("data source=" + dbPath);
                if (dbConnection.State != System.Data.ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                SQLiteCommand sqlcmd = new SQLiteCommand(selectSql, dbConnection);//sql查询语句
                sqlcmd.CommandTimeout = 120;
                SQLiteDataReader reader = sqlcmd.ExecuteReader();

                T entity;
                object v = null;
                while (reader.Read())
                {
                    entity = Activator.CreateInstance<T>();
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        currentValue = reader.GetValue(j);
                        currentField = reader.GetName(j);



                        //GetJAVAField(reader.GetName(j));

                        if (fieldDic.ContainsKey(currentField))
                        {
                            if (fieldDic[currentField].PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(currentValue, Nullable.GetUnderlyingType(fieldDic[currentField].PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(currentValue, fieldDic[currentField].PropertyType);
                            }

                            fieldDic[currentField].SetValue(entity, v, null);
                        }
                    }
                    list.Add(entity);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (dbConnection != null)
                {
                    dbConnection.Close();
                }
            }
            return list;
        }


        /// <summary>
        ///  查询语句
        /// </summary>
        /// <param name="selectSql"></param>
        /// <returns></returns>
        public static DataTable selectBySql(string selectSql)
        {
            SQLiteConnection conn = null;
            try
            {
                string dbPath = sqliteDbLocation + @"\" + sqliteDbName;
                conn = new SQLiteConnection("data source=" + dbPath);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SQLiteCommand sqlcmd = new SQLiteCommand(selectSql, conn);//sql查询语句
                sqlcmd.CommandTimeout = 120;
                SQLiteDataReader reader = sqlcmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (reader != null)
                {
                    dt.Load(reader, LoadOption.PreserveChanges, null);
                }
                return dt;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        //将表字段换成java适配的属性风格
        public static string GetJAVAField(string name)
        {
            name = name.ToLower();
            string pattern = @"(_|-)[0-9a-zA-Z]";

            foreach (Match match in Regex.Matches(name, pattern))
            {
                name = name.Replace(match.Value, match.Value.Substring(1).ToUpper());
            }

            return name;
        }

        /// <summary>
        ///  首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperCaseFirst(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            char[] s = str.ToCharArray();
            char c = s[0];
            if ('a' <= c && c <= 'z')
                c = (char)(c & ~0x20);
            s[0] = c;

            return new string(s);
        }

        /////保留
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqlArr"></param>
        public static bool ExecuteSqlByTransaction(string dbLocation, string dbName, string[] sqlArr)
        {
            bool executeFlag = true;
            string connectionStr = "data source=" + dbLocation + @"\" + dbName;

            using (SQLiteConnection conn = new SQLiteConnection(connectionStr))
            {
                conn.Open();
                using (SQLiteTransaction trans = conn.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    try
                    {
                        //循环
                        foreach (string singleSql in sqlArr)
                        {
                            PrepareCommand(cmd, conn, trans, singleSql, null);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        executeFlag = false;
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return executeFlag;
        }

        /// <summary>
        ///  预编译的sql命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


    }
}
