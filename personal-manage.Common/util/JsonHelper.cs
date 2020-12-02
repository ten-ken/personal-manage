using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace personal_manage.Common.util
{
    /// <summary>
    ///  json 转换的辅助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        ///  对象转json串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonStr(object obj)
        {
            JavaScriptSerializer jserial = new JavaScriptSerializer();
            return jserial.Serialize(obj);
        }

        /// <summary>
        ///  json串转对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToJsonObject<T>(string jsonStr)
        {
            JavaScriptSerializer jserial = new JavaScriptSerializer();
            return jserial.Deserialize<T>(jsonStr);
        }


    }
}
