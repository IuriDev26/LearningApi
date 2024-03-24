using FirstApi.Context;
using FirstApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstApi.Repositories.Implementations {
    public class Repository<T> : IRepository<T> where T :class {

        protected readonly ApiContext _context;

        public Repository(ApiContext context) {
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

        public IEnumerable<T> GetAll() {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(Expression<Func<T, bool>> predicate) {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Update(T entity) {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
