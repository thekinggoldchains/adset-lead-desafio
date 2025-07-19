using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(VeiculoMarca), ReverseMap = true)]
    public class VeiculoMarcaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
