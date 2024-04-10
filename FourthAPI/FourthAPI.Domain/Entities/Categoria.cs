using FourthAPI.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Domain.Entities {
    public class Categoria : Entity {

        public string? Nome { get; set; }
        public ICollection<Produto>? Produtos { get; set; }

        public Categoria(string? nome) {

            ValidateDomain(nome);

        }

        private void ValidateDomain(string? nome) {

            ValidateDomainException.When( string.IsNullOrEmpty(nome), "O campo Nome é obrigatório" );

        }
    }
}
