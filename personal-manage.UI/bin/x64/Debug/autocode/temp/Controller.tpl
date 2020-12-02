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
//import org.apache.shiro.authz.annotation.RequiresPermissions;

/**
 * <ul>
 * <li>Title: ${proName}-${className}Controller.java</li>
 * <li>Description: ${tablecomment}Controller </li>
 * <li>Copyright: Copyright (c) 2018</li>
 * <li>Company: http://www.spic.com.cn/</li>
 * </ul>
 *
 * @author ${author}
 * @version ${version}
 * @date  ${date?datetime}
 */
@Controller
@RequestMapping("/${moduleName}/${classMiniName}/")
public class ${className}Controller extends BaseController{

	/**${tablecomment}业务接口**/
	@Autowired
	private ${className}Service ${classObjectName}Service;

    /**
     * 功能描述: 首页数据展示
     * @param ${classObjectName}
     * @author: ${author}
     * @date: ${date?datetime}
    */
	//@RequiresPermissions(value = {PrivilegeConstants.${tablename?upper_case}_MENU})
    @RequestMapping("list.jiangqiao")
    @ResponseBody
    public PageEntity<${className}> list(${className} ${classObjectName}) throws Exception {
        PageEntity<${className}> pageEntity = new PageEntity<${className}>();
        pageEntity.setParameter(${classObjectName});
        return ${classObjectName}Service.list(pageEntity);
    }

    /**
     * 功能描述: 更新初始化
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
    */
    @RequestMapping("updateInit.jiangqiao")
    public ModelAndView updateInit(Long id,Model model) throws Exception{
         ModelAndView modelAndView  =  new ModelAndView();
         if(!EmptyUtil.isNullOrEmpty(id)){
           modelAndView.addObject("${classObjectName}", ${classObjectName}Service.updateInit(id));
         }
         modelAndView.setViewName("/");
         return  modelAndView;
    }

    /**
     * 新增或更新
     * @param ${classObjectName}
     * @date: ${date?datetime}
     */
	//@RequiresPermissions(value = {PrivilegeConstants.${tablename?upper_case}_ADD,PrivilegeConstants.${tablename?upper_case}_UPDATE},logical = Logical.OR)
    @RequestMapping("saveOrUpdate.jiangqiao")
    @ResponseBody
    public Message saveOrUpdate(@ModelAttribute ${className}  ${classObjectName}) throws Exception {
        return ${classObjectName}Service.saveOrUpdate(${classObjectName});
    }

    /**
     * 功能描述: 批量删除
     * @param id
     * @author: ${author}
     * @date: ${date?datetime}
     */
	//@RequiresPermissions(value = {PrivilegeConstants.${tablename?upper_case}_DELETE})
    @RequestMapping("delete.jiangqiao")
    @ResponseBody
    public Message delete(Long[] id) throws Exception{
       return  ${classObjectName}Service.delete(id);
    }

} 