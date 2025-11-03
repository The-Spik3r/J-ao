using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record MenuDto(int Id, string Name, decimal Price, int Stock, string Description, string ImageUrl, int CategoryId);
}
