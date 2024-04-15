using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Domain.Interfaces;
using Phoenix.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiContext = Phoenix.Infrastructure.Context.ApiContext;


namespace Phoenix.CrossCutting.IoC {
    public static class DependencyInjection {

        public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration config) {

            var connectionString = config.GetConnectionString("MySQL");

            services.AddDbContext<ApiContext>(options => {

                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }

    }
}
