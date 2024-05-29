using Application.Common.Models;
using System.Data;

namespace Domain.Interfaces
{
    public interface IPersonsRepository
    {
        public Task<DataTable> ReadTableAsync(string tableName);
        public Task<List<Column>> GetColumnsOfTableAsync(string shema, string tableName);
    }
}
