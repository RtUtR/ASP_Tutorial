using ASp_Tutorial.Controllers.Second_Day.Models.Dtos;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace ASp_Tutorial.Controllers.Third_Day.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    ProductResponseDto? GetById(int id);
    ProductResponseDto Create(CreateProductDto createProductDto);
    bool Update(int id , UpdateProductDto x);
    bool Delete(int id);
}
