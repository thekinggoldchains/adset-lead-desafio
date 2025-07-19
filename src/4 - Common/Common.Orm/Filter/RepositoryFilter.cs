
namespace Common.Orm.Filter
{
    public class RepositoryFilter : IRepositoryFilter
    {
        public RepositoryFilter()
        {
            PageIndex = 0;
            PageSize = 50;
            IsPagination = true;
        }

        public bool IsPagination { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string[] OrderFields { get; set; }
        public string OrderByType { get; set; }
    }
}