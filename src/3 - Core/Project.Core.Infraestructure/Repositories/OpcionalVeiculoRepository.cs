using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class OpcionalVeiculoRepository : Repository<OpcionalVeiculo>
    {
        private readonly DbContextCore _db;

        public OpcionalVeiculoRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(OpcionalVeiculoFilter filters)
        {
            var query = _db.OpcionalVeiculo
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Id
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<OpcionalVeiculo> GetOne(OpcionalVeiculoFilter filters)
        {
            return await _db.OpcionalVeiculo
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new OpcionalVeiculo
                {
                    Id = _.Id,
                    OpcionalId = _.OpcionalId,
                    VeiculoId = _.VeiculoId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<OpcionalVeiculo>> GetData(OpcionalVeiculoFilter filters)
        {
            var query = _db.OpcionalVeiculo
                .WhereFilters(filters)
                .Select(_ => new OpcionalVeiculo
                {
                    Id = _.Id,
                    OpcionalId = _.OpcionalId,
                    VeiculoId = _.VeiculoId,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
