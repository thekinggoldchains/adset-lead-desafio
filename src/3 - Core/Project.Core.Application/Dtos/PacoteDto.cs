using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(Pacote), ReverseMap = true)]
    public class PacoteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
