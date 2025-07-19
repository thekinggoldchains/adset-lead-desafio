using Common.Orm.Filter;

namespace Project.Core.Infraestructure.Filters
{
    public class FornecedorContatoFilter : RepositoryFilter
    {
        public FornecedorContatoFilter() { }

        public int Id { get; set; }

        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

    }
}
