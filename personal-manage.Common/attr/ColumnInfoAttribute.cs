using System;

namespace personal_manage.Common.attr
{
   

    //导入的注解【特征值/注解】==>修改为只能设置在公有属性上 而非字段
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnInfoAttribute : Attribute{

        /// <summary>
        /// 位置【表格的下标】
        /// </summary>
        public int Index { get ; set ; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get ; set ; }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool Nullable { get ; set ; }

        /// <summary>
        /// 时间格式[用于时间的转换]
        /// </summary>
        public string DateFormat { get ; set ; }

        /// <summary>
        /// 正则表单式 验证数据格式
        /// </summary>
        public string Pattern { get ; set ; }

        public ColumnInfoAttribute(int index, int length)
        {
            Index = index;
            Length = length;
            Nullable = true;//默认允许为空
        }


        public ColumnInfoAttribute(int index, int length, bool nullable)
        {
            Index = index;
            Length = length;
            Nullable = nullable;
        }
    }
}
