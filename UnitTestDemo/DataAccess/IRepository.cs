namespace UnitTestDemo.DataAccess;

public interface IRepository

{
    Task AddAsync<T>(T entity);
    Task<T> GetByIdAsync<T>(int id) where T : class;
    Task<IEnumerable<T>> GetAllAsync<T>() where T  : class;
    Task UpdateAsync<T>(T entity);
    Task DeleteAsync<T>(T entity);
}