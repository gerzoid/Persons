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
    public class TablesRepository :  ITablesRepository
    {
        private readonly PersonsDbContext _context;

        public TablesRepository(PersonsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTableAsync(Tables table)
        {
            var createdTable = _context.Set<Tables>().Add(table);
            await _context.SaveChangesAsync();
            return createdTable.Entity.TableId;
        }

        public async Task<IEnumerable<Tables>> GetTablesAsync()
        {
            return await _context.Set<Tables>().AsNoTracking().ToListAsync();
        }

        public Tables? GetTable(int id)
        {
            return _context.Set<Tables>()
                .AsNoTracking()
                .Include(u => u.Settings)
                .Where(d => d.TableId == id)                
                .FirstOrDefault();
        }

        public async Task<Tables?> GetTableByIdAsync(int id)
        {
            return await _context.Set<Tables>()
                .AsNoTracking()
                .Include(u => u.Settings)
                .Where(d => d.TableId == id)
                .FirstOrDefaultAsync();
        }

    }
}
