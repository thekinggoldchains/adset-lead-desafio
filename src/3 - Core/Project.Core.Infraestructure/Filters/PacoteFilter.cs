using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class PacoteFilter : RepositoryFilter
    {
        public PacoteFilter() { }

        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
