${title}
package ${entityPackage};
import java.math.BigDecimal;
import java.util.Date;
import com.jiangqiao.core.entity.BaseEntity;
import org.springframework.format.annotation.DateTimeFormat;
import com.fasterxml.jackson.annotation.JsonFormat;
/**
 * <ul>
 * <li>Title: ${proName}-${className}</li>
 * <li>Description: ${tablecomment}实体类 </li>
 * <li>Copyright: Copyright (c) 2018</li>
 * <li>Company: http://www.spic.com.cn/</li>
 * </ul>
 *
 * @author ${author}
 * @version ${version}
 * @date ${date?datetime}
 */
public class ${className} extends BaseEntity{

	<#list records as rec>
	<#if rec.comment!='null' && rec.comment!='' >
    /**${rec.comment}*/
    </#if>
    <#if rec.type=='Date' >
    @JsonFormat(pattern = "yyyy-MM-dd", timezone = "GMT+8")
    @DateTimeFormat(pattern = "yyyy-MM-dd")
    </#if>
	private ${rec.type} ${rec.property};

	</#list>
	<#list records as rec> 

	public void set${rec.property?cap_first}(${rec.type} ${rec.property}) {
		this.${rec.property} = ${rec.property};
	}
	public ${rec.type} get${rec.property?cap_first}() {
		return this.${rec.property};
	}
	</#list>
}