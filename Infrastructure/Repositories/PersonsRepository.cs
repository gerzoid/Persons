using Application.Common.Models;
using Domain.Interfaces;
using Infrastructure.Database.RepoDb;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data;

namespace Infrastructure.Repositories
{
    public class PersonsRepository(IConfiguration configuration) : DbServiceBase(configuration), IPersonsRepository
    {
        public async Task<List<Column>> GetColumnsOfTableAsync(string shema, string tableName)
        {
            List<Column> columns = new List<Column>();

            using var reader = _connection.ExecuteReader($"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{shema}' AND TABLE_NAME = '{tableName}'");
            {
                while (reader.Read())
                {
                    var col = new Column();
                    col.Name = reader["COLUMN_NAME"].ToString();
                    col.Title = col.Name;
                    col.Type = reader["DATA_TYPE"].ToString();
                    columns.Add(col);
                }
            }
            return columns;
        }

        public async Task<DataTable> ReadTableAsync(string tableName)
        {
            //var a = _connection.Query<Dictionary<string, object>>($"select * from dbo.erz_find").Take(10).ToList();
           using (var reader = await _connection.ExecuteReaderAsync($"SELECT top 100  * FROM {tableName}"))
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable; 
            }
        }
    }
}
