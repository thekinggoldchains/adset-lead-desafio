using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class PortalRepository : Repository<Portal>
    {
        private readonly DbContextCore _db;

        public PortalRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(PortalFilter filters)
        {
            var query = _db.Portal
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<Portal> GetOne(PortalFilter filters)
        {
            return await _db.Portal
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new Portal
                {
                    Id = _.Id,
                    Nome = _.Nome,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<Portal>> GetData(PortalFilter filters)
        {
            var query = _db.Portal
                .WhereFilters(filters)
                .Select(_ => new Portal
                {
                    Id = _.Id,
                    Nome = _.Nome,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
