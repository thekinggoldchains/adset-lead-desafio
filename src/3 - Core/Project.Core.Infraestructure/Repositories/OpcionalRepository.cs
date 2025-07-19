using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class OpcionalRepository : Repository<Opcional>
    {
        private readonly DbContextCore _db;

        public OpcionalRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(OpcionalFilter filters)
        {
            var query = _db.Opcional
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<Opcional> GetOne(OpcionalFilter filters)
        {
            return await _db.Opcional
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new Opcional
                {
                    Id = _.Id,
                    Nome = _.Nome,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<Opcional>> GetData(OpcionalFilter filters)
        {
            var query = _db.Opcional
                .WhereFilters(filters)
                .Select(_ => new Opcional
                {
                    Id = _.Id,
                    Nome = _.Nome,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
