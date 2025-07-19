using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(VeiculoPortalPacote), ReverseMap = true)]
    public class VeiculoPortalPacoteDto
    {
        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int PortalId { get; set; }

        public int PacoteId { get; set; }


    }
}
