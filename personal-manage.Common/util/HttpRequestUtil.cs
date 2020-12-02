using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Windows.Forms;
using personal_manage.Common.dto;
using personal_manage.Common.vo;
using Newtonsoft.Json;
using personal_manage.Common.extendmethods;//扩展方法的引用

namespace personal_manage.Common.util
{
    /// <summary>
    ///  http 请求的接口
    /// </summary>
    public class HttpRequestUtil
    {


        /// <summary>
        /// 移除 传递的部分属性 防止异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="list"></param>
        /// <param name="ingoreFields"></param>
        /// <returns></returns>
        public static R RequestApi<T>(string api, List<T> list, string[] ingoreFields, string method)
        {
            List<string> curIngores = new List<string>();
            curIngores = GetCurIngores(ingoreFields);

            Type tbc = typeof(T);
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
            PropertyInfo currentProp = null;

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    RemoveFieldValue(item, tbc, bindingFlags, currentProp, curIngores);
                }
            }
      
            return ConnectApiResult(api, list, method);
        }

        /// <summary>
        /// 获取默认忽略传递的属性值
        /// </summary>
        /// <param name="ingoreFields"></param>
        /// <returns></returns>
        private static List<string> GetCurIngores(string[] ingoreFields)
        {
            List<string> curIngores;
            if (ingoreFields != null)
            {
                curIngores = new List<string>(ingoreFields);
                //默认配置
                if (!curIngores.Contains("CreateTime"))
                {
                    curIngores.Add("CreateTime");
                }
                if (!curIngores.Contains("UpdateTime"))
                {
                    curIngores.Add("UpdateTime");
                }
            }
            else
            {
                curIngores = new List<string>(new string[] { "CreateTime", "UpdateTime" });
            }
            return curIngores;
        }

        /// <summary>
        ///  移除 属性值 防止后台转换异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="tbc"></param>
        /// <param name="bindingFlags"></param>
        /// <param name="currentProp"></param>
        /// <param name="curIngores"></param>
        private static void RemoveFieldValue<T>(T item, Type tbc, BindingFlags bindingFlags, PropertyInfo currentProp, List<string> curIngores)
        {
            try
            {
                foreach (var Ingore in curIngores)
                {
                    currentProp = tbc.GetProperty(Ingore.UpperCaseFirst(), bindingFlags);
                    if (currentProp != null)
                    {
                        currentProp.SetValue(item, null);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        /// <summary>
        /// 移除 传递的部分属性 防止异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="t"></param>
        /// <param name="ingoreFields"></param>
        /// <returns></returns>
        public static R RequestApi<T>(string api, T t, string[] ingoreFields, string method)
        {
            List<string> curIngores = new List<string>();
            curIngores = GetCurIngores(ingoreFields);

            Type tbc = typeof(T);
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
            PropertyInfo currentProp = null;

            if (t != null)
            {
                RemoveFieldValue(t, tbc, bindingFlags, currentProp, curIngores);
            }
            return ConnectApiResult(api, t, method);
        }



        /// <summary>
        /// 请求数据接口 返回结果
        /// </summary>
        /// <param name="api"></param>
        /// <param name="entity">实体对象</param>
        /// <param name="method">方法类型 get post delete push</param>
        /// <returns></returns>
        /// PostBasicEntityDataApi
        public static R ConnectApiResult(string api, object entity, string method)

        {
            try
            {

                string restUrl = ConfigurationManager.AppSettings["dataApiPrefixUrl"].ToString();

                api = Regex.Replace(api, @"^(\\|//)", "");

                string url = restUrl + api;

                url = url + "?rnd=" + DateTime.Now.ToFileTimeUtc().ToString() + "&token=" + PublicVo.Token + "&supplierId=" + PublicVo.SupplyId;

                string paramJson = "";

                if (entity != null)
                {
                    paramJson = JsonConvert.SerializeObject(entity);
                }

                string result = DoRequest(url, paramJson, method);

                R resultR = JsonConvert.DeserializeObject<R>(result);

                return resultR;
            }
            catch (Exception ex)
            {
                return new R(9, false, "上传服务器异常,异常信息:" + ex.Message);
            }
        }

        /// <summary>
        /// 请求数据接口 ===>普通删除
        /// </summary>
        /// <param name="api"></param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public static R PostDeleteRemoteDataApi(string api, String deleteIdsStr)
        {
            try
            {
                string restUrl = ConfigurationManager.AppSettings["dataApiPrefixUrl"].ToString();
                api = Regex.Replace(api, @"^(\\|//)", "");

                string url = restUrl + api;

                url = url + "?rnd=" + DateTime.Now.ToFileTimeUtc().ToString() + "&token=" + PublicVo.Token + "&supplierId=" + PublicVo.SupplyId;

                string deletes = JsonConvert.SerializeObject(deleteIdsStr.Replace("'", "").Split(new char[1] { ',' }));
                string result = DoRequest(url, deletes, "POST");

                R resultR = JsonConvert.DeserializeObject<R>(result);

                return resultR;
            }
            catch (Exception ex)
            {
                return new R(9, false, "上传服务器异常,异常信息:" + ex.Message);
            }
        }


        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="jsonStr">json字符串</param>
        /// <returns></returns>
        public static string DoRequest(string Url, string jsonStr, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = method ?? "POST";//默认为post
            request.ReadWriteTimeout = 5000;
            request.KeepAlive = false;

            byte[] postParamsData = Encoding.UTF8.GetBytes(jsonStr); //使用utf-8格式组装post参数

            request.ContentType = "application/json";
            request.ContentLength = postParamsData.Length;

            Stream reqStream = null;
            reqStream = request.GetRequestStream();
            reqStream.Write(postParamsData, 0, postParamsData.Length);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

        }


        /// <summary>
        /// 组装请求参数
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string BuildHttpQueryParams(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder paramsData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name))
                {
                    if (hasParam)
                    {
                        paramsData.Append("&");
                    }
                    paramsData.Append(name);
                    paramsData.Append("=");
                    if (encode == "gb2312")
                    {
                        paramsData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        paramsData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        paramsData.Append(value);
                    }
                    hasParam = true;
                }
            }
            MessageBox.Show(paramsData.ToString());
            return paramsData.ToString();
        }
    }
}
