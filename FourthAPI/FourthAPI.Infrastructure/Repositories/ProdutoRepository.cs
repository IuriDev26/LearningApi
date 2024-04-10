using FourthAPI.Domain.Entities;
using FourthAPI.Domain.Interfaces;
using FourthAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Infrastructure.Repositories {
    public class ProdutoRepository : IProdutoRepository {

        private readonly ApiContext _context;

        public ProdutoRepository(ApiContext context) {
            _context = context;
        }

        public async Task<Produto> CreateAsync(Produto produto) {
            
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeleteByIdAsync(int id) {
            
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) {
                throw new ArgumentNullException("Produto não encontrado");
            }
            
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() {

            return await _context.Produtos.AsNoTracking().ToListAsync();
        
        }

        public async Task<Produto> GetByIdAsync(int id) {

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) {

                throw new ArgumentNullException("Produto não encontrado");
            }

            return produto;

        }

        public async Task<Produto> UpdateAsync(Produto produto) {
            
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;

        }
    }
}
