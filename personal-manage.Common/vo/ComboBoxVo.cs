using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.vo
{
    /// <summary>
    ///  下拉框
    /// </summary>
    public class ComboBoxVo
    {
        string keyName;

        string keyValue;

        //备用字段1
        string extra1;

        //备用字段2
        string extra2;

        //是否选中
        bool selected;

        public ComboBoxVo(string keyName, string keyValue)
        {
            this.KeyName = keyName;
            this.KeyValue = keyValue;
        }

        public ComboBoxVo(string keyName, string keyValue, bool selected) : this(keyName, keyValue)
        {
            this.selected = selected;
        }

        private ComboBoxVo()
        {
        }

        public string KeyName { get => keyName; set => keyName = value; }
        public string KeyValue { get => keyValue; set => keyValue = value; }
    }
}
