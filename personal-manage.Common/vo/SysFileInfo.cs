using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;


//系统存放的文件信息
namespace personal_manage.Common.vo
{
    [TableName("SYS_FILE_INFO")]
    public class SysFileInfo
    {

        public string Id { get; set; }

        /// <summary>
        /// 一般关联表
        /// </summary>
        public string RelatedPage { get; set; }

        /// <summary>
        ///  具体业务相关的操作key
        /// </summary>
        public string RelatedKey { get; set; }

        /// <summary>
        ///  文件相对位置
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        ///  文件格式
        /// </summary>
        public string FileFormat { get; set; }

        /// <summary>
        ///  文件原始名称
        /// </summary>
        public string FileDispName { get; set; }

        /// <summary>
        ///  创建人 
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        ///  上传时间
        /// </summary>
        public string UploadTime { get; set; }

        /// <summary>
        ///  文件大小
        /// </summary>
        public string Size { get; set; }
        public string LocationPath { get; set; }
        /// <summary>
        /// 关联id
        /// </summary>
        public string RelatedId { get; set; }
    }
}
