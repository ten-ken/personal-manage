using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.extendmethods;

namespace personal_manage.Common.util
{
    //属性工具类
    public class PropertyHelper
    {
        public static PropertyInfo[]  GetProperties<T>(string cols)
        {
            Type type = typeof(T);
            return GetProperties(type, cols);
        }

        /// <summary>
        /// 获取需要的列
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(Type type,string cols)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();

            if (string.IsNullOrEmpty(cols))
            {
                return propertyInfos;
            }

            List<string> colsList = new List<string>(cols.Split(new char[] { ',' }));

            if(propertyInfos!=null && propertyInfos.Length > 0)
            {
                //现在不是很确定下面的话
                //NETFramework4.7以后才能使用 ==》函数式编程【lambada表达式】
                propertyInfos = propertyInfos.Where(p => colsList.Contains(p.Name)).ToArray();
            }

            return propertyInfos;
        }
    }
}
