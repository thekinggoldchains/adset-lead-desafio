using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class VeiculoImagemExtension
    {
        public static IQueryable<VeiculoImagem> WhereFilters(this IQueryable<VeiculoImagem> query, VeiculoImagemFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.Url.IsSent())
                query = query.Where(_ => _.Url.ToLower().Contains(filters.Url.ToLower()));

            if (filters.Ordem.IsSent())
                query = query.Where(_ => _.Ordem == filters.Ordem);

            if (filters.VeiculoId.IsSent())
                query = query.Where(_ => _.VeiculoId == filters.VeiculoId);



            return query;
        }
    }
}
