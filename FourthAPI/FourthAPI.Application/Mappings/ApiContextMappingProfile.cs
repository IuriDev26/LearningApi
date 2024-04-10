using AutoMapper;
using FourthAPI.Application.DTOs;
using FourthAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Application.Mappings {
    public class ApiContextMappingProfile : Profile {

        public ApiContextMappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
        }


    }
}
