using AutoMapper;
using SecondApi.DTOs.Entities;
using SecondApi.Models;

namespace SecondApi.DTOs.Mapping {
    public class ApiMappingProfileDTOs : Profile {

        public ApiMappingProfileDTOs()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }


    }
}
