using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWfControls.dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PageInfo
    {

        //当期页 默认是1
        private int currentPage = 1;
        public int CurrentPage { get => currentPage; set => currentPage = value; }

        //总页数
        public int TotalPage { get; set; }

        //当前结果 数量
        public int CurrentCount { get; set; }

        //每页数据默认为10
        private int pageSize = 10;

        public int PageSize { get => pageSize; set => pageSize = value; }

    }
}


