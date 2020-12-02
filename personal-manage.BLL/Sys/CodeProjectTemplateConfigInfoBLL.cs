using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.BLL.Base;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.Models.entity;

namespace personal_manage.BLL.Sys
{
    /// <summary>
    ///  模板配置信息BLL
    /// </summary>
    public class CodeProjectTemplateConfigInfoBLL : BaseBLL
    {
        public R SaveOrUpdateBySelf(CodeProjectTemplateConfigInfo item, string cols, bool needReturn)
        {
            return SaveOrUpdate(item, cols, needReturn, VeriyData);
        }



        /// <summary>
        ///  验证
        /// </summary>
        /// <param name="codeProjectInfo"></param>
        /// <returns></returns>
        private VerifyMessage VeriyData(CodeProjectTemplateConfigInfo codeProjectTemplateConfigInfo)
        {
            VerifyMessage verifyMessage = new VerifyMessage();
            verifyMessage.ExistError = false;

            string pre = "新增";
            string whereCon = $" TEMPLATE_NAME='{codeProjectTemplateConfigInfo.TemplateName}'  and PROJECT_ID='{codeProjectTemplateConfigInfo.ProjectId}' ";
            if (codeProjectTemplateConfigInfo.ID > 0)
            {
                whereCon += $" AND ID !='{codeProjectTemplateConfigInfo.ID}' ";
                pre = "修改";
            }

            List<CodeProjectTemplateConfigInfo> lists = SelectList(codeProjectTemplateConfigInfo, "ID", whereCon, WhereType.SQL);

            if (lists != null && lists.Count > 0)
            {
                verifyMessage.ExistError = true;
                verifyMessage.ErrorInfo = $"{pre}失败，该模板名称已存在";
            }

            return verifyMessage;
        }

    }
}
