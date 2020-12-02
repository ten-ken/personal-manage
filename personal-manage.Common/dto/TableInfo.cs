using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Common.dto
{
    
    public class TableInfo
    {

        /// <summary>
        ///  表名
        /// </summary>
        [TableField("TABLE_NAME")]
        public string TableName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [TableField("TABLE_COMMENT")]
        public string TableComment { get; set; }

        // 数据库引擎 
        [TableField("ENGINE")]
        public string ENGINE { get; set; }


        // 表字符集
        [TableField("TABLE_COLLATION")]
        public string TableCollation { get; set; }
    }
}
