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
            return Ok(_categoryService.GetAll());
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

            var userDto = new CategoryDto(category.Id, category.Name, category.MarketStallId);

            return Ok(userDto);

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
