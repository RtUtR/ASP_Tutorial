using System.ComponentModel.DataAnnotations;

namespace ASp_Tutorial.Controllers.Second_Day.Models.Dtos
{
    public record CreateProductDto(

        [Required(ErrorMessage ="نام محصول اجباری است")]
        [MaxLength(100,ErrorMessage ="نام حداکثر 100 کاراکتر")]
        string Name,

        [Required]
        [Range(0,10000000, ErrorMessage = "قیمت باید بین 0 تا 1000000 باشد")]
        decimal Price,

        [Required(ErrorMessage = "دسته‌بندی الزامی است")]
        [MaxLength(50)]
        string Category
        );
}
