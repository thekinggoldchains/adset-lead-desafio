using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class VeiculoRepository: Repository<Veiculo>
    {
        private readonly DbContextCore _db;

        public VeiculoRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(VeiculoFilter filters)
        {
            var query = _db.Veiculo
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Modelo
                })
                .OrderBy(_ => _.Nome);

            return await query.PagingWithDetails(filters);
        }

        public async Task<Veiculo> GetOne(VeiculoFilter filters)
        {
            return await _db.Veiculo
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new Veiculo
                {
                    Ano = _.Ano,
                    Cor = _.Cor,
                    Id = _.Id,
                    Km = _.Km,
                    MarcaId = _.MarcaId,
                    Modelo = _.Modelo,
                    Placa = _.Placa,
                    Preco = _.Preco,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PaginateResult<Veiculo>> GetData(VeiculoFilter filters)
        {
            var query = _db.Veiculo
                .WhereFilters(filters)
                .Select(_ => new Veiculo
                {
                    Ano = _.Ano,
                    Cor = _.Cor,
                    Id = _.Id,
                    Km = _.Km,
                    MarcaId = _.MarcaId,
                    Modelo = _.Modelo,
                    Placa = _.Placa,
                    Preco = _.Preco,
                });

            return await query.PagingWithDetails(filters);
        }

    }
}
