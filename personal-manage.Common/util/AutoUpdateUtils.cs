/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Newtonsoft.Json;
using personal_manage.Common.dto;

namespace personal_manage.Common.util
{
    public class AutoUpdateUtils
    {
        private static string currentVesion = ConfigurationManager.AppSettings["version"].ToString();  //版本号

        /// <summary>
        /// 判定是否有新版本
        /// </summary>
        /// <returns></returns>
        public static R CheckUpdate()
        {
           
            R back = new R();
            bool result = false;
            
            try
            {
                OsZbToolVersion osZbToolVersion = new OsZbToolVersion();

                string api = ContantUtils.PUBLIC_CHECK_VERSION;

                R  r = WebRequestUtil.PostBasicApi(api, osZbToolVersion);

                if (r.Successful)
                {
                    osZbToolVersion = JsonConvert.DeserializeObject<OsZbToolVersion>(r.ResultValue.ToString());
                    var versionV = Convert.ToDouble((Regex.Replace(osZbToolVersion.VersionNo, "[^\\d\\.]", ""))) ;
                    var curVersionV = Convert.ToDouble((Regex.Replace(currentVesion, "[^\\d\\.]", "")));
                    result = versionV > curVersionV;
                    back.ResultValue = osZbToolVersion.VersionNo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"版本号对比错误:{ex.Message}");
            }
            back.Successful = result;

            return back;
        }




    }
}
*/