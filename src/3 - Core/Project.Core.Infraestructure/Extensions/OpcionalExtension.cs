using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class OpcionalExtension
    {
        public static IQueryable<Opcional> WhereFilters(this IQueryable<Opcional> query, OpcionalFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.Nome.IsSent())
                query = query.Where(_ => _.Nome.ToLower().Contains(filters.Nome.ToLower()));



            return query;
        }
    }
}
