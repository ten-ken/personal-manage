using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.BLL.Base;
using personal_manage.Common.dto;
using personal_manage.Common.enums;
using personal_manage.DAL.Sys;
using personal_manage.Models.entity;

namespace personal_manage.BLL.Sys
{
    /// <summary>
    ///  项目代码生成信息BLL
    /// </summary>
    public class CodeProjectInfoBLL : BaseBLL
    {
        //override
        public  R SaveOrUpdateBySelf(CodeProjectInfo codeProjectInfo, string cols, bool needReturn)
        {
            return SaveOrUpdate(codeProjectInfo, cols, needReturn, VeriyData);
        }



        /// <summary>
        ///  验证
        /// </summary>
        /// <param name="codeProjectInfo"></param>
        /// <returns></returns>
        private VerifyMessage VeriyData(CodeProjectInfo codeProjectInfo)
        {
            VerifyMessage verifyMessage = new VerifyMessage();
            verifyMessage.ExistError = false;

            string pre = "新增";
            string whereCon = $" PRO_NAME='{codeProjectInfo.PRO_NAME}'";
            if (codeProjectInfo.ID>0)
            {
                whereCon += $" AND ID !='{codeProjectInfo.ID}' ";
                pre = "修改";
            }

            List<CodeProjectInfo> lists = SelectList(codeProjectInfo, "PRO_NAME", whereCon, WhereType.SQL);

            if (lists != null && lists.Count > 0)
            {
                verifyMessage.ExistError = true;
                verifyMessage.ErrorInfo = $"{pre}失败，该项目已存在";
            }

            return verifyMessage;
        }

    }
}
