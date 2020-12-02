${title}
package ${servicePackage};

import ${entityPackage}.${className};
import com.jiangqiao.core.entity.PageEntity;
import com.jiangqiao.core.message.Message;
 /**
  * <ul>
  * <li>Title: ${proName}-${className}Service.java</li>
  * <li>Description: ${tablecomment}Service </li>
  * <li>Copyright: Copyright (c) 2018</li>
  * <li>Company: http://www.spic.com.cn/</li>
  * </ul>
  *
  * @author ${author}
  * @version ${version}
  * @date ${date?datetime}
  */
public interface ${className}Service{

    /**
     * 功能描述: 首页数据展示
     * @param pageEntity
     * @author: ${author}
     * @date: ${date?datetime}
    */
    PageEntity<${className}> list(PageEntity<${className}> pageEntity) throws Exception;

    /**
     * 功能描述: 更新初始化
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
    */
    ${className} updateInit(Long id) throws Exception;
    /**
     * 功能描述: 新增或更新
     * @param ${classObjectName}
     * @author: ${author}
     * @date: ${date?datetime}
    */
    Message saveOrUpdate(${className} ${classObjectName}) throws Exception;
    /**
     * 功能描述: 批量删除
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
     */
    Message delete(Long[] id) throws  Exception;

}