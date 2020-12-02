using System;

// ctrl+r 两次 
//prop+两次回车 属性
//propa+两次回车 静态属性方法
//propfull+两次回车 私有字段加属性
namespace personal_manage.Common.attr
{

    //查询 新增 修改的注解 ==>修改为只能设置在公有属性上 而非字段
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class TableFieldAttribute : Attribute
    {
        /// <summary>
        /// 字段是否在数据存在
        /// </summary>
        private bool isExist = true;
        public bool IsExist { get => isExist; set => isExist = value; }

        /// <summary>
        ///  数据库对应的列名
        /// </summary>
        public string ColumName { get; set; }

        /// <summary>
        ///  字段默认值 用于新增和修改操作
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        ///  自定义函数
        /// </summary>
        public bool DefinedFunc { get; set; }

        //函数的表达式
        public string Pattern { get; set; }

        /// <summary>
        /// 默认是false 用于选择性更新 新增 
        /// </summary>
        public bool NotDo { get; set; }
   


        /// <summary>
        ///  该字段在数据库中是否存在
        /// </summary>
        /// <param name="isExist"></param>
        public TableFieldAttribute(string columName,bool isExist)
        {
            IsExist = isExist;
            ColumName = columName;
        }

        public TableFieldAttribute(string columName)
        {
            ColumName = columName;
        }

        public TableFieldAttribute(bool isExist)
        {
            IsExist = isExist;
        }
    }
}
