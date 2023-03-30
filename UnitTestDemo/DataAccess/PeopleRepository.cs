using Microsoft.EntityFrameworkCore;
using UnitTestDemo.DataAccess.Models;

namespace UnitTestDemo.DataAccess;

public class PeopleRepository : IRepository
{
    private readonly PeopleContext _peopleContext;
    
    public PeopleRepository(PeopleContext peopleContext)
    {
        _peopleContext = peopleContext;
    }

    public async Task Add<T>(T entity)
    {
         await _peopleContext.People.AddAsync(entity as Person);
         await _peopleContext.SaveChangesAsync();
    }

    public async Task<T> GetById<T>(int id) where T : class
    {
        return await _peopleContext.People.FindAsync(id) as T;
    }

    public async Task<IEnumerable<T>> GetAll<T>() where T : class
    {
        return await _peopleContext.People.ToListAsync() as IEnumerable<T>;
    }
    
    public async Task UpdateAsync<T>(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync<T>(T entity)
    {
        throw new NotImplementedException();
    }
}