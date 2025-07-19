using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Core.Infraestructure.Entities
{
    public class VeiculoPortalPacote
    {
        public VeiculoPortalPacote() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo VeiculoId")]
        public int VeiculoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo PortalId")]
        public int PortalId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo PacoteId")]
        public int PacoteId { get; set; }

        #endregion
        #region Navegações  
        public virtual Pacote Pacote { get; set; }
        public virtual Portal Portal { get; set; }
        public virtual Veiculo Veiculo { get; set; }


        #endregion

    }
}
