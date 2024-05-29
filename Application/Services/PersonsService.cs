using Application.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<PersonsResponse> OpenTableAsync(PersonsRequest request)
        {
            var tab = await GetTableByIdAsync(request.TableId);
            var response = new PersonsResponse();
            tab.Adapt(response);
            response.Columns = await _personsRepository.GetColumnsOfTableAsync(tab.Shema, tab.TableName);
            foreach (var col in response.Columns)            
                col.Type = ConvertTypeSQLColumnToHandsontableFormat(col.Type);
            
            return response;
        }
        async Task<Tables> GetTableByIdAsync(int tableId)
        {
            var tab = await _tablesRepository.GetTableByIdAsync(tableId);

            if (tab == null)
                throw new InvalidOperationException($"Table with id {tableId} not found");
            return tab;
        }

        public async Task<List<Column>> GetColumnsOfTable(string shema, string tableName)
        {            
            var columns = await _personsRepository.GetColumnsOfTableAsync(shema, tableName);
            return columns;
        }

        //public List<Dictionary<string, object>> GetData(QueryPersonsRequest request)
        public async Task<DataTable> GetDataAsync(QueryPersonsRequest request)
        {
            var tab = await GetTableByIdAsync(request.TableId);
            var table  = await _personsRepository.ReadTableAsync(tab.TableName);
            return table;
            /*Dbf dbf = new Dbf();

            var rows = new List<Dictionary<string, object>>();

            int startRow = data.PageSize * (data.Page - 1);
            startRow = startRow >= dbf.CountRows ? dbf.CountRows : startRow;
            int endRow = startRow + data.PageSize > dbf.CountRows ? dbf.CountRows : startRow + data.PageSize;

            for (int indexRow = startRow; indexRow < endRow; indexRow++)
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                for (int i = 0; i < dbf.CountColumns; i++)
                {
                    values.Add(dbf.GetColumnName(i), dbf.GetValue(i, indexRow));
                }
                values.Add("_IS_DELETED_", dbf.IsDeleted(indexRow));
                rows.Add(values);
            }            
            */
            var rows = new List<Dictionary<string, object>>();

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
