using SecondApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecondApi.DTOs.Entities {
    public class ProdutoDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Descricao { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }

    }
}
