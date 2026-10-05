namespace ASp_Tutorial.Controllers.Second_Day.Models.Dtos
{
    public record ProductResponseDto(
        int Id,
        string Name,
        decimal Price,
        string Category,
        DateTime CreatedAt
    );
}
