${title}
package ${mapperInterfacePackage};
import ${entityPackage}.${className};
import org.apache.ibatis.annotations.Param;
import com.baomidou.mybatisplus.core.mapper.BaseMapper;
import com.baomidou.mybatisplus.core.metadata.IPage;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import java.util.List;

 /**
  * <ul>
  * <li>Title: ${proName}-${className}Mapper.java</li>
  * <li>Description: ${tablecomment}Mapper </li>
  * <li>Copyright: Copyright (c) 2018</li>
  * </ul>
  *
  * @author ${author}
  * @version ${version}
  * @date ${date?datetime}
  */
@KcppcMyBatisDao
public interface ${className}Mapper extends BaseMapper<${className}> {
 
	 /**
	 * 根据主键查询
	 *
	 * @param id 主键
	 * @return  ${classObjectName} 查询内容
	 * @author ${author}
	 */
	${className}  selectByPrimaryKey(String id);
   
    /**
	 * 插入
	 *
	 * @param  ${classObjectName} 插入内容
	 * @return int 插入数量
	 * @author ${author}
	  * @date: ${date?datetime}
	*/
    int  commonInsert(${className}  ${classObjectName});
   
    /**
	 * 数据更新
	 *
	 * @param ${classObjectName} 更新内容
	 * @return int 更新数量
	 * @author ${author}
	  * @date: ${date?datetime}
	 */
    int commonUpdate(${className}  ${classObjectName});
   
    /**
	 * 删除
	 *
	 * @param ${classObjectName} 删除内容
	 * @return int 删除数量
	 * @author ${author}
	  * @date: ${date?datetime}
	 */
	int commonDelete(${className}  ${classObjectName});
   
    /**
	 * 分页查询
	 *
	 * @param page 分页条件
	 * @param ${classObjectName} 查询条件
	 * @return IPage<${className}> 查询结果
	 * @author ${author}
	  * @date: ${date?datetime}
	 */
    IPage<${className}> listPage(Page<${className}> page, @Param("parameter") ${className} ${classObjectName});
	
	
}