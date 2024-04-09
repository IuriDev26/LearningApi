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
    public class CategoriaRepository : ICategoriaRepository {

        private readonly ApiContext _context;

        public CategoriaRepository(ApiContext context) {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria categoria) {
            
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }

        public async Task<Categoria> Delete(Categoria categoria) {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }


        public async Task<IEnumerable<Categoria>> GetAllAsync() {

            return await _context.Categorias.ToListAsync();
            
        }

        public async Task<Categoria> GetByIdAsync(int id) {

            try {

                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
                return categoria;

            } catch (Exception) {

                throw;

            }

        }

        public async Task<Categoria> Update(Categoria categoria) {
            
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
