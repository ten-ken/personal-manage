using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.dto
{
    /// <summary>
    /// sql模型 分别是sql语句和sql参数
    /// </summary>
    public class SqlModel
    {
        //sql
        public string Sql { get; set; }

        //参数
        public SQLiteParameter[] SqlParameters { get; set; }

    }
}
