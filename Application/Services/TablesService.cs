using Application.Common.Dto;
using Application.Common.Models;
using Application.Services.Identity.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace Application.Services;

public class TablesService(ITablesRepository tablesRepo, UserService userService)
{
    private readonly ITablesRepository _tablesRepo = tablesRepo;
    private readonly UserService _userService = userService;

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
        tab.CreatedAt = DateTime.Now;
        //var user = _identity.GetCurrentUser();
        var user = _userService.Users()[0]; //TODO 
        tab.UserId = user!=null ? user.Id : 0;                

        return await _tablesRepo.CreateTableAsync(tab);
    }
    public async Task<Tables> UpdateTableAsync([FromBody] CreateTableRequest table)
    {
        var tab = table.Adapt<Tables>();
        tab.UpdatedAt = DateTime.Now;
        return await _tablesRepo.UpdateTableAsync(tab); //TODO
    }
}
