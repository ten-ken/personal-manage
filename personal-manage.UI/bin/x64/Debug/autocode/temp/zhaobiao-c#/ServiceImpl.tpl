${title}
package ${serviceImplPackage};
import ${mapperInterfacePackage}.${className}Mapper;
import ${entityPackage}.${className};
import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import com.baomidou.mybatisplus.core.metadata.IPage;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import ${servicePackage}.I${className}Service;
import com.jysoft.map.common.entity.R;
import com.jysoft.map.common.exception.DataUpdatedException;
import com.jysoft.map.common.util.UUIDUtil;
import java.util.List;

 /**
 * <ul>
 * <li>Title: ${proName}-${className}ServiceImpl</li>
 * <li>Description:${tablecomment}ServiceImpl </li>
 * <li>Copyright: Copyright (c) 2018</li>
 * </ul>
 *
 * @author ${author}
 * @version ${version}
 * @date ${date?datetime}
 */
@Service
public class ${className}ServiceImpl implements ${className}Service  {

	@Autowired
	private ${className}Mapper ${classObjectName}Mapper;


	/**
	 * 分页查询
	 *
	 * @param page 分页条件
	 * @param ${classObjectName} 查询条件
	 * @return IPage<${className}> 查询结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@Transactional(readOnly=true)
	public IPage<${className}> listPage(Page<${className}> page, ${className} ${classObjectName}) {
        return ${classObjectName}Mapper.listPage(page, ${classObjectName});
	}

	/**
	 * 更新页面初期化
	 *
	 * @param id 主键
	 * @return 更新页面数据
	 */
	@Transactional(readOnly=true)
	public ${className} updateInit(String id) {
        return  ${classObjectName}Mapper.selectByPrimaryKey(id);
	}

	/**
	 * 保存操作
	 *
	 * @param ${classObjectName} 保存内容
	 * @return 保存结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@Transactional(readOnly=false)
	public R save(${className} ${classObjectName}) {
		${classObjectName}.setId(UUIDUtil.guid());
        // 唯一性判断
//		${className} check = ${classObjectName}.selectOne(Wrappers.<${className}>query().lambda()
//         .eq(${className}::getBusinessCode, ${classObjectName}.getBusinessCode()));
//        if (check != null) {
//         	return new R(Boolean.FALSE,"业务代码已存在，请修改后再保存！");
//        }
		${classObjectName}.commonInsert(${classObjectName});
        return new R(Boolean.TRUE,"保存成功！");
	}

	/**
	 * 更新操作
	 *
	 * @param ${classObjectName} 更新内容
	 * @return 更新结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@Transactional(readOnly=false)
	public R update(${className} ${classObjectName}) {
        // 业务代码唯一性判断
		//${className} check = ${classObjectName}Mapper.selectOne(Wrappers.<${className}>query().lambda()
        //.eq(${className}::getBusinessCode, ${classObjectName}.getBusinessCode()).ne(${className}::getId, ${classObjectName}.getId()));
        //if (check != null) {
        //	return new R(Boolean.FALSE,"业务代码已存在，请修改后再保存！");
        //}
        int updateCount = ${classObjectName}Mapper.commonUpdate(${classObjectName});
        if (updateCount == 0) {
        	throw new DataUpdatedException("数据已被其他人更新，请重新查询数据。");
        }
        return new R(Boolean.TRUE,"更新成功！");
	}

	/**
	 * 删除操作
	 *
	 * @param ids 删除主键
	 * @param updateTimes 更新时间（排他用)
	 * @return 删除结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@Transactional(readOnly=false)
	public R delete(String[] ids,String updateTimes[]) {
		${className}  ${classObjectName} = null;
        for (int i = 0;i < ids.length;i++) {
			${classObjectName} = new ${className}();
			${classObjectName}.setId(ids[i]);
			${classObjectName}.setUpdateTimeStr(updateTimes[i]);
			int count = ${classObjectName}Mapper.commonDelete(${classObjectName});
			if (count == 0) {
				throw new DataUpdatedException("数据已被其他人更新，请重新查询数据。");
			}
        }
        return new R(Boolean.TRUE,"删除成功！");
	}


}