namespace Jiao.Models.Dtos
{
    public class MarketStallAnalyticsDto
    {
        public int TotalMarketStalls { get; set; }
        public int TotalViews { get; set; }
        public double AverageViewsPerStall { get; set; }
        public MarketStallReportDto? MostViewedStall { get; set; }
        public MarketStallReportDto? LeastViewedStall { get; set; }
        public List<MarketStallReportDto> TopStallsByViews { get; set; } = new List<MarketStallReportDto>();
        public List<MarketStallReportDto> StallsByLocation { get; set; } = new List<MarketStallReportDto>();
    }
}