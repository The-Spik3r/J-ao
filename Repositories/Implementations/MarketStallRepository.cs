using Jīao.Data;
using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jīao.Repositories.Implementations
{
    public class MarketStallRepository : IMarketStallRepository
    {
        private readonly JīaoContext _context;

        public MarketStallRepository(JīaoContext context)
        {
            _context = context;
        }

        public bool CheckIfMarketStallExists(int marketStallId)
        {
            return _context.MarketStalls.Any(ms => ms.Id == marketStallId);
        }

        public bool CheckIfSellerHasMarketStall(int sellerId)
        {
            return _context.MarketStalls.Any(ms => ms.SellerId == sellerId);
        }

        public int Create(CreateAndUpdateMarketStallDto newMarketStall)
        {
            MarketStall marketStallNew = new MarketStall()
            {
                Name = newMarketStall.Name,
                Description = newMarketStall.Description,
                Location = newMarketStall.Location,
                SellerId = newMarketStall.SellerId,
            };

            MarketStall marketStall = _context.MarketStalls.Add(marketStallNew).Entity;
            _context.SaveChanges();
            return marketStall.Id;
        }

        public List<MarketStall> GetAll()
        {
            return _context.MarketStalls.Include(ms => ms.Seller).ToList();
        }

        public MarketStall? GetById(int marketStallId)
        {
            return _context.MarketStalls.Include(ms => ms.Seller).SingleOrDefault(ms => ms.Id == marketStallId);
        }

        public MarketStall? GetBySellerId(int sellerId)
        {
            return _context.MarketStalls.Include(ms => ms.Seller).SingleOrDefault(ms => ms.SellerId == sellerId);
        }

        public void RemoveMarketStall(int marketStallId)
        {
            _context.MarketStalls.Remove(_context.MarketStalls.Single(ms => ms.Id == marketStallId));
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateMarketStallDto updatedMarketStall, int marketStallId)
        {
            MarketStall marketStallToUpdate = _context.MarketStalls.First(ms => ms.Id == marketStallId);
            marketStallToUpdate.Name = updatedMarketStall.Name;
            marketStallToUpdate.Description = updatedMarketStall.Description;
            marketStallToUpdate.Location = updatedMarketStall.Location;
            marketStallToUpdate.SellerId = updatedMarketStall.SellerId;
            _context.SaveChanges();
        }
    }
}