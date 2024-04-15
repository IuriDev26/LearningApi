using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Interfaces {
    public interface IFuncionarioRepository : IRepository<Funcionario> {

        Funcionario Resignation(Funcionario funcionario);
        Funcionario Promote(Funcionario funcionario, Cargo novoCargo);
        Funcionario EnterPosition(Funcionario funcionario, Cargo novoCargo);
        Funcionario EnterActivities(Funcionario funcionario, Atividade atividade);


    }
}
