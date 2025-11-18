using Jīao.Models.Dtos;
using Jīao.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jīao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketStallController : ControllerBase
    {
        private readonly IMarketStallService _marketStallService;

        public MarketStallController(IMarketStallService marketStallService)
        {
            _marketStallService = marketStallService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_marketStallService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            var marketStall = _marketStallService.GetById(id);

            if (marketStall is null)
            {
                return NotFound();
            }

            var marketStallDto = new MarketStallDto(marketStall.Id, marketStall.Name, marketStall.Description, marketStall.Location, marketStall.SellerId);

            return Ok(marketStallDto);
        }

        [HttpGet("seller/{sellerId}")]
        public IActionResult GetBySellerId(int sellerId)
        {
            if (sellerId == 0)
            {
                return BadRequest("El ID del vendedor debe ser distinto de 0");
            }

            var marketStall = _marketStallService.GetBySellerId(sellerId);

            if (marketStall is null)
            {
                return NotFound("No se encontró un puesto de mercado para este vendedor");
            }

            var marketStallDto = new MarketStallDto(marketStall.Id, marketStall.Name, marketStall.Description, marketStall.Location, marketStall.SellerId);

            return Ok(marketStallDto);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateMarketStall(CreateAndUpdateMarketStallDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto no puede ser nulo");
            }

            int response;
            try
            {
                response = _marketStallService.Create(dto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", response);
        }

        [HttpPut("{marketStallId}")]
        public IActionResult UpdateMarketStall(CreateAndUpdateMarketStallDto dto, int marketStallId)
        {
            if (!_marketStallService.CheckIfMarketStallExists(marketStallId))
            {
                return NotFound();
            }
            try
            {
                _marketStallService.Update(dto, marketStallId);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteMarketStall(int id)
        {
            try
            {
                _marketStallService.RemoveMarketStall(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }
    }
}