using Jīao.Data;
using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jīao.Repositories.Implementations
{
    public class SellerRepository : ISellerRepository
    {
        private JīaoContext _context;

        public SellerRepository(JīaoContext context)
        {
            _context = context;
        }
        public bool CheckIfSellerExists(int sellerId)
        {
            return _context.Sellers.Any(u => u.Id == sellerId);

        }

        public int Create(Seller newSeller)
        {
            Seller seller = _context.Sellers.Add(newSeller).Entity;
            _context.SaveChanges();
            return seller.Id;
        }

        public List<Seller> GetAll()
        {
            return _context.Sellers.Include(s => s.MarketStall).ToList();
        }

        public Seller? GetById(int sellerId)
        {
            return _context.Sellers.Include(s => s.MarketStall).SingleOrDefault(s => s.Id == sellerId);
        }

        public void RemoveSeller(int sellerId)
        {
            _context.Sellers.Remove(_context.Sellers.Single(s => s.Id == sellerId));
            _context.SaveChanges();
        }

        public void Update(Seller updatedSeller, int sellerId)
        {
            Seller sellerToUpdate = _context.Sellers.First(s => s.Id == sellerId);
            sellerToUpdate.Email = updatedSeller.Email;
            sellerToUpdate.State = updatedSeller.State;
            sellerToUpdate.Password = updatedSeller.Password;
            sellerToUpdate.FirstName = updatedSeller.FirstName;
            sellerToUpdate.LastName = updatedSeller.LastName;
            
            _context.SaveChanges();
        }

        public Seller? ValidateSeller(AuthenticationRequestDto authRequestBody)
        {
            return _context.Sellers.FirstOrDefault(s => s.Email == authRequestBody.Email && s.Password == authRequestBody.Password);

        }
    }
}
