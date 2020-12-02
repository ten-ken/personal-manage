/*using System;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using personal_manage.Common.vo;

namespace personal_manage.Common.util
{
    //本地文件上传的通用方法
    public class LocalFileUpLoad
    {
        private static UpLoadLoading upLoadLoading;
        /// <summary>
        /// 本地文件上传的通用方法
        /// </summary>
        /// <param name="filter">限制打开的文件类型  默认是打开excel</param>
        /// <returns></returns>
        public static FileInfoVo UpLoadFile(string filter, string attachType)
        {

            FileInfoVo fileInfoVo = null;

            filter = (filter == null || filter == "") ? "Excel文件|*.xls;*.xlsx" : filter;
            try
            {

                OpenFileDialog fileImportDialog = new OpenFileDialog();
                //文件类型
                fileImportDialog.Filter = filter;
                if (fileImportDialog.ShowDialog() == DialogResult.OK)
                {
                    //相对的跟路径
                    string rootPath = DateTime.Now.ToString("yyyyMMdd") + "\\" + attachType + "\\";
                    //存放的路径
                    string saveTempPath = @System.AppDomain.CurrentDomain.BaseDirectory + "fujian\\" + rootPath;//附件存放的路径
                    string fileName = fileImportDialog.FileName;

                    //上传等待
                    upLoadLoading = new UpLoadLoading();

                    upLoadLoading.Width = 600;
                    upLoadLoading.Height = 200;
                    upLoadLoading.StartPosition = FormStartPosition.CenterParent;
                    upLoadLoading.WindowState = FormWindowState.Normal;
                    Thread uploadFrmLoadingThread = new Thread(new ThreadStart(threadUploadLoding));
                    uploadFrmLoadingThread.Start();
                    upLoadLoading.Show();
                    upLoadLoading.ShowDialog()

                    R r = RemoteFileUpload.UploadSupplierBasicAttachRequest(fileName, attachType);
                    //上传失败
                    if (!r.Successful)
                    {
                        closeLoading();
                        MessageBox.Show("上传失败" + r.ResultHint,
                                               "提示",
                                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return fileInfoVo;
                    }


                    if (!Directory.Exists(saveTempPath))
                    {
                        Directory.CreateDirectory(saveTempPath);
                    }

                    //接收返回的参数
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    CmCEnclosureFile cEnclosureFile = json.Deserialize<CmCEnclosureFile>(r.ResultValue.ToString());
                    //CmCEnclosureFile cEnclosureFile = JsonConvert.DeserializeObject<CmCEnclosureFile>(r.ResultValue.ToString());

                    string oldName = fileName.Substring(fileName.LastIndexOf("\\") + 1);//文件原名称

                    string suffixType = fileName.Substring(fileName.LastIndexOf(".") + 1);//文件类型

                    string saveName = System.Guid.NewGuid().ToString("N").Substring(0, 20) + "." + suffixType;

                    string dataPath = saveTempPath + saveName;//文件地址
                    File.Copy(fileImportDialog.FileNames[0], dataPath, true);

                    fileInfoVo = new FileInfoVo();

                    fileInfoVo.FileDispName = cEnclosureFile.FileDispName;

                    //fileInfoVo.FileDispName = oldName;

                    fileInfoVo.FilePath = rootPath + saveName;

                    //文件格式
                    fileInfoVo.FileFormat = cEnclosureFile.FileFormat;
                    //fileInfoVo.FileFormat = suffixType;
                    fileInfoVo.LocationPath = dataPath;

                    fileInfoVo.EnclosureId = cEnclosureFile.EnclosureId;
                    fileInfoVo.AttachType = attachType;//附件类型

                    closeLoading();
                }
            }
            catch (Exception ex)
            {
                closeLoading();
                MessageBox.Show("上传失败，系统异常",
                         "提示",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }

            return fileInfoVo;
        }
        /// <summary>
        /// 招标文件上传
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="attachType"></param>
        /// <returns></returns>
        public static FileInfoVo UpLoadBidFile(string filter, string attachType)
        {

            FileInfoVo fileInfoVo = null;

            filter = (filter == null || filter == "") ? "Excel文件|*.xls;*.xlsx" : filter;
            try
            {

                OpenFileDialog fileImportDialog = new OpenFileDialog();
                //文件类型
                fileImportDialog.Filter = filter;

                if (fileImportDialog.ShowDialog() == DialogResult.OK)
                {
                    //相对的跟路径
                    string rootPath = DateTime.Now.ToString("yyyyMMdd") + "\\" + attachType + "\\";
                    //存放的路径
                    string saveTempPath = @System.AppDomain.CurrentDomain.BaseDirectory + "fujian\\" + rootPath;//附件存放的路径
                    string fileName = fileImportDialog.FileName;


                    R verify = UTCReadUtil.VerifyAdobeSignature(fileName);

                    //验签失败
                    if (!verify.Successful)
                    {
                        closeLoading();
                        MessageBox.Show(verify.ResultHint,
                                              "提示",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                        return fileInfoVo;
                    }

                    dto.UKResult uKResult = UTCReadUtil.GetAdobeSignature(fileName);

                    if (!"0".Equals(uKResult.Code))
                    {
                        closeLoading();
                        MessageBox.Show("电子钥匙证书获取异常:" + uKResult.Message);
                        return fileInfoVo;
                    }

                    R r = RemoteFileUpload.UploadSupplierBidFileRequest(fileName, uKResult.Result, attachType);

                    //测试接口
                    //R r = RemoteFileUpload.UploadSupplierBidFileRequest(fileName, "KENhdbastd12euigqwjdhnbsa", attachType);

                    //上传失败
                    if (!r.Successful)
                    {
                        closeLoading();
                        MessageBox.Show("上传失败" + r.ResultHint,
                                               "提示",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Warning);
                        return fileInfoVo;
                    }


                    if (!Directory.Exists(saveTempPath))
                    {
                        Directory.CreateDirectory(saveTempPath);
                    }

                    //接收返回的参数
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    CmCEnclosureFile cEnclosureFile = json.Deserialize<CmCEnclosureFile>(r.ResultValue.ToString());
                    //CmCEnclosureFile cEnclosureFile = JsonConvert.DeserializeObject<CmCEnclosureFile>(r.ResultValue.ToString());

                    string oldName = fileName.Substring(fileName.LastIndexOf("\\") + 1);//文件原名称

                    string suffixType = fileName.Substring(fileName.LastIndexOf(".") + 1);//文件类型

                    string saveName = System.Guid.NewGuid().ToString("N").Substring(0, 20) + "." + suffixType;

                    string dataPath = saveTempPath + saveName;//文件地址
                    File.Copy(fileImportDialog.FileNames[0], dataPath, true);

                    fileInfoVo = new FileInfoVo();

                    fileInfoVo.FileDispName = cEnclosureFile.FileDispName;

                    //fileInfoVo.FileDispName = oldName;

                    fileInfoVo.FilePath = rootPath + saveName;

                    //文件格式
                    fileInfoVo.FileFormat = cEnclosureFile.FileFormat;
                    //fileInfoVo.FileFormat = suffixType;
                    fileInfoVo.LocationPath = dataPath;

                    fileInfoVo.EnclosureId = cEnclosureFile.EnclosureId;
                }
            }
            catch (Exception ex)
            {
                closeLoading();
                MessageBox.Show("上传失败，系统异常",
                         "提示",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Warning);
                Console.WriteLine(ex.Message);
            }

            return fileInfoVo;
        }


        // 上传的通用方法==》行事件 按钮上传
        public static R CommonUpLoad(ref DataGridView listDataGriddView, string currentRelatedPage, string attachType, string filter, string selectDataId, string relatedKey, int columnIndex, string tableName)
        {
            R r = new R();
            try
            {
                //当前行 
                if (listDataGriddView.Columns[columnIndex] is DataGridViewButtonColumn)
                {

                    DataGridViewButtonCell vCell = (DataGridViewButtonCell)listDataGriddView.CurrentCell;
                    if (vCell.Value.ToString() == "上传")
                    {
                        //"图片|*.jpg;*.png"
                        FileInfoVo fileInfoVo = UpLoadFile(filter, attachType);
                        if (fileInfoVo != null)
                        {
                            SysFileInfo sysFileInfo = new SysFileInfo();
                            //复制属性
                            ObjectUtil.CopyPop(fileInfoVo, ref sysFileInfo);
                            sysFileInfo.Id = fileInfoVo.EnclosureId;//附件id
                            sysFileInfo.RelatedId = selectDataId;
                            sysFileInfo.RelatedPage = currentRelatedPage;
                            sysFileInfo.RelatedKey = relatedKey;

                            if (!"".Equals(tableName) && tableName != null)
                            {
                                UpdateDataFieldVo updateDataFieldVo = new UpdateDataFieldVo();
                                updateDataFieldVo.Field = "ATTACH_ID";
                                updateDataFieldVo.FieldValue = fileInfoVo.EnclosureId;
                                updateDataFieldVo.TableName = tableName;
                                //"OS_ZB_SUPPLIER_FINANCE_INFO";
                                updateDataFieldVo.KeyId = selectDataId;
                                R result2 = WebRequestUtil.PostBasicEntityDataApi(ContantUtils.PUBLIC_UPDATE_URL, updateDataFieldVo);
                                //操作失败
                                if (!result2.Successful)
                                {
                                    r.Successful = false;
                                    r.ResultHint = result2.ResultHint;
                                    MessageBox.Show(r.ResultHint, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return r;
                                }
                            }


                            r.Successful = true;
                            r.ResultValue = sysFileInfo;
                        }



                    }

                    //下载
                    else if (vCell.Value.ToString() == "下载")
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                closeLoading();
                r.Successful = false;
                r.ResultHint = ex.Message;
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        private static void threadUploadLoding()
        {

            upLoadLoading.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void closeLoading()
        {
            //上传等待取消
            if (upLoadLoading != null)
            {
                upLoadLoading.Close();
                upLoadLoading.Dispose();
            }

        }

    }
}
*/