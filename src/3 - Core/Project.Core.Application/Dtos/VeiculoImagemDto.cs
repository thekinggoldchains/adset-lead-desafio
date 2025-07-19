using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(VeiculoImagem), ReverseMap = true)]
    public class VeiculoImagemDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int? Ordem { get; set; }

        public int VeiculoId { get; set; }


    }
}
