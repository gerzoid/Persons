using Application.Common.Models;
using System.Data;

namespace Domain.Interfaces
{
    public interface IPersonsRepository
    {
        public Task<DataTable> ReadTableAsync(string shema, string tableName);
        public Task<List<Column>> GetColumnsOfTableAsync(string shema, string tableName);
        public Task<int> GetCountRowsAsync(string database, string shema, string tableName);
        public Task<bool> CheckExistsTableAsync(string database, string shema, string tableName);
    }
}
