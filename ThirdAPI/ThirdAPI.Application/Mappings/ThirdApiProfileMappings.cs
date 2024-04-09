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
        
            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing( src => new Produto(src.Nome, src.Descricao, src.Preco, src.ImagemUrl, src.Estoque, src.DataCadastro ))
                .ReverseMap();

            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing( src => new Categoria(src.Nome, src.ImagemUrl, src.Id ))
                .ReverseMap();
        
        }

    }
}
