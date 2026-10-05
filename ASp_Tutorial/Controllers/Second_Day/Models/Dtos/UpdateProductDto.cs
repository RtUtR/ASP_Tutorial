using System.ComponentModel.DataAnnotations;

namespace ASp_Tutorial.Controllers.Second_Day.Models.Dtos
{

    public record UpdateProductDto(
    [Required]
    [MaxLength(100)]
    string Name,

    [Required]
    [Range(0, 1000000)]
    decimal Price,

    [Required]
    [MaxLength(50)]
    string Category);
}