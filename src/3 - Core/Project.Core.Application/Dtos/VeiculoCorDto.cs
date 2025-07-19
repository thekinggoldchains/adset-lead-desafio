using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(VeiculoCor), ReverseMap = true)]
    public class VeiculoCorDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
