using Application.Common.Dto;
using Application.Common.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize(Roles = "Administrator")]
    public class TablesController : ControllerBase
    {
        private readonly ILogger<TablesController> _logger;
        private readonly TablesService _tablesService;

        //private readonly RepoDbContext _context;
        public TablesController(ILogger<TablesController> logger, TablesService tablesService)
        {
            _logger = logger;
            _tablesService = tablesService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TablesDto>>> Get()
        {
            var result = await _tablesService.GetTablesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TablesDto>> GetAsync(int id)
        {
            var result = await _tablesService.GetTableAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<TablesDto>> CreateTableAsync([FromBody]CreateTableRequest request)
        {
            var result = await _tablesService.CreateTableAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Tables>> UpdateTableAsync([FromBody]CreateTableRequest request)
        {
            var table = await _tablesService.UpdateTableAsync(request);
            return Ok(table);
        }

    }
}
