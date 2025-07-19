using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class OpcionalVeiculoExtension
    {
        public static IQueryable<OpcionalVeiculo> WhereFilters(this IQueryable<OpcionalVeiculo> query, OpcionalVeiculoFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.VeiculoId.IsSent())
                query = query.Where(_ => _.VeiculoId == filters.VeiculoId);

            if (filters.OpcionalId.IsSent())
                query = query.Where(_ => _.OpcionalId == filters.OpcionalId);



            return query;
        }
    }
}
