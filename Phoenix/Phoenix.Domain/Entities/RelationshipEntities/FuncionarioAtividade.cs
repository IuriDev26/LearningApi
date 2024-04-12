using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.RelationshipEntities {
    public class FuncionarioAtividade {

        public int FuncionarioId { get; private set; }
        public int AtividadeId { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Atividade Atividade { get; private set; }

        public FuncionarioAtividade(Funcionario funcionario, Atividade atividade) {
            Funcionario = funcionario;
            Atividade = atividade;
        }
    }
}
