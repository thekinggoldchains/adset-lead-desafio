using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(OpcionalVeiculo), ReverseMap = true)]
    public class OpcionalVeiculoDto
    {
        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int OpcionalId { get; set; }


    }
}
