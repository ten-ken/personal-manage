using System;
using System.Collections.Generic;
using System.Text;
using personal_manage.Common.attr;

//供应商保证金缴纳主表
namespace personal_manage.Models.entity
{
    [TableName("OS_ZB_SUPPLIER_DEPOSIT")]
    public class OsZbSupplierDeposit
    {
        ///<summary>
        ///主键
        ///</summary>
        //[JsonProperty("id")]//匹配json的key是“id”而不是“Id”
        [TableField("ID")]
        public string Id { get ; set ; }

        ///<summary>
        ///供应商ID
        ///</summary>
        [PrimaryKey("SUPPLIER_ID")]   
        public string SupplierId { get ; set ; }

        ///<summary>
        ///采购项目编号
        ///</summary>
        [TableField("PROJECT_NO")]
        public string ProjectNo { get ; set ; }

        ///<summary>
        ///总额-金额
        ///</summary>
        [TableField("TOTAL_MONEY")]
        public string TotalMoney { get ; set ; }

        ///<summary>
        ///总额保险
        ///</summary>
       [TableField("TOTAL_INSURE")]
        public string TotalInsure { get ; set ; }

        ///<summary>
        ///总额
        ///</summary>
        [TableField("TOTAL")]
        public string Total { get ; set ; }

        ///<summary>
        ///备注
        ///</summary>
        [TableField("Remark")]
        public string Remark { get ; set ; }

        ///<summary>
        ///创建人
        ///</summary>
        public string CreateUser { get ; set ; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateTime { get ; set ; }

        ///<summary>
        ///更新人
        ///</summary>

        public string UpdateUser { get ; set ; }

        ///<summary>
        ///更新时间
        ///</summary>
        public string UpdateTime { get ; set ; }

        public List<OsZbSupplierDepositDetail> ListData { get ; set ; }
        public string AttachId { get ; set ; }
        public string VoucherCategory { get ; set ; }
        public string FilePath { get ; set ; }
    }
}
