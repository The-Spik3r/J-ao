using Jīao.Entities;
using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateCategoryDto
    {
        public string Name { get; init; }
        public int MarketStallId { get; init; }
        public string Description { get; init; }
        public string FotoUrl { get; init; }

        public CreateAndUpdateCategoryDto() { }
    }
}
