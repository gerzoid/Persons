using Application.Common.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services
{
    public class TablesService
    {
        private readonly ITablesRepository _tablesRepo;
        public TablesService(ITablesRepository tablesRepository)
        {
            _tablesRepo = tablesRepository;
        }
        public IEnumerable<TablesDto> GetTables()
        {            
            return _tablesRepo
                .GetTables()
                .Adapt<IEnumerable<Tables>, IEnumerable<TablesDto>>();
        }
        public TablesDto GetTable(int id)
        {
            return _tablesRepo.GetTableById(id).Adapt<Tables, TablesDto>();
        }

        public void AddTable(TablesDto table)
        {
            var tab = table.Adapt<Tables>();
            _tablesRepo.AddTable(tab);
        }
    }

}
