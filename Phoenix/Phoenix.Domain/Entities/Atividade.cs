using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Domain.Entities {
    public class Atividade : Entity {

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<Cargo> Cargos { get; private set; }
        public ICollection<Funcionario> Funcionarios { get; private set; }

        public Atividade(string? nome, string? descricao) {
            Nome = nome;
            Descricao = descricao;
            Cargos = new List<Cargo>();
            Funcionarios = new List<Funcionario>();

        }

        public Atividade() {

        }
    }
}
