using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ListTableRepository : IListTablesRepository
    {
        private readonly PersonsDbContext _context;

        public ListTableRepository(PersonsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ListTables> GetList()
        {
            return _context.Set<ListTables>().AsNoTracking().ToList();
        }

        public ListTables? GetTable(int id)
        {
            return _context.Set<ListTables>()
                .AsNoTracking()
                .Include(u => u.Settings)
                .Where(d => d.ListTableId == id)                
                .FirstOrDefault();
        }

        public void Test()
        {
            var tableName = "erz_find";
            /*var connection = _context.Database.GetDbConnection();
            connection.Open();
            var schema = connection.GetSchema("Columns", new[] { null, null, tableName });
            var columns = schema.Rows.Cast<DataRow>().Select(r => new { Name = r["COLUMN_NAME"], Type = r["DATA_TYPE"] }).ToList();
            connection.Close();


            var modelBuilder = new ModelBuilder(new ConventionSet());
            var entityType = modelBuilder.Entity(tableName);
            //entityType.HasKey("Id"); // Установить первичный ключ
            foreach (var column in columns)
            {
                entityType.Property((String)column.Name).HasColumnType((String)column.Type); // Добавить свойство, соответствующее столбцу таблицы
            }
            var model = modelBuilder.Model;*/

            var t = _context.Database.SqlQuery<dynamic>($"select top 100 * from erz_find").ToList();

        }
    }
}
