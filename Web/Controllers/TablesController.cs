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
        //private readonly RepoDbContext _context;
        public TablesController(ILogger<TablesController> logger)
        {         
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            var result = "Список таблиц";
            return result;
        }
    }
}
