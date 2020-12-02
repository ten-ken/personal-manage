using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.DAL;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Common.util;
using personal_manage.Common.extendmethods;
using personal_manage.Common.attr;
using System.Data;
using personal_manage.Common.vo;

namespace personal_manage.DAL.Base
{
    /// <summary>
    ///  父 DAL
    /// </summary>
     public class BaseDAL{

        /// <summary>
        ///  查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="whereCols">查询条件</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> SelectList<T>(T t,string cols,string whereCols, WhereType whereType)
        {
            SqlModel selectModel = CreateSqlHelper.SelectSql(t, cols, whereCols, whereType);

            DataTable dataTable = SQLiteHelper.ExecuteDataTable(selectModel.Sql,false, selectModel.SqlParameters);

            List<T> lists = DbConvert.TableToList<T>(dataTable);

            return lists;
        }
        
        
        /// <summary>
        ///  分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="whereCols">查询条件</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public PageInfo<T> SelectPage<T>(PageInfo<T> pageInfo,string cols,string whereCols, WhereType whereType)
        {
     
            SqlModel selectModel = CreateSqlHelper.SelectSqlByPage(pageInfo, cols, whereCols, whereType);

            DataTable dataTable = SQLiteHelper.ExecuteDataTable(selectModel.Sql,false, selectModel.SqlParameters);

            List<T> lists = DbConvert.TableToList<T>(dataTable);


            SqlModel selectCountModel = CreateSqlHelper.SelectCount(pageInfo.ParamsSearch, whereCols, whereType);

            object result = SQLiteHelper.ExecuteScalar(selectCountModel.Sql, false, selectCountModel.SqlParameters);

            int total = Convert.ToInt32(result);
            int totalPage = 0;

            if (total % pageInfo.PageSize == 0)
            {
                totalPage = total / pageInfo.PageSize ;
            }
            else
            {
                totalPage = total / pageInfo.PageSize + 1;
            }

            pageInfo.TotalPage = totalPage;
            pageInfo.Records = lists;
            pageInfo.CurrentCount = total;
                //lists.Count;

            return pageInfo;
        }


        /// <summary>
        ///  查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="whereCols">查询条件</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> SelectPage<T>(T t, string cols, string whereCols, WhereType whereType)
        {

            SqlModel insertModel = CreateSqlHelper.SelectSql(t, cols, whereCols, whereType);

            DataTable dataTable = SQLiteHelper.ExecuteDataTable(insertModel.Sql, false, insertModel.SqlParameters);

            List<T> lists = DbConvert.TableToList<T>(dataTable);

            return lists;
        }

        /// <summary>
        ///  新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cols">选择性插入的字段</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<T>(T t,string cols,bool needReturn)
        {
            if (t == null)
            {
                return 0;
            }
           
            SqlModel insertModel = CreateSqlHelper.InsertSql(t, cols, needReturn);

            if (!needReturn)
            {
                return SQLiteHelper.ExecuteNonQuery(insertModel.Sql, needReturn, insertModel.SqlParameters);
            }

            object resultObj = SQLiteHelper.ExecuteScalar(insertModel.Sql, false, insertModel.SqlParameters);

            if(resultObj!=null && resultObj.ToString() != "")
            {
                return Convert.ToInt32(resultObj);
            }
            return 0;
        }

        /// <summary>
        ///  批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols">选择性插入的字段</param>
        /// <returns></returns>
        public bool InsertBatch<T>(List<T> list, string cols, bool needReturn)
        {
            List<CommandInfo> commandInfos = new List<CommandInfo>();

            if (list == null || list.Count<=0)
            {
                return false;
            }
            CommandInfo commandInfo = null;
            SqlModel insertModel = null;
            for (int i = 0; i < list.Count; i++)
            {
                insertModel = CreateSqlHelper.InsertSql(list[i], cols, needReturn);

                commandInfo = new CommandInfo()
                {
                    CommendText = insertModel.Sql,
                    IsProcess = false,
                    Params = insertModel.SqlParameters
                };
                commandInfos.Add(commandInfo);
            }
            return SQLiteHelper.ExecuteTrans(commandInfos);
        }


        /// <summary>
        ///  修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols">选择性修改的字段</param>
        /// <param name="whereCols">修改的条件 可以是字段也可是  字段 逗号隔开的字段</param>
        /// <returns></returns>
        public int Update<T>(T t, string cols,string whereCols , WhereType whereType, bool needReturn)
        {
            if (t == null)
            {
                return 0;
            }

            SqlModel updateModel = CreateSqlHelper.UpdateSql(t, cols, whereCols, whereType);
            return SQLiteHelper.ExecuteNonQuery(updateModel.Sql, needReturn, updateModel.SqlParameters);
        }



        /// <summary>
        ///  批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols">选择性修改的字段</param>
        /// <param name="whereCols">修改的条件 可以是字段也可是  字段 逗号隔开的字段</param>
        /// <returns></returns>
        public bool UpdateBatch<T>(List<T> list, string cols,string whereStr,WhereType whereType)
        {
            List<CommandInfo> commandInfos = new List<CommandInfo>();

            if (list == null || list.Count <= 0)
            {
                return false;
            }
            CommandInfo commandInfo = null;
            SqlModel updateModel = null;
            for (int i = 0; i < list.Count; i++)
            {
                updateModel = CreateSqlHelper.UpdateSql(list[i], cols, whereStr, whereType);

                commandInfo = new CommandInfo()
                {
                    CommendText = updateModel.Sql,
                    IsProcess = false,
                    Params = updateModel.SqlParameters
                };
                commandInfos.Add(commandInfo);
            }
            return SQLiteHelper.ExecuteTrans(commandInfos);
        }


        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="logDel">是否逻辑删除</param>
        /// <returns></returns>
        public int Delete<T>(T t,bool logDel,string cols)
        {
            if (t == null)
            {
                return 0;
            }
            SqlModel deleteModel = null;
            if (!logDel)
            {
                deleteModel = CreateSqlHelper.DeleteSql(t, cols);
            }
            else
            {
                //待完善
                //deleteModel = CreateSqlHelper.UpdateSql(t, cols);
            }
            return SQLiteHelper.ExecuteNonQuery(deleteModel.Sql, false, deleteModel.SqlParameters);
        }


        /// <summary>
        ///  批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete<T>(List<int> idList)
        {
            List<CommandInfo> commandInfos = new List<CommandInfo>();

            if (idList == null || idList.Count <= 0)
            {
                return false;
            }
            CommandInfo commandInfo = null;
            SqlModel deleteModel = null;

            string whereStr = "";

            Type type = typeof(T);

            PrimaryKeyAttribute primaryKeyAttribute = type.GetPrimaryKey();

            for (int i = 0; i < idList.Count; i++){

                whereStr = string.Format("{0}='{1}'", primaryKeyAttribute.ColumnName, idList[i]);

                deleteModel = CreateSqlHelper.DeleteSqlByWhere<T>(whereStr);

                commandInfo = new CommandInfo()
                {
                    CommendText = deleteModel.Sql,
                    IsProcess = false,
                    Params = deleteModel.SqlParameters
                };
                commandInfos.Add(commandInfo);
            }
            return SQLiteHelper.ExecuteTrans(commandInfos);
        }


        /// <summary>
        ///  查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="whereCols">查询条件</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public DataTable  SelectData(string sql)
        {
            DataTable dataTable = SQLiteHelper.ExecuteDataTable(sql, false, null);

            return dataTable;
        }

    }
}
