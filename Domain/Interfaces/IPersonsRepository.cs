using System.Data;

namespace Domain.Interfaces
{
    public interface IPersonsRepository
    {
        public DataTable ReadTable(string tableName);
    }
}
