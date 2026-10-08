namespace ASp_Tutorial._4Day.Dtos_4
{
    public record ResponseUserDTO(
        int Id,
        string Name,
        string LastName,
        DateTimeOffset register
        );
}
