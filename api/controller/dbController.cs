using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/neon")]
    public class NeonController : ControllerBase
    {
        private readonly IProductService _service;

        public NeonController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("use-value")]
        public IActionResult UseValue([FromBody] PlayingWithNeonData data)
        {
            float processedValue = _service.ProcessValue(data);
            _service.InsertData(data);

            return Ok(new
            {
                OriginalValue = data.Value,
                ProcessedValue = processedValue
            });
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var allData = _service.GetAllData();
            return Ok(allData);
        }
    }
}
