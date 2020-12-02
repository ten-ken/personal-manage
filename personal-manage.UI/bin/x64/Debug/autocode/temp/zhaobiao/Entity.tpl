package ${entityPackage};
import com.baomidou.mybatisplus.annotation.TableField;
import com.jysoft.map.common.entity.BaseEntity;
import java.util.Date;

/**
 * <p>
 * {tablecomment}Entity
 * </p>
 * @Description: ${tablecomment}类</p>
 * @Copyright: Copyright (c) 2020 </p>
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
	
	 /**
    * 创建时间
    */
    @TableField(exist=false)
    private String createTimeStr;

	public String getCreateTimeStr() {
        return createTimeStr;
    }
    public void setCreateTimeStr(String createTimeStr) {
        this.createTimeStr = createTimeStr;
    }	
}