using Application.Common.Models;
using System.Data;

namespace Domain.Interfaces
{
    public interface IPersonsRepository
    {
        public DataTable ReadTable(string tableName);
        public List<Column> GetColumnsOfTable(string shema, string tableName);
    }
}
