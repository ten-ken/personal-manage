using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.DAL.Util
{
    public class OracleHelper
    {
        //数据库连接字符串
        public static string connectionString = "server=192.168.0.118;port=3306;database=erp-xh;user=root;password=123456";

        /// <summary> 
        /// 执行一个查询语句，返回一个包含查询结果的DataTable [多行结果] 
        /// *** 常用于数据量比较大的情况下 ==》只填充到单表  如果是多表使用DataSet
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="parameters">执行查询语句的参数</param> 
        /// <returns></returns> 
        public static DataTable ExecuteDataTable(string sql, bool isProcess, params OracleParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand command = ConfigCommand(connection, sql, isProcess, parameters);

                OracleDataReader reader = command.ExecuteReader();
                DataTable data = new DataTable();
                if (reader != null)
                {
                    data.Load(reader, LoadOption.PreserveChanges, null);
                }
                return data;
            }
        }

        /// <summary>
        ///  配置OracleCommand
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sql"></param>
        /// <param name="isProcess"></param>
        /// <returns></returns>
        private static OracleCommand ConfigCommand(OracleConnection connection, string sql, bool isProcess, OracleParameter[] parameters)
        {
            //sql,connection
            OracleCommand command = new OracleCommand();
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
