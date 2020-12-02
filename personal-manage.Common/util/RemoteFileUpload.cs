using System;
using System.Text;
using System.Configuration;
using System.Net;
using personal_manage.Common.dto;
using System.IO;
using Newtonsoft.Json;

namespace personal_manage.Common.util
{
    public class RemoteFileUpload
    {
        /// <summary>
        /// 上传供应商基础信息 相关附件的方法
        /// </summary>
        /// <param name="filePath">本地待上传的文件路径</param>
        /// <param name="supplierId">供应商ID</param>
        /// <param name="attachType">附件类型</param>
        public static R UploadSupplierBasicAttachRequest(string filePath, String attachType)
        {
            //
            String url = ConfigurationManager.AppSettings["uploadSupplierBaseInfoAttach"].ToString();//
                                                                                                     //  String token= ConfigurationManager.AppSettings["token"].ToString();//
                                                                                                     // 时间戳，用做boundary
            String timeStamp = DateTime.Now.Ticks.ToString("x");

            url = url + "?token=" + PublicVo.Token
                + "&rnd=" + DateTime.Now.ToFileTimeUtc().ToString()
                + "&supplierId=" + PublicVo.SupplyId
                + "&attachType=" + attachType;

            //根据uri创建HttpWebRequest对象
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpReq.Method = "POST";
            httpReq.AllowWriteStreamBuffering = false; //对发送的数据不使用缓存
            httpReq.Timeout = 300000;  //设置获得响应的超时时间（300秒）
            httpReq.ContentType = "multipart/form-data; boundary=" + timeStamp;

            //文件
            FileStream uploadFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader uploadFileBinaryReader = new BinaryReader(uploadFileStream);

            //头信息
            string boundary = "--" + timeStamp;
            string dataFormat = boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\nContent-Type:application/octet-stream\r\n\r\n";
            string header = string.Format(dataFormat, "file", Path.GetFileName(filePath));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(header);

            //结束边界
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + timeStamp + "--\r\n");

            long length = uploadFileStream.Length + postHeaderBytes.Length + boundaryBytes.Length;

            httpReq.ContentLength = length;//请求内容长度

            R result;
            try
            {
                //每次上传4k
                int bufferLength = 4096;
                byte[] bufferStore = new byte[bufferLength];

                //已上传的字节数
                int offset = 0;
                int size = uploadFileBinaryReader.Read(bufferStore, 0, bufferLength);

                //开始上传时间
                DateTime startTime = DateTime.Now;

                Stream requestPostStream = httpReq.GetRequestStream();

                //发送请求头部消息
                requestPostStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                while (size > 0)
                {
                    requestPostStream.Write(bufferStore, 0, size);
                    offset += size;

                    foreach (byte s in bufferStore)
                    {
                        Console.WriteLine(s);
                    }

                    //       MessageBox.Show(System.Text.Encoding.GetEncoding("UTF-8").GetString(bufferStore));
                    /*TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;*/
                    /*  lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
                      if (second > 0.001)
                      {/ second).ToString("0.00") + "KB/秒";
                      }
                          lblSpeed.Text = "平均速度：" + (offset / 1024 
                      else
                      {
                          lblSpeed.Text = " 正在连接…";
                      }
                      lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                      lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";*/

                    size = uploadFileBinaryReader.Read(bufferStore, 0, bufferLength);
                }

                //添加尾部边界
                requestPostStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                // requestPostStream.Flush();
                requestPostStream.Close();

                //获取服务器端的响应
                using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
                {


                    //读取服务器端返回的消息
                    /*  StreamReader sr = new StreamReader(s);
                      String sReturnString = sr.ReadLine();
                      s.Close();
                      sr.Close();
                      if (sReturnString == "Success")
                      {
                          returnValue = 1;
                      }
                      else if (sReturnString == "Error")
                      {
                          returnValue = 0;
                      }*/

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string returnValue = readStream.ReadToEnd();

                    //解析返回的字符串  start
                    result = JsonConvert.DeserializeObject<R>(returnValue);
                    //解析返回的字符串   end


               //   MessageBox.Show(returnValue);
                    response.Close();
                    readStream.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Message = "远程服务器返回错误: (413) Request Entity Too Large。"  代理配置问题
                //401未授权  token
                //500
                // Debug.WriteLine("文件传输异常： " + ex.Message);
              //  MessageBox.Show("文件传输异常： " + ex.Message);
                return new R(999,false, "文件传输异常： " + ex.Message); 
            }
            finally
            {
                uploadFileStream.Close();
                uploadFileBinaryReader.Close();
                
            }
        }

        /// <summary>
        /// 上传供应商标书附件的方法
        /// </summary>
        /// <param name="filePath">本地待上传的文件路径</param>
        /// <param name="supplierId">供应商ID</param>
        /// <param name="attachType">附件类型</param>
        public static R UploadSupplierBidFileRequest(string filePath, string signKey, string attachType)
        {
            String url = ConfigurationManager.AppSettings["uploadSupplierBidFile"].ToString();//
                                                                                                     //  String token= ConfigurationManager.AppSettings["token"].ToString();//
                                                                                                     // 时间戳，用做boundary
            String timeStamp = DateTime.Now.Ticks.ToString("x");

            url = url + "?token=" + PublicVo.Token
                + "&rnd=" + DateTime.Now.ToFileTimeUtc().ToString()
                + "&supplierId=" + PublicVo.SupplyId
                + "&attachType=" + attachType;

            if(signKey!=null && signKey != "")
            {
                url+= "&signKey=" + signKey;
            }


            //根据uri创建HttpWebRequest对象
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpReq.Method = "POST";
            httpReq.AllowWriteStreamBuffering = false; //对发送的数据不使用缓存
            httpReq.Timeout = 300000;  //设置获得响应的超时时间（300秒）
            httpReq.ContentType = "multipart/form-data; boundary=" + timeStamp;

            //文件
            FileStream uploadFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader uploadFileBinaryReader = new BinaryReader(uploadFileStream);

            //头信息
            string boundary = "--" + timeStamp;
            string dataFormat = boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\nContent-Type:application/octet-stream\r\n\r\n";
            string header = string.Format(dataFormat, "file", Path.GetFileName(filePath));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(header);

            //结束边界
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + timeStamp + "--\r\n");

            long length = uploadFileStream.Length + postHeaderBytes.Length + boundaryBytes.Length;

            httpReq.ContentLength = length;//请求内容长度

            R result;
            try
            {
                //每次上传4k
                int bufferLength = 4096;
                byte[] bufferStore = new byte[bufferLength];

                //已上传的字节数
                int offset = 0;
                int size = uploadFileBinaryReader.Read(bufferStore, 0, bufferLength);

                //开始上传时间
                DateTime startTime = DateTime.Now;

                Stream requestPostStream = httpReq.GetRequestStream();

                //发送请求头部消息
                requestPostStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                while (size > 0)
                {
                    requestPostStream.Write(bufferStore, 0, size);
                    offset += size;

                    foreach (byte s in bufferStore)
                    {
                        Console.WriteLine(s);
                    }

                    //       MessageBox.Show(System.Text.Encoding.GetEncoding("UTF-8").GetString(bufferStore));
                    /*TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;*/
                    /*  lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
                      if (second > 0.001)
                      {/ second).ToString("0.00") + "KB/秒";
                      }
                          lblSpeed.Text = "平均速度：" + (offset / 1024 
                      else
                      {
                          lblSpeed.Text = " 正在连接…";
                      }
                      lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                      lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";*/

                    size = uploadFileBinaryReader.Read(bufferStore, 0, bufferLength);
                }

                //添加尾部边界
                requestPostStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                // requestPostStream.Flush();
                requestPostStream.Close();

                //获取服务器端的响应
                using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
                {


                    //读取服务器端返回的消息
                    /*  StreamReader sr = new StreamReader(s);
                      String sReturnString = sr.ReadLine();
                      s.Close();
                      sr.Close();
                      if (sReturnString == "Success")
                      {
                          returnValue = 1;
                      }
                      else if (sReturnString == "Error")
                      {
                          returnValue = 0;
                      }*/

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string returnValue = readStream.ReadToEnd();

                    //解析返回的字符串  start
                    result = JsonConvert.DeserializeObject<R>(returnValue);
                    //解析返回的字符串   end


                    //   MessageBox.Show(returnValue);
                    response.Close();
                    readStream.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Message = "远程服务器返回错误: (413) Request Entity Too Large。"  代理配置问题
                //401未授权  token
                //500
                // Debug.WriteLine("文件传输异常： " + ex.Message);
                //  MessageBox.Show("文件传输异常： " + ex.Message);
                return new R(999, false, "文件传输异常： " + ex.Message);
            }
            finally
            {
                uploadFileStream.Close();
                uploadFileBinaryReader.Close();

            }
        }

        /// <summary>
        ///  上传附件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="attachType"></param>
        /// <returns></returns>
        public static R UploadSupplierBidFileRequest(string filePath, String attachType)
        {
            return UploadSupplierBidFileRequest(filePath, null, attachType);
        }
    }
}
