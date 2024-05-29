using Application.Common.Models;
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
        public PersonsResponse OpenTable(PersonsRequest request)
        {
            var tab = _tablesRepository.GetTableById(request.TableId);
            
            if (tab ==null)
                throw new InvalidOperationException($"Table with id {request.TableId} not found");
                                  
            var response = new PersonsResponse();
            tab.Adapt(response);
            response.Columns = _personsRepository.GetColumnsOfTable(tab.Shema, tab.TableName);
            foreach (var col in response.Columns)            
                col.Type = ConvertTypeSQLColumnToHandsontableFormat(col.Type);
            
            return response;
        }
        public List<Column> GetColumnsOfTable(string shema, string tableName)
        {
            var columns = _personsRepository.GetColumnsOfTable(shema, tableName);
            return columns;
        }

        string ConvertTypeSQLColumnToHandsontableFormat(string typeColumn)
        {
            //Dictionary<string, string> typesConvert = new Dictionary<string, string>() { { "int", "Numeric" }, { "nchar", "Text" }
            switch (typeColumn)
            {
                //case "int": return "text";
                //case "decimal": return "numeric";
                //case "bit": return "checkbox";
                //case "date": return "date";
                //case "smalldatetime": return "date";
                default: return "text";
            }
        }
    }
}
