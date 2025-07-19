using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class VeiculoImagemRepository: Repository<VeiculoImagem>
    {
        private readonly DbContextCore _db;

        public VeiculoImagemRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(VeiculoImagemFilter filters)
        {
            var query = _db.VeiculoImagem
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Url
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<VeiculoImagem> GetOne(VeiculoImagemFilter filters)
        {
            return await _db.VeiculoImagem
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new VeiculoImagem
                {
                    Id = _.Id,
                    Ordem = _.Ordem,
                    Url = _.Url,
                    VeiculoId = _.VeiculoId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<VeiculoImagem>> GetData(VeiculoImagemFilter filters)
        {
            var query = _db.VeiculoImagem
                .WhereFilters(filters)
                .Select(_ => new VeiculoImagem
                {
                    Id = _.Id,
                    Ordem = _.Ordem,
                    Url = _.Url,
                    VeiculoId = _.VeiculoId,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
