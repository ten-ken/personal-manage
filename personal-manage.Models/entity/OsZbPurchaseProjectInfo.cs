using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Models.entity
{

    /// <summary>
    /// cs端 采购项目信息
    /// </summary>
    [TableName("OS_ZB_PURCHASE_PROJECT_INFO")]
    public class OsZbPurchaseProjectInfo
    {
     
        [PrimaryKey("ID")]
        public int Id { get; set; }

        [Verify(30,"项目编号",false)]
        [ColumnInfo(1,50)]
        [TableField("PROJECT_NO")]
        public string ProjectNo { get ; set ; }

 
        [Verify(50, "项目名称", false)]
        [ColumnInfo(2, 50)]
        [TableField("PROJECT_NAME")]
        public string ProjectName { get ; set; }

        [Verify(40, "标编号", false)]
        [ColumnInfo(3, 35)]
        [TableField("MARK_NO")]
        public string MarkNo { get ; set ; }


        [Verify(40, "标名称", false)]
        [ColumnInfo(4, 35)]
        [TableField("MARK_NAME")]
        public string MarkName { get; set; }


        [ColumnInfo(-1,15)]
        [TableField(false)]
        public long CurExcelIndex { get ; set ; }


    }
}
