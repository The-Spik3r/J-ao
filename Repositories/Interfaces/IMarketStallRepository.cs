using Jīao.Entities;
using Jīao.Models.Dtos;
using Jiao.Models.Dtos;

namespace Jīao.Repositories.Interfaces
{
    public interface IMarketStallRepository
    {
        public int Create(CreateAndUpdateMarketStallDto newMarketStall);
        public List<MarketStall> GetAll();
        public MarketStall? GetById(int marketStallId);
        public void RemoveMarketStall(int marketStallId);
        public void Update(CreateAndUpdateMarketStallDto updatedMarketStall, int marketStallId);
        public bool CheckIfMarketStallExists(int marketStallId);
        public bool CheckIfSellerHasMarketStall(int sellerId);
        public MarketStall? GetBySellerId(int sellerId);
        public void IncrementViews(int marketStallId);
        public List<SimpleMarketStallReportDto> Analist();
    }
}