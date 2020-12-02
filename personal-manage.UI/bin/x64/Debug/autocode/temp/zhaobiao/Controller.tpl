${title}
package ${controllerPackage};

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.ui.Model;
import ${entityPackage}.${className};
import ${servicePackage}.${className}Service;
import com.jiangqiao.core.message.Message;
import com.jiangqiao.core.entity.PageEntity;
import com.jiangqiao.core.controller.BaseController;
import com.jiangqiao.util.EmptyUtil;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;


import javax.servlet.http.HttpServletRequest;

import com.jysoft.map.common.util.UUIDUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import ${entityPackage}.${className};
import ${servicePackage}.${className}Service;
import com.jysoft.map.common.Constants;
import com.jysoft.map.common.LogContants;
import com.jysoft.map.common.controller.BaseController;
import com.jysoft.map.common.entity.R;
import com.jysoft.map.common.entity.TokenEntity;
import com.jysoft.map.common.exception.DataUpdatedException;
import com.jysoft.map.common.interceptor.SysLog;
import java.util.ArrayList;
import java.util.List;


/**
 * <ul>
 * <li>Title: ${proName}-${className}Controller.java</li>
 * <li>Description: ${tablecomment}Controller </li>
 * <li>Copyright: Copyright (c) 2018</li>
 * </ul>
 *
 * @author ${author}
 * @version ${version}
 * @date  ${date?datetime}
 */
@Controller
@RequestMapping("/${moduleName}/${classMiniName?replace('_','')}/")
public class ${className}Controller extends BaseController{

	private static final Logger logger = LoggerFactory.getLogger(${className}Controller.class);
	
	/**${tablecomment}业务接口**/
	@Autowired
	private I${className}Service ${classObjectName}Service;

	
	/**
	 * 分页查询
	 *
	 * @param page 分页条件
	 * @param ${classObjectName} 查询条件
     * @param request 请求信息
	 * @return R 查询结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@RequestMapping(value="/listPage", method={RequestMethod.GET})
    @SysLog(operate= LogContants.OPERATE_LIST,module = "${"$"}{modelChName}", menu = "${tablecomment}管理",desc="查询${tablecomment}信息列表")
	public R listPage(Page<${className}> page, ${className} ${classObjectName}, HttpServletRequest request) {
	    try {
			return new R(${classObjectName}Service.listPage(page, ${classObjectName}));
	    } catch (Exception e) {
			logger.error(e.getMessage(), e);
			return new R(Boolean.FALSE, Constants.SYSTEM_ERROR,Constants.ERROR);
	    }
	}

	/**
	 * 更新初始化
	 *
	 * @param id 主键
	 * @param request 请求信息
	 * @return 更新画面数据
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@RequestMapping(value="/{id}", method={RequestMethod.GET})
    @SysLog(operate= LogContants.OPERATE_SEE,module = "${"$"}{modelChName}", menu = "${tablecomment}管理",desc="查询${tablecomment}信息")
	public R updateInit(@PathVariable String id, HttpServletRequest request) {
	    try {
			return new R(${classObjectName}Service.updateInit(id));
	    } catch (Exception e) {
			logger.error(e.getMessage(), e);
			return new R(Boolean.FALSE, Constants.SYSTEM_ERROR,Constants.ERROR);
	    }
	}

	/**
	 * 保存
	 *
	 * @param ${classObjectName} 保存数据
	 * @param request 请求信息
	 * @return R 保存结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@RequestMapping(value="/save", method={RequestMethod.POST})
    @SysLog(operate= LogContants.OPERATE_SAVE,module = "${"$"}{modelChName}", menu = "${tablecomment}管理",desc="新增${tablecomment}信息")
	public R save(@RequestBody ${className} ${classObjectName}, HttpServletRequest request) {
	    try {
			TokenEntity tokenEntity = getToken(request);
			${classObjectName}.setCreateUser(tokenEntity.getId());
			${classObjectName}.setUpdateUser(tokenEntity.getId());
			return  ${classObjectName}Service.save(${classObjectName});
	    } catch (Exception e) {
			logger.error(e.getMessage(), e);
			return new R(Boolean.FALSE, Constants.SYSTEM_ERROR,Constants.ERROR);
	    }
	}

	/**
	 * 更新
	 *
	 * @param ${classObjectName} 更新数据
     * @param request 请求信息
	 * @return R 更新结果
	 * @author ${author}
	 * @version ${version}
	 * @date ${date?datetime}
	 */
	@RequestMapping(value="/update", method={RequestMethod.POST})
    @SysLog(operate= LogContants.OPERATE_UPDATE,module = "${"$"}{modelChName}", menu = "${tablecomment}管理",desc="修改${tablecomment}信息")
	public R update(@RequestBody ${className} ${classObjectName}, HttpServletRequest request) {
	    try {
        	TokenEntity tokenEntity = getToken(request);
			${classObjectName}.setUpdateUser(tokenEntity.getId());
			return  ${classObjectName}Service.update(${classObjectName});
	    } catch (DataUpdatedException e) {
			logger.error(e.getMessage(), e);
			return new R(Boolean.FALSE, Constants.SYSTEM_DATA_UPDATED_ERROR,Constants.ERROR);
	    } catch (Exception e) {
			logger.error(e.getMessage(), e);
			return new R(Boolean.FALSE, Constants.SYSTEM_ERROR,Constants.ERROR);
	    }
	}


} 