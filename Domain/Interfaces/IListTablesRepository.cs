using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITablesRepository
    {
        //Получить список всех таблиц        
        public Task<IEnumerable<Tables>> GetTablesAsync();
        //Получить всю информацию от таблице и её настройках
        public Task<Tables?> GetTableByIdAsync(int id);
        public Task<int> AddTableAsync(Tables table);

    }
}
