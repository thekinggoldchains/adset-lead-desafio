namespace Common.Orm.Filter
{
    public interface IRepositoryFilter
    {
        bool IsPagination { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }

        string[] OrderFields { get; set; }
        string OrderByType { get; set; }

    }
}