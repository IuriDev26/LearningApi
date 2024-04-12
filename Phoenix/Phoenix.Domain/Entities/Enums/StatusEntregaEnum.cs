using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.Enums {
    public enum StatusEntregaEnum {

        AwaitingRoute = 1,
        HaveRoute = 2,
        AwaitingDispatch = 3,
        InRoute = 4,
        Succeeded = 5,
        Cancelled = 6

    }
}
