using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.prop;

namespace personal_manage.Common.util
{
    /// <summary>
    ///  错误日志记录
    /// </summary>
    public class LogHelp
    {

        private static string logPath = AppDomain.CurrentDomain.BaseDirectory  + "Error.txt";
       
        private Type type;

        private LogHelp()
        {

        }

        public LogHelp(Type type)
        {
            this.type = type;
        }



        public static void addLog(string str, string name = "管理员")
        {
            //获取当前日期
            //string s = DateTime.Now.ToString("yyyy-MM-dd");
            //string time = DateTime.Now.ToLongTimeString().ToString();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string path = AppDomain.CurrentDomain.BaseDirectory + "wcfLog.txt"; ;

            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                long fl = fs.Length;
                fs.Seek(fl, SeekOrigin.End);
                sw.WriteLine("时间 :" + time + "   操作员姓名:" + name + "        操作:" + str + "\n");//开始写入值
                sw.Close();
                fs.Close();


            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                long fl = fs.Length;
                fs.Seek(fl, SeekOrigin.Begin);

                sw.WriteLine("时间 :" + time + "   操作员姓名:" + name + "        操作:" + str + "\n");//开始写入值
                sw.Close();
                fs.Close();
            }
        }


        public void AddLog(string message, string operatorId)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.OperatorId = operatorId;
            logInfo.ErrorInfo = message;
            AddLog(logInfo);
        }

    

        private void AddLog(LogInfo logInfo)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                //获取当前日期
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                logInfo.OperateTime = time;
                logInfo.ClassInfo = type.FullName;

                if (!File.Exists(logPath))
                {
                    fs = new FileStream(logPath, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    fs.Seek(fs.Length, SeekOrigin.End);
                }
                else
                {
                    fs = new FileStream(logPath, FileMode.Open, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    fs.Seek(fs.Length, SeekOrigin.Begin);
                }
                //开始写入值
                sw.WriteLine("操作时间 :"+logInfo.OperateTime+", 操作员Id:"+logInfo.OperatorId+" \n");
                sw.Write($"位置信息: {logInfo.ClassInfo}\n");
                sw.Write($"错误信息: {logInfo.ErrorInfo}\n");
            }
            catch (Exception ex)
            {
                //throw;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

    }
}
