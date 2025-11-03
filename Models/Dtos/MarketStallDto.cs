namespace Jīao.Models.Dtos
{
    public record MarketStallDto(
        int Id,
        string Name,
        string Description,
        string Location,
        int SellerId
    );
}