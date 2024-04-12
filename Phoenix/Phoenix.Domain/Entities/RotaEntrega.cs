using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Domain.Entities.Enums;

namespace Phoenix.Domain.Entities
{
    public class RotaEntrega : Entity
    {

        public ICollection<Entrega>? Entregas { get; private set; }
        public DateTime DataStarted { get; private set; }
        public DateTime DataFinished { get; private set; }
        public StatusRotaEnum Status { get; private set; }

        public RotaEntrega(ICollection<Entrega> entregas, DateTime dataStarted)
        {

            ValidateDomain(entregas, dataStarted);

        }

        private void ValidateDomain(ICollection<Entrega> entregas, DateTime dataStarted)
        {

            Status = StatusRotaEnum.Created;
            Entregas = entregas;
            DataStarted = dataStarted;

        }
    }
}
