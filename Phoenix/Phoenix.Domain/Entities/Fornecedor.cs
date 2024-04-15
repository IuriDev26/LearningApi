using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities {
    public class Fornecedor : Entity{

        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public ICollection<Produto> Produtos { get; private set; }

        public Fornecedor() { }

        public Fornecedor(string? nome, string cnpj) {
            Nome = nome;
            CNPJ = cnpj;
            Produtos = new List<Produto>();
        }
    }
}
