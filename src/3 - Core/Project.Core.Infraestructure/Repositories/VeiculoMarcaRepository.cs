using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class VeiculoMarcaRepository : Repository<VeiculoMarca>
    {
        private readonly DbContextCore _db;

        public VeiculoMarcaRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(VeiculoMarcaFilter filters)
        {
            var query = _db.VeiculoMarca
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<VeiculoMarca> GetOne(VeiculoMarcaFilter filters)
        {
            return await _db.VeiculoMarca
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new VeiculoMarca
                {
                    Id = _.Id,
                    Nome = _.Nome,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<VeiculoMarca>> GetData(VeiculoMarcaFilter filters)
        {
            var query = _db.VeiculoMarca
                .WhereFilters(filters)
                .Select(_ => new VeiculoMarca
                {
                    Id = _.Id,
                    Nome = _.Nome,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
