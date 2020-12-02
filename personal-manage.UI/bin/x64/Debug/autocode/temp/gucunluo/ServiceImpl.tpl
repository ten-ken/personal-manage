${title}
package ${serviceImplPackage};
import ${mapperInterfacePackage}.${className}Mapper;
import ${entityPackage}.${className};
import org.springframework.stereotype.Service;
import ${servicePackage}.${className}Service;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.transaction.annotation.Transactional;
import com.jiangqiao.core.message.Message;
import com.jiangqiao.core.message.MessageUtil;
import com.jiangqiao.sys.service.common.BaseOaService;
import com.jiangqiao.sys.common.CodeHelper;
import com.jiangqiao.core.entity.PageEntity;
import com.jiangqiao.util.EmptyUtil;
import java.util.List;

 /**
 * <ul>
 * <li>Title: ${proName}-${className}ServiceImpl</li>
 * <li>Description:${tablecomment}ServiceImpl </li>
 * <li>Copyright: Copyright (c) 2018</li>
 * <li>Company: http://www.spic.com.cn/</li>
 * </ul>
 *
 * @author ${author}
 * @version ${version}
 * @date ${date?datetime}
 */
@Service
public class ${className}ServiceImpl extends BaseOaService implements ${className}Service {

	@Autowired
	private ${className}Mapper ${classObjectName}Mapper;

	/**
     * 功能描述: 首页数据展示
     * @param pageEntity
     * @author: ${author}
     * @date: ${date?datetime}
    */
    @Override
    @Transactional(readOnly = true)
    public PageEntity<${className}> list(PageEntity<${className}> pageEntity) throws Exception {
        List<${className}> list = ${classObjectName}Mapper.list(pageEntity);
        pageEntity.setData(CodeHelper.getInstance().setCodeValue(list));
        return pageEntity;
    }
    /**
     * 功能描述: 更新初始化
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
    */
    @Override
    @Transactional(readOnly = true)
    public ${className} updateInit(Long id) throws Exception {
        return ${classObjectName}Mapper.selectByPrimaryKey(id);
    }
    /**
     * 功能描述: 新增或更新
     * @param ${classObjectName}
     * @author: ${author}
     * @date: ${date?datetime}
    */
    @Override
    @Transactional
    public Message saveOrUpdate(${className} ${classObjectName}) throws Exception {
        if (EmptyUtil.isNullOrEmpty(${classObjectName}.getId())) {
           /**新增*/
            ${classObjectName}Mapper.insert(${classObjectName});
            return MessageUtil.createMessage(true, "新增成功");
        }else{
            /**修改*/
            ${classObjectName}Mapper.updateByPrimaryKeySelective(${classObjectName});
            return MessageUtil.createMessage(true, "更新成功");
        }
    }
    /**
     * 功能描述: 批量删除
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
     */
    @Override
    @Transactional
    public Message delete(Long[] id) throws Exception {
        for(int i=0;id.length > i;i++){
            ${classObjectName}Mapper.deleteByPrimaryKey(id[i]);
        }
        return  MessageUtil.createMessage(true, "删除成功！");
    }

}