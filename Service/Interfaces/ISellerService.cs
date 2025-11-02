using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Service.Interfaces
{
    public interface ISellerService
    {
        public bool CheckIfSellerExists(int sellerId);
        public SellerDto Create(CreateAndUpdateSellerDto dto);
        public IEnumerable<SellerDto> GetAll();
        public GetSellerByIdDto? GetById(int sellerId);
        public void RemoveSeller(int sellerId);
        public void Update(CreateAndUpdateSellerDto dto, int sellerId);
        public Seller? ValidateSeller(AuthenticationRequestDto authRequestBody);
    }
}
