using Jīao.Models.Dtos;
using Jīao.Service.Implementations;
using Jīao.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jīao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<UserDto> GetAll()
        {
            var categories = _categoryService.GetAll();
            
            var categoryDtos = categories.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                FotoUrl = c.FotoUrl,
                MarketStallId = c.MarketStallId,
                MarketStall = c.MarketStall != null ? new
                {
                    Id = c.MarketStall.Id,
                    Name = c.MarketStall.Name,
                    Description = c.MarketStall.Description,
                    Location = c.MarketStall.Location,
                    Views = c.MarketStall.Views,
                    SellerId = c.MarketStall.SellerId
                } : null,
                Menus = c.Menus.Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Stock = m.Stock,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                    IsFeatured = m.IsFeatured,
                    CategoryId = m.CategoryId
                }).ToList()
            }).ToList();

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            var category = _categoryService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }

            var categoryDto = new
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                FotoUrl = category.FotoUrl,
                MarketStallId = category.MarketStallId,
                MarketStall = category.MarketStall != null ? new
                {
                    Id = category.MarketStall.Id,
                    Name = category.MarketStall.Name,
                    Description = category.MarketStall.Description,
                    Location = category.MarketStall.Location,
                    Views = category.MarketStall.Views,
                    SellerId = category.MarketStall.SellerId
                } : null,
                Menus = category.Menus.Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Stock = m.Stock,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                    IsFeatured = m.IsFeatured,
                    CategoryId = m.CategoryId
                }).ToList()
            };

            return Ok(categoryDto);
        }

        [HttpPost]
        [AllowAnonymous] //Esto lo agregamos porque en nuestro caso el create user lo vamos a usar para el registro (queremos saltear la autenticación)
        public IActionResult CreateCategory(CreateAndUpdateCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto no puede ser nulo");
            }

            int response;
            try
            {
                response = _categoryService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", response);
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateUser(CreateAndUpdateCategoryDto dto, int categoryId)
        {
            if (!_categoryService.CheckIfCategoryExists(categoryId))
            {
                return NotFound();
            }
            try
            {
                _categoryService.Update(dto, categoryId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _categoryService.RemoveCategory(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }

            return NoContent();
        }
    }
}
