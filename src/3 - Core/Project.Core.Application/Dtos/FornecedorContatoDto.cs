using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(FornecedorContato), ReverseMap = true)]
    public class FornecedorContatoDto
    {
        public int Id { get; set; }

        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

    }
}
