
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.dto;

namespace personal_manage.Common.DAL

{
    public static class SQLiteHelper
    {
        
        //数据库根目录【非顶级目录】
        private static string dbRootFolder = ConfigurationManager.AppSettings["dbRootFolder"].ToString(); //数据库存放根目录

        //数据库名称
        private static string dbName = ConfigurationManager.AppSettings["dbName"].ToString(); //数据库名称加后缀

        public static string connectionString = $@"data source={AppDomain.CurrentDomain.BaseDirectory}{dbRootFolder}\{dbName}";


        /// <summary>
        ///  设置连接
        /// </summary>
        /// <param name="connectionStr"></param>
        public static void SetConnectionString(string connectionStr)
        {
            connectionString = connectionStr;
        }

        /// <summary> 
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。 
        /// </summary> 
        /// <param name="sql">要执行的增删改的SQL语句</param> 
        /// <param name="parameters">执行增删改语句的参数</param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string sql, bool isProcess, params SQLiteParameter[] parameters)
        {
            int affectedRows = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    SQLiteCommand command = ConfigCommand(connection, sql, isProcess,parameters);
                    affectedRows = command.ExecuteNonQuery();

                    command.Parameters.Clear();//防止上一次的参数缓存
                    transaction.Commit();
                    connection.Close();
                }
            }
            return affectedRows;
        }

     


        /// <summary> 
        /// 执行一个查询语句，返回SQLiteDataReader实例   
        /// *** =》一般用于修改
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="parameters">执行查询语句的参数</param> 
        /// <returns></returns> 
        public static SQLiteDataReader ExecuteReader(string sql, bool isProcess, params SQLiteParameter[] parameters)
        {
            SQLiteConnection connection = null;
            SQLiteDataReader sQLiteDataReader = null;
            try
            {
                connection = new SQLiteConnection(connectionString);
                SQLiteCommand command = ConfigCommand(connection, sql, isProcess, parameters);
                //connection.Open();//==>这个不需要  这个执行完后关闭连接 
                sQLiteDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("创建Reader对象发送异常", ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }     
            return sQLiteDataReader;
        }


        /// <summary> 
        /// 执行一个查询语句，返回一个包含查询结果的DataTable [多行结果] 
        /// *** 常用于数据量比较大的情况下 ==》只填充到单表  如果是多表使用DataSet
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="parameters">执行查询语句的参数</param> 
        /// <returns></returns> 
        public static DataTable ExecuteDataTable(string sql, bool isProcess, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = ConfigCommand(connection, sql, isProcess, parameters);

                SQLiteDataReader reader = command.ExecuteReader();
                DataTable data = new DataTable();
                if (reader != null)
                {
                    data.Load(reader, LoadOption.PreserveChanges, null);
                }

                /*  SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                  DataTable data = new DataTable();
                  adapter.Fill(data);*/

                //connection.Close(); //不需要 填充完后会自动关闭
                return data;
            }
        }


        /// <summary> 
        /// 执行一个查询语句，返回查询结果的第一行第一列 [永远只有一行结果]
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public static Object ExecuteScalar(string sql, bool isProcess, params SQLiteParameter[] parameters)
        {
            object result = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = ConfigCommand(connection, sql, isProcess, parameters);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                //下面的注释不可取 空白数据会用已有数据填充 造成重复数据
                /*DataTable data = new DataTable();
                adapter.Fill(data);*/
                result = command.ExecuteScalar();

                command.Parameters.Clear();//防止上一次的参数缓存

                //connection.Close(); //不需要 因为会自动关闭
                if (result == null || result == DBNull.Value)
                {
                    result = null;
                }
                return result;

            }
        }


        /// <summary>
        /// 批量删除、修改、新增 需要放到事务里面 不然保证不了一致性
        /// </summary>
        public static bool ExecuteTrans(List<string> listSql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                SQLiteCommand command = new SQLiteCommand(connection);

                try
                {
                    int count = 0;
                    for (int i = 0; i < listSql.Count; i++)
                    {
                        command.CommandText = listSql[i];
                        command.CommandType = CommandType.Text;
                        count += command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();//事务回滚
                    throw new Exception("执行事务出现异常",ex);
                }
            }
        }


        /// <summary>
        /// 批量删除、修改、新增 需要放到事务里面 不然保证不了一致性
        /// </summary>
        public static bool ExecuteTrans(List<CommandInfo> comList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                SQLiteCommand command = new SQLiteCommand(connection);
                try
                {
                    int count = 0;
                    for (int i = 0; i < comList.Count; i++)
                    {
                        command.CommandText = comList[i].CommendText;

                        //是否是存储过程
                        if (comList[i].IsProcess)
                        {
                            command.CommandType = CommandType.StoredProcedure;
                        }
                        else
                        {
                            command.CommandType = CommandType.Text;
                        }

                        if(comList[i].Params!=null && comList[i].Params.Length > 0)
                        {
                            command.Parameters.Clear();//清理上一次的参数

                            foreach (var item in comList[i].Params)
                            {
                                command.Parameters.Add(item);
                            }
                           
                        }
                        count += command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();//事务回滚
                    throw new Exception("执行事务出现异常", ex);
                }
            }
        }


        /// <summary>
        /// 执行事务==》 
        /// 运用了委托的方式 ==>把数据库连接和事务创建 “外包”给委托方法 让他代理执行
        /// </summary>
        public static T ExecuteTrans<T>(Func<IDbCommand,T> action)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                IDbCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                return action(command);
            }
        }


        /// <summary>
        ///  配置SQLiteCommand
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sql"></param>
        /// <param name="isProcess"></param>
        /// <returns></returns>
        private static SQLiteCommand ConfigCommand(SQLiteConnection connection, string sql, bool isProcess, SQLiteParameter[] parameters)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = sql;
            if (isProcess)
            {
                command.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                command.CommandType = CommandType.Text;
            }

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

    }
}