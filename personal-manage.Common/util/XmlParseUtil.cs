using personal_manage.Common.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace personal_manage.Common.util
{
    public class XmlParseUtil
    {

        /// <summary>
        ///  读取xml文件的sql methodId就是标签的id 不要内容不要带空格
        /// </summary>
        /// <param name="methodId"></param>
        /// <returns></returns>
        public static XmlSql GetXmlSql(string methodId)
        {
            string root = System.Environment.CurrentDirectory;

            root = root.Replace("bin\\Debug", "");

            XmlSql xmlSql = new XmlSql();
            XmlDocument doc = new XmlDocument();

            doc.Load(root+"\\mapper\\UserMapper.xml");

            // 得到根节点mapper
            XmlNode xn = doc.SelectSingleNode("mapper");
            XmlNodeList nodeList = xn.ChildNodes;

            string sqlxml = "";

            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlAttributeCollection attributes = nodeList.Item(i).Attributes;

                sqlxml = nodeList.Item(i).OuterXml;

                //匹配方法
                if (sqlxml.Contains("id=\"" + methodId + "\""))
                {

                    xmlSql.Type = nodeList.Item(i).Name;

                    xmlSql.SqlTem = nodeList.Item(i).InnerXml;

                    for (int k = 0; k < attributes.Count; k++)
                    {

                        if (methodId.Equals(attributes[k].Value))
                        {
                            xmlSql.SqlId = attributes[k].Value;
                        }

                        else if ("parameterType".Equals(attributes[k].Name))
                        {
                            xmlSql.ParameterType = attributes[k].Value;
                        }

                        else if ("resultType".Equals(attributes[k].Name))
                        {
                            xmlSql.ResultType = attributes[k].Value;
                        }
                    }

                    break;

                }
            }
            return xmlSql;

        }
    }
}
