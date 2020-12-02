using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using personal_manage.Common.vo;
using personal_manage.Common.extendmethods;//扩展方法的引用

namespace personal_manage.Common.util
{
    //本地下载模板的通用方法
    public class LocalFileDownLoad
    {

        private static string sqliteDbName = ConfigurationManager.AppSettings["sqliteDBName"].ToString();  //数据库名称
        private static string sqliteDbLocation = ConfigurationManager.AppSettings["sqliteDBLocation"].ToString(); //数据库存放路径

        //文件
        public static void downLoadFile(string fileName){
            DownLoadFile(fileName, null);
        }

        /// <summary>
        ///  默认是导出  模板文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tempPath"></param>
        public static void DownLoadFile(string fileName,string tempPath)
        {
            tempPath = (tempPath == null || tempPath == "") ? @System.AppDomain.CurrentDomain.BaseDirectory + "templates\\export\\" : tempPath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileName;
            saveFileDialog.AddExtension = false;

            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "文件保存路径";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                FileUtils.FileDownLoad(tempPath + fileName, path, "下载");
            }
        }


        public static void downLoadAttachFile(string attachId, string tempPath)
        {
            string sql = "select * from SYS_FILE_INFO where id='"+ attachId + "'";
            DataTable dataTable = new DataTable();

            List<SysFileInfo> lists =DbConvert.TableToList<SysFileInfo>(dataTable);

            if (lists.Count > 0)
            {
                tempPath = (tempPath == null || tempPath == "") ? AppDomain.CurrentDomain.BaseDirectory + "fujian\\" : tempPath;
                string realPath = tempPath+lists[0].FilePath;

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + lists[0].FileDispName;

                saveFileDialog.AddExtension = false;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "文件保存路径";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    FileUtils.FileDownLoad(realPath, path, "下载");
                }
            }
        }


        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="fileOldName">文件原名称</param>
        /// <param name="relPath">表存放的文件路径</param>
        public static void downLoadAttach(string fileOldName, string relPath)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "templates\\export\\" + relPath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "word文件|*.xlxs;*.xls";
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileOldName;
            saveFileDialog.AddExtension = false;
          
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "文件保存路径";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                FileUtils.FileDownLoad(filepath, path, "下载");
            }
        }
    }
}
