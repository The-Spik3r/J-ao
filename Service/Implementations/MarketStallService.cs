using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class MarketStallService : IMarketStallService
    {
        private readonly IMarketStallRepository _repository;

        public MarketStallService(IMarketStallRepository repository)
        {
            _repository = repository;
        }

        public bool CheckIfMarketStallExists(int marketStallId)
        {
            return _repository.CheckIfMarketStallExists(marketStallId);
        }

        public bool CheckIfSellerHasMarketStall(int sellerId)
        {
            return _repository.CheckIfSellerHasMarketStall(sellerId);
        }

        public int Create(CreateAndUpdateMarketStallDto newMarketStall)
        {
            // Validate that the seller doesn't already have a market stall (one-to-one constraint)
            if (CheckIfSellerHasMarketStall(newMarketStall.SellerId))
            {
                throw new InvalidOperationException($"El vendedor con ID {newMarketStall.SellerId} ya tiene un puesto de mercado asignado.");
            }

            return _repository.Create(newMarketStall);
        }

        public List<MarketStall> GetAll()
        {
            return _repository.GetAll();
        }

        public MarketStall? GetById(int marketStallId)
        {

            return _repository.GetById(marketStallId);
        }

        public MarketStall? GetBySellerId(int sellerId)
        {
            return _repository.GetBySellerId(sellerId);
        }

        public void RemoveMarketStall(int marketStallId)
        {
            _repository.RemoveMarketStall(marketStallId);
        }

        public void Update(CreateAndUpdateMarketStallDto updatedMarketStall, int marketStallId)
        {
            // Get the current market stall to check if SellerId is changing
            var currentMarketStall = _repository.GetById(marketStallId);
            if (currentMarketStall != null && currentMarketStall.SellerId != updatedMarketStall.SellerId)
            {
                // If changing seller, validate the new seller doesn't already have a market stall
                if (CheckIfSellerHasMarketStall(updatedMarketStall.SellerId))
                {
                    throw new InvalidOperationException($"El vendedor con ID {updatedMarketStall.SellerId} ya tiene un puesto de mercado asignado.");
                }
            }

            _repository.Update(updatedMarketStall, marketStallId);
        }
    }
}