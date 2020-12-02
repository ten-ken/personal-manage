using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.DAL;
using personal_manage.Common.dto;
using personal_manage.DAL.adapter;
using personal_manage.Models.entity;

namespace personal_manage.BLL.adapter
{
    public class DbBLL
    {
        public List<TableInfo> SelectTableList(CodeProjectDbConfigInfo codeProjectDbConfigInfo, string tableKeyword)
        {
            if (codeProjectDbConfigInfo.DbType == "Mysql" )
            {
              return  DbAdapter.SelectTableNameByMySql(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableKeyword);
            }else if(codeProjectDbConfigInfo.DbType == "Oracle")
            {
                return DbAdapter.SelectTableNameByOracle(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableKeyword);
            }
            else if (codeProjectDbConfigInfo.DbType == "Sqlite")
            {
                return DbAdapter.SelectTableNameBySqlite(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableKeyword);
            }


            return null;
        }


        public List<TableFieldInfo> SelectTableFields(CodeProjectDbConfigInfo codeProjectDbConfigInfo, string tableName)
        {
            if (codeProjectDbConfigInfo.DbType == "Mysql")
            {
                return DbAdapter.SelectTableFieldsByMySql(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableName);
            }
            else if (codeProjectDbConfigInfo.DbType == "Oracle")
            {
                return DbAdapter.SelectTableFieldsByOracle(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableName);
            }
            else if (codeProjectDbConfigInfo.DbType == "Sqlite")
            {
                return DbAdapter.SelectTableFieldsBySqlite(codeProjectDbConfigInfo.DbConnect, codeProjectDbConfigInfo.DbName, tableName);
            }

            return null;
        }
    }
}
