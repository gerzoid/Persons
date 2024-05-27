using Application.Common.Dto;
using Domain.Interfaces;
using Infrastructure.Database.RepoDb;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data;

namespace Infrastructure.Repositories
{
    public class PersonsRepository(IConfiguration configuration) : DbServiceBase(configuration), IPersonsRepository
    {
        //public string[] GetColumnsOfTable(string tableName)
        public string[] GetColumnsOfTable(string shema, string tableName)
        {
            var reader = _connection.ExecuteQuery<string>($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{shema}' AND TABLE_NAME = '{tableName}'");
            return  reader?.Select(d =>(string)d).ToArray();
        }

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
