namespace SecondApi.Repositories.Interfaces {
    public interface IRepository<T>  {

        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(Func<T, bool> predicate);

        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
