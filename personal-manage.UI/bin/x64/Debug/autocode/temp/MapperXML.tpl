<?xml version="1.0" encoding="UTF-8" ?>
<!DOCTYPE mapper PUBLIC "-//mybatis.org//DTD Mapper 3.0//EN" "http://mybatis.org/dtd/mybatis-3-mapper.dtd" >

<mapper namespace="${mapperInterfacePackage}.${className}Mapper">

	<resultMap id="BaseResultMap" type="${entityPackage}.${className}">
		<#list records as rec>
		<#if rec.pk>
		<id column="${rec.fieldName}" property="${rec.property}" jdbcType="${rec.jdbcType}" />
		<#else>
		<result column="${rec.fieldName}" property="${rec.property}" jdbcType="${rec.jdbcType}" />
		</#if>
		</#list>
	</resultMap>

 <sql id="Base_Column_List" >
  <#list records as rec>
  		  <#if rec_index == 0>
  		${rec.fieldName}
  		  <#else>
  		  ,${rec.fieldName}
  		  </#if>
  		 </#list>
  </sql>
    <!-- 主键查找 -->
    <select id="selectByPrimaryKey" resultMap="BaseResultMap" parameterType="java.lang.Long" >
        select
        <include refid="Base_Column_List" />
        from ${tablename}
        where ${pkRecords[0].fieldName} = ${"#{"}${pkRecords[0].property}}
    </select>
   <!-- 主键删除 -->
 <delete id="deleteByPrimaryKey" parameterType="java.lang.Long" >
    delete from ${tablename}
    where ${pkRecords[0].fieldName} = ${"#{"}${pkRecords[0].property}}
  </delete>

   <!-- 插入 -->
<insert id="insert" parameterType="${entityPackage}.${className}" useGeneratedKeys="true" keyProperty="id">
    insert into ${tablename}
            <trim prefix="(" suffix=")" suffixOverrides=",">
                <#list records as rec>
                     <#if rec_index != 0>
                  <if test="${rec.property} != null">
                  ${rec.fieldName},
                  </if>
                   </#if>
                </#list>
            </trim>
            <trim prefix="values (" suffix=")" suffixOverrides=",">
                <#list records as rec>
                <#if rec_index != 0>
                <if test="${rec.property} != null">
                ${"#{"}${rec.property}},
                </if>
                 </#if>
                </#list>
            </trim>
  </insert>
  
   <!-- 更新 -->
<update id="updateByPrimaryKeySelective" parameterType="${entityPackage}.${className}" >
        update ${tablename}
        <set >
         <#list records as rec>
                   <#if rec_index != 0>
              <if test="${rec.property} != null">
              ${rec.fieldName} = ${"#{"}${rec.property}},
              </if>
                </#if>
         </#list>
        </set>
        where ${pkRecords[0].fieldName} = ${"#{"}${pkRecords[0].property}}
 </update>

<!--自定义sql-->
  <select id="list" resultMap="BaseResultMap" parameterType="com.jiangqiao.core.entity.PageEntity">
    select *
    from ${tablename}
    where 1=1
    <#list records as rec>
         <#if rec_index != 0>
             <if test="parameter.${rec.property} != null and parameter.${rec.property} != ''">
                AND ${tablename?upper_case}.${rec.fieldName?upper_case}=${"#"}{parameter.${rec.property}${"}"}
             </if>
         </#if>
    </#list>
    <if test="parameter.orders != null and parameter.orders != ''">
      order by ${r'${parameter.orders}'}
    </if>
  </select>

</mapper>