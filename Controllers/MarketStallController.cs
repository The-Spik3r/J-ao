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
            var marketStalls = _marketStallService.GetAll();
        
            var marketStallDtos = marketStalls.Select(ms => new
            {
                Id = ms.Id,
                Name = ms.Name,
                Description = ms.Description,
                Location = ms.Location,
                Views = ms.Views,
                SellerId = ms.SellerId,
                Seller = ms.Seller != null ? new
                {
                    Id = ms.Seller.Id,
                    FirstName = ms.Seller.FirstName,
                    LastName = ms.Seller.LastName,
                    Email = ms.Seller.Email,
                    State = ms.Seller.State
                } : null,
                Categories = ms.Categories.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    MarketStallId = c.MarketStallId,
                    Description = c.Description,
                    FotoUrl = c.FotoUrl
                }).ToList()
            }).ToList();
  
            return Ok(marketStallDtos);
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

            var marketStallDto = new
            {
                Id = marketStall.Id,
                Name = marketStall.Name,
                Description = marketStall.Description,
                Location = marketStall.Location,
                Views = marketStall.Views,
                SellerId = marketStall.SellerId,
                Seller = marketStall.Seller != null ? new
                {
                    Id = marketStall.Seller.Id,
                    FirstName = marketStall.Seller.FirstName,
                    LastName = marketStall.Seller.LastName,
                    Email = marketStall.Seller.Email,
                    State = marketStall.Seller.State
                } : null,
                Categories = marketStall.Categories.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    MarketStallId = c.MarketStallId,
                    Description = c.Description,
                    FotoUrl = c.FotoUrl
                }).ToList()
            };

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

            var marketStallDto = new
            {
                Id = marketStall.Id,
                Name = marketStall.Name,
                Description = marketStall.Description,
                Location = marketStall.Location,
                Views = marketStall.Views,
                SellerId = marketStall.SellerId,
                Seller = marketStall.Seller != null ? new
                {
                    Id = marketStall.Seller.Id,
                    FirstName = marketStall.Seller.FirstName,
                    LastName = marketStall.Seller.LastName,
                    Email = marketStall.Seller.Email,
                    State = marketStall.Seller.State
                } : null,
                Categories = marketStall.Categories.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    MarketStallId = c.MarketStallId,
                    Description = c.Description,
                    FotoUrl = c.FotoUrl
                }).ToList()
            };

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