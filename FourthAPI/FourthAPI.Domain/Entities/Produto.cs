using FourthAPI.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Domain.Entities {
    public class Produto : Entity {

        public string? Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Categoria? Categoria { get; private set; }
        public int CategoriaId { get; private set; }

        public Produto(string? descricao, decimal preco, int estoque, int categoriaId) {

            ValidateDomain(descricao, preco, estoque, categoriaId);
            
        }

        private void ValidateDomain(string? descricao, decimal preco, int estoque, int categoriaId) {

            ValidateDomainException.When(string.IsNullOrEmpty(descricao), "O campo descrição é obrigatório");
            ValidateDomainException.When( preco < 0 , "Preço Inválido");
            ValidateDomainException.When( estoque < 0 , "Estoque Inválido");

            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            DataCadastro = dataCadastro;
            CategoriaId = categoriaId;

        }
    }
}
