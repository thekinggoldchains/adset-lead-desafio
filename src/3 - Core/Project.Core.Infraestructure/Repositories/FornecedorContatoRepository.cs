using Common.Orm.Repository;
using Project.Core.Infraestructure.Context;
using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Extensions;
using Project.Core.Infraestructure.Filters;
using Microsoft.EntityFrameworkCore;
using Common.Orm.Extensions; 

namespace Project.Core.Infraestructure.Repositories
{
    public class FornecedorContatoRepository : Repository<FornecedorContato>
    {
        private readonly DbContextCore _db;
        public FornecedorContatoRepository(DbContextCore ctx)
            : base(ctx)
        {
            _db = ctx;
        }

        public async Task<dynamic> GetDataItem(FornecedorContatoFilter filters)
        {
            var query = _db.FornecedorContato
                .WhereFilters(filters)
                .Select(_ => new
                {
                    Id = _.Id,
                    Nome = _.Nome
                });

            return await query.OrderBy(_ => _.Nome).ToListAsync();
        }

        public async Task<FornecedorContato> GetOne(FornecedorContatoFilter filters)
        {
            return await _db.FornecedorContato
                .Where(_ => _.Id == filters.Id)
                .Select(_ => new FornecedorContato
                {
                    Email = _.Email,
                    FornecedorId = _.FornecedorId,
                    Id = _.Id,
                    Nome = _.Nome,
                    Telefone = _.Telefone,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<FornecedorContato>> GetData(FornecedorContatoFilter filters)
        {
            var query = _db.FornecedorContato
                .WhereFilters(filters)
                .Select(_ => new FornecedorContato
                {
                    Email = _.Email,
                    FornecedorId = _.FornecedorId,
                    Id = _.Id,
                    Nome = _.Nome,
                    Telefone = _.Telefone,
                });
            return await query.Paging(filters).ToListAsync();
        }

    }
}
