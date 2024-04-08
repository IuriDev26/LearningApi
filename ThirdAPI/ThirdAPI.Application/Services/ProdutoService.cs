using AutoMapper;
using ThirdAPI.Application.DTOs;
using ThirdAPI.Domain.Entities;
using ThirdAPI.Domain.Interfaces;

namespace ThirdAPI.Application.Services {
    public class ProdutoService {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtorRepository, IMapper mappeer) {
            _produtoRepository = produtorRepository;
            _mapper = mappeer;
        }


        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync() {

            var produtos = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

        }


        public async Task<ProdutoDTO> GetByIdAsync(int id) {

            var produto = await _produtoRepository.GetByIdAsync(id);

            return _mapper.Map<ProdutoDTO>(produto);

        }


        public async Task<ProdutoDTO> Create(ProdutoDTO produtoDto) {

            var produto = _mapper.Map<Produto>(produtoDto);

            var produtoCriado = await _produtoRepository.Create(produto);

            return _mapper.Map<ProdutoDTO>(produtoCriado);

        }


        public async Task<ProdutoDTO> Update(ProdutoDTO produtoDto) {

            var produto = _mapper.Map<Produto>(produtoDto);

            var produtoAtualizado = await _produtoRepository.Create(produto);

            return _mapper.Map<ProdutoDTO>(produtoAtualizado);

        }


        public async Task<ProdutoDTO> Delete(ProdutoDTO produtoDto) {

            var produto = _mapper.Map<Produto>(produtoDto);

            var produtoDeleteado = await _produtoRepository.Create(produto);

            return _mapper.Map<ProdutoDTO>(produtoDeleteado);

        }

    }
}
