using Microsoft.EntityFrameworkCore;
using Phoenix.Domain.Interfaces;
using Phoenix.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.Repositories {
    public class Repository<T> : IRepository<T> where T : class {

        protected readonly ApiContext _context;

        public Repository(ApiContext context) {
            _context = context;
        }

        public T CreateAsync(T entity) {
            
            _context.Set<T>().Add(entity);
            return entity;

        }

        public T DeleteAsync(T entity) {
            
            _context.Set<T>().Remove(entity);
            return entity;

        }

        public async Task<IEnumerable<T>> GetAllAsync() {

            return await _context.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicate) {

            return await _context.Set<T>()
                            .Where(predicate)
                                .AsQueryable()
                                    .ToListAsync();

            


        }

        public T UpdateAsync(T entity) {
            
            _context.Set<T>().Update(entity);
            return entity;

        }
    }
}
