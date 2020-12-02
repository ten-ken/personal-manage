using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using personal_manage.Common.attr;
using personal_manage.Common.extendmethods;

namespace personal_manage.Common.dto
{

    public class TableFieldInfo
    {

      /*  // 字段名称
        [PrimaryKey("ID")]
        public string ID { get; set; }*/

        // 字段名称
        [TableField("ColumnName")]
        public string ColumnName { get; set; }

        // 字段的最大长度
        [TableField("MaxLength")]
        public int MaxLength { get; set; }

        // 字段的注释
        [TableField("Comments")]
        public string Comment { get; set; }

        // 数据库类型 mysql是 bigstring/varchar/decimal
        [TableField("DataType")]
        public string DataType { get; set; }

        // 主键 外键标识  如mysql 主键是PRI
        [TableField("ColumnKey")]
        public string ColumnKey { get; set; }

        // 额外信息  如mysql auto_increment代表是主键自增
        [TableField("Extra")]
        public string Extra { get; set; }
       
        
        //是否可以为空 Y or N
        [TableField("Nullable")]
        public string Nullable { get; set; }


        /// <summary>
        ///  实体字段
        /// </summary>
        public string EntityField { get; set; }



        /// <summary>
        ///  jdbc的类型
        /// </summary>
        public string JdbcType { get; set; }


        /// <summary>
        ///  获取实体的值 【首字母是小写】
        /// </summary>
        public string GetEntityField()
        {
            if (string.IsNullOrEmpty(this.ColumnName))
            {
                this.EntityField = "";
                return "";
            }
            string str = this.ColumnName.ToLower();

            Regex r = new Regex("(-|_)[a-zA-Z1-9]");
            //bool ismatch = r.IsMatch(str);
            MatchCollection mc = r.Matches(str);

            string newValue;
            for (int i = 0; i < mc.Count; i++)
            {
                newValue = Regex.Replace(mc[i].Value, "(-|_)", "").ToUpper();
                str = str.Replace(mc[i].Value, newValue);
            }
            this.EntityField = str;
            return str;
        }


        /// <summary>
        ///  首字母大写
        /// </summary>
        public string GetCaptureEntityField()
        {
            return this.EntityField.UpperCaseFirst();
        }

        /// <summary>
        ///  获取JdbcType的值
        /// </summary>
        public string GetJdbcType()
        {
            return this.DataType.ToUpper();
        }

        /// <summary>
        ///  是否是主键
        /// </summary>
        public bool IsPrimary()
        {
            return this.ColumnKey == "PRI";
        }


        /// <summary>
        ///  获取java字段的类型
        /// </summary>
        public string GetJavaType()
        {
            string javaType;
            switch (this.DataType)
            {
               case "bigint":
                     javaType = "Long";
                     break;
                case "varchar":
                    javaType = "String";
                    break;
                case "datetime":
                    javaType = "Date";
                    break;
                case "date":
                    javaType = "Date";
                    break;
                case "decimal":
                    javaType = "BigDecimal";
                    break;
                case "int":
                    javaType = "Integer";
                    break;
                case "float":
                    javaType = "BigDecimal";
                    break;
                case "double":
                    javaType = "BigDecimal";
                    break;
                case "text":
                    javaType = "String";
                    break; 
                case "VARCHAR2":
                    javaType = "String";
                    break;   
                case "NUMBER":
                    javaType = "BigDecimal";
                    break;
                case "TIMESTAMP(6)":
                    javaType = "Date";
                    break;
                case "TIMESTAMP":
                    javaType = "Date";
                    break;
                case "VARCHAR":
                    javaType = "String";
                    break;
                case "DATE":
                    javaType = "Date";
                    break;
                case "FLOAT":
                    javaType = "BigDecimal";
                    break;
                case "DOUBLE":
                    javaType = "BigDecimal";
                    break;
                default:
                    javaType = "String";
                    break;
            }

            return javaType;
        }

    }
}
