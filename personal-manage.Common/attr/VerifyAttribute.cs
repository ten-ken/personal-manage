using System;
using System.Collections.Generic;
using System.Text;
namespace personal_manage.Common.attr
{
    //验证的特性==>修改为只能设置在公有属性上 而非字段
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class VerifyAttribute : Attribute
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool Nullable { get; set; }


        /// <summary>
        /// 是否为空
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// 是否可以重复
        /// </summary>
        public bool Repeat { get; set; }

        /// <summary>
        /// 中文注释【用于提示】
        /// </summary>
        public string ColumCnm { get; set ; }

        /// <summary>
        /// 正则完全匹配【数据格式验证】
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// 业务类型==》一般用不得
        /// </summary>
        public string[] BusinessDiff { get; set ; }


        /// <summary>
        /// 仅提示
        /// </summary>
        public bool PromptOnly { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="maxLength"></param>
        /// <param name="columCnm"></param>
        /// <param name="promptOnly"></param>
        public VerifyAttribute(int maxLength, string columCnm)
        {
            MaxLength = maxLength;
            ColumCnm = columCnm;
            Repeat = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="maxLength"></param>
        /// <param name="columCnm"></param>
        /// <param name="repeat"></param>
        public VerifyAttribute(int maxLength, string columCnm,bool repeat)
        {
            MaxLength = maxLength;
            ColumCnm = columCnm;
            Repeat = repeat;
        }
    }
}
