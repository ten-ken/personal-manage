using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;
using System.IO;
using System.Net;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Compression;
using System.Collections.ObjectModel;
using SharpCompress.Readers;
using personal_manage.Upgrade.dto;
using System.Threading;
using System.Windows;


namespace personal_manage.Upgrade
{
    public partial class AutoUpdateFrm : Form
    {
        private static string mainexe = ConfigurationManager.AppSettings["mainexe"].ToString();  //主程序

        //下载的压缩包路径
        private string downFile;

        //压缩包存放的根目录
        string pathToSaveDirectory = "";

        //更新的URL
        string checkUpdateURL = "";

        int process = 0;

        string versionNo = "";

        long fileSize = 1;

        long defaultSpeed = 15;//默认速度15M/s

        bool handZip = false;//是否在解压

        public AutoUpdateFrm()
        {
            InitializeComponent();
        }  
        
        public AutoUpdateFrm(string versionNo)
        {
            this.versionNo = versionNo;
            InitializeComponent();
        }

        private void AutoUpdateFrm_Load(object sender, EventArgs e)
        {
            //不出现关闭按钮
            this.ControlBox = false;

            //模拟进度
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Process_Tick;
            timer1.Start();

            //进度条默认值设置
            this.progressBarUpdate.Minimum = 0;
            this.progressBarUpdate.Maximum = 100;

            DownLoadFile();
        }


        /// <summary>
        ///  模拟进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_Tick(object sender, EventArgs e)
        {
            this.process += 5;
            if (this.process > 94)
            {
                this.process = 99;
            }
            else
            {
                this.process += 5;
            }
            this.labelProcess.Text = this.process + "%";
            this.progressBarUpdate.Value = this.process;
        }


        /// <summary>
        /// 下载更新文件
        /// </summary>
        public void DownLoadFile()
        {
            checkUpdateURL = ConfigurationManager.AppSettings["autoUpdateUrl"].ToString();
            checkUpdateURL = checkUpdateURL + "?token=autoupdate"
             + "&rnd=" + DateTime.Now.ToFileTimeUtc().ToString()
             + "&supplierId=autoupdate";
            pathToSaveDirectory = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToFileTimeUtc();

            if (!Directory.Exists(pathToSaveDirectory))
            {
                Directory.CreateDirectory(pathToSaveDirectory);
            }

            downFile = pathToSaveDirectory + "\\autoUpdateFile.zip";

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //文件下载完成事件
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    
                    //进度条变化
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    
                    //异步下载文件
                    webClient.DownloadFileAsync(new Uri(checkUpdateURL), downFile);
                    /* webClient.DownloadFile(CheckUpdateURL, "zs01.zip");*/
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 下载更新文件的监听1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            /*if (e.TotalBytesToReceive == -1)
            {
                return;
            }
            //this.progressBarUpdate.Minimum = 0;
            //this.progressBarUpdate.Maximum = (int)e.TotalBytesToReceive;
            this.progressBarUpdate.Value = (int)e.BytesReceived;
            Console.WriteLine("当前进度:{0}", e.ProgressPercentage);
            this.labelProcess.Text = e.ProgressPercentage + "%";*/
        }

        /// <summary>
        /// 下载更新文件的监听2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string message = "";
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                message = "下载完成";
                btnAllCheck_Click(null, null);//文件解压 覆盖操作
            }
        }

        /// <summary>
        /// 取消更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllCheckedCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        /// <summary>
        /// 确认更新 ==》更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            try
           {
                handZip = true;
                if (File.Exists(downFile))
                {
                    FileInfo fileInfo = new FileInfo(downFile);
                    fileSize = fileInfo.Length / 1024;
                }

                //文件进行创建和覆盖操作
                //所有的文件路径
                Dictionary<string, UpdateFileDto> allFilePath = new Dictionary<string, UpdateFileDto>();
                //系统路径
                string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = "";

                string parentFolder = null;


                using (Stream stream = File.OpenRead(downFile))
                {
                    var reader = ReaderFactory.Open(stream);
                    UpdateFileDto dto = null;
                    while (reader.MoveToNextEntry())
                    {
                        dto = new UpdateFileDto();
                        dto.IsDirectory = reader.Entry.IsDirectory;

                        Console.WriteLine(reader.Entry);
                        int loc = reader.Entry.ToString().LastIndexOf("/");
                        bool noParent = !reader.Entry.ToString().Contains("/");//没有父节点

                        string name = loc > 0 ? reader.Entry.ToString().Substring(0, loc) : reader.Entry.ToString();

                        string relativePath = "";

                        //文件
                        if (!reader.Entry.IsDirectory)
                        {
                            Console.WriteLine("文件名:" + reader.Entry);
                            parentFolder = noParent ? pathToSaveDirectory : Path.Combine(pathToSaveDirectory, name);
                            reader.WriteEntryToDirectory(parentFolder);

                            if (@reader.Entry.ToString().Contains("Compressed Size"))
                            {
                                relativePath = @reader.Entry.ToString().Substring(0, @reader.Entry.ToString().IndexOf(" Compressed Size"));
                            }
                            else
                            {
                                relativePath = @reader.Entry.ToString();
                            }

                            //文件路径
                            fullPath = Path.Combine(rootFolder, relativePath);

                            dto.FullPath = fullPath;
                            if (!allFilePath.ContainsKey(fullPath))
                            {
                                dto.IsExist = File.Exists(dto.FullPath);
                                allFilePath.Add(fullPath, dto);
                            }

                            //跳过这部分文件==》数据库 版本信息  日志 附件 必须的dll文件
                            if(relativePath.Contains("zbfz.sqlite")
                                || relativePath.Contains("version.info.txt")
                                || relativePath.Contains("wcfLog.txt")
                                || relativePath.Contains("fujian/")
                                || relativePath.Contains("System.Buffers.")
                                || relativePath.Contains("System.Memory.")
                                || relativePath.Contains("System.Runtime.CompilerServices.Unsafe.")
                                || relativePath.Contains("updated_version.exe")
                                || relativePath.Contains("SharpCompress.")
                                )
                            {
                                continue;
                            }

                            if (File.Exists(dto.FullPath))
                            {
                                File.Delete(dto.FullPath);
                            }


                            //FileStream fs = File.Open(Path.Combine(pathToSaveDirectory, relativePath), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                            File.Copy(Path.Combine(pathToSaveDirectory, relativePath), dto.FullPath, true);

                        }
                        else//文件夹
                        {
                            Console.WriteLine("文件夹名:" + reader.Entry);
                            parentFolder = Path.Combine(pathToSaveDirectory, name);
                            Directory.CreateDirectory(parentFolder);

                            //文件夹路径
                            fullPath = Path.Combine(rootFolder, name);
                            dto.FullPath = fullPath;
                            if (!allFilePath.ContainsKey(fullPath))
                            {
                                dto.IsExist = Directory.Exists(dto.FullPath);
                                allFilePath.Add(fullPath, dto);
                            }

                            if (!dto.IsExist)
                            {
                                Directory.CreateDirectory(dto.FullPath);
                            }
                        }
                    }
                    stream.Close();                 
                    this.labelProcess.Text = "100%";//进度条满了
                    this.progressBarUpdate.Value = 100;
                    this.buttonOver.Visible = true;
                    //停止计时器
                    timer1.Stop();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("解压的进程被占用," + ex.Message);

                MessageBox.Show("更新异常:"+ ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DelectDir(pathToSaveDirectory);//删除下载的文件及该文件夹
            }

        }

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                dir.Delete(true);          //删除子目录和文件
            }
            catch (Exception e)
            {
                Console.WriteLine("删除文件抛出异常:{0},文件位置:{1}",e.Message, srcPath);
            }
        }

        private void buttonOver_Click(object sender, EventArgs e)
        {
            //DelectDir(pathToSaveDirectory);//删除下载的文件
            this.Hide();
            this.Close();
        }

        //关闭窗口前
        private void AutoUpdateFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] appProcess = Process.GetProcessesByName("在线投标工具");
            //防止多次调用主程序
            if (appProcess.Length <=0)
            {
                //启动 调用更新程序
                string startExe = $@"{AppDomain.CurrentDomain.BaseDirectory}{mainexe}";
                if (File.Exists(startExe))
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = startExe;
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Minimized;
                    Process.Start(info);
                }
            }

            Process[] process = Process.GetProcessesByName("online_bid_autoUpdate");
            foreach (Process prc in process)
            {
               prc.Kill();
               return;
            }
            Application.Exit();//退出应用程序
        }


        /// <summary>
        /// 写入版本信息
        /// </summary>
        /// <param name="content"></param>
        public static void WriteContent(string content){
            string path = AppDomain.CurrentDomain.BaseDirectory + "version.info.txt"; ;
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        ///  获取txt文本内容
        /// </summary>
        /// <returns></returns>
        public static string GetContentByTxt()
        {
            StringBuilder sbfContent = new StringBuilder();
            StreamReader sr = null;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "version.info.txt"; ;
                if (File.Exists(path))
                {
                    string content;
                    sr = new StreamReader(path, Encoding.Default);
                    while ((content = sr.ReadLine()) != null)
                    {
                        sbfContent.Append(content);
                    }

                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

            }
            return sbfContent.ToString();
        }


    }
}
