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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public ActionResult<MenuDto> GetAll()
        {
            return Ok(_menuService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            var menu = _menuService.GetById(id);

            if (menu is null)
            {
                return NotFound();
            }

            var menuDto = new MenuDto(menu.Id, menu.Name, menu.Price, menu.Stock, menu.Description, menu.ImageUrl, menu.CategoryId, menu.IsFeatured);

            return Ok(menuDto);
        }

        [HttpPost]
        [AllowAnonymous] //Esto lo agregamos porque en nuestro caso el create user lo vamos a usar para el registro (queremos saltear la autenticación)
        public IActionResult CreateMenu(CreateAndUpdateMenuDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto no puede ser nulo");
            }

            int response;
            try
            {
                response = _menuService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Created("Created", response);
        }

        [HttpPut("{menuId}")]
        public IActionResult UpdateMenu(CreateAndUpdateMenuDto dto, int menuId)
        {
            if (!_menuService.CheckIfMenuExists(menuId))
            {
                return NotFound();
            }

            try
            {
                _menuService.Update(dto, menuId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteMenu(int id)
        {
            try
            {
                _menuService.RemoveMenu(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }
    }
}
