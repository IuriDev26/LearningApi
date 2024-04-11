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
    public class ProdutoService : IProdutoService {

        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> CreateAsync(ProdutoDTO produtoDTO) {

            var produto = _mapper.Map<Produto>(produtoDTO);
            await _repository.CreateAsync(produto);
            return produtoDTO;

        }

        public async Task<ProdutoDTO> DeleteAsync(int id) {
            
            var produto = await _repository.DeleteByIdAsync(id);
            var produtoDto = _mapper.Map<ProdutoDTO>(produto);
            return produtoDto;

        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync() {
            
            var produtos = await _repository.GetAllAsync();
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return produtosDto;

        }

        public async Task<ProdutoDTO> GetByIdAsync(int id) {
            
            var produto = await _repository.GetByIdAsync(id);
            var produtoDto = _mapper.Map<ProdutoDTO>(produto);
            return produtoDto;

        }

        public async Task<ProdutoDTO> UpdateAsync(ProdutoDTO produtoDTO) {

            var produto = _mapper.Map<Produto>(produtoDTO);
            var produtoAlterado = await _repository.UpdateAsync(produto);
            return _mapper.Map<ProdutoDTO>(produtoAlterado);
        }
    }
}
