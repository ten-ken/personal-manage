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
    ///  一般由于批量执行的sql语句
    /// </summary>
    public class CommandInfo
    {

        public string CommendText { get; set; }

        //参数列表
        public SQLiteParameter[] Params { get; set; }

        //是否存储过程
        public bool IsProcess { get; set; }

        public CommandInfo()
        {
        }

        public CommandInfo(string commendText, bool isProcess)
        {
            CommendText = commendText;
            IsProcess = isProcess;
        }

        public CommandInfo(string commendText, SQLiteParameter[] @params, bool ispProcess)
        {
            CommendText = commendText;
            Params = @params;
            IsProcess = ispProcess;
        }

    }
}
