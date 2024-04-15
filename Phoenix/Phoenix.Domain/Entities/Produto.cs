using Phoenix.Domain.Entities.RelationshipEntities;
using Phoenix.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities
{
    public class Produto : Entity {

        public string? Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public int Estoque { get; private set; }

        public ICollection<Venda>? Vendas { get; private set; }
        public ICollection<Compra>? Compras { get; private set; }
        public Fornecedor? Fornecedor { get; private set; }
        public int FornecedorId { get; private set; }

        public DateTime DataCadastro { get; private set; }
        
        
        
        
        public Produto() { }

       
        
        
        public Produto(string? descricao, decimal precoVenda, decimal precoCompra, int estoque, Fornecedor fornecedor) {
            
            ValidateDomain(descricao, precoVenda, precoCompra, estoque, fornecedor);
            Vendas = new List<Venda>();
            Compras = new List<Compra>();
        }


        private void ValidateDomain(string? descricao, decimal precoVenda, decimal precoCompra, int estoque, Fornecedor fornecedor) {

            DomainValidationException.When( string.IsNullOrEmpty(descricao),  
                "O campo Descrição é obrigatório");

            DomainValidationException.When( precoVenda < 0 ,
                "O campo Descrição é obrigatório");

            DomainValidationException.When( precoCompra < 0 ,
                "O campo Descrição é obrigatório");

            DomainValidationException.When( estoque < 0 ,
                "O campo Descrição é obrigatório");

            Descricao = descricao;
            PrecoVenda = precoVenda;
            PrecoCompra = precoCompra;
            Estoque = estoque;
            Fornecedor = fornecedor;

        }


    }
}
