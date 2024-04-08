using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Application.DTOs;
using ThirdAPI.Domain.Entities;

namespace ThirdAPI.Application.Mappings {
    public class ThirdApiProfileMappings : Profile{


        public ThirdApiProfileMappings() { 
        
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        
        }

    }
}
