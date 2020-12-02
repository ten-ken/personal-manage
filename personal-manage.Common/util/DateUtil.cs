using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.Common.util
{
    public class DateUtil
    {
        public static string yyyyMMdd ="yyyyMMdd";

        public static string yyyy_MM_dd = "yyyy-MM-dd";

        public static string yyyy_MM_ddhhmmss = "yyyy-MM-dd hh:mm:ss";

        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

        /// <summary>
        ///  将字符串转时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime StrToDateTime(string source)
        {
            return Convert.ToDateTime(source);
        }

        /// <summary>
        /// 将字符串转时间
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dtFormat"></param>
        /// <returns></returns>
        public static DateTime StrToDateTime(string source, string pattern)
        {
            //DateTimeFormatInfo df = new DateTimeFormatInfo();
            if(pattern==null || "".Equals(pattern))
            {
                pattern ="yyyy/MM/dd";
            }
            //df.ShortDatePattern = pattern;
            return DateTime.ParseExact(source, pattern,CultureInfo.CurrentCulture);
            //return Convert.ToDateTime(source, df);
        }



        /// <summary>
        ///  设置时间选择器的样式
        /// </summary>
        /// <param name="timePicker"></param>
        /// <param name="customFormat"></param>
        /// <param name="allowDrop"></param>
        public static void SetDatePick(ref DateTimePicker timePicker,string customFormat,bool allowDrop,Action<object, EventArgs> changeCall)
        {
            customFormat = customFormat == null ? "yyyy-MM-dd" : customFormat;           

            timePicker.CustomFormat = "   ";
            //使用自定义格式
            timePicker.Format =DateTimePickerFormat.Custom;

            //下拉选项是否展示==》默认展示
            timePicker.AllowDrop = allowDrop;

            //timePicker.Text = textValue;

            if(timePicker.Text!=null && !"".Equals(timePicker.Text))
            {
                //使用设置的格式
                timePicker.CustomFormat = customFormat;
                timePicker.ShowCheckBox = true;
            }
            else
            {
                timePicker.ShowCheckBox = false;
            }

            if (changeCall != null)
            {
                timePicker.ValueChanged += new EventHandler(changeCall);
            }

        }



        /// <summary>
        /// 设置时间选择器的样式
        /// </summary>
        /// <param name="timePicker"></param>
        /// <param name="customFormat"></param>
        /// <param name="allowDrop"></param>
        public static void SetDatePick(ref DateTimePicker timePicker, string customFormat, bool allowDrop)
        {
            SetDatePick(ref timePicker, customFormat, allowDrop, null);
        }

        /// <summary>
        /// 设置时间选择器的样式
        /// </summary>
        /// <param name="timePicker"></param>
        /// <param name="customFormat"></param>
        public static void SetDatePick(ref DateTimePicker timePicker, string customFormat)
        {
            SetDatePick(ref timePicker, customFormat, true, null);
        }


    }
}
