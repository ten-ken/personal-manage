using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace personal_manage.Common.util
{
    public class FileUtils
    {
        /// <summary>
        /// 上传文件到服务器
        /// </summary>
        /// <param name="fileNamePath"> 待上传文件名称，全路径格式 </param>
        /// <param name="uriString"> 服务器文件夹路径 </param>
        /// <param name="isAutoRename"> 是否自动改名 </param>
        public static void UploadFile(string fileNamePath, string uriString, bool isAutoRename)
        {
           UploadFileMethod(fileNamePath, uriString, isAutoRename);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileNamePath"> 待上传文件名称，全路径格式 </param>
        /// <param name="uriString"> 服务器文件夹路径 </param>
        /// <param name="isAutoRename"> 是否自动改名 </param>
        private static void UploadFileMethod(string fileNamePath, string uriString, bool isAutoRename)
        {
            // 获取文件名称
            string fileName = Path.GetFileName(fileNamePath);

            string newFileName = fileName;
            if (isAutoRename)
            {
                // 获取文件后缀名
                //string extName = Path.GetExtension(fileNamePath);
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
            }
            if (!uriString.EndsWith("/"))
            {
                uriString = uriString + "/";
            }

            // 文件保存路径（最底层文件夹）
            string saveFilePath = uriString.Substring(0, uriString.LastIndexOf("/"));
            // 判断文件存不存在,不能存在，则创建
            DirectoryInfo directoryInfo = new DirectoryInfo(saveFilePath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            // 服务器文件路劲
            uriString = uriString + newFileName;
            // 创建webClient实例
            WebClient webClient = new WebClient();
            // 设置网络凭证
            webClient.Credentials = CredentialCache.DefaultCredentials;
            // 要上传的文件
            FileStream fileStream = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader reader = new BinaryReader(fileStream);
            byte[] postArray = reader.ReadBytes((int)fileStream.Length);
            Stream postStream = webClient.OpenWrite(uriString, "PUT");

            try
            {
                //webClient.UploadFile(uriString, "PUT", fileNamePath);

                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                    fileStream.Dispose();
                    Console.WriteLine("----文件上传成功----");
                }
                else
                {
                    postStream.Close();
                    fileStream.Dispose();
                    Console.WriteLine("----失败了----");
                }

            }
            catch (Exception e)
            {
                postStream.Close();
                fileStream.Dispose();
                Console.WriteLine("----文件上传失败-----");
                throw e;
            }
            finally
            {
                postStream.Close();
                fileStream.Dispose();
            }

        }

        /// <summary>
        /// http下载文件(自定义文件保存路径)
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
     /*   public static bool HttpDownload(string url, string path)
        {
            string tempPath = Path.GetDirectoryName(path) + @"\temp";
            Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + Path.GetFileName(path) + ".temp"; //临时文件
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                WebRequest webRequest = WebRequest.Create(url);
                //HttpWebRequest request = webRequest as HttpWebRequest;
                //发送请求并获取相应回应数据
                WebResponse webResponse = webRequest.GetResponse();
                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = webResponse.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                File.Move(tempFile, path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }*/

        /// <summary>
        /// webRequest方式文件下载（自定义保存路劲）
        /// </summary>
        /// <param name="filePath">服务器中文件地址，全路径格式</param>
        /// <param name="fileName">文件另存为地址，包含文件名</param>
        /// <param name="preMessage">文件下载提示前缀</param>
        public static void FileDownLoad(string filePath, string fileName,String preMessage)
        {

            if (preMessage == null || preMessage.Equals("")) {
                preMessage = "文件下载";
               }
            try
            {
                string url = filePath;

                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                Stream stream = res.GetResponseStream();
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                int l;
                byte[] buffer = new byte[1024];
                do
                {
                    l = stream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        fs.Write(buffer, 0, l);

                } while (l > 0);

                fs.Flush();
                fs.Close();
                stream.Flush();
                stream.Close();
             //  Console.WriteLine("----文件下载成功----");
                MessageBox.Show(preMessage+"成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(preMessage + "异常：" +e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw e;
            }
        }
    }
}
