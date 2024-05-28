using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    //[Authorize]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        //private readonly RepoDbContext _context;
        public TestController(ILogger<TestController> logger)
        {         
            _logger = logger;
        }
        [HttpGet("get-imports")]
        public IEnumerable<Imports> Get()
        {
            var result = new List<Imports>();
            return result;
        }
    }
}
