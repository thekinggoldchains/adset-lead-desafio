namespace Common.Orm
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task RowbackTransaction();
        Task Commit();
    }
}
