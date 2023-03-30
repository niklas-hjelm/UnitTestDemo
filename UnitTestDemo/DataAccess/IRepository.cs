namespace UnitTestDemo.DataAccess;

public interface IRepository

{
    Task Add<T>(T entity);
    Task<T> GetById<T>(int id) where T : class;
    Task<IEnumerable<T>> GetAll<T>() where T : class;
    Task UpdateAsync<T>(T entity);
    Task DeleteAsync<T>(T entity);
}