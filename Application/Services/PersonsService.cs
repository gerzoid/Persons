using Application.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using System.Data;

namespace Application.Services;

public class PersonsService(ITablesRepository tablesRepository, IPersonsRepository personsRepository)
{
    private readonly ITablesRepository _tablesRepository = tablesRepository;
    private readonly IPersonsRepository _personsRepository = personsRepository;
    public async Task<PersonsResponse> OpenTableAsync(PersonsRequest request)
    {
        var tab = await GetTableByIdAsync(request.TableId);
        var response = new PersonsResponse();
        tab.Adapt(response);
        response.Columns = await _personsRepository.GetColumnsOfTableAsync(tab.Shema, tab.TableName);
        //TODO вынести в отдельную процедуру, там же задавать из конфигуации и настроек видимость, перевод, возможность редактировать
        foreach (var col in response.Columns)
        {
            col.Type = ConvertTypeSQLColumnToHandsontableFormat(col.Type);
            col.ReadOnly = true;
        }

        return response;
    }
    async Task<Tables> GetTableByIdAsync(int tableId)
    {
        var tab = await _tablesRepository.GetTableByIdAsync(tableId);

        if (tab == null)
            throw new InvalidOperationException($"Table with id {tableId} not found");
        return tab;
    }

    public async Task<int?> CheckTable(string database, string shema, string tableName)
    {
        bool exist = await _personsRepository.CheckExistsTableAsync(database, shema, tableName);
        if (!exist)
            return null;

        int cnt = await _personsRepository.GetCountRowsAsync(database, shema, tableName);
        return cnt;
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
        var table = await _personsRepository.ReadTableAsync(tab.Shema, tab.TableName);
        return table;
    }


    string ConvertTypeSQLColumnToHandsontableFormat(string typeColumn)
    {
        //Dictionary<string, string> typesConvert = new Dictionary<string, string>() { { "int", "Numeric" }, { "nchar", "Text" }
        switch (typeColumn)
        {
            //case "int": return "text";
            //case "decimal": return "numeric";
            //case "bit": return "checkbox";
            case "date": return "date";
            case "smalldatetime": return "date";
            default: return "text";
        }
    }
}
