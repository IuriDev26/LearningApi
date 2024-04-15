using Phoenix.Domain.Entities.Enums;
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
        public ICollection<Cargo> Cargos { get; private set; }
        public ICollection<Atividade> Atividades { get; private set; }
        public ICollection<Compra> Compras { get; private set; }
        public StatusFuncionarioEnum Status {  get; private set; }

        public Funcionario() { }


        public Funcionario(string nome, int idade, DateTime admissao, DateTime demissao) {
            Nome = nome;
            Idade = ValidateIdade(idade);
            Admissao = admissao;
            Demissao = demissao;
            Cargos = new List<Cargo>();
            Atividades = new List<Atividade>();
            Compras = new List<Compra>();
        }


        private int ValidateIdade( int idade ) {

            DomainValidationException.When(idade < 18,
                "Não é possível cadastrar um funcionário com menos de 18 anos");

            return idade;

        }


        public void AddCargos(IEnumerable<Cargo> cargos) {

            cargos = cargos.ToList();
            Cargos.Concat(cargos);
            
            foreach ( Cargo cargo in cargos) {

                Atividades.Concat(cargo.Atividades);

            }

        }

        public void Promote(Cargo novoCargo) {

            this.Cargos = new List<Cargo>();
            this.Cargos.Add(novoCargo);
       
        }


        public void Resignation() {

            this.Demissao = DateTime.UtcNow;

        }

            
        

    }
}
