using Jīao.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jīao.Entities
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirtName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public State State { get; set; } = State.Active;

        public ICollection<MarketStall> MarketStalls { get; set; } = new List<MarketStall>();
    }
}
