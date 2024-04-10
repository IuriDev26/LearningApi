using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Domain.Entities;
using ThirdAPI.Domain.Interfaces;
using ThirdAPI.Infrastructure.Context;

namespace ThirdAPI.Infrastructure.Repositories {
    public class ProdutoRepository : IProdutoRepository {

        private readonly ApiContext _context;

        public ProdutoRepository(ApiContext context) {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto) {

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;

        }

        public async Task<Produto> Delete(Produto produto) {
            
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;

        }

        public async Task<IEnumerable<Produto>> GetAllAsync() {

            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            return produtos;

        }

        public async Task<Produto?> GetByIdAsync(int id) {

            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<Produto> Update(Produto produto) {
            
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            


            return produto;
        }
    }
}
