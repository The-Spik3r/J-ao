using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jīao.Entities
{
    public class MarketStall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int Views { get; set; }
        public int SellerId { get; set; }

        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}

