using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.RelationshipEntities {
    public class FuncionarioCargo {

        public int FuncionarioId { get; private set; }
        public int CargoId { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Cargo Cargo { get; private set; }

        public FuncionarioCargo(Funcionario funcionario, Cargo cargo) {
            Funcionario = funcionario;
            Cargo = cargo;
        }
    }
}
