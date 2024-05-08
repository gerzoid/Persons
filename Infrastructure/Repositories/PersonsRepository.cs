using Domain.Interfaces;
using Infrastructure.Database.RepoDb;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data;

namespace Infrastructure.Repositories
{
    public class PersonsRepository(IConfiguration configuration) : DbServiceBase(configuration), IPersonsRepository
    {
        public DataTable ReadTable(string tableName)
        {
            //var a = _connection.Query<Dictionary<string, object>>($"select * from dbo.erz_find").Take(10).ToList();
           using (var reader = _connection.ExecuteReader($"SELECT top 100  * FROM {tableName}"))
           // using (var reader = _connection.ExecuteReader($"SELECT top 100  * FROM Tables"))
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable; 
            }
        }
    }
}
