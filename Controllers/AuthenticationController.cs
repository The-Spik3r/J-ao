using Jīao.Models.Dtos;
using Jīao.Models.Enum;
using Jīao.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jīao.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            ISellerService sellerService,
            IAuthenticationService authenticationService)
        {
            _sellerService = sellerService;
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public IActionResult SellerAuthenticate(AuthenticationRequestDto authenticationRequestBody)
        {
            var seller = _sellerService.ValidateSeller(authenticationRequestBody);

            if (seller is null)
                return Unauthorized();

            var token = _authenticationService.GenerateTokenJWT(
                userType.Seller,
                seller.Id,
                seller.FirtName,
                seller.LastName);

            return Ok(token);
        }
    }
}