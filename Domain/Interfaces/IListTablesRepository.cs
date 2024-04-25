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
        public IEnumerable<Tables> GetList();
        //Получить всю информацию от таблице и её настройках
        public Tables? GetTableById(int id);
        
        public bool CreateTable(Tables table);


    }
}
