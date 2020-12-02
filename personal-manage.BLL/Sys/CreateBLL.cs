using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.BLL.Base;
using personal_manage.DAL.Base;

namespace personal_manage.BLL.Sys
{
    public class CreateBLL : BaseBLL
    {
        private BaseDAL baseDAL = new BaseDAL();

        public DataTable SelectData(string sql)
        {
            return baseDAL.SelectData(sql);
        }


    }
}
