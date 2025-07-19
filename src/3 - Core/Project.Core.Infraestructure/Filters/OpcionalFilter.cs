using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class OpcionalFilter : RepositoryFilter
    {
        public OpcionalFilter() { }

        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
