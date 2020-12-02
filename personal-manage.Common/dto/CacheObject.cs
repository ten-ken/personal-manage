using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.dto
{
    public class CacheObject
    {
        /// <summary>
        ///  缓存的对象
        /// </summary>
        public object CacheObj { get; set; }

        /// <summary>
        ///  按秒计算--》 存活时间
        /// </summary>
        public int ExpiryTime { get; set; }

        /// <summary>
        ///  失效时间
        /// </summary>
        public DateTime OverTime { get; set; }

    }
}
