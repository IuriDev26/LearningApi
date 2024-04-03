using FirstApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstApi.DTOs.Entities {
    public class CategoriaDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

    }
}
