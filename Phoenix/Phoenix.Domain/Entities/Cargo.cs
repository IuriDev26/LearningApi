using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Domain.Entities
{
    public class Cargo : Entity {

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<Atividade> Atividades { get; private set; }
        public ICollection<Funcionario> Funcionarios { get; private set; }

        public Cargo(string? nome, string? descricao, List<Atividade> atividades) {
            
            Nome = nome;
            Descricao = descricao;
            Atividades = atividades;
            Funcionarios = new List<Funcionario>();
        }

        public Cargo() { }


        

    }
}
