using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.attr
{
    //查询 新增 修改的注解==>修改为只能设置在公有属性上 而非字段
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PrimaryKeyAttribute : Attribute
    {
        //列名称
        private string columnName;

        //对应属性
        public PropertyInfo Prop { get; set; }


        public PrimaryKeyAttribute()
        {
        }

        public PrimaryKeyAttribute(string columnName)
        {
            this.columnName = columnName;
        }

        public string ColumnName { get => columnName; set => columnName = value; }
    }
}
