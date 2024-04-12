using Phoenix.Domain.Entities.Enums;
using Phoenix.Domain.Entities.RelationshipEntities;
using Phoenix.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities
{
    public class Venda : Entity {

        public StatusVendaEnum Status { get; private set; }
        public DateTime DataVenda { get; private set; }
        public Cliente? Cliente { get; private set; }
        public int ClienteId { get; private set; }
        public ICollection<VendaProduto>? VendaProduto { get; private set; }

        public Venda(int clienteId, IEnumerable<Produto> produtos) {


            ValidateDomain(clienteId, produtos);
                       
        }

        private void ValidateDomain(int clienteId, IEnumerable<Produto> produtos) {

            Status = StatusVendaEnum.Finalizada;
            ClienteId = clienteId;

            foreach (Produto produto in produtos) {

                VendaProduto vendaProduto = new VendaProduto(this, produto);
                VendaProduto?.Add(vendaProduto);

            }



        }

    }
}
