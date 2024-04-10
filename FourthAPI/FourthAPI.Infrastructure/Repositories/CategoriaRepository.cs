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
    public class CategoriaRepository : ICategoriaRepository {
    
        private readonly ApiContext _context;

        public CategoriaRepository(ApiContext context) {
            _context = context;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria) {

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }

        public async Task<Categoria> DeleteByIdAsync(int id) {
            
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) {

                throw new ArgumentNullException("Categoria não encontrada");
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }

        public async Task<IEnumerable<Categoria>> GetAllAsync() {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id) {

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) {

                throw new ArgumentNullException("Categoria não encontrada");
            }

            return categoria;

        }

        public async Task<Categoria> UpdateAsync(Categoria categoria) {
            
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
