using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.RelationshipEntities
{
    public class CargoAtividade
    {

        public Cargo Cargo { get; private set; }
        public Atividade Atividade { get; private set; }

        public int CargoId { get; private set; }
        public int AtividadeId { get; private set; }

        public CargoAtividade(Cargo cargo, Atividade atividade)
        {
            Cargo = cargo;
            Atividade = atividade;
        }
    }
}
