using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Core.Infraestructure.Entities
{
    public class Veiculo
    {
        public Veiculo() { }

        #region Propriedades da tabela

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo MarcaId")]
        public int MarcaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Modelo")]
        [Length(1, 100, ErrorMessage = "O tamanho máximo para o campo Modelo é 100 caracteres")]
        public string Modelo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Ano")]
        public int Ano { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Placa")]
        [Length(1, 10, ErrorMessage = "O tamanho máximo para o campo Placa é 10 caracteres")]
        public string Placa { get; set; }

        public int? Km { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Cor")]
        [Length(1, 50, ErrorMessage = "O tamanho máximo para o campo Cor é 50 caracteres")]
        public string Cor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o campo Preco")]
        public decimal Preco { get; set; }

        #endregion
        #region Navegações        
        public virtual VeiculoMarca VeiculoMarca { get; set; }
        public virtual ICollection<OpcionalVeiculo> CollectionOpcionalVeiculo { get; set; }
        public virtual ICollection<VeiculoImagem> CollectionVeiculoImagem { get; set; }
        public virtual ICollection<VeiculoPortalPacote> CollectionVeiculoPortalPacote { get; set; }


        #endregion

    }
}
