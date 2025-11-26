using Jīao.Entities;
using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateMenuDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public int CategoryId { get; init; }

        public bool IsFeatured { get; init; }
        public bool IsHappyHour { get; init; }
        public int DiscountPercentage { get; init; }

        public CreateAndUpdateMenuDto() { }
    }
}
