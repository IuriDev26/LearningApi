using AutoMapper;
using ThirdAPI.Application.DTOs;
using ThirdAPI.Domain.Entities;
using ThirdAPI.Domain.Interfaces;

namespace ThirdAPI.Application.Services {
    public class CategoriaService {

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper) {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync() {

            var categorias = await _categoriaRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);

        }

        
        public async Task<CategoriaDTO> GetByIdAsync(int id) {

            var categoria = await _categoriaRepository.GetByIdAsync(id);

            return _mapper.Map<CategoriaDTO>(categoria);

        }
        

        public async Task<CategoriaDTO> Create(CategoriaDTO categoriaDTO) {

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            var categoriaCriada = await _categoriaRepository.Create(categoria);

            return _mapper.Map<CategoriaDTO>(categoriaCriada);

        }


        public async Task<CategoriaDTO> Update(CategoriaDTO categoriaDTO) {

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            var categoriaAtualizada = await _categoriaRepository.Update(categoria);

            return _mapper.Map<CategoriaDTO>(categoriaAtualizada);

        }


        public async Task<CategoriaDTO> Delete(CategoriaDTO categoriaDTO) {

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            var categoriaDeletada = await _categoriaRepository.Create(categoria);

            return _mapper.Map<CategoriaDTO>(categoriaDeletada);

        }

    }
}
