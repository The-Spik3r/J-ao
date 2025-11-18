using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Service.Interfaces
{
    public interface IMarketStallService
    {
        public int Create(CreateAndUpdateMarketStallDto newMarketStall);
        public List<MarketStall> GetAll();
        public MarketStall? GetById(int marketStallId);
        public void RemoveMarketStall(int marketStallId);
        public void Update(CreateAndUpdateMarketStallDto updatedMarketStall, int marketStallId);
        public bool CheckIfMarketStallExists(int marketStallId);
        public bool CheckIfSellerHasMarketStall(int sellerId);
        public MarketStall? GetBySellerId(int sellerId);
    }
}