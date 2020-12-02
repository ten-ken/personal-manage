using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.dto{

    /// <summary>
    /// 验证的消息
    /// </summary>
    public class VerifyMessage{

        //错误数量
        public int ErrorCount { get ; set; }

        //错误信息
        public string ErrorInfo { get; set; }

        //存在错误
        public bool ExistError { get; set; }


        //提示信息==》意味着不阻碍业务进程进行
        public string PromptInfo { get; set; }



    }
}
