using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.util
{
    class LocalFileUtil
    {
        /// <summary>
        /// 获取上传的文件所在的绝对路径
        /// </summary>
        /// <param name="realPath"></param>
        /// <returns></returns>
        public static string GetPath(string realPath)
        {
            string saveTempPath = AppDomain.CurrentDomain.BaseDirectory + "fujian\\" ;//附件存放的路径
            return saveTempPath + realPath;
        }
    }
}
