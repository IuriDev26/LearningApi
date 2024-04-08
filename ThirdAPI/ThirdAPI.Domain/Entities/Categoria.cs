using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Domain.Validation;

namespace ThirdAPI.Domain.Entities {
    public sealed class Categoria : Entity {

        public string Nome { get; private set; }

        public string ImagemUrl { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria(string nome, string imagemUrl)
        {
            ValidateDomain(nome, imagemUrl);
        }

        public Categoria(string nome, string imagemUrl, int id)
        {
            ValidateDomain(nome, imagemUrl);
            Id = id;
        }


        private void ValidateDomain(string nome, string imagemUrl) {

            DomainValidationException.When( string.IsNullOrEmpty(nome), "Nome é Obrigatório.");

            DomainValidationException.When( string.IsNullOrEmpty(imagemUrl), "Imagem é obrigatório");

            DomainValidationException.When( nome.Length < 3, "O nome deve ter pelo menos 3 caracteres");

            DomainValidationException.When(imagemUrl.Length < 5, "Nome de imagem deve ter pelo menos 5 caracteres");

            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
