using ASp_Tutorial.Controllers.Second_Day.Models.Dtos;
using ASp_Tutorial.Controllers.Second_Day.Models.entities;
using System.Runtime.CompilerServices;

namespace ASp_Tutorial.Controllers.Second_Day.Mapper
{
    public static class ProductMapper
    {
        private static int idpl = 3;
        public static Product ToEntity(this CreateProductDto _dto)
        {

            Product New = new Product()
            {
                Category = _dto.Category,
                Name = _dto.Name,
                CreatedAt = DateTime.UtcNow,
                Price = _dto.Price,
                Id = idpl + 1
            };
            return New;
        }
        public static ProductResponseDto ToResponse(this Product entity)
        {
            return new ProductResponseDto
            (
            Id: entity.Id,
            Name: entity.Name,
            Price: entity.Price,
            Category: entity.Category,
            CreatedAt: entity.CreatedAt
            );
        }
        public static ProductListDto ToListDto(this Product entity)
        {
            return new ProductListDto(
                entity.Id,
                entity.Name,
                entity.Price
            );
        }
    }
}
