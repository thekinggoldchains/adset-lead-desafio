using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Orm
{
    public class UnitOfWork<T> : IUnitOfWork
    {
        private readonly DbContext _ctx;
        private bool _disposed;
        private IDbContextTransaction _transaction;

        public UnitOfWork(T ctx) => _ctx = ctx as DbContext;

        public async Task BeginTransaction()
        {
            this._transaction = await this._ctx.Database.BeginTransactionAsync();
        }

        public async Task RowbackTransaction()
        {
            await this._ctx.Database.RollbackTransactionAsync();

            if (this._transaction is not null)
                await this._transaction.DisposeAsync();
        }

        public async Task Commit()
        {
            await this._ctx.SaveChangesAsync();

            if (this._transaction is not null)
                await this._transaction.CommitAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
