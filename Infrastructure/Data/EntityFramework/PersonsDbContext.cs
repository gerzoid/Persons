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
        
        
        public DbSet<Tables> Tables { get; set; }
        public DbSet<SettingsTables> SettingsTables { get; set; }

    }
}

//dotnet ef migrations add Added_SettinsTable --context=PersonsDbContext --project=Infrastructure --startup-project=Web
//dotnet ef database update --project=Infrastructure --startup-project=web