using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class VeiculoFilter : RepositoryFilter
    {
        public VeiculoFilter() { }

        public int Id { get; set; }

        public int MarcaId { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Placa { get; set; }

        public int? Km { get; set; }

        public string Cor { get; set; }

        public decimal Preco { get; set; }


    }
}
