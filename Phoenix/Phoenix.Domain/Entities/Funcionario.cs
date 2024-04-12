using Phoenix.Domain.Entities.RelationshipEntities;
using Phoenix.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities {
    public class Funcionario : Entity {

        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public DateTime Admissao { get; private set; }
        public DateTime Demissao { get; private set; }
        public ICollection<FuncionarioCargo> FuncionarioCargos { get; private set; }
        public ICollection<FuncionarioAtividade> FuncionarioAtividades { get; private set; }
        public ICollection<Compra> Compras { get; private set; }


        public Funcionario(string nome, int idade, DateTime admissao, DateTime demissao) {
            Nome = nome;
            Idade = ValidateIdade(idade);
            Admissao = admissao;
            Demissao = demissao;
            FuncionarioCargos = new List<FuncionarioCargo>();
            FuncionarioAtividades = new List<FuncionarioAtividade>();
            Compras = new List<Compra>();
        }


        private int ValidateIdade( int idade ) {

            DomainValidationException.When(idade < 18,
                "Não é possível cadastrar um funcionário com menos de 18 anos");

            return idade;

        }


        public void AddCargos(IEnumerable<Cargo> cargos) {

            foreach (Cargo cargo in cargos) {

                var funcionarioCargo = new FuncionarioCargo(this, cargo);
                FuncionarioCargos.Add(funcionarioCargo);

                List<Atividade> atividades = cargo.CargoAtividades.Select(c => c.Atividade).ToList();
                
                foreach ( Atividade atividade in atividades) {

                    var funcionarioAtividade = new FuncionarioAtividade(this, atividade);

                }


            }

            
        }

    }
}
