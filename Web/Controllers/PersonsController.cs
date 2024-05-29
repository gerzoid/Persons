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
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<TablesController> _logger;
        private readonly PersonsService _personsService;

        //private readonly RepoDbContext _context;
        public TablesController(ILogger<TablesController> logger, PersonsService personsService)
        {
            _logger = logger;
            _personsService = personsService;
        }
        [HttpGet]

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
