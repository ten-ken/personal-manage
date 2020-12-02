using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using personal_manage.Common.attr;
using personal_manage.Common.dto;
using personal_manage.Common.extendmethods;//扩展方法的引用

namespace personal_manage.Common.util
{
    /// <summary>
    /// 验证的工具类==》非空 字符长度 字段重复性 
    /// </summary>
    public class VerifyUtil
    {
        /// <summary>
        ///  验证list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lists"></param>
        /// <param name="needColum">一般是list的数据 按行提醒</param>
        /// <param name="tipPreffix">提示头</param>
        /// <returns></returns>
        public static VerifyMessage Verify<T>(List<T> lists, string businessDiff, bool needColum, string tipPreffix)
        {
            VerifyMessage message = new VerifyMessage();
            message.ExistError = false;
            try
            {
                string preffix = "";
                StringBuilder sbf = new StringBuilder("");

                //仅提示
                StringBuilder onlyPrompt = new StringBuilder("");

                if (lists != null && lists.Count > 0)
                {
                    T entity = Activator.CreateInstance<T>();

                    Type tbc = typeof(T);
                    /*BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
                    */

                    PropertyInfo[] propertyInfos = tbc.GetProperties();//获取

                    VerifyAttribute verifyAttr = null;

                    Dictionary<string, PropertyInfo> dictionAry = new Dictionary<string, PropertyInfo>();
                    Dictionary<string, VerifyAttribute> columnDic = new Dictionary<string, VerifyAttribute>();

                    string popName = "";

                    for (int p = 0; p < propertyInfos.Length; p++)
                    {
                        verifyAttr = propertyInfos[p].GetCustomAttribute<VerifyAttribute>();
                        if (verifyAttr != null && CheckPattern(verifyAttr.BusinessDiff, businessDiff))
                        {
                            popName = propertyInfos[p].Name.UpperCaseFirst();
                            dictionAry.Add(popName, tbc.GetProperty(popName));
                            columnDic.Add(popName, verifyAttr);
                        }
                    }

                    Dictionary<string, string> columnRepeat = new Dictionary<string, string>();

                    Dictionary<string, PropertyInfo>.KeyCollection keys = dictionAry.Keys;
                    object v = null;

                    VerifyAttribute currentVerify;

                    int count = 0;
                    string tipMsg = "";

                    bool onlyAlert = false;//仅提示        

                    foreach (T info in lists)
                    {
                        count++;
                        //提示行？
                        preffix = needColum ? $"第{count}行 " : "";

                        foreach (string key in keys)//获得类型的属性字段  
                        {
                            v = dictionAry[key].GetValue(info);
                            currentVerify = columnDic[key];

                            if (currentVerify == null)
                            {
                                break;
                            }
                            tipMsg = (currentVerify.ColumCnm != null && currentVerify.ColumCnm != "") ? currentVerify.ColumCnm : dictionAry[key].Name;

                            onlyAlert = currentVerify.PromptOnly;


                            //非空性验证
                            if (!currentVerify.Nullable && (v == null || v.ToString().Trim() == ""))
                            {
                                message.ExistError = true;
                                if (onlyAlert)
                                {
                                    onlyPrompt.Append(preffix + tipPreffix + tipMsg + "不得为空\n");
                                }
                                else
                                {
                                    sbf.Append(preffix + tipPreffix + tipMsg + "不得为空\n");
                                }
                            }

                            //长度
                            if (currentVerify.MaxLength > 0 && (v != null && v.ToString().Length > currentVerify.MaxLength))
                            {
                                message.ExistError = true;
                                if (onlyAlert)
                                {
                                    onlyPrompt.Append(preffix + tipPreffix + tipMsg + "长度不得超过" + currentVerify.MaxLength + "个字符\n");
                                }
                                else
                                {
                                    sbf.Append(preffix + tipPreffix + tipMsg + "长度不得超过" + currentVerify.MaxLength + "个字符\n");
                                }

                            }

                            //重复性
                            if (currentVerify.Repeat && v != null && !string.IsNullOrWhiteSpace(v.ToString()))
                            {
                                if (columnRepeat.ContainsKey(key + "-||-" + v.ToString()))
                                {
                                    message.ExistError = true;
                                    sbf.Append(preffix + tipPreffix + tipMsg + "存在重复\n");
                                }
                                else
                                {
                                    columnRepeat.Add(key + "-||-" + v.ToString(), "");
                                }

                            }


                            //正则验证部分==> 数据格式验证
                            if (v != null && currentVerify.Pattern != null && currentVerify.Pattern != "" && v.ToString().Trim().Length > 0)
                            {
                                //不匹配正则
                                if (!Regex.IsMatch(v.ToString().Trim(), currentVerify.Pattern))
                                {
                                    message.ExistError = true;
                                    if (onlyAlert)
                                    {
                                        onlyPrompt.Append(preffix + tipPreffix + tipMsg + "格式不正确\n");
                                    }
                                    else
                                    {
                                        sbf.Append(preffix + tipPreffix + tipMsg + "格式不正确\n");
                                    }

                                }
                            }
                        }

                    }
                    message.ErrorInfo = sbf.ToString();
                    message.PromptInfo = onlyPrompt.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return message;
        }

        /// <summary>
        /// 完全匹配的验证 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lists"></param>
        /// <param name="needColum"></param>
        /// <returns></returns>
        public static VerifyMessage Verify<T>(List<T> lists, bool needColum, string tipPreffix)
        {
            return Verify(lists, null, needColum, tipPreffix);
        }

        /// <summary>
        ///  是否匹配业务 进行验证
        /// </summary>
        /// <param name="businessDifField"></param>
        /// <param name="businessSource"></param>
        /// <returns></returns>
        private static bool CheckPattern(string[] businessDifField, string businessSource)
        {
            //不匹配
            if (businessSource != null && businessDifField == null)
            {
                return false;
            }
            //适配所有
            else if (businessDifField == null)
            {
                return true;
            }
            List<string> list = new List<string>(businessDifField);
            return list.Contains(businessSource);
        }



        /// <summary>
        ///  完全匹配的验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="needColum"></param>
        /// <returns></returns>
        public static VerifyMessage Verify<T>(T t)
        {
            if (t != null)
            {
                List<T> lists = new List<T>();
                lists.Add(t);
                return Verify<T>(lists, false, "");
            }
            VerifyMessage message = new VerifyMessage();
            message.ExistError = false;
            return message;
        }

        /// <summary>
        ///  匹配业务的验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="businessDiff"></param>
        /// <returns></returns>
        public static VerifyMessage Verify<T>(T t, string businessDiff)
        {
            if (t != null)
            {
                List<T> lists = new List<T>();
                lists.Add(t);
                return Verify<T>(lists, businessDiff, false, "");
            }
            VerifyMessage message = new VerifyMessage();
            message.ExistError = false;
            return message;
        }
    }
}
