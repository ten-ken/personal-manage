using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Upgrade.dto
{

     public class UpdateFileDto
    {
        //文件全路径
        public string FullPath { get; set; }

        //文件名
        public string FileName { get; set; }

        //是否文件夹
        public bool IsDirectory { get; set; }

        //文件或文件夹是否存在【保留字段】
        public bool IsExist { get; set; }

    }
}
