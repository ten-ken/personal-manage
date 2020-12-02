using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_manage.Common.vo
{
    public class PageInfo<T>
    {

        //查询的参数
        public T ParamsSearch { get; set; }

        //查询的结果
        public List<T> Records { get; set; }

        //当期页 默认是1
        private int currentPage = 1;
        public int CurrentPage { get => currentPage; set => currentPage = value; }

        //总页数
        public int TotalPage { get; set; }

        //当前结果 数量
        public int CurrentCount { get; set; }

        //每页数据默认为10
        private int pageSize =10;

        public int PageSize { get => pageSize; set => pageSize = value; }

    }
}
