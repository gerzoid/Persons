using Application.Common.Models;
using Domain.Interfaces;
using Infrastructure.Database.RepoDb;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PersonsRepository(IConfiguration configuration) : DbServiceBase(configuration), IPersonsRepository
    {
        public async Task<List<Column>> GetColumnsOfTableAsync(string shema, string tableName)
        {
            List<Column> columns = new List<Column>();

            using var reader = await _connection.ExecuteReaderAsync($"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{shema}' AND TABLE_NAME = '{tableName}'");
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

        public async Task<int> GetCountRowsAsync(string database, string shema, string tableName)
        {
            int cnt = await _connection.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM {database}.{shema}.[{tableName}]");
            return cnt;
        }

        public async Task<bool> CheckExistsTableAsync(string database, string shema, string tableName)
        {
            int cnt  = await _connection.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG ='{database}' AND TABLE_SCHEMA='{shema}' AND TABLE_NAME = '{tableName}'");
            return cnt>0 ? true : false;
        }


        public string GetFormattingColumns(List<Column> columns)
        {
            StringBuilder formattedColumns = new StringBuilder();

            foreach (var col in columns)
            {
                if (col.Type == "date" || col.Type == "datetime" || col.Type == "smalldatetime")
                    formattedColumns.Append($" FORMAT([{col.Name}], 'dd.MM.yyyy') as {col.Name},");
                else
                    formattedColumns.Append($"{col.Name},");
            }
            formattedColumns.Remove(formattedColumns.Length - 1, 1);
            return formattedColumns.ToString();
        }
        public async Task<DataTable> ReadTableAsync(string shema, string tableName)
        {
            var columns = await GetColumnsOfTableAsync(shema, tableName);
            string formattedColumns = GetFormattingColumns(columns);
            //using (var reader = await _connection.ExecuteReaderAsync($"SELECT top 100  * FROM {tableName}"))
            using (var reader = await _connection.ExecuteReaderAsync($"SELECT top 100 {formattedColumns} FROM {tableName}"))
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable; 
            }
        }
    }
}
