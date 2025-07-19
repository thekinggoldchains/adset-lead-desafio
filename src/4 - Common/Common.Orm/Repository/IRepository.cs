using Common.Orm.Filter;
using Microsoft.EntityFrameworkCore;

namespace Common.Orm.Repository
{
    public interface IRepository<TClass>
        where TClass : class
    {
        TClass Add(TClass entity);
        void Add(IEnumerable<TClass> entities);
        void Remove(TClass entity);
        void Remove(IEnumerable<TClass> entitys);
        TClass Update(TClass entity);
        void Update(IEnumerable<TClass> entities);
        Task<int> CommitAsync();

    }
}
