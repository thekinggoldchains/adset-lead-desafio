using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Core.Infraestructure.Entities
{
    public class VeiculoCor
    {
        public VeiculoCor() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Nome")]
        [Length(1, 100, ErrorMessage = "O tamanho máximo para o campo Nome é 100 caracteres")]
        public string Nome { get; set; }

        #endregion
        #region Navegações

        #endregion

    }
}
