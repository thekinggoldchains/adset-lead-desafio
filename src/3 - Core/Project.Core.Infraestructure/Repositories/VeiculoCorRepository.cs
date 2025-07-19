using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class VeiculoCorRepository: Repository<VeiculoCor>
    {
        private readonly DbContextCore _db;

        public VeiculoCorRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(VeiculoCorFilter filters)
        {
            var query = _db.VeiculoCor
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<VeiculoCor> GetOne(VeiculoCorFilter filters)
        {
            return await _db.VeiculoCor
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new VeiculoCor
                {
                    Id = _.Id,
                    Nome = _.Nome,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<VeiculoCor>> GetData(VeiculoCorFilter filters)
        {
            var query = _db.VeiculoCor
                .WhereFilters(filters)
                .Select(_ => new VeiculoCor
                {
                    Id = _.Id,
                    Nome = _.Nome,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
