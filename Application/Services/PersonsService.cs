using Application.Common.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using System.Data;

namespace Application.Services
{
    public class PersonsService
    {
        private readonly ITablesRepository _tablesRepository;
        private readonly IPersonsRepository _personsRepository;
        public PersonsService(ITablesRepository tablesRepository, IPersonsRepository personsRepository)
        {
            _tablesRepository = tablesRepository;
            _personsRepository = personsRepository;
        }
        public DataTable ReadTable(string tableName)
        {
            var resultTable = _personsRepository.ReadTable(tableName);
            return resultTable;
        }
        public string[] GetColumnsOfTable(string shema, string tableName)
        {
            var columns = _personsRepository.GetColumnsOfTable(shema, tableName);
            return columns;
        }

    }
}
