using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.DAL.Util;


namespace personal_manage.DAL.Sys
{
    public class DemoDAL
    {
        public void CreateDB()
        {
            try
            {
                string location = @System.AppDomain.CurrentDomain.BaseDirectory + "database";
                /*SQLiteLibrary.CreateDB(location, "peoplemanage.sqlite");*/

                System.Data.DataTable dataTable = SQLiteLibrary.selectDataBySql(location, "peoplemanage.sqlite", "select * from OS_ZB_PURCHASE_PROJECT_INFO");

                Console.WriteLine("---");
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        
    }
}
