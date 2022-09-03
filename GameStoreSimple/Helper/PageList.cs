using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public int CurrentPageNum { get; set; }
        public int PageSize { get; set; }

        public PagedList()
        {

        }

        public PagedList(IQueryable<T> source, int requestPageNum, int pageSize)
        {
            TotalCount = source.Count();
            TotalPageCount = GetTotalPageCount(pageSize, TotalCount);
            CurrentPageNum = requestPageNum < 1 ? 0 : requestPageNum - 1;
            PageSize = pageSize;
            AddRange(source.Skip(CurrentPageNum * PageSize).Take(PageSize).ToList());
            CurrentPageNum = requestPageNum;
        }
        private int GetTotalPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
            {
                return 0;
            }
            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }

}
