using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.extendmethods
{
    public static class StringExtend
    {


        /// <summary>
        /// 获取某个限定之后的字符串 如果限定存在多个则取最后一个的位置
        /// </summary>
        public static string GetAfterKeyData(this string str, string key)
        {
            int index = str.LastIndexOf(key) + key.Length;
            int length = str.Length - index;
            return str.Substring(index, length);
        }
        /// <summary>
        /// 获取某个限定之前的字符串 如果限定存在多个则取最后一个的位置
        /// </summary>
        public static string GetBeforeKeyData(this string str, string key)
        {
            int index = str.LastIndexOf(key);
            return str.Substring(0, index);
        }
        /// <summary>
        /// 获取限定范围内的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="star"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GetLimitStr(this string str, string star, string end)
        {
            if (star.IndexOf(end, 0) != -1)
                return "";
            //转换为在字符串第几位
            int i = str.IndexOf(star);
            //第二个与第一个index差值
            int j = str.IndexOf(end);
            if (i == -1 || j == -1)
                return "";
            //截取的位置就是第一个位置加上他的长度 到 第二个位置与第一个位置的差值
            return str.Substring(i + star.Length, j - i - star.Length);
        }


        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 支持负数转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return str.Contains("-") ? -int.Parse(str.Replace("-", "")) : int.Parse(str);
        }

        /// <summary>
        /// 字符串相加优化用于大循环
        /// </summary>
        /// <param name="str"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public static string StrBuild(this string str, Action<StringBuilder> callBack)
        {
            StringBuilder sb = new StringBuilder(str);
            callBack?.Invoke(sb);
            return sb.ToString();
        }



        /// <summary>
        ///  首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperCaseFirst(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            char[] s = str.ToCharArray();
            char c = s[0];
            if ('a' <= c && c <= 'z')
                c = (char)(c & ~0x20);
            s[0] = c;

            return new string(s);
        }


        /// <summary>
        ///  判断是否为空 仅支持 null和""
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty(string source)
        {
            return source == null || "".Equals(source);
        }


        /// <summary>
        ///  判断是否为空 仅支持 null/""/" "/"\n"等
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsBlack(string source)
        {
            return source == null || "".Equals(source.Trim());
        }

        public static bool IsEmpty(StringBuilder sbf)
        {
            return sbf == null || "".Equals(sbf.ToString());
        }



        public static bool IsBlack(StringBuilder sbf)
        {
            return sbf == null || "".Equals(sbf.ToString().Trim());
        }


       
    }
}
