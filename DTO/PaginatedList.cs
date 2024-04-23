using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int pageIndex, int totalPage)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPage = totalPage;
        }
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext => PageIndex < TotalPage;
        public bool HasPrevious => PageIndex > 1;

        public static PaginatedList<T> Create(IQueryable<T> query, int page, int size)
        {
            int total = (int)Math.Ceiling(query.Count() / (double)size);
            return new PaginatedList<T>(query.Skip((page - 1) * size).Take(size).ToList(), page, total);
        }
    }
}
