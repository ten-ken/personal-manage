using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.vo
{
    public class XmlSql
    {
        private string type;//select insert update delete

        private string sqlTem;

        private string sqlId;

        private string resultType;

        private string parameterType;

        public string SqlTem { get => sqlTem; set => sqlTem = value; }
        public string SqlId { get => sqlId; set => sqlId = value; }
        public string ResultType { get => resultType; set => resultType = value; }
        public string ParameterType { get => parameterType; set => parameterType = value; }
        public string Type { get => type; set => type = value; }
    }
}
