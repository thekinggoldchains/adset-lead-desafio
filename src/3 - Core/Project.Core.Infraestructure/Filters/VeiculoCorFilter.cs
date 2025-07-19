using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class VeiculoCorFilter : RepositoryFilter
    {
        public VeiculoCorFilter() { }

        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
