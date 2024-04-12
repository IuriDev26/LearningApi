using Phoenix.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities {
    public class Cliente : Entity {

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Cep { get; set; }
        public string ResidencialNumber { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ICollection<Venda>? Compras { get; private set; }

        public Cliente(string nome, string cpf, string telefone, string email, string endereco, string cep, string residencialNumber) {

            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Cep = cep;
            ResidencialNumber = residencialNumber;
            Compras = new List<Venda>();

        }

            
    }
}
