using ASp_Tutorial.Controllers.Second_Day.Models.Dtos;
using ASp_Tutorial.Controllers.Third_Day.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial.Controllers.Third_Day
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdDAyDIController(IProductService _productService) : Controller
    {
        //DI Dependency Injection
        [HttpGet("GetAll_V3")]
        public ActionResult Getall()
        {
            var i = _productService.GetAll();
            return Ok(i);
        }
        [HttpGet("getbyid/{id:int}")]
        public ActionResult GetById(int id)
        {
            ProductResponseDto? i = _productService.GetById(id);
            return i is null ? NotFound() : Ok(i);
        }
        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateProductDto x)
        {
            ProductResponseDto Res = _productService.Create(x);
            return CreatedAtAction(nameof(GetById), new { id = Res.Id }, Res);

        }
        [HttpPut("Update/{id:int}")]
        public ActionResult Update(int id, [FromBody] UpdateProductDto UpdatePro)
        {
            bool Res = _productService.Update(id, UpdatePro);
            if(!Res) return NotFound();
            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
           bool Res =  _productService.Delete(id);
            if(!Res) return NotFound();
            return NoContent();
        }
    }
}
