using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jīao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService SellerService)
        {
            _sellerService = SellerService;
        }

        [HttpGet]
        public ActionResult<SellerDto> GetAll()
        {
            return Ok(_sellerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            var user = _sellerService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            var userDto = new SellerDto(user.Id, user.FirstName, user.LastName, user.Email, user.State);

            return Ok(userDto);

        }

        [HttpPost]
        [AllowAnonymous] 
        public IActionResult CreateSeller(CreateAndUpdateSellerDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto no puede ser nulo");
            }

            SellerDto response = null;
            try
            {
                response = _sellerService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", response);
        }

        [HttpPut("{sellerId}")]
        public IActionResult UpdateSeller(CreateAndUpdateSellerDto dto, int sellerId)
        {
            if (!_sellerService.CheckIfSellerExists(sellerId))
            {
                return NotFound();
            }
            try
            {
                _sellerService.Update(dto, sellerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteSeller(int id)
        {
            try
            {
                _sellerService.RemoveSeller(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("me")]
        public ActionResult<GetSellerByIdDto> GetSellerInfo()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("sub"))!.Value);
            var user = _sellerService.GetById(userId);
            return Ok(user);
        }

        [HttpGet("{sellerId}/marketstall")]
        public IActionResult GetSellerMarketStall(int sellerId)
        {
            if (sellerId == 0)
            {
                return BadRequest("El ID del vendedor debe ser distinto de 0");
            }

            var seller = _sellerService.GetById(sellerId);
            if (seller is null)
            {
                return NotFound("Vendedor no encontrado");
            }

            if (seller.MarketStall is null)
            {
                return NotFound("El vendedor no tiene un puesto de mercado asignado");
            }

            return Ok(seller.MarketStall);
        }

    }
}
