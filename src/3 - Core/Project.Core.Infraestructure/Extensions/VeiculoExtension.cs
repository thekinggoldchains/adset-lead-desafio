using Project.Core.Infraestructure.Entities;
using Project.Core.Infraestructure.Filters;

namespace Project.Core.Infraestructure.Extensions
{
    public static class VeiculoExtension
    {
        public static IQueryable<Veiculo> WhereFilters(this IQueryable<Veiculo> query, VeiculoFilter filters)
        {
            if (filters.Id.IsSent())
                query = query.Where(_ => _.Id == filters.Id);

            if (filters.MarcaId.IsSent())
                query = query.Where(_ => _.MarcaId == filters.MarcaId);

            if (filters.Modelo.IsSent())
                query = query.Where(_ => _.Modelo.ToLower().Contains(filters.Modelo.ToLower()));

            if (filters.Ano.IsSent())
                query = query.Where(_ => _.Ano == filters.Ano);

            if (filters.Placa.IsSent())
                query = query.Where(_ => _.Placa.ToLower().Contains(filters.Placa.ToLower()));

            if (filters.Km.IsSent())
                query = query.Where(_ => _.Km == filters.Km);

            if (filters.Cor.IsSent())
                query = query.Where(_ => _.Cor.ToLower().Contains(filters.Cor.ToLower()));

            if (filters.Preco.IsSent())
                query = query.Where(_ => _.Preco == filters.Preco);



            return query;
        }
    }
}
