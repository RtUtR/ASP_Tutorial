using ASp_Tutorial._4Day.Dtos_4;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ASp_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelBindingDay_5Controller : Controller
    {
        [HttpGet("{ProductID:int}")]
        public IActionResult Index([FromRoute(Name = "ProductID")] int id)
        {
            return Ok(id);
        }
        [HttpGet]
        public IActionResult Querry([FromQuery] string? name, int? age = 1)
        {
            return Ok(new { name, age });
        }
        //frombody ->Json /xml. frombody can only use one time
        [HttpPost]
        public IActionResult FromBody([FromBody] CreateUserDTO x)
        {
            return Ok(x);
        }
        [HttpGet("cc")]
        public IActionResult Get([FromHeader(Name = "Authorization")] string apiKey)
        {
            return Ok(new { apiKey });
        }
        [HttpPost("ff")]
        public IActionResult Upload([FromForm] string description)
        {
            return Ok();
        }
        [HttpGet("dd")]
        public IActionResult GetAll([AsParameters] ProductFilter filter)
        {
            return Ok(new
            {
                filter.Search,
                filter.Category,
                filter.page,
                filter.pageSize
            });
        }
    }
        public record ProductFilter
        (
            string? Search,
            string? Category,
            int page = 1,
            int pageSize = 10
        );
}
