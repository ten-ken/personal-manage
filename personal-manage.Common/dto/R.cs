using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.dto
{
   public  class R {
        public int Code { get ; set ; }

        //错误信息
        public string ResultHint { get ; set ; }

        //是否成功
        public bool Successful { get ; set ; }

        //返回的结果
        public object ResultValue { get ; set ; }

        public R(int code, string resultHint, bool successful, object resultValue)
        {
            this.Code = code;
            this.ResultHint = resultHint;
            this.Successful = successful;
            this.ResultValue = resultValue;
        }

        public R(int code, bool successful, object resultValue)
        {
            this.Code = code;
            this.Successful = successful;
            this.ResultValue = resultValue;
        }



        public R()
        {
        }
    }
}
