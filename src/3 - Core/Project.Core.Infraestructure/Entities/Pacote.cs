using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Core.Infraestructure.Entities
{
    public class Pacote
    {
        public Pacote() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Nome")]
        [Length(1, 50, ErrorMessage = "O tamanho máximo para o campo Nome é 50 caracteres")]
        public string Nome { get; set; }

        #endregion    
        #region Navegações 
        public virtual ICollection<VeiculoPortalPacote> CollectionVeiculoPortalPacote { get; set; }


        #endregion

    }
}
