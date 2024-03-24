using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstApi.Models {
    public class Produto {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string?  Descricao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        
        [Required]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

    }
}
