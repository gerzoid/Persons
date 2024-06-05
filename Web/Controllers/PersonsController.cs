using Application.Common.Dto;
using Application.Common.Models;
using Application.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly PersonsService _personsService;

        //private readonly RepoDbContext _context;
        public PersonsController(ILogger<PersonsController> logger, PersonsService personsService)
        {
            _logger = logger;
            _personsService = personsService;
        }

        //¬озвращает первичную информацию о таблице, список колонок, название, кол-во записей
        [HttpPost]
        [Route("opentable")]
        public async Task<ActionResult<PersonsResponse>> OpenTableAsync([FromBody] PersonsRequest request)
        {
            var result = await _personsService.OpenTableAsync(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("getdata")]
        public async Task<ActionResult> GetData([FromBody] QueryPersonsRequest request)
        {
            var result = await _personsService.GetDataAsync(request);
            return Ok(DataTableToJsonSerializer.SystemTextJson(result));
        }

        [HttpPost]
        [Route("checktable")]
        public async Task<ActionResult> CheckTable(string database, string shema, string tableName)
        {
            var result = await _personsService.CheckTable(database, shema, tableName);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}
