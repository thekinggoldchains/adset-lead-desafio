using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(Opcional), ReverseMap = true)]
    public class OpcionalDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
