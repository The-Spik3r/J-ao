using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Implementations;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class SellerService : ISellerService
    {
        private ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        public bool CheckIfSellerExists(int sellerId)
        {
            return _sellerRepository.CheckIfSellerExists(sellerId);
        }

        public SellerDto Create(CreateAndUpdateSellerDto dto)
        {
            Seller seller = new Seller()
            {
                Email = dto.Email,
                FirtName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                MarketStalls = dto.MarketStalls,
                State = dto.State,
            };
            int newId = _sellerRepository.Create(seller);
            var newSellerDto = new SellerDto(newId, seller.FirtName, seller.LastName, seller.Email, seller.State);
            return newSellerDto;
        }

        public IEnumerable<SellerDto> GetAll()
        {
            return _sellerRepository.GetAll().Select(s => new SellerDto(s.Id, s.FirtName, s.LastName, s.Email, s.State));
        }

        public GetSellerByIdDto? GetById(int sellerId)
        {
            var seller = _sellerRepository.GetById(sellerId);
            if (seller is not null)
            {
                return new GetSellerByIdDto(seller.Id, seller.FirtName, seller.LastName, seller.Email, seller.State);
            }
            return null;
        }

        public void RemoveSeller(int sellerId)
        {
            _sellerRepository.RemoveSeller(sellerId);
        }

        public void Update(CreateAndUpdateSellerDto dto, int sellerId)
        {
            var seller = new Seller()
            {
                Email = dto.Email,
                State = dto.State,
                FirtName = dto.FirstName,
                LastName = dto.LastName,
                MarketStalls = dto.MarketStalls,
                Password = dto.Password,
            };
            _sellerRepository.Update(seller, sellerId);
        }

        public Seller? ValidateSeller(AuthenticationRequestDto authRequestBody)
        {
            Seller? result = null;
            if (!string.IsNullOrEmpty(authRequestBody.Email) && !string.IsNullOrEmpty(authRequestBody.Password)) //verifico que no sean null (no deberían por definición) ni que sea un string vacío
                result = _sellerRepository.ValidateSeller(authRequestBody: new AuthenticationRequestDto(authRequestBody.Email, authRequestBody.Password));
            return result;
        }
    }
}
