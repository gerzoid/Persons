using Application.Common.Dto;
using Application.Services;
using Domain.Entities;
using Infrastructure.Database.RepoDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Helpers;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class TablesController : ControllerBase
    {
        private readonly ILogger<TablesController> _logger;
        private readonly TablesService _tablesService;
        private readonly PersonsService _personsService;

        //private readonly RepoDbContext _context;
        public TablesController(ILogger<TablesController> logger, TablesService tablesService, PersonsService personsService)
        {
            _logger = logger;
            _tablesService = tablesService;
            _personsService = personsService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TablesDto>> Get()
        {
            var result = _tablesService.GetTables();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<TablesDto> Get(int id)
        {
            var result = _tablesService.GetTable(id);
            _personsService.GetColumnsOfTable(result.Shema, result.TableName);

            return Ok(result);
        }

    }
}
