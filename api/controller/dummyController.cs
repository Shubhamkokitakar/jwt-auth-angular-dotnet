using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DummyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Dummy API is working");
        }

        [HttpPost]
        public IActionResult Create([FromBody] DummyRequest request)
        {
            return Ok(request);
        }
    }
}
