using System;
using System.Collections.Generic;
using System.Text;
using personal_manage.Common.attr;

//账号管理
namespace com.jysoft.ess.zbfz.entity
{
    [TableName("APP_ACCOUNT_MGN")]
    public class AppAccountMgn
    {

        ///<summary>
        /// ID
        ///</summary>
        [PrimaryKey("ID")]
        public int ID { get; set; }


        ///<summary>
        /// 账号
        ///</summary>
        [Verify(150, "来源", false)]
        [TableField("SOURCE")]
        public string SOURCE { get; set; }


        ///<summary>
        /// 账号
        ///</summary>
        [Verify(120, "账号", false)]
        [TableField("ACCOUNT")]
        public string ACCOUNT { get; set; }

        ///<summary>
        /// 伪码
        ///</summary>
        [Verify(-1, "伪码", false,Nullable=true)]
        [TableField("PSEUDO_CODE")]
        public string PSEUDOCODE { get; set; }

        ///<summary>
        /// 加密码
        ///</summary>
        [Verify(-1, "加密码", false,Nullable = true)]
        [TableField("ENC_PWD")]
        public string ENCPWD { get; set; }


        ///<summary>
        /// 管理密码
        ///</summary>
        [Verify(15, "管理密码", false, Nullable = false)]
        [TableField("MGN_PWD")]


        public string MGNPWD { get; set; }



        ///<summary>
        /// 管理密码
        ///</summary>
        [Verify(15, "二次输入密码", false, Nullable = false)]
        [TableField("jiaoyanPwd",IsExist =false)]
        public string JiaoyanPwd { get; set; }

        ///<summary>
        /// 输入密码
        ///</summary>
        [Verify(15, "密码", false, Nullable = false)]
        [TableField("InputPwd", IsExist = false)]
        public string InputPwd { get; set; }



        ///<summary>
        /// $item.Comment
        ///</summary>
        [TableField("REMARK")]
        public string REMARK { get; set; }


        [TableField("UPDATE_USER")]
        public string UPDATEUSER { get; set; }

        [TableField("CREATE_USER")]
        public string CREATEUSER { get; set; }

        [TableField("CREATE_TIME")]
        public string CREATETIME { get; set; }

        [TableField("UPDATE_TIME")]
        public string UPDATETIME { get; set; }

        public int CurExcelIndex { get; set; }

    }
}