using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdAPI.Application.DTOs {
    public class CategoriaDTO {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome da imagem é obrigatório")]
        [MinLength(5)]
        [MaxLength(100)]
        public string ImagemUrl { get; set; }

    }
}
