using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class FornecedorContatoExtension
    {
        public static IQueryable<FornecedorContato> WhereFilters(this IQueryable<FornecedorContato> query, FornecedorContatoFilter filters)
        {
            if (filters.Email.IsSent())
                query = query.Where(_ => _.Email.ToLower().Contains(filters.Email.ToLower()));

            if (filters.FornecedorId.IsSent())
                query = query.Where(_ => _.FornecedorId == filters.FornecedorId);

            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.Nome.IsSent())
                query = query.Where(_ => _.Nome.ToLower().Contains(filters.Nome.ToLower()));

            if (filters.Telefone.IsSent())
                query = query.Where(_ => _.Telefone.ToLower().Contains(filters.Telefone.ToLower()));



            return query;
        }
    }
}
