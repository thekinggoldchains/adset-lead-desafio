using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Core.Infraestructure.Entities
{
    public class VeiculoImagem
    {
        public VeiculoImagem() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Url")]
        public string Url { get; set; }

        public int? Ordem { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo VeiculoId")]
        public int VeiculoId { get; set; }

        #endregion
        #region Navegações
        public virtual Veiculo Veiculo { get; set; }


        #endregion

    }
}
