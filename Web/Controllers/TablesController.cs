using Application.Common.Dto;
using Application.Common.Models;
using Application.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(result);
        }

        //¬озвращает первичную информацию о таблице, список колонок, название, кол-во записей
        [HttpPost]
        [Route("opentable")]
        public ActionResult<PersonsResponse> OpenTable([FromBody] PersonsRequest request)
        {
            var result = _personsService.OpenTable(request);
            return Ok(result);
            //return Ok(DataTableToJsonSerializer.SystemTextJson(result));
        }


    }
}
