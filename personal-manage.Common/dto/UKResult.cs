using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.dto
{
    public  class UKResult
    {
  
        /// <summary>
        /// 具体数据  成功后返回的数据，例如钥匙 ID“030242….”等， 失败则返回 null 
        /// </summary>
        public string Result { get; set ; }


        /// <summary>
        /// ：错误信息 成功则返回 null失败则返回错误信息
        /// </summary>
        public string Message { get ; set ; }


        /// <summary>
        /// 成功或错误代码成功会返回“0”，失败会返回响相应的错误代码比如“0x000000A4”(代表钥匙被锁了)
        /// </summary>
        public string Code { get; set ; }


        /// <summary>
        /// 额外的信息
        /// </summary>
        public string ExtraInfo { get; set; }

    }
}
