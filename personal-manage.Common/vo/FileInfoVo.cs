using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.vo
{
    public class FileInfoVo
    {
        /// <summary>
        /// 文件展示名
        /// </summary>
        public string FileDispName { get; set; }

        /// <summary>
        /// 文件存放路径 =》相对路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件格式 入jpg txt等
        /// </summary>
        public string FileFormat { get; set; }

        /// <summary>
        /// 文件具体位置
        /// </summary>
        public string LocationPath { get; set; }

        /// <summary>
        /// 附件id
        /// </summary>
        public string EnclosureId { get; set; }
        public string AttachType { get; set; }
    }
}
