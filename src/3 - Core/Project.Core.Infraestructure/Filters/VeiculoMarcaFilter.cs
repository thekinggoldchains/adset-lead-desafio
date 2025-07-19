using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class VeiculoMarcaFilter : RepositoryFilter
    {
        public VeiculoMarcaFilter() { }

        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
