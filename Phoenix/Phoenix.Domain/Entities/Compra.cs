using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Domain.Entities
{
    public class Compra : Entity {

        public string Descricao { get; private set; }
        public int FuncionarioId { get; private set; }
        public Funcionario? Funcionario { get; private set; }
        public DateTime DataCompra { get; private set; }
        public ICollection<CompraProduto> CompraProdutos { get; private set; }

        public Compra(string descricao, int funcionarioId) {
            Descricao = descricao;
            FuncionarioId = funcionarioId;
            CompraProdutos = new List<CompraProduto>();
        }

        public void AddProduto(IEnumerable<Produto> produtos) {

            foreach (var produto in produtos) {

                var compraProduto = new CompraProduto(this, produto);
                CompraProdutos.Add(compraProduto);

            }

        }


    }
}
