using Common.Orm.Filter;
using Microsoft.EntityFrameworkCore;

namespace Common.Orm.Repository
{
    public abstract class Repository<TClass> : IRepository<TClass>, IDisposable
        where TClass : class
    {
        protected readonly DbContext _ctx;
        protected DbSet<TClass> _dbSet;

        protected Repository(DbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TClass>();
        }

        protected DbContext DbContext()
        {
            return _ctx;
        }

        public TClass Add(TClass entity)
        {
            var result = _dbSet.Add(entity);
            return result.Entity;
        }

        public void Add(IEnumerable<TClass> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(TClass entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(IEnumerable<TClass> entitys)
        {
            _dbSet.RemoveRange(entitys);
        }

        public TClass Update(TClass entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity;
        }

        public void Update(IEnumerable<TClass> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task<int> CommitAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }
    }
}
