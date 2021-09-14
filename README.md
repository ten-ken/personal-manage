# personal-manage

<span style='color:orange;font-size:15'>最新版本在gitee上，如有需要请在gitee上搜索ten-ken</span>

项目配置:

![输入图片说明](https://images.gitee.com/uploads/images/2021/0529/124933_647eee7d_5556017.png "屏幕截图.png")

客户端管理工具：

 **1.任务管理**： 保护复制整个控件的功能 提供外部函数 去绑定事件或修改文本 及样式等，多个线程调度任务，任务结束有语音播报。

 **2.列表演示** ：保护封装的 导入功能【读取excel】  和 通用的CURD功能【反射生成sql 反射获取实体 和注入控件值】 

 **3.内置浏览器**  ：暂不支持视频播放功能

 **<a href="#GenCode">4.代码生成器</a>**  ：方式1. 通过java的jar生成（需要熟悉freemark模板，内置有模板）  方式二.通过c#入口配置生成(需要熟悉NVelocity的语法)
 
 **<a href="#Account">5.账号加密管理</a>**  

 **<a href="#EnsFile">6.文件加密解密</a>**

 **7.图表功能**
 
 **8.文章控件支持图片和视频上传【未联通远程】**

| 参数  | 解释  |  类型 | 
|---|---|---|
| tableName  |  数据库表名 | string  | 
|  tableComment |  表备注内容 |  string |  
|  entityName |  实体名（首字母是大小） | string  |  
|  projectName | 项目名称  |  string |  
| <a href="#projectCode ">projectCode </a>| 解析的表内容  | object  |  

----------------------------------
-------------------------------------

##  <h2 id="projectCode">projectCode 对象里面的属性</h2>

| 参数  | 解释  |  类型 | 
|---|---|---|
|  ProName| 项目名称 | string  | 
|  Version|  项目版本信息 |  string |  
|  Author |  作者 | string  |  
|  TopLevel| 顶级包名|  string |  
|  TableName|表名称  | string  |  
|  <a href="#TableFieldInfos">TableFieldInfos</a>| 表字段信息 | List|  

----------------------------------
-------------------------------------

##  <h2 id="TableFieldInfos">TableFieldInfos 集合 里面单个 对象的属性</h2>

| 参数  | 解释  |  类型 | 
|---|---|---|
|  ColumnName| 字段在数据库中的列名 | string  | 
|  MaxLength|  字段最大长度 |  int|  
|  Comments|  字段注释 | string  |  
|  DataType| 数据库字段-数据类型|  string |  
|  Primary|是否主键  | bool  |  
|  Extra| 额外的信息 | List|  
|  Nullable| 是否为空 （“Y” or "N"）|  string |  
|  EntityField|字段名（首字母默认小写）  | string  |  
|  JdbcType| Java字段类型 | string  |  
|  CsType| Java字段类型 | string  |  
|  UFirst| 带参数，则是把参数首字母大小，不带参数是字段首字母大小| 方法|  

![输入图片说明](https://images.gitee.com/uploads/images/2020/1210/230815_e68cab20_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143056_dc46d066_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143204_1ac23023_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143214_18dbdb81_5556017.png "屏幕截图.png")

## <h2 id="GenCode">java版配置入口</h2>
![java版](https://images.gitee.com/uploads/images/2021/0119/143224_a5444f9a_5556017.png "屏幕截图.png")

## csharpe版配置入口
![csharpe版](https://images.gitee.com/uploads/images/2021/0119/143310_35c2f682_5556017.png "屏幕截图.png")

![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143336_de1cb52b_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143344_5213701c_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143359_8fd9379c_5556017.png "屏幕截图.png")


![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143424_10f4e137_5556017.png "屏幕截图.png")


##  我的应用


### 内置浏览器:
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143450_d2c64e41_5556017.png "屏幕截图.png")

### <h2 id="Account">账号管理:</h2>
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143529_4a87623d_5556017.png "屏幕截图.png")
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143544_9466d2de_5556017.png "屏幕截图.png")

### <h2 id="EnsFile">文件加解密：</h2>
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143604_c218a8aa_5556017.png "屏幕截图.png")

### 数据库字段生成：【为了同步线上线下的数据库结构 如果不能使用其他联通两方数据库 这里就能派上用场 】
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143630_5c00f1bf_5556017.png "屏幕截图.png")

### 演示页面：
![输入图片说明](https://images.gitee.com/uploads/images/2021/0119/143758_f057faf2_5556017.png "屏幕截图.png")

### 文章列表页 【点击普通图片进入图片轮播 点击视频播放标志的进入视频播放】
![文章列表页](https://images.gitee.com/uploads/images/2021/0320/184543_a4f73fe3_5556017.png "屏幕截图.png")

#### 图片‘轮播’

![输入图片说明](https://images.gitee.com/uploads/images/2021/0320/184707_748b196c_5556017.png "屏幕截图.png")

#### 视频播放
![输入图片说明](https://images.gitee.com/uploads/images/2021/0320/184725_72760715_5556017.png "屏幕截图.png")


#### 导出excel的demo 

#### 将工作表转换为图像【[来自官网](https://products.aspose.com/cells/net)】

~~~
// load spreadsheet file
var workbook = new Aspose.Cells.Workbook(dir + "template.xls");
// access the first worksheet from the collection
var worksheet = workbook.Worksheets[0];
// define parameters for resultant image
var options = new Aspose.Cells.Rendering.ImageOrPrintOptions()
{
    OnePagePerSheet = true,
    ImageType = Aspose.Cells.Drawing.ImageType.Jpeg
};
// convert worksheet to image in JPEG format
var renderer = new Aspose.Cells.Rendering.SheetRender(worksheet, options);
renderer.ToImage(0, dir + "output.jpeg");

~~~

#### 代码式导出（非模板）
~~~
                string xyqkPath = Path.Combine(directory, "供应商响应情况汇总.xlsx");

                string[] heads = { "项目编号", "标号", "包名", "投标商名称", "是否提供资质业绩核实证明", "企业成立时间"};//标题栏

                string[] fields = { "projectNo", "markNo", "packName", "supplierId", "provideCertificate", "entRegTime"};//映射 标题栏 对应数据 字段 

                List<OsZbSupplierResponseInfo> xyqkList = SQLiteLibrary.SelectBySql<OsZbSupplierResponseInfo>(sqliteDbLocation, sqliteDbName, xyqkSql);
                if (xyqkList != null)
                {
                    int lastRow = AsposeExcel.ExportToExcel(xyqkList, "供应商响应情况汇总", xyqkPath, heads, fields);//返回最终操作行的下一行的位置（row）
                }
~~~


#### 模板式导出

> &=DataSource.Field，&=[DataSource].[Field]是对DataTable和几何类型的引用，将会从当前行开始竖直向下生成多行数据。
> &=$data:是对变量或数组的引用。数组存在skip，horizontal等属性，具体参见
> &=&=动态公式计算；{r}当前行，{c}当前列，{-n}，{n}当前行或列的偏移量前n或后n。
> &==是动态计算，如excel，if等语句。（if（logic_test,true_value,false_value））

~~~
    1.编写模板: 参考模板=>https://gitee.com/ten-ken/personal-manage/blob/main/personal-manage.UI/bin/x64/Debug/templates/export/muban/template.xlsx
    2.演示代码
          DataTable dt = new DataTable();
         dt.Columns.AddRange(new DataColumn[] { 
             new DataColumn("procedureName", typeof(string)),
             new DataColumn("weight", typeof(double)),
             new DataColumn("nums", typeof(double)),
             new DataColumn("userName", typeof(string)) });

            dt.TableName = "table";
            for (int i = 1; i < 9; i++)
            {
                dt.Rows.Add("工序0" + i, 9 * i, 1.5 * 9 * i, "操作人" + i);
            }

            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("batchNo", "20210529001");
            keyValues.Add("operateTime", "2021-05-29");
            string tmpPath = AppDomain.CurrentDomain.BaseDirectory + "templates\\export\\muban\\template.xlsx";
            AsposeExcel.TemplateToExcel(tmpPath, dt, keyValues,savePath);

~~~

#### [Aspose.Cell 相关参考](https://gitee.com/ten-ken/personal-manage/blob/main/ReadAsposeCells.md)

最后附赠两个代码生成的脚本：

1.java实体


```
package com.jysoft.ess.zbfz.zb.entity;
import com.baomidou.mybatisplus.annotation.TableField;
import com.jysoft.map.common.entity.BaseEntity;
import java.util.Date;


/**
 * <p>
 * 供应商实验报告信息Entity
 * </p>
 * @Description: Entity类 -${entityName}.java</p>
 * @author ${csProjectCode.Author}
 * @date
 */
public class ${entityName} extends BaseEntity {

    private static final long serialVersionUID = 1L;

	#foreach($item in $projectCode.TableFieldInfos)
		/**
		* $item.Comment
		*/
		 private $item.JavaType $item.EntityField;
	 #end  	


	#foreach($item in $projectCode.TableFieldInfos)
   
	     public $item.JavaType get$item.UFirst()(){
			return id;
	     }
		
	     public $item.JavaType set$item.UFirst()() {
			return id;
	     }		
	#end  	
   
   
}

```

2.java的mapper.xml



```

<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE mapper PUBLIC "-//mybatis.org//DTD Mapper 3.0//EN" "http://mybatis.org/dtd/mybatis-3-mapper.dtd">
  <!--专家组人员-->       
<mapper namespace="${projectCode.TopLevel}.MapperPackage.${entityName}Mapper">
    <!-- 通用查询映射结果 -->
    <resultMap id="BaseResultMap" type="${projectCode.TopLevel}.EntityPackage.${entityName}">
       #foreach($item in $projectCode.TableFieldInfos)
		 #if($item.Primary) 
		  <id column="$item.EntityField" property="$item.ColumnName"  />
		 #else
		   <result column="$item.EntityField" property="$item.ColumnName" />
		 #end    
	   #end  	
    </resultMap>

	
	  <!--插入-->
    <insert id="commonInsert" parameterType="${entityPackage}.${className}">
        INSERT INTO ${tableName}
            <trim prefix="(" suffix=")" suffixOverrides=",">
			  #foreach($item in $projectCode.TableFieldInfos)
				#if($item.ColumnName== "CREATE_TIME" || $item.ColumnName == "UPDATE_TIME") 
					${item.ColumnName},
				#else
					<if test="${item.EntityField} != null">
					  ${item.ColumnName},
                    </if>
				#end  
			  #end  	
            </trim>
            <trim prefix="values (" suffix=")" suffixOverrides=",">
			
			 #foreach($item in $projectCode.TableFieldInfos)
				#if($item.ColumnName== "CREATE_TIME" || $item.ColumnName == "UPDATE_TIME") 
					systimestamp,
				#else
					<if test="$item.EntityField != null">
					 #{$item.EntityField},
                    </if>
				#end  
			  #end  	
			 
			 
            </trim>
    </insert>
   
	
</mapper>

```

