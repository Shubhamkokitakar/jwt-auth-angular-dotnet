using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace api.Controllers
{
    [ApiController]
    [Route("api/db-test")]
    public class DbTestController : ControllerBase
    {
        private readonly NpgsqlConnection _connection;

        public DbTestController(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        [HttpGet("check")]
        public IActionResult CheckConnection()
        {
            try
            {
                _connection.Open();

                using var cmd = new NpgsqlCommand("SELECT NOW();", _connection);
                var result = cmd.ExecuteScalar();

                _connection.Close();

                return Ok(new
                {
                    Message = "Connected to Neon DB successfully",
                    ServerTime = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
