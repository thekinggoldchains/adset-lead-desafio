using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class PortalExtension
    {
        public static IQueryable<Portal> WhereFilters(this IQueryable<Portal> query, PortalFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.Nome.IsSent())
                query = query.Where(_ => _.Nome.ToLower().Contains(filters.Nome.ToLower()));



            return query;
        }
    }
}
