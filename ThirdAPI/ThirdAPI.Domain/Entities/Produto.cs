using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Domain.Validation;

namespace ThirdAPI.Domain.Entities {
    public sealed class Produto : Entity {

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public int Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro) {

            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
                              
        }

        public void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro) {

            DomainValidationException.When( string.IsNullOrEmpty(nome), "Nome é obrigatório" );

            DomainValidationException.When( string.IsNullOrEmpty(descricao), "Descrição é obrigatória" );

            DomainValidationException.When( string.IsNullOrEmpty(imagemUrl), "Nome da imagem é obrigatório" );

            DomainValidationException.When( preco < Decimal.Zero, "O preço é obrigatório");

            DomainValidationException.When( estoque < Decimal.Zero, "O estoque é obrigatório");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImagemUrl = imagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro; 

        }

        public void Update(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro, int categoriaId) {

            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
            CategoriaId = categoriaId;
        }
    }
}
