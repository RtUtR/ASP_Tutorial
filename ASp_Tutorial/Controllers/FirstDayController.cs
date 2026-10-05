using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASp_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstDayController : ControllerBase
    {
        private static List<ProductDto> _product = new()
        {
            new(1, "laptop", 1500, "Electronics"),
            new(2, "Phone", 800, "Electronics"),
            new(3, "Book", 20, "Books")
        };

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] string? Cat)
        {
           List<ProductDto> i =string.IsNullOrWhiteSpace(Cat) || string.IsNullOrEmpty(Cat)
                ?_product
                :_product.Where(w=>w.Category== Cat).ToList();
                return Ok(i);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var res=_product.FirstOrDefault(w=>w.Id==id);
            return res is null ? NotFound("پیدا نشد ") : Ok(res);
        }

        [HttpGet("expensive/{price:decimal?}")]
        public IActionResult GetExpensive(decimal? price)
        {
            var pri = price ?? 100;
            return Ok(_product.Where(w => w.Price >= pri).ToList());
        }

        [HttpGet("by-category/{name:alpha}")]
        public IActionResult GetByCategory(string name)
        {
            var result = _product.Where(p => p.Category == name).ToList();
            return result is null?NotFound():Ok(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            ProductDto newProduct = new(
                Category: dto.Category,
                Id : _product.Count + 1,
                Name:dto.Name,
                Price:dto.Price
                );
            _product.Add(newProduct);
            // createdataction -> https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdataction?view=aspnetcore-10.0
            return CreatedAtAction(nameof(GetById),new {id=newProduct.Id},newProduct);
        }


        // DTO's
        public record ProductDto(int Id, string Name, decimal Price, string Category);
        public record CreateProductDto(
        [Required][MaxLength(100)] string Name,
        [Range(0, 20000)] decimal Price,
        [Required] string Category
        );
    }

}
