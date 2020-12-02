using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.jysoft.ess.zbfz.entity;
using personal_manage.BLL.Base;
using personal_manage.Common.dto;
using personal_manage.Common.enums;

namespace personal_manage.BLL.Sys
{
    public class AppAccountMgnBLL : BaseBLL
    {
        public R SaveOrUpdateBySelf(AppAccountMgn saveItem, string cols, bool needReturn)
        {
            return SaveOrUpdate(saveItem, cols, needReturn, VeriyData);
        }


        /// <summary>
        ///  验证
        /// </summary>
        /// <param name="codeProjectInfo"></param>
        /// <returns></returns>
        private VerifyMessage VeriyData(AppAccountMgn saveItem)
        {
            VerifyMessage verifyMessage = new VerifyMessage();
            verifyMessage.ExistError = false;

            string pre = "新增";
            string whereCon = $" SOURCE='{saveItem.SOURCE}'  and ACCOUNT='{saveItem.ACCOUNT}'";
            if (saveItem.ID > 0)
            {
                whereCon += $" AND ID !='{saveItem.ID}' ";
                pre = "修改";
            }

            List<AppAccountMgn> lists = SelectList(saveItem, "ID", whereCon, WhereType.SQL);

            if (lists != null && lists.Count > 0)
            {
                verifyMessage.ExistError = true;
                verifyMessage.ErrorInfo = $"{pre}失败，该来源的账号已存在";
            }

            return verifyMessage;
        }

    }
}
