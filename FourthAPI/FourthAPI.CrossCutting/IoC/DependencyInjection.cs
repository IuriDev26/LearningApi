using FourthAPI.Application.Interfaces;
using FourthAPI.Application.Mappings;
using FourthAPI.Application.Services;
using FourthAPI.Domain.Interfaces;
using FourthAPI.Infrastructure.Context;
using FourthAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.CrossCutting.IoC {
    public static class DependencyInjection {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) {

            var connectionString = config.GetConnectionString("MySQL");
            services.AddDbContext<ApiContext>(options => {

                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddAutoMapper(typeof(ApiContextMappingProfile));

            return services;


        }

    }
}
