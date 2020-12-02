${title}
package ${mapperInterfacePackage};
import ${entityPackage}.${className};
import java.util.List;
import com.jiangqiao.core.mapper.BaseMapper;
import com.jiangqiao.core.entity.PageEntity;
import org.apache.ibatis.annotations.Param;
import com.jiangqiao.core.mapper.annotation.KcppcMyBatisDao;
 /**
  * <ul>
  * <li>Title: ${proName}-${className}Mapper.java</li>
  * <li>Description: ${tablecomment}Mapper </li>
  * <li>Copyright: Copyright (c) 2018</li>
  * <li>Company: http://www.izkml.com/</li>
  * </ul>
  *
  * @author ${author}
  * @version ${version}
  * @date ${date?datetime}
  */
@KcppcMyBatisDao
public interface ${className}Mapper extends BaseMapper<${className}>{
    /**
     * 功能描述: 首页数据展示
     * @param pageEntity
     * @author: ${author}
     * @date: ${date?datetime}
    */
    List<${className}> list(PageEntity<${className}> pageEntity);
}