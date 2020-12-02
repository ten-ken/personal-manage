using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using personal_manage.Common.attr;

//反射的扩展类
namespace personal_manage.Common.extendmethods
{
    public static class ReflectExpand
    {

        //获取列名特性（类似注解）[PropertyInfo 扩展方法]
        /// <summary>
        /// 获取特性【TableFieldAttribute】
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static TableFieldAttribute GetColumnAttriBute(this PropertyInfo prop)
        {
            return prop.GetCustomAttribute<TableFieldAttribute>();
        }



        //获取列名[PropertyInfo 扩展方法]
        /// <summary>
        /// 获取数据库列名
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetColumnName(this PropertyInfo prop)
        {
            string columnName = null;

            TableFieldAttribute tableFieldAttribute = GetColumnAttriBute(prop);

            if (tableFieldAttribute != null)
            {
                columnName = tableFieldAttribute.ColumName;
            }
            else
            {
                PrimaryKeyAttribute primaryKeyAttribute = prop.GetCustomAttribute<PrimaryKeyAttribute>();
                columnName = primaryKeyAttribute != null ? primaryKeyAttribute.ColumnName : columnName;
            }

            return columnName;
        }

        //获取列名[PropertyInfo 扩展方法]
        /// <summary>
        /// 获取字段在数据库中是否存在
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static bool IsExist(this PropertyInfo prop)
        {
            TableFieldAttribute tableFieldAttribute = GetColumnAttriBute(prop);

            if (tableFieldAttribute != null)
            {
                return tableFieldAttribute.IsExist;
            }
            else
            {
                PrimaryKeyAttribute primaryKeyAttribute = prop.GetCustomAttribute<PrimaryKeyAttribute>();                
                return primaryKeyAttribute != null;
            }
        }

        //获取数据库表名[Type 扩展方法]
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTableName(this Type type)
        {
            TableNameAttribute tableName1Attribute = type.GetCustomAttribute<TableNameAttribute>();
            return tableName1Attribute != null ? tableName1Attribute.Value : null;
        }

        //是否是表的主键[PropertyInfo 扩展方法]
        /// <summary>
        /// 是否主键
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static bool IsPrimaryKey(this PropertyInfo prop)
        {
            PrimaryKeyAttribute primaryKeyAttribute = GetPrimaryKey(prop);

            return primaryKeyAttribute != null ? true : false;
        }


        /// <summary>
        /// 获取表的主键信息[PropertyInfo 扩展方法]
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static PrimaryKeyAttribute GetPrimaryKey(this PropertyInfo prop)
        {
            PrimaryKeyAttribute primaryKeyAttribute = prop.GetCustomAttribute<PrimaryKeyAttribute>();
            if (primaryKeyAttribute != null)
            {
                primaryKeyAttribute.Prop = prop;
            }

            return primaryKeyAttribute;
        }


        //获取数据库表名[Type 扩展方法]==>
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PrimaryKeyAttribute GetPrimaryKey(this Type type)
        {
            PropertyInfo[] props = type.GetProperties();

            props = props.Where(p => p.IsPrimaryKey()).ToArray();

            if (props != null && props.Length > 0)
            {
                PrimaryKeyAttribute primaryKeyAttribute = GetPrimaryKey(props[0]);
                return primaryKeyAttribute;
            }
            return null;
        }

        /// <summary>
        /// 驼峰转下划线,首字母不转
        /// </summary>
        /// <param name="source">目标字符串</param>
        /// <returns></returns>
        public static string HumpToUnderline(this string source)
        {
            if (string.IsNullOrEmpty(source)) return "";
            string strItemTarget = "";  //目标字符串
            for (int j = 0; j < source.Length; j++)  //strItem是原始字符串
            {
                string temp = source[j].ToString();
                if (Regex.IsMatch(temp, "[A-Z]") && j != 0)
                {
                    temp = "_" + temp.ToLower();
                }
                strItemTarget += temp;
            }
            return strItemTarget.ToUpper();
        }


    }
}
