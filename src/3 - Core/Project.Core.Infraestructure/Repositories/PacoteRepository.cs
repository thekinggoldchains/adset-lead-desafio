using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class PacoteRepository : Repository<Pacote>
    {
        private readonly DbContextCore _db;

        public PacoteRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(PacoteFilter filters)
        {
            var query = _db.Pacote
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<Pacote> GetOne(PacoteFilter filters)
        {
            return await _db.Pacote
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new Pacote
                {
                    Id = _.Id,
                    Nome = _.Nome,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<Pacote>> GetData(PacoteFilter filters)
        {
            var query = _db.Pacote
                .WhereFilters(filters)
                .Select(_ => new Pacote
                {
                    Id = _.Id,
                    Nome = _.Nome,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
