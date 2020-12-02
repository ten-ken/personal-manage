using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using personal_manage.Common.attr;
using personal_manage.Common.dto;
using personal_manage.Common.extendmethods;

namespace personal_manage.Models.entity
{
    public class CsProjectCode
    {
        [TableField("PRO_NAME")]
        // # 项目名称
        public string ProName { set; get; }


        [TableField("VERSION")]
        // 版本
        public string Version { set; get; }


        [TableField("TITLE")]
        //TITLE =/**************** 版权所有：************************/
        public string Title { set; get; }


        [TableField("AUTHOR")]
        // 作者
        public string Author { set; get; }


        [TableField("PRO_SITE")]
        //= E:\\zhaobiao-2020\\zhaobiao
        public string ProSite { set; get; }


        [TableField("TOP_LEVEL")]
        //顶层包名 = com.jysoft.ess.zbfz
        public string TopLevel { set; get; }

        /// <summary>
        ///  数据库表名
        /// </summary>
        public string TableName { set; get; }


        /// <summary>
        ///  实体类名
        /// </summary>
        public string EntityName { set; get; }

        /// <summary>
        /// 表字段信息
        /// </summary>
        public List<TableFieldInfo> TableFieldInfos { set; get; }

        public CsProjectCode(string tableName)
        {
            TableName = tableName;

            if (string.IsNullOrEmpty(this.TableName))
            {
                this.EntityName = "";
            }
            string str = this.TableName.ToLower();

            Regex r = new Regex("(-|_)[a-zA-Z1-9]");
            //bool ismatch = r.IsMatch(str);
            MatchCollection mc = r.Matches(str);

            string newValue;
            for (int i = 0; i < mc.Count; i++)
            {
                newValue = Regex.Replace(mc[i].Value, "(-|_)", "").ToUpper();
                str = str.Replace(mc[i].Value, newValue);
            }
            this.EntityName = str.UpperCaseFirst();
        }

        private CsProjectCode()
        {
        }
    }
}
