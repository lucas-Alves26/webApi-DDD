namespace Business.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> Get();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
    }
}
