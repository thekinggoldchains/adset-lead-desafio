using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(Portal), ReverseMap = true)]
    public class PortalDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }


    }
}
