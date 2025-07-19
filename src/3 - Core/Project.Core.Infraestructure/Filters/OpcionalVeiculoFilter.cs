using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class OpcionalVeiculoFilter : RepositoryFilter
    {
        public OpcionalVeiculoFilter() { }

        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int OpcionalId { get; set; }


    }
}
