using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ThirdAPI.Application.DTOs {
    public class ProdutoDTO {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [MinLength(10)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [MaxLength(250)]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "Estoque é obrigatório")]
        [Range(1,999)]
        public int Estoque { get; set; }
        
        [Required]
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }


    }
}
