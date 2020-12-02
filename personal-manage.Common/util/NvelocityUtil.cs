using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;

namespace personal_manage.Common.util
{
    public class NvelocityUtil
    {

        /// <summary>
        ///  通过模板文件 生成文件
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="templateFileName"></param>
        /// <param name="outFilePath"></param>
        /// <param name="dictKv"></param>
        public static void WriteTemplateByFile(string templatePath,string templateFileName,string outFilePath,Dictionary<string,object> dictKv)
        {
            // 初始化模板引擎
            VelocityEngine ve = new VelocityEngine();
            //可选值："class"--从classpath中读取，"file"--从文件系统中读取
            ve.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            //如果从文件系统中读取模板，那么属性值为org.apache.velocity.runtime.resource.loader.FileResourceLoader
            ve.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, @templatePath);
            ve.Init();


            //模板内容
            VelocityContext vlc = new VelocityContext();
            foreach (string key in dictKv.Keys)
            {
                vlc.Put(key, dictKv[key]);
            }

            /*
            *指定引擎加载的模版
             */
            Template vtp = ve.GetTemplate(@templateFileName);
            StringWriter str = new StringWriter();
            vtp.Merge(vlc, str);

            File.WriteAllText(@outFilePath, str.GetStringBuilder().ToString());//生成文件的路径可以自由选择
            MessageBox.Show(str.GetStringBuilder().ToString());
        }
        
       
        /// <summary>
        ///  通过字符串【模板】 生成文件
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static void WriteTemplateByString(string outFilePath,string templateString, Dictionary<string, object> dictKv)
        {
            VelocityEngine templateEngine = new VelocityEngine();
            templateEngine.Init();

            VelocityContext velocityContext = new VelocityContext();
            foreach (string key in dictKv.Keys)
            {
                velocityContext.Put(key, dictKv[key]);
            }


            StringWriter writer = new StringWriter();
            templateEngine.Evaluate(velocityContext, writer, null, templateString);

            FileInfo fileInfo = new FileInfo(outFilePath);

            //父目录不存在 进行创建
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            File.WriteAllText(@outFilePath, writer.GetStringBuilder().ToString());//生成文件的路径可以自由选择
            //MessageBox.Show(writer.GetStringBuilder().ToString());
        }





      /*  /// <summary>
        ///  通过字符串【模板】 生成文件
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static void WriteTemplateByString(string outFileFolder, string templateString, Dictionary<string, object> dictKv)
        {
            VelocityEngine templateEngine = new VelocityEngine();
            templateEngine.Init();

            VelocityContext velocityContext = new VelocityContext();
            foreach (string key in dictKv.Keys)
            {
                velocityContext.Put(key, dictKv[key]);
            }


            StringWriter writer = new StringWriter();
            templateEngine.Evaluate(velocityContext, writer, null, templateString);

            File.WriteAllText(@outFilePath, writer.GetStringBuilder().ToString());//生成文件的路径可以自由选择
            //MessageBox.Show(writer.GetStringBuilder().ToString());
        }*/

    }
}
