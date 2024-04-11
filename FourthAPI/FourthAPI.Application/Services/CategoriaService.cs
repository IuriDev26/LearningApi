using AutoMapper;
using FourthAPI.Application.DTOs;
using FourthAPI.Application.Interfaces;
using FourthAPI.Domain.Entities;
using FourthAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Application.Services {
    public class CategoriaService : ICategoriaService {

        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;


        public CategoriaService(ICategoriaRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _repository.CreateAsync(categoria);
            return categoriaDto;


        }

        public async Task<CategoriaDTO> DeleteAsync(int id) {
            
            var categoria =  await _repository.DeleteByIdAsync(id);
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDto;

        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync() {
            
            var categorias = await _repository.GetAllAsync();
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return categoriasDto;

        }

        public async Task<CategoriaDTO> GetByIdAsync(int id) {
            
            var categoria = await _repository.GetByIdAsync(id);
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDto;


        }

        public async Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _repository.UpdateAsync(categoria);
            return categoriaDto;


        }
    }
}
