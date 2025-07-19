using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class VeiculoPortalPacoteRepository : Repository<VeiculoPortalPacote>
    {
        private readonly DbContextCore _db;

        public VeiculoPortalPacoteRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(VeiculoPortalPacoteFilter filters)
        {
            var query = _db.VeiculoPortalPacote
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Id
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<VeiculoPortalPacote> GetOne(VeiculoPortalPacoteFilter filters)
        {
            return await _db.VeiculoPortalPacote
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new VeiculoPortalPacote
                {
                    Id = _.Id,
                    PacoteId = _.PacoteId,
                    PortalId = _.PortalId,
                    VeiculoId = _.VeiculoId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<VeiculoPortalPacote>> GetData(VeiculoPortalPacoteFilter filters)
        {
            var query = _db.VeiculoPortalPacote
                .WhereFilters(filters)
                .Select(_ => new VeiculoPortalPacote
                {
                    Id = _.Id,
                    PacoteId = _.PacoteId,
                    PortalId = _.PortalId,
                    VeiculoId = _.VeiculoId,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
