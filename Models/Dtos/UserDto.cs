using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
        public record UserDto(int Id, string FirstName,string Lastname, string Address,string Email, string Password, State State);
}
