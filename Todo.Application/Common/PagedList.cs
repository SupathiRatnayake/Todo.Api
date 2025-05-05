using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Common
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pagesize)
        {
            Items = items;
            TotalCount = count;
            PageNumber = pageNumber;
            PageSize = pagesize;
        }
    }
}
