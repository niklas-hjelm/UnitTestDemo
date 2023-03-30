namespace UnitTestDemo.DataAccess;

public interface IRepository

{
    void Add<T>(T entity);
    T GetById<T>(int id) where T : class;
    IEnumerable<T> GetAll<T>() where T  : class;
    Task UpdateAsync<T>(T entity);
    Task DeleteAsync<T>(T entity);
}