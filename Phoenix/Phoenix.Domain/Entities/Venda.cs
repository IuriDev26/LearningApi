using Phoenix.Domain.Entities.Enums;
using Phoenix.Domain.Entities.RelationshipEntities;
using Phoenix.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities {
    public class Venda : Entity {

        public StatusVendaEnum Status { get; private set; }
        public DateTime DataVenda { get; private set; }
        public Cliente? Cliente { get; private set; }
        public int ClienteId { get; private set; }
        public ICollection<Produto> Produtos { get; private set; }

        public Venda() {

        }

        public Venda(int clienteId, IEnumerable<Produto> produtos) {

            ClienteId = clienteId;
            Produtos = produtos.ToList();
        }

        public void SaleCancel() {

            this.Status = StatusVendaEnum.Cancelada;

        }







    }
}
