using Microsoft.EntityFrameworkCore;
using SecondApi.Context;
using SecondApi.Repositories.Interfaces;

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

        public async Task<IEnumerable<T>> GetAll() {

            return await _context.Set<T>().ToListAsync();

        }

        public Task<T?> GetById(Func<T, bool> predicate) {
            throw new NotImplementedException();
        }

        public T Update(T entity) {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
