using Phoenix.Application.Interfaces;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Application.Services {
    public class ClienteService : ServiceApplication<Cliente>, IClienteService {

        public ClienteService( IRepository<Cliente> repository ): base(repository)
        {
            
        }



    }
}
