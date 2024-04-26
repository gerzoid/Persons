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
        public WeatherForeCastController(ILogger<WeatherForeCastController> logger, TablesService tablesService)
        {         
            _logger = logger;
            _tableService = tablesService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = _tableService.GetTables();
            Console.WriteLine(a.Count());
            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
