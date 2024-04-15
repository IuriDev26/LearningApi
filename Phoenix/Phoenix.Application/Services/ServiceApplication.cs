using Phoenix.Application.Interfaces;
using Phoenix.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Application.Services {
    public class ServiceApplication<T> : IServiceApplication<T> where T : class {

        protected readonly IRepository<T> _repository;

        public ServiceApplication(IRepository<T> repository) {
            _repository = repository;
        }

        public T Create(T entity) {
            
           return _repository.Create(entity);

        }

        public T Delete(T entity) {
            return _repository.Delete(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync() {
            return _repository.GetAllAsync();
        }

        public Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicate) {
            return _repository.GetByPredicateAsync(predicate);
        }

        public T Update(T entity) {
            return _repository.Update(entity); 
        }
    }
}
