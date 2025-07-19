using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Infraestructure.Entities
{
    public class OpcionalVeiculo
    {
        public OpcionalVeiculo() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo VeiculoId")]
        public int VeiculoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo OpcionalId")]
        public int OpcionalId { get; set; }

        #endregion

        #region Navegações        
        public virtual Opcional Opcional { get; set; }
        public virtual Veiculo Veiculo { get; set; }


        #endregion

    }
}
