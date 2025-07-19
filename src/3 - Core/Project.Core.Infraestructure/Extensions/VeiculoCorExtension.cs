using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class VeiculoCorExtension
    {
        public static IQueryable<VeiculoCor> WhereFilters(this IQueryable<VeiculoCor> query, VeiculoCorFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.Nome.IsSent())
                query = query.Where(_ => _.Nome.ToLower().Contains(filters.Nome.ToLower()));



            return query;
        }
    }
}
