using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities {
    public class DevolucaoVenda : Entity {

        public string Motivo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public Venda VendaDevolvida { get; private set; }
        public int VendaId { get; private set; }

        public DevolucaoVenda() {

        }

        public DevolucaoVenda(string motivo, DateTime dataDevolucao, Venda vendaDevolvida) {
            Motivo = motivo;
            DataDevolucao = dataDevolucao;
            VendaDevolvida = vendaDevolvida;
        }
    }
}
