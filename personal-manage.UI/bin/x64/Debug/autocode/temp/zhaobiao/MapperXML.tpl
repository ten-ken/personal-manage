<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE mapper PUBLIC "-//mybatis.org//DTD Mapper 3.0//EN" "http://mybatis.org/dtd/mybatis-3-mapper.dtd">
  <!--专家组人员-->       
<mapper namespace="${mapperInterfacePackage}.${className}Mapper">
    <!-- 通用查询映射结果 -->
    <resultMap id="BaseResultMap" type="${entityPackage}.${className}">
       <#list records as rec>
		<#if rec.pk>
		  <id column="${rec.fieldName}" property="${rec.property}"  />
		<#else>
		   <result column="${rec.fieldName}" property="${rec.property}" />
		</#if>
		</#list>
    </resultMap>
	

    <!--根据主key查询-->
    <select id="selectByPrimaryKey" parameterType="${entityPackage}.${className}"  resultMap="BaseResultMap">
	      SELECT
        ${tablename?upper_case}.*,
         TO_CHAR(${tablename?upper_case}.UPDATE_TIME, 'yyyy-mm-dd hh24missxff6') as updateTimeStr,
        TO_CHAR(${tablename?upper_case}.UPDATE_TIME, 'yyyy-mm-dd hh24missxff6') as updateTimeStr
        FROM
      ${tablename?upper_case}
        WHERE  ${tablename?upper_case}.${pkRecords[0].fieldName?upper_case}=${"#{"}${pkRecords[0].property}}
    </select>
	
	
	  <!--插入-->
    <insert id="commonInsert" parameterType="${entityPackage}.${className}">
        INSERT INTO ${tablename?upper_case}
            <trim prefix="(" suffix=")" suffixOverrides=",">
			   <#list records as rec> 
				<#if (rec.fieldName == "CREATE_TIME" || rec.fieldName == "UPDATE_TIME")>     
					${rec.fieldName},				
				</#if>	
				<#if (rec.fieldName != "CREATE_TIME" && rec.fieldName != "UPDATE_TIME")>     
					<if test="${rec.property} != null">
					  ${rec.fieldName},
                    </if>						
				</#if>						
			 </#list>
            </trim>
            <trim prefix="values (" suffix=")" suffixOverrides=",">
			
			 <#list records as rec>
				<#if (rec.fieldName == "CREATE_TIME" || rec.fieldName == "UPDATE_TIME")>		    
					<#if (rec.fieldName == "CREATE_TIME" || rec.fieldName == "UPDATE_TIME")>     
					systimestamp as  systime${rec_index},				
				</#if>	
				<#if (rec.fieldName != "CREATE_TIME" && rec.fieldName != "UPDATE_TIME")>     
					<if test="${rec.property} != null">
						${"#{"}${rec.property}},
                    </if>						
				</#if>			
				</#if>				
			 </#list>
            </trim>
    </insert>


    <!--修改-->
    <update id="commonUpdate" parameterType="${entityPackage}.${className}">		
		update   ${tablename?upper_case}
        <set >
         <#list records as rec>
            <#if rec_index != 0 && (rec.fieldName == "UPDATE_TIME") >
              UPDATE_TIME = systimestamp,
			  <#else>
			  ${rec.fieldName} = ${"#{"}${rec.property}},
            </#if>
         </#list>
        </set>
        where ${pkRecords[0].fieldName} = ${"#{"}${pkRecords[0].property}}	  AND TO_CHAR(UPDATE_TIME, 'yyyy-mm-dd hh24missxff6') = ${"#{"}updateTimeStr}
			
    </update>
	
	
    <!--删除-->
    <delete id="commonDelete" parameterType="${entityPackage}.${className}">
	    DELETE FROM  ${tablename?upper_case}
		where ${pkRecords[0].fieldName} = ${"#{"}${pkRecords[0].property}}    AND TO_CHAR(UPDATE_TIME, 'yyyy-mm-dd hh24missxff6') = ${"#{"}updateTimeStr}
    </delete>  
	
    <!--分页查询-->
    <select id="listPage" parameterType="${entityPackage}.${className}" resultMap="BaseResultMap">
        SELECT
        ${tablename?upper_case}.*,
        TO_CHAR(${tablename?upper_case}.CREATE_TIME,'yyyy-mm-dd hh24:mi:ss') as createTimeStr,
        TO_CHAR(${tablename?upper_case}.UPDATE_TIME, 'yyyy-mm-dd hh24missxff6') as updateTimeStr
        FROM
        ${tablename?upper_case}
        <where>
            <#list records as rec>
			     <#if rec_index != 0>
					<if test="parameter.${rec.property} != null and parameter.${rec.property} != ''">
                   AND ${tablename?upper_case}.${rec.fieldName?upper_case}=${"#"}{parameter.${rec.property}${"}"}
					</if>
				</#if>
			</#list>
        </where>
    	ORDER BY ${tablename?upper_case}.CREATE_TIME DESC
    </select>


	 <insert id="saveBatch" useGeneratedKeys="false" parameterType="java.util.List">
        INSERT INTO ${tablename?upper_case}(
		   <#list records as rec>
              ${rec.fieldName}<#if (rec_has_next)>,</#if>      			
           </#list>
		)
        select a.* from (
        <foreach collection="list" item="item" index="index" separator="union all" >
            select
			 <#list records as rec>
				<#if (rec.fieldName == "CREATE_TIME" || rec.fieldName == "UPDATE_TIME")>
					systimestamp as  systime${rec_index}<#if (rec_has_next)>,</#if>
					<#else>
					${"#{"}item.${rec.property}} as ${rec.property}<#if (rec_has_next)>,</#if>
				</#if>				
			</#list>
            from dual
        </foreach>
        ) a
    </insert>
	
</mapper>
