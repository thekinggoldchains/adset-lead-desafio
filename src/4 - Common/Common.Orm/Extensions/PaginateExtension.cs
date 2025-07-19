using Common.Orm.Filter;
using Microsoft.EntityFrameworkCore;

namespace Common.Orm.Extensions
{
    public static class Paginate
    {
        public static async Task<PaginateResult<T2>> PagingWithDetails<T2>(this IQueryable<T2> query, IRepositoryFilter filter)
        {
            return await query.PagingWithDetails(filter.PageIndex, filter.PageSize, filter.IsPagination);
        }

        public static IQueryable<T2> Paging<T2>(this IQueryable<T2> query, IRepositoryFilter filter)
        {
            return query.Paging(filter.PageIndex, filter.PageSize, filter.IsPagination);
        }

        public static async Task<PaginateResult<T2>> PagingWithDetails<T2>(this IQueryable<T2> query, int pageIndex, int pageSize, bool isPagination = true)
        {
            var totalCount = await query.CountAsync();
            var paginateResult = await query.Paging(pageIndex, pageSize, isPagination).ToListAsync();

            return new PaginateResult<T2>
            {
                Data = paginateResult,
                Total = totalCount,
                PageSize = pageSize,
                PageIndex = pageIndex,
                PageSkipped = (pageSize > 0 ? pageIndex - 1 : 0) * pageSize,
            };
        }

        public static IQueryable<T2> Paging<T2>(this IQueryable<T2> source, int pageIndex, int pageSize, bool isPagination = true)
        {
            if (isPagination)
            {
                pageIndex = pageIndex <= 0 ? 1 : pageIndex;
                var pageSkipped = (pageSize > 0 ? pageIndex - 1 : 0) * pageSize;
                return source.Skip(pageSkipped).Take(pageSize);
            }

            return source;
        }

    }

    public class PaginateResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageSkipped { get; set; }
    }
}
