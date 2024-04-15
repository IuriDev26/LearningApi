using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Application.DTOs {
    public class ClienteDTO {

        [Required]
        [StringLength(100)]
        public string? Nome { get; private set; }

        [Required]
        [StringLength(11)]
        public string? CPF { get; private set; }

        [Required]
        [StringLength(9)]
        public string? Telefone { get; private set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; private set; }

        [Required]
        [StringLength(100)]
        public string? Endereco { get; private set; }

        [Required]
        [StringLength(8)]
        public string? Cep { get; set; }

        [Required]
        public string? ResidencialNumber { get; private set; }
        
    }
}
