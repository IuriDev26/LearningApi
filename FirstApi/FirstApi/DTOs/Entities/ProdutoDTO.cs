using FirstApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstApi.DTOs.Entities {
    public class ProdutoDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }

       

    }
}
