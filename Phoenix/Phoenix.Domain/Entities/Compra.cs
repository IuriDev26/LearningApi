using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Domain.Entities {
    public class Compra : Entity {

        public string Descricao { get; private set; }
        public int FuncionarioId { get; private set; }
        public Funcionario? Funcionario { get; private set; }
        public DateTime DataCompra { get; private set; }
        public ICollection<Produto> Produtos { get; private set; }

        public Compra() {

        }

        public Compra(string descricao, int funcionarioId, List<Produto> produtos) {
            Descricao = descricao;
            FuncionarioId = funcionarioId;
            Produtos = produtos;

        }


    }
}
