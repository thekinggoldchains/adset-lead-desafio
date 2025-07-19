using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Infraestructure.Entities
{
    public class FornecedorContato
    {
        public FornecedorContato() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo FornecedorId")]
        public Guid FornecedorId { get; set; }

        [Length(0, 50, ErrorMessage = "O tamanho máximo para o campo Nome é 50 caracteres")]
        public string Nome { get; set; }

        [Length(0, 250, ErrorMessage = "O tamanho máximo para o campo Email é 250 caracteres")]
        [EmailAddress(ErrorMessage = "O valor informado para o campo e-mail é inválido")]
        public string Email { get; set; }

        [Length(0, 20, ErrorMessage = "O tamanho máximo para o campo Telefone é 20 caracteres")]
        public string Telefone { get; set; }


    }
}
