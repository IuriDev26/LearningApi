using AutoMapper;
using FirstApi.Context;
using FirstApi.DTOs.Mapping;
using FirstApi.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApixUnitTestes.ProdutosControllerUnitTest
{
    public class ProdutoUnitTesteController
    {

        public IUnitOfWork Uof { get; set; }
        public IMapper Mapper { get; set; }
        public static DbContextOptions<ApiContext> dbContextOptions { get; }

        public static string ConnectionString = "Server=localhost;Database=catalogodb;Uid=Iuri;Pwd=261117";
        static ProdutoUnitTesteController()
        {

            dbContextOptions = new DbContextOptionsBuilder<ApiContext>().UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)).Options;
        }

        public ProdutoUnitTesteController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });


            Mapper = config.CreateMapper();

            var context = new ApiContext(dbContextOptions);
            Uof = new UnitOfWork(context);
        }
    }
}
