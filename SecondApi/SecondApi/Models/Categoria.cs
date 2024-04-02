using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecondApi.Models {
    public class Categoria {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }

    }
}
