using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using personal_manage.Common.dto;
using personal_manage.Common.util;

namespace personal_manage.DAL.Util
{
    public  class MySqlHelper
    {

            //数据库连接字符串
            public static string connectionString = "server=192.168.0.118;port=3306;database=erp-xh;user=root;password=123456";
            
            //用于缓存参数的hash表
            private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());



            /// <summary> 
            /// 执行一个查询语句，返回一个包含查询结果的DataTable [多行结果] 
            /// *** 常用于数据量比较大的情况下 ==》只填充到单表  如果是多表使用DataSet
            /// </summary> 
            /// <param name="sql">要执行的查询语句</param> 
            /// <param name="parameters">执行查询语句的参数</param> 
            /// <returns></returns> 
            public static DataTable ExecuteDataTable(string sql, bool isProcess, params MySqlParameter[] parameters)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = ConfigCommand(connection, sql, isProcess, parameters);

                    MySqlDataReader reader = command.ExecuteReader();
                    DataTable data = new DataTable();
                    if (reader != null)
                    {
                        data.Load(reader, LoadOption.PreserveChanges, null);
                    }
                    return data;
                }
            }

            /// <summary>
            ///  配置MySqlCommand
            /// </summary>
            /// <param name="connection"></param>
            /// <param name="sql"></param>
            /// <param name="isProcess"></param>
            /// <returns></returns>
            private static MySqlCommand ConfigCommand(MySqlConnection connection, string sql, bool isProcess, MySqlParameter[] parameters)
            {
            //sql,connection
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
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
