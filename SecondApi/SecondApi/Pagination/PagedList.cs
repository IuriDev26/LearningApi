using Microsoft.EntityFrameworkCore;

namespace SecondApi.Pagination {
    public class PagedList<T> : List<T> {

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPrevious => CurrentPage > 1;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = PageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;

            AddRange(items);
        }


        public async Task<IEnumerable<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize) {

            var count = source.Count();
            var items = await source.Skip( (pageNumber - 1) *  pageSize).Take(pageSize).ToListAsync();


            return new PagedList<T>(items,count,pageNumber, pageSize);

        }

    }
}
