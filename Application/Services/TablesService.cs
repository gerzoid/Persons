using Application.Common.Dto;
using Application.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using System.Web.Http;

namespace Application.Services
{
    public class TablesService
    {
        private readonly ITablesRepository _tablesRepo;
        public TablesService(ITablesRepository tablesRepository)
        {
            _tablesRepo = tablesRepository;
        }
        public async Task<IEnumerable<TablesDto>> GetTablesAsync()
        {
            return (await _tablesRepo
                .GetTablesAsync())
                .Adapt<IEnumerable<Tables>, IEnumerable<TablesDto>>();
        }
        public async Task<TablesDto> GetTableAsync(int id)
        {
            return (await _tablesRepo.GetTableByIdAsync(id)).Adapt<Tables, TablesDto>();
            //var tableDTO = table.Adapt<Tables, TablesDto>();
            //return tableDTO;
        }

        public async Task<int> CreateTableAsync([FromBody] CreateTableRequest table)
        {
            var tab = table.Adapt<Tables>();
            return await _tablesRepo.CreateTableAsync(tab);
        }
        public async Task<int> UpdateTableAsync([FromBody] CreateTableRequest table)
        {
            var tab = table.Adapt<Tables>();
            return await _tablesRepo.CreateTableAsync(tab); //TODO
        }

    }

}
