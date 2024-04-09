using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Application.Interfaces;
using ThirdAPI.Application.Mappings;
using ThirdAPI.Application.Services;
using ThirdAPI.Domain.Interfaces;
using ThirdAPI.Infrastructure.Context;
using ThirdAPI.Infrastructure.Repositories;

namespace ThirdAPI.CrossCutting.IoC {
    public static class DependencyInjection {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var MySQL = configuration.GetConnectionString("MySQL");


            services.AddDbContext<ApiContext>(options =>
            options.UseMySql(MySQL, ServerVersion.AutoDetect(MySQL)));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddAutoMapper(typeof(ThirdApiProfileMappings));

            return services;
        }


    }
}
