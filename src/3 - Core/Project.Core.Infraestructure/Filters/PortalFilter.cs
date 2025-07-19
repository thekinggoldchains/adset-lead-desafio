using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class PortalFilter : RepositoryFilter
    {
        public PortalFilter() { }

        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
