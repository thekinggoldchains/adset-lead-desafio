using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class VeiculoPortalPacoteFilter : RepositoryFilter
    {
        public VeiculoPortalPacoteFilter() { }

        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int PortalId { get; set; }

        public int PacoteId { get; set; }


    }
}
