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

    public void Add<T>(T entity)
    {
         _peopleContext.People.Add(entity as Person);
         _peopleContext.SaveChanges();
    }

    public T GetById<T>(int id) where T : class
    {
        return _peopleContext.People.Find(id) as T;
    }

    IEnumerable<T> IRepository.GetAll<T>()
    {
        return _peopleContext.People.ToList() as IEnumerable<T>;
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