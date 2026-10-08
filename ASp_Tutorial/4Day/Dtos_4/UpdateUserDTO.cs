using System.ComponentModel.DataAnnotations;

namespace ASp_Tutorial._4Day.Dtos_4
{
    public record UpdateuserDTO(
        [Required] string Name,
        bool IsMarried,
        string Phone
        );
}
