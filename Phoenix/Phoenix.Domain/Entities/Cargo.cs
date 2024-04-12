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
        public ICollection<CargoAtividade> CargoAtividades { get; private set; }

        public Cargo(string? nome, string? descricao) {
            
            Nome = nome;
            Descricao = descricao;
            CargoAtividades = new List<CargoAtividade>();
        }

        public void AddAtividades(List<Atividade> atividades) {

            foreach (Atividade atividade in atividades) {

                CargoAtividade cargoAtividade = new CargoAtividade(this, atividade);
                CargoAtividades.Add(cargoAtividade);

            }


        }

    }
}
