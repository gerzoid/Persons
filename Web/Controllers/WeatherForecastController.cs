using Application.Services;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Helpers;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    //[Authorize]
    public class WeatherForeCastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForeCastController> _logger;
        private readonly TablesService _tableService;
        private readonly PersonsService _peopleService;
        public WeatherForeCastController(ILogger<WeatherForeCastController> logger, TablesService tablesService, PersonsService personsService)
        {         
            _logger = logger;
            _tableService = tablesService;
            _peopleService = personsService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = _tableService.GetTable(3);
            Console.WriteLine(a.Name);
            //var t = _peopleService.ReadTable(a.TableName);
            //Console.WriteLine(t.Rows.Count);
            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("test")]
        public ActionResult Test()
        {
            var a = _tableService.GetTable(3);
            Console.WriteLine(a.Name);
            //var t = _peopleService.ReadTable(a.TableName);
            //Console.WriteLine(t.Rows.Count);

            return Ok();
            //return Ok( DataTableToJsonSerializer.SystemTextJson());
        }

    }
}
