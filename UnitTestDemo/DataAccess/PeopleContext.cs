using Microsoft.EntityFrameworkCore;
using UnitTestDemo.DataAccess.Models;

namespace UnitTestDemo.DataAccess;

public class PeopleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public PeopleContext(DbContextOptions options) : base(options)
    {
        
    }
}