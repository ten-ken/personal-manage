using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
///  @author swc
/// </summary>
namespace personal_manage.Common.util
{
    /// <summary>
    ///  对象工具类
    /// </summary>
    public class ObjectUtil
    {
        /// <summary>
        ///  将对象b的属性 赋给对象a
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <param name="ignores">数组 大写的属性值==》可变形参</param>

        public static void CopyPop<A, B>(B b, ref A a,params string[] ignores)
        {
            List<string> lists = new List<string>();
            if(ignores!=null && ignores.Length>0){
                lists = new List<string>(ignores);
            }
            try
            {
                Type Typeb = b.GetType();//获得类型  
                Type Typea = typeof(A);
                Dictionary<string, PropertyInfo> keyValues = new Dictionary<string, PropertyInfo>();

                object value = null;

                foreach (PropertyInfo sp in Typeb.GetProperties())//获得类型的属性字段  
                {
                    if (!keyValues.ContainsKey(sp.Name))
                    {
                        keyValues.Add(sp.Name,sp);
                    }
                }


                foreach (PropertyInfo ap in Typea.GetProperties()){                    
                    if (keyValues.ContainsKey(ap.Name) && !lists.Contains(ap.Name))
                    {
                        value = keyValues[ap.Name].GetValue(b);
                        //值为null 则不赋值
                        if(value != null)
                        {
                            ap.SetValue(a, keyValues[ap.Name].GetValue(b));//获得b对象属性的值复制给a对象的属性  
                        }     
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  将对象b的属性 赋给对象a
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public static void CopyPop<A, B>(B b, ref A a)
        {
            CopyPop(b, ref a, null);
        }


        /// <summary>
        /// 首字母小写写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstToLower(string input)
        {
            if (string.IsNullOrEmpty(input)) { 
                return input;
            }
            string str =input.Substring(0,1).ToLower()+ input.Substring(1);
            return str;
        }


    }
}
