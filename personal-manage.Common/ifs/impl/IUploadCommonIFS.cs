using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.dto;
using personal_manage.Common.vo;

namespace personal_manage.Common.serivce.impl
{
    /// <summary>
    /// 上传的公共接口
    /// </summary>
    public interface IUploadCommonIFS{


         R CallBackUpload(List<FileInfoVo>  fileInfoList);
    }
}
