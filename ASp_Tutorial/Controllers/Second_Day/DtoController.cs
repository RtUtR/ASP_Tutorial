using ASp_Tutorial.Controllers.Second_Day.Mapper;
using ASp_Tutorial.Controllers.Second_Day.Models.Dtos;
using ASp_Tutorial.Controllers.Second_Day.Models.entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial.Controllers.Second_Day
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtoController : ControllerBase
    {
        private static readonly List<Product> _products = new()
    {
        new() { Id = 1, Name = "Laptop", Price = 1500, Category = "Electronics" },
        new() { Id = 2, Name = "Phone", Price = 800, Category = "Electronics" },
        new() { Id = 3, Name = "Book", Price = 20, Category = "Books" }
    };
        /*
         better to use actionResult<T>
        be: it would declear the type of response 
         */
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ProductListDto>> GetAll()
        {
            List<ProductListDto> Result =_products.Select(x => x.ToListDto()).ToList();
            return Ok(Result);
        }
        [HttpGet("getbyid/{id:int}")]
        public ActionResult<ProductResponseDto> GetById(int id)
        {
            Product ?x = _products.FirstOrDefault(x => x.Id == id);
            if(x == null) return NotFound();
            ProductResponseDto i = x.ToResponse();
            return Ok(i);
        }
        [HttpPost("Create")]
        public ActionResult<ProductResponseDto> Create([FromBody]CreateProductDto _create)
        {
            Product pr=_create.ToEntity();
            _products.Add(pr);
            return CreatedAtAction(nameof(GetById),new {id=pr.Id},pr.ToResponse());
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id ,[FromBody]UpdateProductDto x)
        {
            Product? product = _products.FirstOrDefault(q => q.Id == id);
            if(product == null) return NotFound();
            product.Name = x.Name;
            product.Category = x.Category;
            product.Price = x.Price;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            _products.Remove(product);

            return NoContent();
        }
    }
}