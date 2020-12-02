using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace personal_manage.Common.vo
{
    /// <summary>
    ///  后台接口接收
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransferEntityVo<T>
    {

        private string tableName;

        private List<T> data;

        private string[] ids;

        public TransferEntityVo()
        {
        }

        public TransferEntityVo(string tableName, List<T> data)
        {
            this.tableName = tableName;
            this.data = data;
        }

        public TransferEntityVo(string tableName, string idstr)
        {
            this.tableName = tableName;
            this.ids = idstr!=null? idstr.Replace("'", "").Split(new char[1] { ',' }):null;
        }


        [JsonProperty("tableName")]
        public string TableName
        {
            get => tableName; set => tableName = value;
        }

        [JsonProperty("data")]
        public List<T> Data { get => data; set => data = value; }

        [JsonProperty("ids")]
        public string[] Ids { get => ids; set => ids = value; }
        
      
    }
}
