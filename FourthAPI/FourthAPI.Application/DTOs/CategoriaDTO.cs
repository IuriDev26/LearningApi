using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Application.DTOs {
    public class CategoriaDTO {

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

    }
}
