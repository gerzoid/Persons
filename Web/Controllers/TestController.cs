using Domain.Entities;
using Infrastructure.Database;
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
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        private readonly RepoDbContext _context;
        public TestController(ILogger<TestController> logger, RepoDbContext context)
        {         
            _logger = logger;
            _context = context;
        }
        [HttpGet("get-imports")]
        public IEnumerable<Imports> Get()
        {
            var result = _context.QueryAll<Imports>();
            return result;
        }
    }
}
