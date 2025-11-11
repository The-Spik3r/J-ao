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

        public int Create(CreateAndUpdateMarketStallDto newMarketStall)
        {
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

        public void RemoveMarketStall(int marketStallId)
        {
            _repository.RemoveMarketStall(marketStallId);
        }

        public void Update(CreateAndUpdateMarketStallDto updatedMarketStall, int marketStallId)
        {
            _repository.Update(updatedMarketStall, marketStallId);
        }
    }
}   