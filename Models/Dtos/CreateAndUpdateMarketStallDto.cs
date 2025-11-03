using System.ComponentModel.DataAnnotations;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateMarketStallDto
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public string Location { get; init; }

        public int SellerId { get; init; }

        public CreateAndUpdateMarketStallDto() { }
    }
}