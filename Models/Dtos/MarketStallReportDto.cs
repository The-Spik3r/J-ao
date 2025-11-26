namespace Jiao.Models.Dtos
{
    public class MarketStallReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Views { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; } = string.Empty;
        public string SellerEmail { get; set; } = string.Empty;
        public int CategoriesCount { get; set; }
        public int MenusCount { get; set; }
    }
}