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

    public async Task AddAsync<T>(T entity)
    {
        await _peopleContext.People.AddAsync(entity as Person);
        await _peopleContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class
    {
        return await _peopleContext.People.FindAsync(id) as T;
    }

    async Task<IEnumerable<T>> IRepository.GetAllAsync<T>()
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