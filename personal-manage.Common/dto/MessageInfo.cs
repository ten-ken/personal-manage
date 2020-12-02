using System;
using System.Collections.Generic;
namespace personal_manage.Common.dto
{
    public class MessageInfo<T>
    {

        //成功的记录
        public List<T> Record { get ; set ; }

        //错误信息
        public string ErrorInfo { get ; set ; }

        //成功条数
        public int SuccessCount { get ; set ; }
        public int ErrorCount { get ; set ; }

        //是否成功
        public bool ExistError { get ; set ; }

        //总记录
        public int TotalCount { get ; set ; }

        public bool Success { get ; set ; }
       
        public string Code { get ; set ; }
       
       
    }
}
