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
        private readonly IUserService _userService;
        private readonly ISellerService _sellerService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IUserService userService,
            ISellerService sellerService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _sellerService = sellerService;
            _authenticationService = authenticationService;
        }

        [HttpPost("user/authenticate")]
        public IActionResult UserAuthenticate(AuthenticationRequestDto authenticationRequestBody)
        {
            var user = _userService.ValidateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

            var token = _authenticationService.GenerateTokenJWT(
                userType.User,
                user.Id,
                user.FirstName,
                user.LastName);

            return Ok(token);
        }

        [HttpPost("seller/authenticate")]
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