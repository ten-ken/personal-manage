using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PublicLibrary.attr;

//${tablecomment}
namespace ess_zbfz_main.entity
{
	[TableNameAttr("${tablename?upper_case}")]
    public class ${className}{

		    //当前excel的行
        [ColumnInfoAttr(-10, 1000, true)]
        private int curExcelIndex;
	 
	<#list records as rec>
		
      <#if rec.property =="ID" || rec.property =="id">
        [TableFieldAttr("${rec.fieldName}", null, null, true, true, null)]
      <#elseif rec.fieldName?contains("time")>
        [TableFieldAttr("${rec.fieldName}", "datetime('now')", null, false, false)]
      <#elseif rec.fieldName?contains("date")>
        [TableFieldAttr("${rec.fieldName}", "datetime('now')", null, false, false)]
      <#else>
         [TableFieldAttr("${rec.fieldName}", null, null, false, false, null)]
      </#if>
	   [ColumnInfoAttr(${rec_index-2}, 35, false,null,"")]
	    private string ${rec.property};

	</#list>

	<#list records as rec>
	    ///<summary>
        ///${rec.comment!''}
        ///</summary>
		[JsonProperty("${rec.property}")]
        public string ${rec.property?cap_first} { get => ${rec.property}; set => ${rec.property} = value; }

    </#list>
    public int CurExcelIndex { get => curExcelIndex; set => curExcelIndex = value; }

    }
}
