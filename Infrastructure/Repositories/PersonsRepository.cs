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
        public List<Column> GetColumnsOfTable(string shema, string tableName)
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
