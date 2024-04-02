using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SecondApi.Models {
    public class Produto {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Descricao { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        [Required]
        public int CategoriaId { get; set; }

    }
}
