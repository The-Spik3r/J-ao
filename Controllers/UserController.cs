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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserDto> GetAll()
        {
            //No lo estamos verificando, pero por lo general un GetAll de todos los users lo debería poder hacer solo un usuario con rol ADMIN
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            if (id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            var user = _userService.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            var userDto = new UserDto(user.Id,user.FirstName,user.LastName,user.Address,user.Email,user.Password,user.State);

            return Ok(userDto);

        }

        [HttpPost]
        [AllowAnonymous] //Esto lo agregamos porque en nuestro caso el create user lo vamos a usar para el registro (queremos saltear la autenticación)
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto no puede ser nulo");
            }

            int response;
            try
            {
                User user = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    Email = dto.Email,
                    Password = dto.Password,
                    State = dto.State
                };
                response = _userService.Create(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", response);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            if (!_userService.CheckIfUserExists(userId))
            {
                return NotFound();
            }
            try
            {
                User user = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    Email = dto.Email,
                    Password = dto.Password,
                    State = dto.State
                };

                _userService.Update(user, userId);
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
                _userService.RemoveUser(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("me")]
        public ActionResult<GetUserByIdDto> GetUserInfo()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            var user = _userService.GetById(userId);
            return Ok(user);
        }

    }
}
