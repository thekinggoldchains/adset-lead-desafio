using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class VeiculoImagemFilter : RepositoryFilter
    {
        public VeiculoImagemFilter() { }

        public int Id { get; set; }

        public string Url { get; set; }

        public int? Ordem { get; set; }

        public int VeiculoId { get; set; }


    }
}
