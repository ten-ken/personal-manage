using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Models.entity
{
    [TableName("t_base_info")]
    public class TestEntity
    {
        [TableField("my_age")]
        public int Age { get; set; }

        [TableField("my_name")]

        public string Name { get; set; }

        [TableField("money")]
        public Decimal money { get; set; }

        [TableField("birthday")]
        public DateTime birthDay { get; set; }
    }
}
