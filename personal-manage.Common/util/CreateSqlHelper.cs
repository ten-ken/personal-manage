using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.extendmethods;//扩展方法的引用
using personal_manage.Common.vo;

namespace personal_manage.Common.util
{
    //支持数据库 sqlite
    public class CreateSqlHelper

    {

        /// <summary>
        /// 创建查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static SqlModel SelectSql<T>(T t, string cols, string strWhere, WhereType whereType)
        {
            Type type = typeof(T);

            PropertyInfo[] propertyInfos = PropertyHelper.GetProperties<T>(cols);

            string colums = string.Join(",", propertyInfos.Where(p => p.IsExist()).Select(p => $"[{p.GetColumnName()}]"));

            bool isSql = WhereType.Columns.Equals(whereType);
            if (isSql && !string.IsNullOrEmpty(strWhere))
            {
                PropertyInfo[] whereProp = PropertyHelper.GetProperties<T>(strWhere);
                //.Where(p => !p.IsPrimaryKey())
                strWhere = string.Join(",", whereProp.Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));

                //合并两个数组 [去掉交集]
                List<PropertyInfo> newsProps = new List<PropertyInfo>(propertyInfos);
                bool flag = true;

                for (int w = 0; w < whereProp.Length; w++)
                {
                    for (int i = 0; i < newsProps.Count; i++)
                    {
                        if (newsProps[i].Name == whereProp[w].Name)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        newsProps.Add(whereProp[w]);
                    }
                }
                propertyInfos = newsProps.ToArray();
            }

            //生成参数数组
            SQLiteParameter[] arrParams = CreateParameters(propertyInfos, t);

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "  1=1 ";
            }

            string sql = $"SELECT {colums} FROM [{type.GetTableName()}] WHERE {strWhere} ";

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };

            return sqlModel;
        }


        /// <summary>
        ///  分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageInfo"></param>
        /// <param name="cols"></param>
        /// <param name="whereCols">column1='column1' and column2 ='column2'</param>
        /// <param name="whereType"></param>
        /// <returns></returns>
        public static SqlModel SelectSqlByPage<T>(PageInfo<T> pageInfo, string cols, string whereCols, WhereType whereType)
        {
            Type type = typeof(T);

            PropertyInfo[] propertyInfos = PropertyHelper.GetProperties<T>(cols);

            string colums = string.Join(",", propertyInfos.Where(p => p.IsExist()).Select(p => $"[{p.GetColumnName()}]"));

            bool isSql = WhereType.Columns.Equals(whereType);

            int start = pageInfo.CurrentPage > 1 ? pageInfo.CurrentPage - 1 : 0;
            int offlimit = start * pageInfo.PageSize;//

            if (isSql && !string.IsNullOrEmpty(whereCols))
            {
                PropertyInfo[] whereProp = PropertyHelper.GetProperties<T>(whereCols);
                whereCols = string.Join(",", whereProp.Where(p => !p.IsPrimaryKey()).Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));

                //合并两个数组 [去掉交集]
                List<PropertyInfo> newsProps = new List<PropertyInfo>(propertyInfos);
                bool flag = true;

                for (int w = 0; w < whereProp.Length; w++)
                {
                    for (int i = 0; i < newsProps.Count; i++)
                    {
                        if (newsProps[i].Name == whereProp[w].Name)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        newsProps.Add(whereProp[w]);
                    }
                }
                propertyInfos = newsProps.ToArray();
            }

            //生成参数数组
            SQLiteParameter[] arrParams = CreateParameters(propertyInfos, pageInfo.ParamsSearch);

            if (string.IsNullOrEmpty(whereCols))
            {
                whereCols = "  1=1 ";
            }

            string sql = $"SELECT {colums} FROM [{type.GetTableName()}] WHERE {whereCols} limit {offlimit},{pageInfo.PageSize}";

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };

            return sqlModel;
        }


        /// <summary>
        ///  条件查询结果 总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageInfo"></param>
        /// <param name="cols"></param>
        /// <param name="whereCols"></param>
        /// <param name="whereType"></param>
        /// <returns></returns>
        public static SqlModel SelectCount<T>(T t, string whereCols, WhereType whereType)
        {
            Type type = typeof(T);
            PropertyInfo[] whereProp = null;

            //参数数组
            SQLiteParameter[] arrParams = null;

            bool isSql = WhereType.Columns.Equals(whereType);

            if (isSql && !string.IsNullOrEmpty(whereCols))
            {
                whereProp = PropertyHelper.GetProperties<T>(whereCols);
                whereCols = string.Join(",", whereProp.Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));
                //生成参数数组
                 arrParams = CreateParameters(whereProp, t);
            }      

            if (string.IsNullOrEmpty(whereCols))
            {
                whereCols = "  1=1 ";
            }

            string sql = $"SELECT COUNT(0) FROM [{type.GetTableName()}] WHERE {whereCols}";

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };
            return sqlModel;
        }


        /// <summary>
        /// 创建新增语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static SqlModel InsertSql<T>(T t, string cols,bool needReturn){

            Type type = typeof(T);

            PropertyInfo[] propertyInfos = PropertyHelper.GetProperties<T>(cols);

            //生成要插入的列 $的出现｛｝就是占位符 里面就可以放变量
            string colums = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey()&&p.IsExist()).Select(p => $"[{p.GetColumnName()}]"));

            //生成插入的参数
            string paramColums = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey() && p.IsExist()).Select(p => $"@{p.GetColumnName()}"));

            //生成参数数组
            SQLiteParameter[] arrParams = CreateParameters(propertyInfos, t);

            string sql = $"INSERT INTO [{type.GetTableName()}] ({colums}) values({paramColums})";

            //需要返回主键id
            if (needReturn)
            {
                //sql += " ;select @@identity"; //sqlserver 支持
                sql += ";select last_insert_rowid();"; //sqlserver 支持
            }
                

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };

            return sqlModel;
        }


        /// <summary>
        /// 创建修改语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols"></param>
        /// <param name="strWhere">修改语句的条件/列【逗号隔开】</param>
        /// <returns></returns>
        public static SqlModel UpdateSql<T>(T t, string cols,string strWhere, WhereType whereType)
        {
            Type type = typeof(T);

            PrimaryKeyAttribute primaryKeyAttribute = type.GetPrimaryKey();

            string primaryKeyName = primaryKeyAttribute.ColumnName;

            PropertyInfo[] propertyInfos = PropertyHelper.GetProperties<T>(cols);

            //生成要插入的列 $的出现｛｝就是占位符 里面就可以放变量
            string colums = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey() && p.IsExist()).Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));

           
            bool isSql = WhereType.Columns.Equals(whereType);
            if (isSql && !string.IsNullOrEmpty(strWhere))
            {
                PropertyInfo[] whereProp = PropertyHelper.GetProperties<T>(strWhere);
                strWhere = string.Join(" and ", whereProp.Where(p => !p.IsPrimaryKey()).Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));

                //合并两个数组 [去掉交集]
                List<PropertyInfo> newsProps = new List<PropertyInfo>(propertyInfos);
                bool flag = true;

                for (int w = 0; w < whereProp.Length; w++)
                {
                    for (int i = 0; i < newsProps.Count; i++)
                    {
                        if (newsProps[i].Name == whereProp[w].Name)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        newsProps.Add(whereProp[w]);
                    }
                }
                propertyInfos = newsProps.ToArray();
            }

            //生成插入的参数
            string paramColums = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey()).Select(p => $"@{p.GetColumnName()}"));

            //生成参数数组
            SQLiteParameter[] arrParams = CreateParameters(propertyInfos, t);

            //默认更加主键修改
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = $"{primaryKeyName} =@{primaryKeyName}";
            }

            string sql = $" UPDATE [{type.GetTableName()}] SET {colums} WHERE {strWhere} ";

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };

            return sqlModel;
        }


        /// <summary>
        /// 创建删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="whereCols">删除的条件 如果木有默认通过主键</param>
        /// <returns></returns>
        public static SqlModel DeleteSql<T>(T t, string whereCols)
        {
            Type type = typeof(T);

            PrimaryKeyAttribute primaryKeyAttribute = type.GetPrimaryKey();

            string primaryKeyName = primaryKeyAttribute.ColumnName;

            PropertyInfo[] propertyInfos = PropertyHelper.GetProperties<T>(whereCols);

            string strWhere = "";

            //生成插入的参数
            string paramColums = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey()).Select(p => $"@{p.GetColumnName()}"));

            SQLiteParameter[] arrParams = null;


            if (string.IsNullOrEmpty(whereCols))
            {
                strWhere = $"{primaryKeyName} = '{primaryKeyAttribute.Prop.GetValue(t)}'";
            }
            else{
                //生成参数数组
                arrParams = CreateParameters(propertyInfos, t);
                strWhere = string.Join(",", propertyInfos.Where(p => !p.IsPrimaryKey()).Select(p => string.Format("[{0}]=@{0}", p.GetColumnName())));
            }

            string sql = $" DELETE FROM [{type.GetTableName()}]  WHERE {strWhere} ";

            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                SqlParameters = arrParams
            };

            return sqlModel;
        }


        /// <summary>
        /// 创建删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strWhere">自定义条件</param>
        /// <returns></returns>
        public static SqlModel DeleteSqlByWhere<T>(string strWhere)
        {
            Type type = typeof(T);

            //SQLiteParameter[] arrParams = null;
            string sql = $" DELETE FROM [{type.GetTableName()}]  WHERE {strWhere} ";
            SqlModel sqlModel = new SqlModel()
            {
                Sql = sql,
                //SqlParameters = arrParams
            };

            return sqlModel;
        }



        /// <summary>
        ///  创建参数集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyInfos"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static SQLiteParameter[] CreateParameters<T>(PropertyInfo[] propertyInfos, T t)
        {
            SQLiteParameter[] arrParams = propertyInfos.Select(p => new SQLiteParameter("@" + p.GetColumnName(), p.GetValue(t) ?? DBNull.Value)).ToArray();
            return arrParams;
        }

    }
}
