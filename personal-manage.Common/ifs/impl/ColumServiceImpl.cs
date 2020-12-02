
namespace personal_manage.Common.serivce.impl
 
{
    public class ColumServiceImpl:IColumService{


        public string DoFormat(string key, string value, string patternStr){
            //生成主键
            if("ID"== key || "id"== key){
                return (value!=null && value.Trim()!="" && value != "''") ? value:"'" +System.Guid.NewGuid().ToString("N")+"'";
            }
            //一般是日期类的处理
            return " to_timestamp("+value+",'"+ patternStr+ "')";
        }
    }
}
