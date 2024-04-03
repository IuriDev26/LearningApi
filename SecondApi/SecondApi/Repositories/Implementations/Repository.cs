using Microsoft.EntityFrameworkCore;
using SecondApi.Context;
using SecondApi.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SecondApi.Repositories.Implementations {
    public class Repository<T> : IRepository<T> where T : class {

        protected readonly ApiContext _context;

        public Repository(ApiContext context)
        {
            _context = context;
        }


        public T Create(T entity) {
            
            _context.Set<T>().Add(entity);
            return entity;

        }

        public T Delete(T entity) {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync() {

            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate) {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T Update(T entity) {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
