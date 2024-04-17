using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntityFramework
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
        
        
        public DbSet<ListTables> ListTables { get; set; }

    }
}
