using System;
using System.Collections.Generic;
using System.Text;

namespace personal_manage.Common.attr
{
    //数据库表名
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TableNameAttribute: Attribute{
        
        string value;

        public TableNameAttribute(string value)
        {
            this.Value = value;
        }

        public string Value { get => value; set => this.value = value; }
    }
}
