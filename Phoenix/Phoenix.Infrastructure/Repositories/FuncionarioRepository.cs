using Phoenix.Domain.Entities;
using Phoenix.Domain.Interfaces;
using Phoenix.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.Repositories {
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository {
        public FuncionarioRepository(ApiContext context) : base(context) {
        }

        public Funcionario EnterActivities(Funcionario funcionario, Atividade atividade) {
            
            funcionario.Atividades.Add(atividade);
            _context.Funcionarios.Update(funcionario);
            return funcionario;

        }

        public Funcionario EnterPosition(Funcionario funcionario, Cargo novoCargo) {
            
            funcionario.Cargos.Add(novoCargo);
            _context.Funcionarios.Update(funcionario);
            return funcionario;


        }

        public Funcionario Promote(Funcionario funcionario, Cargo novoCargo) {

            funcionario.Promote(novoCargo);
            _context.Funcionarios.Update(funcionario);
            return funcionario;


        }

        public Funcionario Resignation(Funcionario funcionario) {

            funcionario.Resignation();
            _context.Funcionarios.Update(funcionario);
            return funcionario;


        }
    }
}
