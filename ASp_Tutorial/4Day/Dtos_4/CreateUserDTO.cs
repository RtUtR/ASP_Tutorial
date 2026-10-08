using System.ComponentModel.DataAnnotations;

namespace ASp_Tutorial._4Day.Dtos_4
{
    public record CreateUserDTO(
        [Required][MaxLength(20)] string Name,
        [Required][MaxLength(20)] string LastName,
        string phone,
        bool IsMarried
        );
}
