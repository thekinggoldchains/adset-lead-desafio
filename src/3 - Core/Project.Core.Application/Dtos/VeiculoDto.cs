using AutoMapper;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Application.Dtos
{
    [AutoMap(typeof(Veiculo), ReverseMap = true)]
    public class VeiculoDto
    {
        public int Id { get; set; }

        public int MarcaId { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Placa { get; set; }

        public int? Km { get; set; }

        public string Cor { get; set; }

        public decimal Preco { get; set; }


    }
}
