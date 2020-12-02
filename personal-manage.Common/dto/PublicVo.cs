//供应商信息
namespace personal_manage.Common.dto
{
   public static class PublicVo
    {

        private static string token;

        private static string account;

        private static string supplyId;

        //
        private static string id;

        //企业名称
        private static string supplyName;

        /**
         * 企业名称
         */
        private static string entName;

        /**
         * 企业简介
         */
        private static string entIntroduce;
        /**
         * 成立时间
         */
        private static string entRegTime;
        /**
         * 注册资本(万元)
         */
        private static string regCapital;
        /**
         * 注册地
         */
        private static string regPlace;
        /**
         * 厂房所在地(市)
         */
        private static string facBuildPlace;
        /**
         * 法定代表人
         */
        private static string legalRep;
        /**
         * 企业类型
         */
        private static string entType;
        /**
         * 单位类型
         */
        private static string deptType;
        /**
         * 企业性质
         */
        private static string entNature;
        /**
         * 营业执照注册号
         */
        private static string businessLicRegNo;
        /**
         * 营业执照有效期类型
         */
        private static string businessLicActiveType;
      
        /**
         * 工商登记号
         */
        private static string indusRegNo;
        /**
         * 组织机构代码
         */
        private static string orgNo;
        /**
         * 国税税务号
         */
        private static string nationalTaxNo;
        /**
         * 邮政编码
         */
        private static string postCode;
        /**
         * 通讯地址
         */
        private static string mailAddress;
        /**
         * 当前状态
         */
        private static string status;
        /**
         * 经营范围
         */
        private static string businessScope;
       
        /**
         * 登录账号
         */
        private static string loginAccount;
        /**
         * 登录密码
         */
        private static string loginPwd;


        public static string Account { get => account; set => account = value; }
        public static string SupplyId { get => supplyId; set => supplyId = value; }
        public static string SupplyName { get => supplyName; set => supplyName = value; }
        public static string EntName { get => entName; set => entName = value; }
        public static string EntIntroduce { get => entIntroduce; set => entIntroduce = value; }
        public static string EntRegTime { get => entRegTime; set => entRegTime = value; }
        public static string RegCapital { get => regCapital; set => regCapital = value; }
        public static string RegPlace { get => regPlace; set => regPlace = value; }
        public static string FacBuildPlace { get => facBuildPlace; set => facBuildPlace = value; }
        public static string LegalRep { get => legalRep; set => legalRep = value; }
        public static string EntType { get => entType; set => entType = value; }
        public static string DeptType { get => deptType; set => deptType = value; }
        public static string EntNature { get => entNature; set => entNature = value; }
        public static string BusinessLicRegNo { get => businessLicRegNo; set => businessLicRegNo = value; }
        public static string BusinessLicActiveType { get => businessLicActiveType; set => businessLicActiveType = value; }
        public static string IndusRegNo { get => indusRegNo; set => indusRegNo = value; }
        public static string OrgNo { get => orgNo; set => orgNo = value; }
        public static string NationalTaxNo { get => nationalTaxNo; set => nationalTaxNo = value; }
        public static string PostCode { get => postCode; set => postCode = value; }
        public static string MailAddress { get => mailAddress; set => mailAddress = value; }
        public static string Status { get => status; set => status = value; }
        public static string BusinessScope { get => businessScope; set => businessScope = value; }
        public static string LoginAccount { get => loginAccount; set => loginAccount = value; }
        public static string LoginPwd { get => loginPwd; set => loginPwd = value; }
        public static string Id { get => id; set => id = value; }
        public static string Token { get => token; set => token = value; }
    }
}
