using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Domain.Entities
{
    public class Atividade : Entity {

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<CargoAtividade> CargoAtividades { get; private set; }

        public Atividade(string? nome, string? descriçao) {
            Nome = nome;
            Descricao = descriçao;
            CargoAtividades = new List<CargoAtividade>();
           
        }
    }
}
