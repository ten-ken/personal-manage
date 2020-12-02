using System;
using System.Collections.Generic;
using System.Text;
using personal_manage.Common.attr;
using personal_manage.Common.vo;


//供应商保证金缴纳明细
namespace personal_manage.Models.entity
{
    [TableName("OS_ZB_SUPPLIER_DEPOSIT_DETAIL")]
    public class OsZbSupplierDepositDetail
    {



        /* private string packName;


         [TableFieldAttr("ATTACH_ID", null, null, false, false, null)]
         [ColumnInfoAttr(-1, 35, false, null, "")]
         private string attachId;


         [TableFieldAttr("VOUCHER_CATEGORY", null, null, false, false, null)]
         [ColumnInfoAttr(0, 35, false, null, "")]
         private string voucherCategory;


         [TableFieldAttr("ID", null, null, true, true, null)]
         [ColumnInfoAttr(1, 35, false, null, "")]
         private string id;


         [TableFieldAttr("PARENT_ID", null, null, false, false, null)]
         [ColumnInfoAttr(2, 35, false, null, "")]
         private string parentId;

         [VerifyAttr(-1,"分标编号",new string[] {"baozhengjin"})]
         [TableFieldAttr("MARK_NO", null, null, false, false, null)]
         [ColumnInfoAttr(3, 35, false, null, "")]
         private string markNo;



         [TableFieldAttr("PACK_NO", null, null, false, false, null)]
         [ColumnInfoAttr(4, 35, false, null, "")]
         private string packNo;

         [VerifyAttr(false,-1, "保证金-金额", "^\\d{1,10}(\\.\\d{1,5})?\\d", new string[] { "baozhengjin" })]
         [TableFieldAttr("DEPOSIT_MONEY", null, null, false, false, null)]
         [ColumnInfoAttr(5, 35, false, null, "")]
         private string depositMoney;

         //[VerifyAttr(-1, "保证金-保险", new string[] { "baozhengjin" })]
         [TableFieldAttr("DEPOSIT_INSURE", null, null, false, false, null)]
         [ColumnInfoAttr(6, 35, false, null, "")]
         private string depositInsure;

         //^\\d{1,15}(\\.\\d{1,7})?$
         [VerifyAttr(-1,"保证金-总额", new string[] { "baozhengjin" })]
         [TableFieldAttr("TOTAL_MONEY", null, null, false, false, null)]
         [ColumnInfoAttr(7, 35, false, null, "")]
         private string totalMoney;

         [VerifyAttr(-1, "缴纳时间", new string[] { "baozhengjin" })]
         [TableFieldAttr("PAY_TIME", null, null, false, false, null)]
         [ColumnInfoAttr(8, 35, false, null, "")]
         private string payTime;


         [TableFieldAttr("REMARK", null, null, false, false, null)]
         [ColumnInfoAttr(9, 35, false, null, "")]
         private string remark;


         [TableFieldAttr("CREATE_USER", null, null, false, false, null)]
         [ColumnInfoAttr(10, 35, false, null, "")]
         private string createUser;


         [TableFieldAttr("CREATE_TIME", null, null, false, false, null)]
         [ColumnInfoAttr(11, 35, false, null, "")]
         private string createTime;


         [TableFieldAttr("UPDATE_USER", null, null, false, false, null)]
         [ColumnInfoAttr(12, 35, false, null, "")]
         private string updateUser;


         [TableFieldAttr("UPDATE_TIME", null, null, false, false, null)]
         [ColumnInfoAttr(13, 35, false, null, "")]
         private string updateTime;

         //是否新增行
         [TableFieldAttr("isAddRow", false)]
         private string isAddRow;

         //标下拉框
         private List<ComboBoxVo> markList;

         //包下拉框
         private List<ComboBoxVo> packList;*/

        ///<summary>
        ///主键
        ///</summary>
        [PrimaryKey("ID")]
        public string Id { get; set; }


        ///<summary>
        ///无注释
        ///</summary>
        [TableField("PACK_NAME")]
        public string PackName { get; set; }

        ///<summary>
        ///附件
        ///</summary>
        [TableField("ATTACH_ID")]
        public string AttachId { get; set; }

        ///<summary>
        ///凭证【附件】类别:baodan(保单)/（huikuan）汇款
        ///</summary>
        [TableField("VOUCHER_CATEGORY")]
        public string VoucherCategory { get; set; }

        ///<summary>
        ///缴纳主表ID
        ///</summary>
        [TableField("PARENT_ID")]
        public string ParentId { get; set; }

        ///<summary>
        ///分标编号
        ///</summary>
        [TableField("MARK_NO")]
        public string MarkNo { get; set; }

        ///<summary>
        ///分包编号
        ///</summary>
        [TableField("PACK_NO")]
        public string PackNo { get; set; }

        ///<summary>
        ///保证金-金额
        ///</summary>
        [TableField("DEPOSIT_MONEY")]
        public string DepositMoney { get; set; }

        ///<summary>
        ///保证金-保险
        ///</summary>
        [TableField("DEPOSIT_INSURE")]
        public string DepositInsure { get; set; }

        ///<summary>
        ///总额
        ///</summary>
        [TableField("TOTAL_MONEY")]
        public string TotalMoney { get; set; }

        ///<summary>
        ///缴纳时间
        ///</summary>
        [TableField("PAY_TIME")]
        public string PayTime { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        [TableField("REMARK")]
        public string Remark { get; set; }

        ///<summary>
        ///创建人
        ///</summary>
        public string CreateUser { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateTime { get; set; }

        ///<summary>
        ///更新人
        ///</summary>
        public string UpdateUser { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        public string UpdateTime { get; set; }

        public int CurExcelIndex { get; set; }
        public List<ComboBoxVo> MarkList { get; set; }
        public List<ComboBoxVo> PackList { get; set; }
        public string IsAddRow { get; set; }
    }
}
