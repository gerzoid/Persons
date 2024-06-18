using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITablesRepository: IEFGenericRepository<Tables>
    {
        //Получить список всех таблиц        
        public Task<IEnumerable<Tables>> GetTablesAsync();
        //Получить всю информацию от таблице и её настройках
        public Task<Tables?> GetTableByIdAsync(int id);
        public Task<int> CreateTableAsync(Tables table);
        public Task<Tables> UpdateTableAsync(Tables table);

    }
}
