using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Application.Interfaces {
    public interface IServiceApplication<T>  {

        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicate);
    }
}
