using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.vo;

namespace personal_manage.Common.util
{
    public class FileUtil
    {
        /// <summary>
        ///  获取文件类型码
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string getFileCode(string filePath){
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            string fileType = "";
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    fileType += reader.ReadByte().ToString();
                }
            }
            catch (Exception){
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }                    
            return fileType;
        }

        /// <summary>
        ///  是否 pdf
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsPDF(string filePath)
        {
            return "3780" == getFileCode(filePath);
        }

        /// <summary>
        ///  是否 txt
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsTxt(string filePath)
        {
            return "210187" == getFileCode(filePath);
        }

        /// <summary>
        ///  是否 word
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsWord(string filePath)
        {
            return "208207" == getFileCode(filePath)|| "8075" == getFileCode(filePath);
        }


        /// <summary>
        ///  是否 excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsExcel(string filePath)
        {
            return "208207" == getFileCode(filePath) || "8075" == getFileCode(filePath);
        }

        /// <summary>
        /// 是否动图
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsImage(string filePath)
        {
            return "255216" == getFileCode(filePath) || "7173" == getFileCode(filePath) || "6677" == getFileCode(filePath) || "13780" == getFileCode(filePath);
        }
    }
}
