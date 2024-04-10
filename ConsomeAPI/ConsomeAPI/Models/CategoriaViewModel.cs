using System.ComponentModel.DataAnnotations;

namespace ConsomeAPI.Models {
    public class CategoriaViewModel {

        
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [Required]
        [Display(Name = "Imagem")]
        public string? ImagemUrl { get; set; }


    }
}
