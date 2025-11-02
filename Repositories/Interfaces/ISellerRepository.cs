using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Repositories.Interfaces
{
    public interface ISellerRepository
    {
        public bool CheckIfSellerExists(int sellerId);
        public int Create(Seller newSeller);
        public List<Seller> GetAll();
        public Seller? GetById(int sellerId);
        public void RemoveSeller(int sellerId);
        public void Update(Seller updatedSeller, int sellerId);
        public Seller? ValidateSeller(AuthenticationRequestDto authRequestBody);
    }
}
