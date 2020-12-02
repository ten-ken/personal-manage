using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Models.entity
{
    [TableName("CODE_PROJECT_DB_CONFIG_INFO")]
    public class CodeProjectDbConfigInfo
    {

        [PrimaryKey("ID")]
        public int ID { set; get; }

        [Verify(18, "数据库类型", false)]
        [TableField("DB_TYPE")]
        public string DbType { set; get; }

        [Verify(30, "数据库名称", false)]
        [TableField("DB_NAME")]
        public string DbName { set; get; }


        [Verify(600, "数据库连接", false)]
        [TableField("DB_CONNECT")]
        public string DbConnect { set; get; }


        [TableField("PROJECT_ID")]
        public int ProjectId { set; get; }



        [TableField("CREATE_TIME")]
        public string CREATE_TIME { set; get; }

        [TableField("CREATE_USER")]
        public string CREATE_USER { set; get; }

        [TableField("UPDATE_TIME")]
        public string UPDATE_TIME { set; get; }

        [TableField("UPDATE_USER")]
        public string UPDATE_USER { set; get; }

    }
}
