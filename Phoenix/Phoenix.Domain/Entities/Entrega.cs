using Phoenix.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities
{
    public class Entrega : Entity {

        public Venda Venda { get; private set; }
        public int VendaId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public StatusEntregaEnum StatusEntrega { get; private set; }
        public RotaEntrega RotaEntrega { get; private set; }
        public int RotaEntregaId { get; private set; }

        public Entrega()
        {
            
        }

        public Entrega(Venda venda, RotaEntrega rotaEntrega) {
            Venda = venda;
            RotaEntrega = rotaEntrega;
            VendaId = Venda.Id;
            DataVenda = Venda.DataVenda;


        }
    }
}
