using Microsoft.AspNetCore.Mvc;
using Sales_CRUD.Services;
using System.Threading.Tasks;

namespace Sales_CRUD.Controllers
{
    [Route("api/DatabaseTest")]
    [ApiController]
    public class DatabaseTestController : ControllerBase
    {
        private readonly DatabaseTestService _databaseTestService;

        public DatabaseTestController(DatabaseTestService databaseTestService)
        {
            _databaseTestService = databaseTestService;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var canConnect = await _databaseTestService.CanConnectAsync();
            if (canConnect)
            {
                return Ok("Connection to the DB is successfull.");
            }
            else
            {
                return StatusCode(500, "Failed to connect to the DB.");
            }
        }
    }
}
