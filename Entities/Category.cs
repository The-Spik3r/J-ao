using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jīao.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string FotoUrl { get; set; }

        public int MarketStallId { get; set; }

        [ForeignKey("MarketStallId")]
        public MarketStall MarketStall { get; set; }

        public ICollection<Menu> Menus { get; set;} = new List<Menu>();
    }
}
