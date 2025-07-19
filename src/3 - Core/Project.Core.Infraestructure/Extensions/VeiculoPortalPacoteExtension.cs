using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class VeiculoPortalPacoteExtension
    {
        public static IQueryable<VeiculoPortalPacote> WhereFilters(this IQueryable<VeiculoPortalPacote> query, VeiculoPortalPacoteFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.VeiculoId.IsSent())
                query = query.Where(_ => _.VeiculoId == filters.VeiculoId);

            if (filters.VeiculoId.IsSent())
                query = query.Where(_ => _.VeiculoId == filters.VeiculoId);

            if (filters.PortalId.IsSent())
                query = query.Where(_ => _.PortalId == filters.PortalId);

            if (filters.PortalId.IsSent())
                query = query.Where(_ => _.PortalId == filters.PortalId);

            if (filters.PacoteId.IsSent())
                query = query.Where(_ => _.PacoteId == filters.PacoteId);



            return query;
        }
    }
}
