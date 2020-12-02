using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;
using personal_manage.Common.extendmethods;

namespace personal_manage.Common.util
{
   
    ///支持泛型直接new
    public static class DbConvert
    {

        /// <summary>
        /// DataTable转成Dto ==>不建议使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToDataDto<T>(this DataTable dt){
            T s = Activator.CreateInstance<T>();
            if (dt == null || dt.Rows.Count == 0)
            {
                return s;
            }
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PropertyInfo info = plist.Find(p => p.Name.HumpToUnderline() == dt.Columns[i].ColumnName.ToUpper());
                if (info != null)
                {
                    try
                    {
                        if (!Convert.IsDBNull(dt.Rows[0][i]))
                        {
                            object v = null;
                            if (info.PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], Nullable.GetUnderlyingType(info.PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], info.PropertyType);
                            }
                            info.SetValue(s, v, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                    }
                }
            }
            return s;
        }


        /// <summary>
        /// DataTable转list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> TableToList<T>(DataTable dt)
        {

            List<T> list = new List<T>();
            if (dt == null)
            {
                return list;

            }
            //BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            Type type = typeof(T);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            
            var plist = new List<PropertyInfo>(propertyInfos);

            TableFieldAttribute tableFieldAttr = null;

            PrimaryKeyAttribute keyAttribute = null;

            Dictionary<string, PropertyInfo> dictionAry = new Dictionary<string, PropertyInfo>();

            for (int p = 0; p < propertyInfos.Length; p++)
            {
                tableFieldAttr = propertyInfos[p].GetCustomAttribute<TableFieldAttribute>();

                keyAttribute = propertyInfos[p].GetCustomAttribute<PrimaryKeyAttribute>();

                if (tableFieldAttr != null && tableFieldAttr.ColumName != null)
                {
                    dictionAry.Add(tableFieldAttr.ColumName, propertyInfos[p]);
                }
                else if(keyAttribute != null && keyAttribute.ColumnName != null)
                {
                    dictionAry.Add(keyAttribute.ColumnName, propertyInfos[p]);
                }

            }

            PropertyInfo currentProp = null;

            //实体
            T s;
            foreach (DataRow item in dt.Rows)
            {
                s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dictionAry.ContainsKey(dt.Columns[i].ColumnName))
                    {
                        currentProp = dictionAry[dt.Columns[i].ColumnName];
                        object v = null;
                        if (currentProp.PropertyType.ToString().Contains("System.Nullable"))
                        {
                            v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(currentProp.PropertyType));
                        }
                        else
                        {
                            if(!(item[i] is DBNull))
                            {
                                v = Convert.ChangeType(item[i], currentProp.PropertyType);
                            }
                        }
                        currentProp.SetValue(s, v, null);
                    }

                }
                list.Add(s);
            }
            return list;
        }

    }
}
